using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Crawler2._0.Classes.Websites;
using Crawler2._0.Properties;

//Måste ta och skriva om downloader / crawler, det är påtok för segt, måste gå att skriva bättre

namespace Crawler2._0.Classes
{
    internal class Crawler
    {
        public static string DownloadPath;
        private readonly Listhandler _listhandler;
        //Classes


        private readonly Settings _settings = new Settings();
        internal List<Manga> Mangalist;

        public Crawler(Listhandler lstHandler, List<Manga> list)
        {
            _listhandler = lstHandler;
            Mangalist = list;
            //_mainForm = mainForm;
            // _htmlAgilityDocumentTag = htmlAgilityDocumentTag;


            PictureCrawlingFinishedEvent += crawler_PictureCrawlingFinishedEvent;
            ThreadPool.SetMaxThreads(1, 1);
        }

        private void crawler_PictureCrawlingFinishedEvent(int index, Manga manga)
        {
            //throw new NotImplementedException();
        }

        public virtual void OnPictureCrawlingFinishedEvent(int index, Manga manga)
        {
            var handler = PictureCrawlingFinishedEvent;
            if (handler != null) handler(index, manga);
        }

        #region Mangalist Crawler

        public void Crawl_MangaList(object siteName)
        {

            switch ((string) siteName)
            {
                case "Nhentai":
                    var crawlerNhentai = new CrawlerNhentai(this, _listhandler.ReadTagList());
                    crawlerNhentai.ListCrawlingStartedEvent += MangalistCrawlingStartedEventRelay;
                    crawlerNhentai.ListCrawlingUpdateProgressEvent += MangalistCrawlingUpdateProgressEventRelay;


                    Mangalist = crawlerNhentai.Crawl();

                    break;
                case "Pururin":
                    var crawlerPururin = new CrawlerPururin(this, _listhandler.ReadTagList());
                    crawlerPururin.ListCrawlingStartedEvent += MangalistCrawlingStartedEventRelay;
                    crawlerPururin.ListCrawlingUpdateProgressEvent += MangalistCrawlingUpdateProgressEventRelay;
                    Mangalist = crawlerPururin.Crawl();
                    break;


                case "Fakku":
                    var crawlerFakku = new CrawlerFakku();
                    crawlerFakku.FakkulistCrawlingStartedEvent += MangalistCrawlingStartedEventRelay;
                    crawlerFakku.FakkulistCrawlingUpdateProgressEvent += MangalistCrawlingUpdateProgressEventRelay;

                    Mangalist.AddRange(crawlerFakku.Crawl());
                    break;
                case "Hentai2read":
                    var crawlerHentai2Read = new CrawlerHentai2Read();
                    crawlerHentai2Read.Hentai2ReadlistCrawlingStartedEvent += MangalistCrawlingStartedEventRelay;
                    crawlerHentai2Read.Hentai2ReadlistCrawlingUpdateProgressEvent +=
                        MangalistCrawlingUpdateProgressEventRelay;


                    Mangalist.AddRange(crawlerHentai2Read.Crawl());


                    break;
            }


            MangalistCrawlingUpdateProgressEventRelay = null;
            MangalistCrawlingStartedEventRelay = null;

            //_listhandler.WriteMangaList(Mangalist, (string) siteName);
            if (MangalistCrawlingFinishedEvent != null)
                MangalistCrawlingFinishedEvent(Mangalist);
        }

        #endregion

        #region PictureUrl Crawler

        public void Crawl_PictureUrls(string siteName, Manga selectedManga, int index, bool createSubfolders)
        {
            var stopwatch = new Stopwatch();
            switch (siteName)
            {
                case "Pururin":

                    var crawlerPururin = new CrawlerPururin(this, _listhandler.ReadTagList());
                    crawlerPururin.PictureCrawlingStartedEvent += PictureCrawlingStartedEventRelay;
                    crawlerPururin.PictureCrawlingUpdateProgressEvent += PictureCrawlingUpdateProgressEventRelay;
                    crawlerPururin.PictureDownloadUpdateProgressEvent += PictureDownloadUpdateProgressEventRelay;
                    crawlerPururin.MangaDownloadFinishedEvent += MangaDownloadFinishedEventRelay;
                    crawlerPururin.PictureDownloadStartedEvent += PictureDownloadStartedEventRelay;
                    
                    
                
                
                
                   
                    stopwatch.Start();

                    crawlerPururin.CrawlPictureUrls_Pururin(selectedManga, createSubfolders);

                    if (stopwatch.IsRunning)
                        stopwatch.Stop();

                    if (MangaDownloadFinishedEventRelay != null)
                        MangaDownloadFinishedEventRelay(selectedManga.Title, DateTime.Now,
                            stopwatch.Elapsed.Seconds + " seconds");


                    Form1.CompletedMangaToBeSaved.Add(
                        selectedManga.Title +
                        "%#%Downloaded%#%" +
                        DateTime.Now + "%#%" +
                        DownloadPath + "%#%" +
                        selectedManga.CoverUrl + "%#%" +
                        stopwatch.Elapsed.Seconds + " seconds");

                    break;
                case "Nhentai":
                    var crawlerNhentai = new CrawlerNhentai(this,null);
                    
                    crawlerNhentai.PictureCrawlingStartedEvent += PictureCrawlingStartedEventRelay;
                    crawlerNhentai.PictureCrawlingUpdateProgressEvent += PictureCrawlingUpdateProgressEventRelay;
                    crawlerNhentai.PictureDownloadStartedEvent += PictureDownloadStartedEventRelay;
                    crawlerNhentai.PictureDownloadUpdateProgressEvent += PictureDownloadUpdateProgressEventRelay;
                    //PictureDownloadStartedEvent
                    stopwatch.Start();
                    crawlerNhentai.CrawlPictureUrls_Nhentai(selectedManga,createSubfolders);
                    if (stopwatch.IsRunning)
                        stopwatch.Stop();

                    if (MangaDownloadFinishedEventRelay != null)
                        MangaDownloadFinishedEventRelay(selectedManga.Title, DateTime.Now,
                            stopwatch.Elapsed.Seconds + " seconds");
                    

                    _listhandler.WriteToFile("Data\\Lists\\CompletedDownloads.List",
                        selectedManga.Title +
                        "%#%Downloaded%#%" +
                        DateTime.Now + "%#%" +
                        DownloadPath + "%#%" +
                        selectedManga.CoverUrl+
                        "%#%" + stopwatch.Elapsed.Seconds 
                        );


                    break;
                case "Fakku":
                    var crawlerFakku = new CrawlerFakku();
                    crawlerFakku.FakkuPictureCrawlingStartedEvent += PictureCrawlingStartedEventRelay;
                    crawlerFakku.FakkuPictureCrawlingUpdateProgressEvent += PictureCrawlingUpdateProgressEventRelay;
                    crawlerFakku.FakkuPictureDownloadUpdateProgressEvent += PictureDownloadUpdateProgressEventRelay;
                    //crawlerFakku.FakkuMangaDownloadFinishedEvent += MangaDownloadFinishedEvent_Relay;
                    crawlerFakku.FakkuPictureDownloadStartedEvent += PictureDownloadStartedEventRelay;


                    crawlerFakku.CrawlPictureUrls_Fakku(selectedManga, createSubfolders);
                    Form1.CompletedMangaToBeSaved.Add(
                        selectedManga.Title +
                        "%#%Downloaded%#%" +
                        DateTime.Now + "%#%" +
                        DownloadPath + "%#%" +
                        selectedManga.CoverUrl
                        );
                    break;
            }
        }

        #endregion

        #region eventhandlers and relay functions

        public delegate void MangaDownloadFinishedEventHandler(string title, DateTime time, string timeTaken);

        public delegate void MangaListCrawlingFailedEventHandler(string url);

        public delegate void MangalistCrawlingFinishedEventHandler(List<Manga> list);

        public delegate void MangalistCrawlingStartedEventHandler(int maximum);

        public delegate void MangalistCrawlingUpdateProgressEventHandler(double percentage);

        public delegate void MangaReadEventHandler(int pages);

        public delegate void PictureCrawlingFinishedEventHandler(int index, Manga manga);

        public delegate void PictureCrawlingStartedEventHandler(
            string title, string status, string percentage, string pages);

        public delegate void PictureCrawlingUpdateProgressEventHandler(string title, int pageCount, int queueCount);

        public delegate void PictureDownloadStartedEventHandler(string title, string pages);

        public delegate void PictureDownloadUpdateProgressEventHandler(string title, int pageCount, int queueCount);

        public delegate void TagCrawlingFinishedEventHandler();

        public delegate void TagCrawlingStartedEventHandler(
            string sitename, int pages, int currentpage);

        public delegate void TagCrawlingUpdateProgressEventHandler(int value);


        public event MangalistCrawlingFinishedEventHandler MangalistCrawlingFinishedEvent;
        public event MangalistCrawlingStartedEventHandler MangalistCrawlingStartedEventRelay;
        public event MangalistCrawlingUpdateProgressEventHandler MangalistCrawlingUpdateProgressEventRelay;
        public event PictureCrawlingStartedEventHandler PictureCrawlingStartedEventRelay;
        public event PictureCrawlingUpdateProgressEventHandler PictureCrawlingUpdateProgressEventRelay;
        public event PictureCrawlingFinishedEventHandler PictureCrawlingFinishedEvent;
        public event MangaDownloadFinishedEventHandler MangaDownloadFinishedEventRelay;
        public event PictureDownloadStartedEventHandler PictureDownloadStartedEventRelay;
        public event TagCrawlingStartedEventHandler TagCrawlingStartedEventRelay;
        public event PictureDownloadUpdateProgressEventHandler PictureDownloadUpdateProgressEventRelay;

        #endregion

        #region Tag Crawler

        public void Crawl_TagList(string siteName)
        {
            switch (siteName)
            {
                case "Pururin":
                    var crawlerPururin = new CrawlerPururin(this, _listhandler.ReadTagList());
                    crawlerPururin.TagCrawlingStartedEvent += TagCrawlingStartedEventRelay;
                    crawlerPururin.CrawlTagList_Pururin(null);

                    break;
            }
        }


        public void CrawlTagList_Pururin_DoWork()
        {
            /*
         kolla om HtmlAgilityDocument_Picture != null
          * om så är fallet, så är det första sidan.


         */
        }

        #endregion
    }
}