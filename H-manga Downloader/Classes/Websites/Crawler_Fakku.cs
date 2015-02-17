using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Crawler2._0.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crawler2._0.Classes.Websites
{
    internal class CrawlerFakku
    {
        private const string UrlListStartUrl = "https://api.fakku.net/manga/english";
        private readonly Downloader _downloader = new Downloader();
        private readonly List<Manga> _fakkuMangaList = new List<Manga>();
        private readonly bool _saveCovers;
        private readonly Settings _settings = new Settings();
        private List<string> _urlList;

        public CrawlerFakku()
        {
            _saveCovers = _settings.SaveCoversToDisk;
        }

        public event Crawler.MangalistCrawlingUpdateProgressEventHandler FakkulistCrawlingUpdateProgressEvent;
        public event Crawler.MangalistCrawlingStartedEventHandler FakkulistCrawlingStartedEvent;
        public event Crawler.PictureCrawlingUpdateProgressEventHandler FakkuPictureCrawlingUpdateProgressEvent;
        public event Crawler.PictureCrawlingStartedEventHandler FakkuPictureCrawlingStartedEvent;
        public event Crawler.PictureDownloadStartedEventHandler FakkuPictureDownloadStartedEvent;
        public event Crawler.PictureDownloadUpdateProgressEventHandler FakkuPictureDownloadUpdateProgressEvent;

        internal List<string> CreateUrls()
        {
            var localList = new List<string>();
            var client = new WebClient();
            var json = client.DownloadString(UrlListStartUrl);


            var o = JsonConvert.DeserializeObject<RootObjectMangalist>(json);


            var pageCount = o.Pages;


            localList.Add(UrlListStartUrl);

            for (var x = 0; x < pageCount; x++)
            {
                var url = string.Format("https://api.fakku.net/manga/english/page/{0}", (x + 1));
                localList.Add(url);
            }
            if (FakkulistCrawlingStartedEvent != null)
                FakkulistCrawlingStartedEvent(localList.Count + 1);
            return localList;
        }

        internal List<Manga> Crawl()
        {
            _urlList = CreateUrls();
            Parallel.ForEach(_urlList, item => FetchInfo(item));


            return _fakkuMangaList;
        }

        private void FetchInfo(string currentMangaPage)
        {
            //https://api.fakku.net/manga/english
            var client = new WebClient();
            var json = client.DownloadString(currentMangaPage);
            var o = JsonConvert.DeserializeObject<RootObjectMangalist>(json);


            foreach (var content in o.Content)
            {
                var m = new Manga();
                m.Title = content.ContentName;
                m.GalleryUrl = content.ContentUrl;

                m.CoverUrl = content.ContentImages.Cover.TrimStart('/');
                //m.Info = content.content_description;
                m.Language = content.ContentLanguage;
                m.Website = "Fakku";
                m.Pages = content.ContentPages;


                if (_saveCovers)
                {
                    if (!Directory.Exists("Data/Pictures/Covers/Fakku"))
                        Directory.CreateDirectory("Data/Pictures/Covers/Fakku");


                    var pictureClient = new WebClient();
                    var filename = Path.GetFileName(m.CoverUrl);
                    var filepath = "Data/Pictures/Covers/Fakku/" + filename;

                    if (!File.Exists(filepath))
                    {
                        pictureClient.DownloadFile("http://" + m.CoverUrl, filepath);
                    }
                    m.LocalImage = true;
                    m.ImagePath = filepath;
                }
                else
                {
                    m.ImagePath = m.Title + "-" + Path.GetFileName(m.CoverUrl);
                }

                if (Form1.MaxPages < m.Pages)
                    Form1.MaxPages = m.Pages;


                if (m != null)
                    _fakkuMangaList.Add(m);
            }
            if (FakkulistCrawlingUpdateProgressEvent != null)
                FakkulistCrawlingUpdateProgressEvent(1);

            //if (_saveCovers)
            //{
            //    if (!Directory.Exists("Data/Pictures/Covers"))
            //        Directory.CreateDirectory("Data/Pictures/Covers");


            //    var client = new WebClient();

            //    var filename = Path.GetFileName(coverUrl);
            //    var filepath = "Data/Pictures/Covers/" + filename;

            //    if (!File.Exists(filepath))
            //    {
            //        client.DownloadFile("http://" + coverUrl, filepath);
            //    }
            //    m.LocalImage = true;
            //    m.ImagePath = filepath;
            //}
            //else
            //{
            //    m.ImagePath = Path.GetFileName(coverUrl);
            //}
            //m.Title = titleString;
            ////m.Pages = pagesInt;
            //m.Website = "Fakku";
            //if (MangaReadEvent != null)
            //  MangaReadEvent(pagesInt);


            //if (Form1.MaxPages < pagesInt)
            //  Form1.MaxPages = pagesInt;

            //m.GalleryUrl = url;
            //m.Language = languageString;
            //m.CoverUrl = coverUrl;

            ////m.info = InfoString;
            ////m.Tags = tags;

            //_pururinMangaList.Add(m);
            //}
        }

        public void CrawlPictureUrls_Fakku(object o, bool createSubfolders)
        {
            var manga = (Manga) o;

            var sourceQueue = new List<string>();
            sourceQueue.Clear();


            var downloadPath = "";
            if (createSubfolders)
                downloadPath = _settings.DownloadPath + "/Fakku/";
            else
                downloadPath = _settings.DownloadPath + "/Fakku/";


            var currentCount = 0;
            if (FakkuPictureCrawlingStartedEvent != null)
                FakkuPictureCrawlingStartedEvent(manga.Title, "Prepairing pictures", "0.0 %", "0 /" + manga.Pages);

            sourceQueue = GetSource(manga);


            Parallel.ForEach(sourceQueue, currentSource =>
            {
                currentCount++;


                //Debugger.Log(1, "json", "link - " + p.image + Environment.NewLine);
                if (
                    !_downloader.Download(currentSource, downloadPath, manga.Title, manga.Title, manga.Pages,
                        currentCount)) return;
                if (FakkuPictureDownloadUpdateProgressEvent != null)
                    FakkuPictureDownloadUpdateProgressEvent(manga.Title, manga.Pages, currentCount);
            });
            Crawler.DownloadPath = downloadPath;

            // List<Dictionary<string,Dictionary<string, string>>> test  =  JsonConvert.DeserializeObject<List<Dictionary<string,Dictionary<string, string>>>>(Jobj.Values().ToString());
        }

        private List<string> GetSource(Manga manga)
        {
            var localList = new List<string>();
            var url = manga.GalleryUrl.Replace("www.fakku.net", "api.fakku.net") + "/read";
            var client = new WebClient();
            var jsonString = client.DownloadString(url);
            var jObj = JObject.Parse(jsonString);
            var jTok = jObj["pages"];
            Parallel.ForEach(jTok.Values().ToList(), cToken =>
            {
                var currentToken = cToken;
                var p = currentToken.ToObject<Page>();
                var currentSource = p.Image;
                localList.Add(currentSource);
            });
            return localList;
        }
    }

    public class Content
    {
        public string ContentName { get; set; }
        public string ContentUrl { get; set; }
        public string ContentDescription { get; set; }
        public string ContentLanguage { get; set; }
        //public string content_category { get; set; }
        //public int content_date { get; set; }
        //public int content_filesize { get; set; }
        //public int content_favorites { get; set; }
        //public int content_comments { get; set; }
        public int ContentPages { get; set; }
        //public string content_poster { get; set; }
        //public string content_poster_url { get; set; }
        public List<ContentTag> ContentTags { get; set; }
        //public List<ContentTranslator> content_translators { get; set; }
        //public List<ContentSery> content_series { get; set; }
        //public List<ContentArtist> content_artists { get; set; }
        public ContentImages ContentImages { get; set; }
    }

    public class ContentTag
    {
        public string Attribute { get; set; }
        public string AttributeLink { get; set; }
        public string AttributeId { get; set; }
    }

    public class ContentImages
    {
        public string Cover { get; set; }
        public string Sample { get; set; }
    }

    public class RootObjectMangalist
    {
        public List<Content> Content { get; set; }
        public int Total { get; set; }
        public string Page { get; set; }
        public int Pages { get; set; }
    }

    public class RootObjectManga
    {
        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("pages")]
        public Page Page { get; set; }
    }

    public class Page
    {
        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}