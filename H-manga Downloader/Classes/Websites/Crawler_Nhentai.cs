using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crawler2._0.Forms;
using Crawler2._0.Properties;
using CsQuery;
using Newtonsoft.Json;

namespace Crawler2._0.Classes.Websites
{
    internal class CrawlerNhentai
    {
        private const string UrlListStartUrl = "http://pururin.com/browse/0/60/1.html";
        private const string MaxNodeXpathPururin = "div.pager";
        private const int NrOfCalls = 150;
        private readonly Downloader _downloader = new Downloader();
        
        private readonly List<Manga> _nhentaiMangaList = new List<Manga>();
        //private HtmlWeb _htmlAgilityWeb = new HtmlWeb();
        private readonly Settings _settings = new Settings();
        private CQ _mangaCqDocument;
        private CQ _pictureCqDocument;
        public Dictionary<int, string> TagDictionary;

        public CrawlerNhentai(Dictionary<int, string> dic)
        {
            TagDictionary = dic;
        }

        public event Crawler.MangalistCrawlingUpdateProgressEventHandler ListCrawlingUpdateProgressEvent;
        public event Crawler.MangalistCrawlingStartedEventHandler ListCrawlingStartedEvent;
        public event Crawler.PictureCrawlingUpdateProgressEventHandler PictureCrawlingUpdateProgressEvent;
        public event Crawler.PictureDownloadStartedEventHandler PictureDownloadStartedEvent;
        public event Crawler.PictureDownloadUpdateProgressEventHandler PictureDownloadUpdateProgressEvent;
        //Gets the number of pages by finding the value on the website.
        private int GetPageCount()
        {
            var cqMaxNode = _mangaCqDocument[MaxNodeXpathPururin];

            var value = Convert.ToInt32(cqMaxNode[0].GetAttribute("data-pmax"));

            return value;
        }

        //Create all the gallery urls based on the number of pages that there are.
        internal List<string> CreateUrls()
        {
            var localList = new List<string>();
            _mangaCqDocument = CQ.CreateFromUrl(UrlListStartUrl);

            if (_mangaCqDocument != null)
            {
                var pageCount = GetPageCount();


                for (var x = 1; x < pageCount; x++)
                {
                    var url = string.Format("http://nhentai.net/tagged/english/?page={0}", (x - 1));
                    localList.Add(url);
                }
            }
            return localList;
        }

        //This is the function in use, downloads a list file from a server. the others exist to be used if this wont work
        //The failsafe has not been added.
        

        
        //Not in use
        public void FetchFromApi()
        {
            var client = new WebClient();
            var mangaCount = Convert.ToInt32(client.DownloadString("http://hellborg.org/GetJson.php?Site=nhentai&Count"));
            var remainder = mangaCount%NrOfCalls;


            var mangasPerCall = (mangaCount - remainder)/NrOfCalls;


            if (ListCrawlingStartedEvent != null)
                ListCrawlingStartedEvent(NrOfCalls + 1);

            var z = 0;
            Parallel.For(z, NrOfCalls, ctr =>
            {
                var localClient = new WebClient();
                Debugger.Log(1, "",
                    "min=" + (ctr*mangasPerCall) + "&max=" + ((ctr + 1)*mangasPerCall) + Environment.NewLine);
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

                    m.PageLinks =
                        m.Tags = o.JsonManga.Tags.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    m.Website = "Nhentai";
                    m.PageLinks =
                        o.JsonManga.PageLinks.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
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
                    o.JsonManga.PageLinks.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                _nhentaiMangaList.Add(m);
                //add to manga list
            }
            Debugger.Log(1, "API", "MangaList COunt = " + _nhentaiMangaList.Count);
        }

      

        public List<string> GetSource(List<string> urls, int pages, string title) //not in use
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
            foreach (var s in m.PageLinks)
            {
                if (m.Website == "Nhentai")
                {
                    sourceQueue.Add(string.Format(Strings.nhentai_url_String, m.UniqueId, s));
                }
            }
            var path = _settings.DownloadPath + "/Nhentai/";


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