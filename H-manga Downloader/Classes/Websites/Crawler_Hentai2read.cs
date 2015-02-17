using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler2._0.Classes.Websites
{
    internal class CrawlerHentai2Read
    {
        private const string MaxNodeXpath = ".//ul[@class='img_pgg']/li[11]/a";
        private const string MaxAttributeXpath = "data-pmax";
        private const string UrlListStartUrl = "http://hentai2read.com/hentai-list/category/adult/name-az";
        private readonly List<Manga> _pururinMangaList = new List<Manga>();
        //private HtmlWeb _htmlAgilityWeb = new HtmlWeb();
        private List<string> _urlList;
        //private HtmlDocument _htmlAgilityDocumentManga;
        //private HtmlDocument _htmlAgilityDocumentPicture;
        //private HtmlDocument _htmlAgilityDocumentTag;

        public event Crawler.MangalistCrawlingUpdateProgressEventHandler Hentai2ReadlistCrawlingUpdateProgressEvent;
        public event Crawler.MangalistCrawlingStartedEventHandler Hentai2ReadlistCrawlingStartedEvent;

        internal List<Manga> Crawl()
        {
            _urlList = CreateUrls();
            Parallel.ForEach(_urlList, item => FetchInfo(item));


            return _pururinMangaList;
        }

        private void FetchInfo(string item)
        {
            // _htmlAgilityDocumentManga = _htmlAgilityWeb.Load(item);
            //var htmlAgilityNodeCollection = _htmlAgilityDocumentManga.DocumentNode.SelectNodes("//div[@class='section']/ul[@class='anm-ul']/li");

            //if (ListCrawlingUpdateProgressEvent != null)
            //ListCrawlingUpdateProgressEvent(1);


            //Parallel.ForEach(htmlAgilityNodeCollection, htmlAgilityNode =>
            // {
            //     HtmlNode rootNode = htmlAgilityNode.SelectSingleNode("./div[@class='lst-anm-cvr']/a[@class='mng_det_pop']");
            //     Manga m = new Manga();
            //     m.Title = rootNode.Attributes["title"].Value;

            //     string url = rootNode.Attributes["href"].Value;

            //     HtmlDocument mangaDocument = _htmlAgilityWeb.Load(url);


            // });
            //Parallel.ForEach(htmlAgilityNodeCollection,htmlAgilityNode => 
            //{
            //    HtmlNode rootNode = htmlAgilityNode.SelectSingleNode("./div[@class='lst-anm_cvr']/a[@class='mng_det_pop']");
            //    Manga m = new Manga();
            //    


            //});
        }

        private List<string> CreateUrls()
        {
            //List<string> _localList = new List<string>();
            //_htmlAgilityDocumentManga = _htmlAgilityWeb.Load(UrlListStartUrl);
            //if (_htmlAgilityDocumentManga != null)
            //{
            //    var pageCount = getPageCount();


            //    if (Hentai2readlistCrawlingStartedEvent != null)
            //        Hentai2readlistCrawlingStartedEvent(pageCount);


            //    for (var x = 1; x <= pageCount; x++)
            //    {
            //        string url = string.Format("http://hentai2read.com/hentai-list/category/adult/name-az/{0}/",x);
            //        _localList.Add(url);
            //    }
            //}
            return null;
            //return _localList;
        }

        private int GetPageCount()
        {
            //HtmlAgilityPack.HtmlNode htmlAgilityMaxNode = _htmlAgilityDocumentManga.DocumentNode.SelectSingleNode(MaxNodeXpath);
            //int value = Convert.ToInt32(htmlAgilityMaxNode.InnerText);

            //return value;
            return 0;
        }
    }
}