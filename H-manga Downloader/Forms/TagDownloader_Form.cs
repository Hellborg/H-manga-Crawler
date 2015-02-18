using System;
using System.Windows.Forms;
using Crawler2._0.Classes;

namespace Crawler2._0.Forms
{
    public partial class TagDownloaderForm : Form
    {
        private readonly Crawler _crawler;

        internal TagDownloaderForm(Crawler crawler)
        {
            _crawler = crawler;
            InitializeComponent();

            // crawler.TagCrawlingStartedEvent +=crawler_TagCrawlingStartedEvent;


            //crawler.TagCrawlingUpdateProgressEvent += crawler_TagCrawlingUpdateProgressEvent;
            //crawler.TagCrawlingFinishedEvent += crawler_TagCrawlingFinishedEvent;
        }

        private void TagDownloader_Form_Load(object sender, EventArgs e)
        {
            _crawler.Crawl_TagList("Pururin");
        }
    }
}