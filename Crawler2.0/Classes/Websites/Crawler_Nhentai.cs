using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crawler2._0.Properties;
using CsQuery;
using CsQuery.ExtensionMethods.Internal;
using Newtonsoft.Json;

//using HtmlAgilityPack;

namespace Crawler2._0.Classes.Websites
{
    internal class CrawlerNhentai
    {
        //private HtmlDocument _htmlAgilityDocumentPicture;
        //private HtmlDocument _htmlAgilityDocumentTag;
        // private const string MaxNodeXpath = "//div[@class='pager jumper']";
        private const string UrlListStartUrl = "http://pururin.com/browse/0/60/1.html";
        private const string MaxNodeXpathPururin = "div.pager";
        private const string MangaListXpathPururin = "#list-browse > ul> li";
        private const string TitleNodeXpath = "div > a > div.overlay > div.title > div > h2";
        private const string InfoNodeXpath = "div > a > div.overlay > div.info > div:nth-child(1)";
        private const string GalleryLinkXpath = "div > a";
        private const int NrOfCalls = 150;
        private readonly Downloader _downloader = new Downloader();
        private readonly List<Manga> _nhentaiMangaList = new List<Manga>();
        private readonly Crawler _parent;
        private readonly bool _saveCovers;
        //private HtmlWeb _htmlAgilityWeb = new HtmlWeb();
        private readonly Settings _settings = new Settings();
        private readonly List<string> _urlQueueTagList = new List<string>();
        private CQ _mangaCqDocument;
        private int _mangaPageCount;
        private CQ _pictureCqDocument;
        private List<string> _urlList;
        public Dictionary<int, string> TagDictionary = new Dictionary<int, string>();
        ManualResetEvent ma = new ManualResetEvent(false);
        public CrawlerNhentai(Crawler crawler, Dictionary<int, string> dic)
        {
            _parent = crawler;
            _saveCovers = _settings.SaveCoversToDisk;
            TagDictionary = dic;
        }

        public event Crawler.MangalistCrawlingUpdateProgressEventHandler ListCrawlingUpdateProgressEvent;
        public event Crawler.MangalistCrawlingStartedEventHandler ListCrawlingStartedEvent;
        public event Crawler.PictureCrawlingStartedEventHandler PictureCrawlingStartedEvent;
        public event Crawler.PictureCrawlingUpdateProgressEventHandler PictureCrawlingUpdateProgressEvent;
        public event Crawler.PictureDownloadStartedEventHandler PictureDownloadStartedEvent;
        public event Crawler.PictureDownloadUpdateProgressEventHandler PictureDownloadUpdateProgressEvent;
        public event Crawler.MangaDownloadFinishedEventHandler MangaDownloadFinishedEvent;
        public event Crawler.TagCrawlingStartedEventHandler TagCrawlingStartedEvent;
        public event Crawler.TagCrawlingFinishedEventHandler TagCrawlingFinishedEvent;
        public event Crawler.TagCrawlingUpdateProgressEventHandler TagCrawlingUpdateProgressEvent;

        private int GetPageCount()
        {
            var cqMaxNode = _mangaCqDocument[MaxNodeXpathPururin];

            var value = Convert.ToInt32(cqMaxNode[0].GetAttribute("data-pmax"));

            return value;
        }

        internal List<string> CreateUrls()
        {
            var localList = new List<string>();
            _mangaCqDocument = CQ.CreateFromUrl(UrlListStartUrl);

            if (_mangaCqDocument != null)
            {
                var pageCount = GetPageCount();


                //if (ListCrawlingStartedEvent != null)
                //eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeePururinlistCrawlingStartedEvent(pageCount);


                for (var x = 1; x < pageCount; x++)
                {
                    var url = string.Format("http://nhentai.net/tagged/english/?page={0}", (x - 1));
                    localList.Add(url);
                }
            }
            return localList;
        }

        public List<Manga> DownloadListfile()
        {
            WebClient client = new WebClient();
           
            
            //string test = client.DownloadString("http://hellborg.org.preview.crystone.se/Lists/nhentai.List");
           // File.WriteAllText("Data\\Lists\\nhentai.List",test);
            //using (StreamWriter sw = new StreamWriter(@"Data\\Lists\\nhentai.List"))
            //{
               // sw.Write(test);
            //}

            //Debugger.Log(1,"",test);
            try
            {

                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;

                string localFile = "Data\\Lists\\nhentai.List";
                Uri remoteFile = new Uri("http://hellborg.org.preview.crystone.se/Lists/nhentai.List");
                FileInfo localFileInfo = new FileInfo(localFile);
                if (File.Exists(localFile))
                {
                   if ((localFileInfo.CreationTime.Day - DateTime.Now.Day) > 1)
                    {
                        ma.Reset();

                      client.DownloadFileAsync(remoteFile, localFile);
                        ma.WaitOne();
                    } 
                }
                else
                {
                    ma.Reset();

                    client.DownloadFileAsync(remoteFile, localFile);
                    ma.WaitOne();
                }
                
                
                return Listhandler.ReadMangaList();
            }
            catch (System.Net.WebException wex)
            {
                MessageBox.Show(wex.Message+" inner exeption = "+wex.InnerException);
                throw;
            }
        }

        void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ma.Set();
        }

        

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = e.ProgressPercentage;
            if (ListCrawlingUpdateProgressEvent != null)
                ListCrawlingUpdateProgressEvent(percentage);

        }
        public void FetchFromApi()
        {
            var client = new WebClient();
            var mangaCount = Convert.ToInt32(client.DownloadString("http://hellborg.org/GetJson.php?Site=nhentai&Count"));
            Debugger.Log(1, "counter", "count = " + mangaCount);
            var remainder = mangaCount%NrOfCalls;

            var calls = (mangaCount - remainder);
            var mangasPerCall = (mangaCount - remainder)/NrOfCalls;


            if (ListCrawlingStartedEvent != null)
                ListCrawlingStartedEvent(NrOfCalls + 1);

            var z = 0;
            Debugger.Log(1, "", "mangas per call = " + mangasPerCall);
            Parallel.For(z, NrOfCalls, ctr =>
            {
                var localClient = new WebClient();
                Debugger.Log(1, "","min=" + (ctr*mangasPerCall) + "&max=" + ((ctr + 1)*mangasPerCall) + Environment.NewLine);
                var json =
                    localClient.DownloadString("http://hellborg.org/GetJson.php?Site=nhentai&min=" + (ctr*mangasPerCall) +
                                               "&max=" + ((ctr + 1)*mangasPerCall));
                var list = JsonConvert.DeserializeObject<List<RootObject>>(json);

                if (ListCrawlingUpdateProgressEvent != null)
                    ListCrawlingUpdateProgressEvent(1);

                foreach (var o in list)
                {
                    var m = new Manga
                    {
                        Title = o.JsonManga.Title,
                        Pages = Convert.ToInt32(o.JsonManga.Pages),
                        CoverUrl = o.JsonManga.CoverUrl,
                        GalleryUrl = o.JsonManga.GalleryUrl,
                        Info = o.JsonManga.Info,
                        Language = o.JsonManga.Language,
                        LocalImage = false
                    };
                    
                    m.ImagePath = m.CoverUrl;
                    m.UniqueId = o.JsonManga.NhentaiId;
                    //Debugger.Log(1,"json","unique ID [>"+o.JsonManga.NhentaiId+"<]"+Environment.NewLine);
                   
                    m.PageLinks=
                    m.Tags = o.JsonManga.Tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    m.Website = "Nhentai";
                    string[] separator = {"%#%"};
                    m.PageLinks =
                        o.JsonManga.PageLinks.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    //new[] {','}, StringSplitOptions.RemoveEmptyEntries
                    
                    
                    _nhentaiMangaList.Add(m);
                    //add to manga list
                }
                z = (ctr + 1)*mangasPerCall;
            });


            //while (z < calls)
            //{
            //    var json = client.DownloadString("http://hellborg.org/GetJson.php?Site=nhentai&min="+z+"&max="+(z+mangasPerCall));
            //    List<RootObject> list = JsonConvert.DeserializeObject<List<RootObject>>(json);

            //    if (ListCrawlingUpdateProgressEvent != null)
            //        ListCrawlingUpdateProgressEvent(1);


            //    foreach (RootObject o in list)
            //    {
            //        Manga m = new Manga
            //        {
            //            Title = o.JsonManga.Title,
            //            Pages = Convert.ToInt32(o.JsonManga.Pages),
            //            CoverUrl = o.JsonManga.CoverUrl,
            //            GalleryUrl = o.JsonManga.GalleryUrl,
            //            Info = o.JsonManga.Info,
            //            Language = o.JsonManga.Language,
            //            LocalImage = false
            //        };
            //        m.ImagePath = m.CoverUrl;
            //        m.UniqueId = o.JsonManga.NhentaiId;
            //        m.Tags = o.JsonManga.Tags.Split(',').ToArray();

            //        m.Website = "Nhentai";


            //        _nhentaiMangaList.Add(m);
            //        //add to manga list
            //    }
            //    z = z + mangasPerCall;
            //}
            var lastUrl = "http://hellborg.org/GetJson.php?Site=nhentai&min=" + z + "&max=" +
                          (z + remainder);

            Debugger.Log(1, "API", "Last Url = " + lastUrl);
            var lastJson = client.DownloadString(lastUrl);
            var lastList = JsonConvert.DeserializeObject<List<RootObject>>(lastJson);

            foreach (var o in lastList)
            {
                var m = new Manga();
                m.Title = o.JsonManga.Title;
                m.Pages = Convert.ToInt32(o.JsonManga.Pages);
                m.CoverUrl = o.JsonManga.CoverUrl;
                m.GalleryUrl = o.JsonManga.GalleryUrl;
                m.Info = o.JsonManga.Info;
                m.Language = o.JsonManga.Language;
                m.LocalImage = false;
                m.ImagePath = m.CoverUrl;
                m.Tags = o.JsonManga.Tags.Split(',').ToArray();
                //m.Tags = tagInts;
                m.Website = "Nhentai";
                m.UniqueId = o.JsonManga.NhentaiId;
                m.PageLinks =
                        o.JsonManga.PageLinks.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                _nhentaiMangaList.Add(m);
                //add to manga list
            }
            Debugger.Log(1, "API", "MangaList COunt = " + _nhentaiMangaList.Count);
        }

        internal List<Manga> Crawl()
        {
            //get info from mysql, with the normal crawling as a fallback

            return DownloadListfile();
            

            //1FetchFromApi();

            if (_nhentaiMangaList.Count == 0)
            {
                _urlList = CreateUrls();
                Parallel.ForEach(_urlList, item => FetchInfo(item));
            }

            //return _nhentaiMangaList;
        }

        private void FetchInfo(string currentMangaPage)
        {
            //try
            //{
            var document = CQ.CreateFromUrl(currentMangaPage);


            //_htmlAgilityDocumentManga = _htmlAgilityWeb.Load(currentMangaPage);
            //}

            //catch (//HtmlAgilityPack.HtmlWebException webException)
            //{
            //Loghandler.LogToFile(webException, 3);
            //Add a eventhander that deals with errors
            //}


            var htmlAgilityNodeCollection = document[MangaListXpathPururin];


            if (ListCrawlingUpdateProgressEvent != null)
                ListCrawlingUpdateProgressEvent(1);

            foreach (var node in htmlAgilityNodeCollection)
            {
                var m = new Manga();
                var titleNode = node.Cq().Find(TitleNodeXpath);
                // titlenode = htmlAgilityNode;

                var titleString = titleNode.Html().Split(new[] {"<br>"}, StringSplitOptions.None)[0];
                // titleNode.InnerHtml.Split(new[] { "<br>" }, StringSplitOptions.None)[0];


                if (_parent.Mangalist.Count(item => item.Title == titleString) == 0)
                {
                    var tagStrings = node.GetAttribute("data-tags").Split('-');
                    // htmlAgilityNode.Attributes["data-tags"].Value.Split('-');
                    var tags = tagStrings.Select(Int32.Parse).ToArray();

                    var infoNode = node.Cq().Find(InfoNodeXpath);

                    var explodedInfoString = infoNode.Text().Split(',');
                    ////string InfoString = ExplodedInfoString[0];
                    //var languageString = explodedInfoString[explodedInfoString.Length - 2];

                    //#list-browse > ul > li.G16872.gallery-block > #list-browse > ul > li.G16872.gallery-block > div > a > div.overlay > div.info > div:nth-child(1)
                    var pagesInt =
                        Convert.ToInt32(Regex.Replace(explodedInfoString[explodedInfoString.Length - 1], "[^0-9.]", ""));
                    ////Fucks up here IF there are Numbers in the name


                    var galleryNode = node.Cq().Find(GalleryLinkXpath);

                    var galleryUrl = "www.pururin.com" + galleryNode[0].GetAttribute("href");
                    Debugger.Log(1, "CSS path", "gallery url = " + galleryUrl);
                    var coverUrl = "www.pururin.com" + galleryNode.Children("img")[0].GetAttribute("src");
                    if (_saveCovers)
                    {
                        if (!Directory.Exists("Data/Pictures/Covers"))
                            Directory.CreateDirectory("Data/Pictures/Covers");


                        var client = new WebClient();

                        var filename = Path.GetFileName(coverUrl);
                        var filepath = "Data/Pictures/Covers/Pururin" + filename;

                        if (!File.Exists(filepath))
                        {
                            client.DownloadFile("http://" + coverUrl, filepath);
                        }
                        m.LocalImage = true;
                        m.ImagePath = filepath;
                    }
                    else
                    {
                        m.ImagePath = Path.GetFileName(coverUrl);
                    }
                    m.Title = titleString;
                    m.Pages = pagesInt;
                    m.Website = "Pururin";
                    //if (MangaReadEvent != null)
                    //  MangaReadEvent(pagesInt);


                    if (Form1.MaxPages < pagesInt)
                        Form1.MaxPages = pagesInt;

                    m.GalleryUrl = galleryUrl;
                    //m.Language = languageString;
                    m.CoverUrl = coverUrl;

                    //m.info = InfoString;
                    //m.Tags = tags;
                    _nhentaiMangaList.Add(m);
                    // Parent.Mangalist.Add(m);
                }
            }
        }

        public List<string> GetSource(List<string> urls, int pages, string title)
        {
            var currentCount = pages;
            var tempList = new List<string>();
            var cts = new CancellationTokenSource();
            var po = new ParallelOptions();
            po.CancellationToken = cts.Token;

            try
            {
                Parallel.ForEach(urls, po, currentUrl =>
                {
                    currentCount--;
                    try
                    {
                        var html = new WebClient().DownloadString(currentUrl);
                        _pictureCqDocument = CQ.Create(html);
                        var src = "http://www.pururin.com" + _pictureCqDocument["img.b"][0].GetAttribute("src");

                        tempList.Add(src);


                        Loghandler.LogToFile("Title: " + title + " --------- URL " + src, 1);

                        if (PictureCrawlingUpdateProgressEvent != null)
                            PictureCrawlingUpdateProgressEvent(title, pages, currentCount);
                    }
                    catch (WebException webException)
                    {
                        Loghandler.LogToFile(webException, 3);
                    }


                    //img.b

                    //try
                    //{
                    //    _htmlAgilityDocumentPicture = _htmlAgilityWeb.Load(currentUrl);
                    //    if (_htmlAgilityDocumentPicture.DocumentNode.SelectSingleNode("//div[@class='cf-error-details']") == null)
                    //    {
                    //        var htmlAgilityNode = _htmlAgilityDocumentPicture.DocumentNode.SelectSingleNode("//img[@class='b']");
                    //        var pictureUrl = "http://www.pururin.com" + htmlAgilityNode.GetAttributeValue("src", null);
                    //        //SourceQueue.Add(pictureUrl);
                    //        TempList.Add(pictureUrl);

                    //        if (PictureCrawlingUpdateProgressEvent != null)
                    //            PictureCrawlingUpdateProgressEvent(title, pages, CurrentCount);
                    //    }
                    //    else
                    //    {
                    //        Loghandler.LogToFile("It seems the website is down, please try again later.", 3);
                    //        cts.Cancel();
                    //    }
                    //}
                    //catch (WebException wEx)
                    //{
                    //    Loghandler.LogToFile(wEx, 3);
                    //    cts.Cancel();
                    //}
                });
            }

            catch (OperationCanceledException oCex)
            {
            }

            return tempList;
        }

        public List<string> CreateLinks(string id, string title, int pageCount, string website)
        {
            var templist = new List<string>();

            for (var count = 0; count < pageCount; count++)
            {
                var s = website + id + "/0" + count + "/" + title;
                s = s.Insert((s.Length - 5), "_" + (count + 1));
                templist.Add(s);
            }
            return templist;
        }

        public void CrawlPictureUrls_Nhentai(object o, bool createSubfolders)
        {





            var sourceQueue = new List<string>();
            sourceQueue.Clear();
            var m = ((Manga) o);

            var currentCount = 0;
            if (!m.PageLinks.Any())
            {
                var url = "http://" + m.GalleryUrl.Replace("gallery", "view");
                var idRegex = new Regex(@"/view/(\d+)");
                var id = idRegex.Match(url).Groups[1].Value;
                var titleRegex = new Regex(@id + "/(.*)");
                var title = titleRegex.Match(url).Groups[1].Value;
                var downloadPath = "";
                
                downloadPath = _settings.DownloadPath + "/Pururin/";


                _mangaPageCount = m.Pages;

                if (PictureCrawlingStartedEvent != null)
                    PictureCrawlingStartedEvent(m.Title, "Prepairing pictures", "0.0 %", "0 /" + m.Pages);

                sourceQueue = GetSource(CreateLinks(id, title, m.Pages, "http://www.pururin.com/view/"), m.Pages, m.Title);
                


                if (PictureDownloadStartedEvent != null)
                    PictureDownloadStartedEvent(m.Title, m.Pages.ToString());

                Parallel.ForEach(sourceQueue, currentSource =>
                {
                    currentCount++;
                    if (!_downloader.Download(currentSource, downloadPath, m.Title, m.Title, m.Pages, currentCount)) return;

                    if (PictureDownloadUpdateProgressEvent != null)
                        PictureDownloadUpdateProgressEvent(m.Title, m.Pages, currentCount); //
                }); //add crawlerObject to download queue, and 

                Crawler.DownloadPath = downloadPath;
            }

            foreach (string s in m.PageLinks)
            {
                if (m.Website == "Nhentai")
                {
                    sourceQueue.Add(string.Format("http://i.nhentai.net/galleries/{0}/{1}",m.UniqueId,s));    
                }


            }
            string path = _settings.DownloadPath + "/Nhentai/";
            
            
            if (PictureDownloadStartedEvent != null)
                PictureDownloadStartedEvent(m.Title, m.Pages.ToString());
         
            
            Parallel.ForEach(sourceQueue, currentSource =>
            {
                currentCount++;
                if (!_downloader.Download(currentSource, path, m.Title, m.Title, m.Pages, currentCount)) return;

                if (PictureDownloadUpdateProgressEvent != null)
                    PictureDownloadUpdateProgressEvent(m.Title, m.Pages, currentCount); //
            }); //add crawlerObject to download queue, and 
            
            Crawler.DownloadPath = path;

            
        }
        public static void While(ParallelOptions parallelOptions, Func<bool> condition, Action body)
        {
            Parallel.ForEach(IterateUntilFalse(condition), parallelOptions, ignored => body());
        }

        public static IEnumerable<bool> IterateUntilFalse(Func<bool> condition)
        {
            while (condition()) yield return true;
        }
    }

    public class JsonManga
    {
        public string Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Pages")]
        public string Pages { get; set; }

        [JsonProperty("GalleryUrl")]
        public string GalleryUrl { get; set; }

        [JsonProperty("CoverUrl")]
        public string CoverUrl { get; set; }

        [JsonProperty("Info")]
        public string Info { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("Tags")]
        public string Tags { get; set; }

        [JsonProperty("PageAdress")]
        public string PageAdress { get; set; }

        [JsonProperty("pageLinks")]
        public string PageLinks { get; set; }

        [JsonProperty("nhentaiID")]
        public string NhentaiId { get; set; }
    }

    public class RootObject
    {
        public JsonManga JsonManga { get; set; }
    }
}