using System;
using System.Windows.Forms;
using Crawler2._0.Classes;

namespace Crawler2._0.Forms
{
    public partial class TagDownloaderForm : Form
    {
        private readonly Crawler _crawler;
        private readonly Form1 _mainForm;

        internal TagDownloaderForm(Crawler crawler, Form1 mainform)
        {
            _crawler = crawler;
            _mainForm = mainform;
            InitializeComponent();

            // crawler.TagCrawlingStartedEvent +=crawler_TagCrawlingStartedEvent;


            //crawler.TagCrawlingUpdateProgressEvent += crawler_TagCrawlingUpdateProgressEvent;
            //crawler.TagCrawlingFinishedEvent += crawler_TagCrawlingFinishedEvent;
        }

        private void crawler_TagCrawlingFinishedEvent()
        {
            if (!InvokeRequired)
            {
                _mainForm.Focus();
                Close();
            }

            else
                Invoke(new Action(crawler_TagCrawlingFinishedEvent));
        }

        private void crawler_TagCrawlingUpdateProgressEvent(int value)
        {
            if (!InvokeRequired)
            {
                TagDownloadProgressBar.Value += value;
                TagDownloadProgressLabel.Text = "Page " + TagDownloadProgressBar.Value + " of " +
                                                TagDownloadProgressBar.Maximum;
            }
            else
            {
                Invoke(new Action(() => crawler_TagCrawlingUpdateProgressEvent(value)));
            }
        }

        private void crawler_TagCrawlingStartedEvent(string sitename, int pages, int currentpage)
        {
            if (!InvokeRequired)
            {
                TagDownloadProgressBar.Maximum = pages;
                TagDownloadProgressBar.Value = 1;
                TagDownloadProgressLabel.Text = "Page " + currentpage + " of " + pages;
            }
            else
            {
                Invoke(new Action(() => crawler_TagCrawlingStartedEvent(sitename, pages, currentpage)));
            }
        }

        private void TagDownloader_Form_Load(object sender, EventArgs e)
        {
            _crawler.Crawl_TagList("Pururin");
        }
    }
}