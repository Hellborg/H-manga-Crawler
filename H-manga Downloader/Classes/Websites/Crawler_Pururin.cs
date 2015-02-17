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
using Crawler2._0.Forms;
using Crawler2._0.Properties;
using CsQuery;
using Newtonsoft.Json;

//using HtmlAgilityPack;

namespace Crawler2._0.Classes.Websites
{
    internal class CrawlerPururin
    {
        //private HtmlDocument _htmlAgilityDocumentPicture;
        //private HtmlDocument _htmlAgilityDocumentTag;
        // private const string MaxNodeXpath = "//div[@class='pager jumper']";
        private const string UrlListStartUrl = "http://pururin.com/browse/0/60/1.html";
        
        private const string MaxNodeXpathPururin = "div.pager";
        /*private const string MangaListXpathPururin = "#list-browse > ul> li";
        private const string TitleNodeXpath = "div > a > div.overlay > div.title > div > h2";
        private const string InfoNodeXpath = "div > a > div.overlay > div.info > div:nth-child(1)";
        private const string GalleryLinkXpath = "div > a";
         */
        private const int NrOfCalls = 300;
        private readonly Downloader _downloader = new Downloader();
        private readonly Crawler _parent;
        private readonly bool _saveCovers;
        //private HtmlWeb _htmlAgilityWeb = new HtmlWeb();
        private readonly Settings _settings = new Settings();
        private readonly Dictionary<int, string> _tagDictionary = new Dictionary<int, string>();
       
        private CQ _mangaCqDocument;
        
        private CQ _pictureCqDocument;
        private List<string> _urlList;

        public CrawlerPururin(Crawler crawler, Dictionary<int, string> dic)
        {
            _parent = crawler;
            _saveCovers = _settings.SaveCoversToDisk;
            _tagDictionary = dic;
        }

        public event Crawler.MangalistCrawlingUpdateProgressEventHandler ListCrawlingUpdateProgressEvent;
        public event Crawler.MangalistCrawlingStartedEventHandler ListCrawlingStartedEvent;
        public event Crawler.PictureCrawlingStartedEventHandler PictureCrawlingStartedEvent;
        public event Crawler.PictureCrawlingUpdateProgressEventHandler PictureCrawlingUpdateProgressEvent;
        public event Crawler.PictureDownloadStartedEventHandler PictureDownloadStartedEvent;
        public event Crawler.PictureDownloadUpdateProgressEventHandler PictureDownloadUpdateProgressEvent;
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


                if (ListCrawlingStartedEvent != null)
                    ListCrawlingStartedEvent(pageCount);


                for (var x = 1; x < pageCount; x++)
                {
                    var url = string.Format("http://pururin.com/browse/0/6{0}/{1}.html", (x - 1), x);
                    localList.Add(url);
                }
            }
            return localList;
        }

        public void FetchFromApi()
        {
            var client = new WebClient();
            var mangaCount =
                Convert.ToInt32(
                    client.DownloadString("http://hellborg.org.preview.crystone.se/GetJson.php?Site=pururin&Count"));
            Debugger.Log(1, "counter", "count = " + mangaCount);
            var remainder = mangaCount%NrOfCalls;

            var mangasNoRemainder = (mangaCount - remainder);
            var mangasPerCall = (mangaCount - remainder)/NrOfCalls;

            if (ListCrawlingStartedEvent != null)
                ListCrawlingStartedEvent(NrOfCalls + 1);
            var z = 0;
            while (z < mangasNoRemainder)
            {
                var json =
                    client.DownloadString("http://hellborg.org.preview.crystone.se/GetJson.php?Site=pururin&min=" + z +
                                          "&max=" + (z + mangasPerCall));
                var list = JsonConvert.DeserializeObject<List<RootObject>>(json);
                if (ListCrawlingUpdateProgressEvent != null)
                    ListCrawlingUpdateProgressEvent(1);

                foreach (var o in list)
                {
                    var m = new Manga
                    {
                        Title = o.JsonManga.Title,
                        Pages = Convert.ToInt32(o.JsonManga.Pages),
                        CoverUrl = "www.pururin.com" + o.JsonManga.CoverUrl,
                        GalleryUrl = "www.pururin.com" + o.JsonManga.GalleryUrl,
                        Info = o.JsonManga.Info,
                        Language = o.JsonManga.Language,
                        LocalImage = false
                    };
                    m.ImagePath = m.CoverUrl;
                    var tagInts =
                        o.JsonManga.Tags.Split('-').Where(x => x != null).Select(x => Convert.ToInt32(x)).ToArray();
                    var tagList = new List<string>();
                    foreach (var tagId in tagInts)
                    {
                        var value = _tagDictionary.FirstOrDefault(x => x.Key == tagId).Value;
                        tagList.Add(value);
                    }


                    m.Tags = tagList.ToArray();


                    m.Website = "Pururin";

                    //add to manga list
                }
                z = z + mangasPerCall;
            }
            var lastUrl = "http://hellborg.org.preview.crystone.se/GetJson.php?Site=pururin&min=" + z + "&max=" +
                          (z + remainder);

            var lastJson = client.DownloadString(lastUrl);
            var lastList = JsonConvert.DeserializeObject<List<RootObject>>(lastJson);

            foreach (var o in lastList)
            {
                var m = new Manga();
                m.Title = o.JsonManga.Title;
                m.Pages = Convert.ToInt32(o.JsonManga.Pages);
                m.CoverUrl = "www.pururin.com" + o.JsonManga.CoverUrl;
                m.GalleryUrl = "www.pururin.com" + o.JsonManga.GalleryUrl;
                m.Info = o.JsonManga.Info;
                m.Language = o.JsonManga.Language;
                m.LocalImage = false;
                m.ImagePath = m.CoverUrl;
                var tags = o.JsonManga.Tags.Split('-');
                var tagInts =
                    o.JsonManga.Tags.Split('-').Where(x => x != null).Select(x => Convert.ToInt32(x)).ToArray();
                var tagList = new List<string>();
                foreach (var tagId in tagInts)
                {
                    var value = _tagDictionary.FirstOrDefault(x => x.Key == tagId).Value;
                    tagList.Add(value);
                }


                m.Tags = tagList.ToArray();
                //m.Tags = tagInts;

                m.Website = "Pururin";


                //add to manga list
            }
        }
        public List<Manga> DownloadListfile()
        {
            WebClient client = new WebClient();
            try
            {
                //check local file against remote file, if server has a newer one, download, otherwise dont and just read.
                client.DownloadFile("http://hellborg.org.preview.crystone.se/Lists/pururin.List", "Data\\Lists\\pururin.List");
                return Listhandler.ReadMangaList();
            }
            catch (WebException wex)
            {
                MessageBox.Show(wex.Message + " inner exeption = " + wex.InnerException);
                throw;
            }
        }
        internal List<Manga> Crawl()
        {
            return DownloadListfile();
            
        }

        /*private void FetchInfo(string currentMangaPage)
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


                    if (Form1.MaxPages < pagesInt)
                        Form1.MaxPages = pagesInt;

                    m.GalleryUrl = galleryUrl;
                    m.CoverUrl = coverUrl;

                }
            }
        }
        */
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

        public void CrawlPictureUrls_Pururin(object o, bool createSubfolders)
        {
            var sourceQueue = new List<string>();
            sourceQueue.Clear();
            var m = ((Manga) o);

            var url = "http://" + m.GalleryUrl.Replace("gallery", "view");
            var idRegex = new Regex(@"/view/(\d+)");
            var id = idRegex.Match(url).Groups[1].Value;
            var titleRegex = new Regex(@id + "/(.*)");
            var title = titleRegex.Match(url).Groups[1].Value;
            var downloadPath = "";

            downloadPath = _settings.DownloadPath + "/Pururin/";



            if (PictureCrawlingStartedEvent != null)
                PictureCrawlingStartedEvent(m.Title, "Prepairing pictures", "0.0 %", "0 /" + m.Pages);

            sourceQueue = GetSource(CreateLinks(id, title, m.Pages, "http://www.pururin.com/view/"), m.Pages, m.Title);
            var currentCount = 0;


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

        public void CrawlTagList_Pururin(object state)
        {
            //_htmlAgilityDocumentTag = _htmlAgilityWeb.Load(TagListStartUrlPururin);
            //if (_htmlAgilityDocumentTag != null)
            //{
            //    var htmlAgilityMaxNode = _htmlAgilityDocumentTag.DocumentNode.SelectSingleNode(MaxNodeXpathPururin);
            //    var pageCountPururin = Convert.ToInt32(htmlAgilityMaxNode.Attributes["data-pmax"].Value);

            //    if (TagCrawlingStartedEvent != null)
            //        TagCrawlingStartedEvent("Pururin", pageCountPururin, 1);

            //    for (var x = 1; x < pageCountPururin; x++)
            //    {
            //        var mangaUrl = "http://pururin.com/tags/0/1" + (x - 1) + "/" + x + ".html";
            //        _urlQueueTagList.Add(mangaUrl);
            //    }

            //    Parallel.ForEach(_urlQueueTagList, FetchTags);


            //    _listhandler.WriteTagList(_tagList);
            //    if (TagCrawlingFinishedEvent != null)
            //        TagCrawlingFinishedEvent();
            //}
        }

        private void FetchTags(string currentTagSite)
        {
            //_htmlAgilityDocumentTag = _htmlAgilityWeb.Load(currentTagSite);
            //var htmlAgilityNodeCollection = _htmlAgilityDocumentTag.DocumentNode.SelectNodes("//table[@class='table-data tag-table']/tbody/tr");//kolla upp vilken xpath det är :)

            //if (TagCrawlingUpdateProgressEvent != null)
            //    TagCrawlingUpdateProgressEvent(1);

            //foreach (var htmlAgilityNode in htmlAgilityNodeCollection)
            //{
            //    string tagKey = htmlAgilityNode.GetAttributeValue("data-tid", "");
            //    string tagText = htmlAgilityNode.SelectSingleNode("td/a[@class='js-tooltip-tag']").GetAttributeValue("title", "");

            //    string[] explodedStrings = tagText.Split('/');
            //    tagText = explodedStrings[0].Trim();

            //    //_tagList.Add(tagKey, tagText);

            //}
        }
    }
}