using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Crawler2._0.Classes;
using Crawler2._0.Forms;
using Crawler2._0.Properties;

//Städa koden




//Behöver ändra namnen på eventen, så de är lite bättre förklarande.
//Fixa så man kan ha custom namn på filerna. 
//
//  %Title%    Begränsad till 100 karaktärer
//  %Page%     helt enkelt vilken sidnr filen har
//   %Website%  vilken sida den är tagen ifrån
//
//Fixa buggen med att den ibland inte uppdatererar progress, utan står kvar på awaiting free thread
//verkar som att detta bara händer första gången när jag måste ladda ner list filen, och sedan inte stänger av programmet eoch startar det igen.

namespace Crawler2._0
{
    public partial class Form1 : Form
    {
        internal static int MaxPages;
        public static List<string> CompletedMangaToBeSaved = new List<string>();

        public static readonly List<string> SupportedSites = new List<string>(new[]
        {
            "Nhentai",
            "Pururin" //,
            //"Fakku",
            //,"Hentai2read"
        });

        private readonly List<string> _completedMangas = new List<string>();
        private readonly Listhandler _listhandler = new Listhandler();
        private readonly bool _saveCovers;
        private readonly Settings _setting = new Settings();

        private Crawler _crawler;
        private List<Manga> _filteredList = new List<Manga>();
        private List<Manga> _mangaList = new List<Manga>();
        private Dictionary<int, string> _tagDictionary = new Dictionary<int, string>();
        private TagDownloaderForm _tagDownloader;
        //sätta limit på antalet du kan ha i nedladdnigns kön samtidigt

        

        public Form1()
        {
            InitializeComponent();
            ServicePointManager.DefaultConnectionLimit = 160;

            ThreadPool.SetMaxThreads(4, 4);
            CreateDirectories();
            _saveCovers = _setting.SaveCoversToDisk;

            #region CustomEventHandlers

            _listhandler.CompletedMangaLineRead += _listhandler_CompletedLineRead;
            _listhandler.MangaListLineRead += _listhandler_MangaListRead;
            _listhandler.MangaListReadFinished += _listhandler_MangaListReadFinished;
            _listhandler.TagListLineRead += _listhandler_TagListLineRead;

            #endregion
        }

        private void CreateCrawlerEventListeners()
        {
            _crawler.PictureCrawlingStartedEventRelay += _crawler_PictureCrawlingStartedEvent;
            _crawler.PictureCrawlingUpdateProgressEventRelay += _crawler_PictureCrawlingUpdateProgressEvent;
            _crawler.PictureDownloadStartedEventRelay += downloader_PictureDownloadStartedEvent;


            _crawler.MangalistCrawlingFinishedEvent += _crawler_MangalistFinishedCrawlingEvent;
            _crawler.MangalistCrawlingStartedEventRelay += _crawler_CrawlingStartedEvent;
            _crawler.MangalistCrawlingUpdateProgressEventRelay += _crawler_CrawlingUpdateProgressEvent;



            _crawler.MangalistCrawlingFinishedEvent += _crawler_MangalistFinishedCrawlingEvent;

            _crawler.MangaDownloadFinishedEventRelay += _crawler_MangaDownloadFinishedEvent;
            _crawler.PictureDownloadUpdateProgressEventRelay += _crawler_PictureDownloadUpdateProgressEvent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // BackgroundWorkerTagDownloader.RunWorkerAsync();


            
            LoadGui();
            LoadSettings();
            LoadTagList();
            LoadMangaList();
            FilterByTags();
            LoadCompletedDownloads();
            //FilterByWebsite(WebsiteDropdown.SelectedItem.ToString());
            InitializeList(_filteredList);
            _crawler = new Crawler(_listhandler, _mangaList);
            CreateCrawlerEventListeners();
        }

       

        

        
    

        private void LoadGui()
        {
            foreach (var s in SupportedSites)
            {
                var node = new TreeNode();
                node.Text = s;


            }
            UpdateWebsiteDropdown();
            TextboxCustomFilter.Text = _setting.FilterString;
        }

        private void UpdateWebsiteDropdown()
        {
            foreach (var s in SupportedSites)
            {
                WebsiteDropdown.Items.Add(s);
            }
            WebsiteDropdown.SelectedIndex = 0;
            DownloadButton.Text = "Download List(" + WebsiteDropdown.SelectedItem + ")";
        }

        private void LoadCompletedDownloads()
        {
            //listhandler.ReadMangaList();
            var loadCompletedThread = new Thread(_listhandler.ReadCompletedDownloads);
            loadCompletedThread.Start();
        }

        private bool TagFileTooOld() //funkar inte som tänkt, får se över den men det är inte super viktigt just nu
        {
            var currentDate = DateTime.Today;
            var fileDate = File.GetLastWriteTime("Data/Tags/Pururin.Tags").Date;
            var numberOfDays = (currentDate - fileDate).TotalDays;
            return numberOfDays > 14;
            //return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var website = WebsiteDropdown.SelectedItem.ToString();
            _crawler = new Crawler(_listhandler, _mangaList);

            ToolstripProgress.Visible = true;
            ToolstripLabel.Visible = true;
           
            CreateCrawlerEventListeners();



            //_crawler.PictureCrawlingUpdateProgressEvent += downloader_PictureDownloadUpdateProgressEvent;

            var t = new Thread(_crawler.Crawl_MangaList);
            t.Start(website);
            //_crawler.Crawl_MangaList(website);
        }

        private void LoadMangaList()
        {
            _mangaList = Listhandler.ReadMangaList();

            numericFilterPageCount.Maximum = MaxPages;
        }

        private void LoadTagList()
        {
            if (!TagFileTooOld())
                _tagDictionary = _listhandler.ReadTagList();
            else
            {
               // var result = MessageBox.Show("Your tag file is tooo ooooold, update it? might take a while", "",
                  //  MessageBoxButtons.YesNo);

                DialogResult result = DialogResult.No;


                if (result == DialogResult.Yes)
                {
                    //Show tagdownloader form
                    _tagDownloader = new TagDownloaderForm(_crawler, this);
                    _tagDownloader.Closed += tagDownloader_Closed;

                    _tagDownloader.ShowDialog();
                }
                else
                    _tagDictionary = _listhandler.ReadTagList();
            }
        }

        private void CreateDirectories()
        {
            if (!Directory.Exists("Data"))
                Directory.CreateDirectory("Data");
            
            if (!Directory.Exists("Data/Tags"))   
                Directory.CreateDirectory("Data/Tags");
            
            if (!Directory.Exists("Data/Lists"))    
                Directory.CreateDirectory("Data/Lists");
            
            var appPath = Path.GetDirectoryName(Application.ExecutablePath);

            if (_setting.DownloadPath == "")
            {
                _setting.DownloadPath = appPath + "\\Downloads";
                _setting.Save();
            }
        }

        public void ClearInfoBox()
        {
            pictureBox1.ImageLocation = null;
            lblTitle.Text = "";
            lblInfo.Text = "";
            lblLanguage.Text = "";
            lblPages.Text = "";
            lblTags.Text = "";

        }

        private void TabpageOptions_Enter(object sender, EventArgs e)
        {
          
            LoadSettings();
        }

        private void LoadSettings()
        {
            SaveCoversCheckbox.Checked = _saveCovers;
            createSiteFolderCheckbox.Checked = _setting.CreateSiteFolder;
            //NumericInfoThreadCount.Value = _setting.InfoThreadCount;
            //NumericDownloaderThreadCount.Value = _setting.DownloaderThreadCount;
            textboxRememberedFilter.Text = _setting.FilterString;
            SelectedPathTextbox.Text = _setting.DownloadPath;
            CreateSubfoldersCheckbox.Checked = _setting.CreateSubfolders;
        }

        private void SaveOptionsButton_Click(object sender, EventArgs e)
        {
            _setting.SaveCoversToDisk = SaveCoversCheckbox.Checked;
            // _setting.DownloaderThreadCount = Convert.ToInt32(NumericDownloaderThreadCount.Value);
            //_setting.InfoThreadCount = Convert.ToInt32(NumericInfoThreadCount.Value);
            _setting.DownloadPath = SelectedPathTextbox.Text;
            _setting.CreateSubfolders = CreateSubfoldersCheckbox.Checked;
            //_setting.DownloadingJobs = Convert.ToInt32(NumericDownloaderJobs.Value);
            _setting.CreateSiteFolder = createSiteFolderCheckbox.Checked;
            _setting.RetryTime = Convert.ToDouble(numericRetryTime.Value);
            _setting.FilterString = textboxRememberedFilter.Text;
            _setting.Save();
            TextboxCustomFilter.Text = _setting.FilterString;
        }

        private void TagListbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = TagListbox.IndexFromPoint(e.Location);
                if (item >= 0)
                {
                    TagListbox.SelectedIndex = item;
                    ContextmenuTags.Show(MousePosition);
                }
            }
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            var selectedPath = folderDialog.SelectedPath;
            SelectedPathTextbox.Text = selectedPath;
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListviewMangas.SelectedObjects.Count >= 1)
            {
                foreach (Manga m in ListviewMangas.SelectedObjects)
                {
                    //Manga manga = MangaList.Find(x => x.title == ListviewMangas.SelectedItem.Text);
                    var item = new ListViewItem {Text = m.Title};

                    var subItemStatus = new ListViewItem.ListViewSubItem();
                    var subItemPercentage = new ListViewItem.ListViewSubItem();
                    var subItemPages = new ListViewItem.ListViewSubItem();

                    subItemStatus.Text = "Awaiting free worker thread";
                    subItemPercentage.Text = "";
                    subItemPages.Text = "";

                    item.SubItems.Add(subItemStatus);
                    item.SubItems.Add(subItemPercentage);
                    item.SubItems.Add(subItemPages);

                    ListviewCurrentDownloads.Items.Add(item);

                    ThreadPool.QueueUserWorkItem(DownloadSelected, m);

                    //var t = new Thread(DownloadSelected);
                    //t.Start(m);
                    //_threadPool.Add(t);
                }
            }
        }

        private void DownloadSelected(object o)
        {
            var m = (Manga) o;
            _crawler.Crawl_PictureUrls(m.Website, m, ListviewCurrentDownloads.Items.Count,CreateSubfoldersCheckbox.Checked);
        }

        private void ToolstripItemGotoGallery_Click(object sender, EventArgs e)
        {
            var manga = (Manga)ListviewMangas.SelectedObject;
            Process.Start("www.pururin.com/gallery"+manga.GalleryUrl);
        }

     

        private void ShowMangaInfo(object m)
        {
            
            var manga = (Manga) m;
            if (!InvokeRequired)
            {
                if (!Directory.Exists("Data/Pictures/Covers"))
                    Directory.CreateDirectory("Data/Pictures/Covers");


                pictureBox1.Load("Data/Pictures/ajax-loader.gif");
                lblTitle.Text = "Title: " + manga.Title;
                lblPages.Text = "Pages: " + manga.Pages;
                lblInfo.Text = "Site: "+manga.Website;
                if (manga.Tags != null)
                {
                    foreach (var x in manga.Tags)
                    {
                        //string tagValue;
                        //_//tagDictionary.TryGetValue(x, out tagValue);
                        //if (tagValue != null) 
                        TagListbox.Items.Add(x.Trim());
                    }
                }
                var filename = Path.GetFileName(manga.ImagePath);
                if (!File.Exists("Data/Pictures/Covers/" + manga.Website + "/" + manga.UniqueId + "-" + filename))
                    //Means its not local.
                {
                    if (!Directory.Exists("Data/Pictures/Covers/" + manga.Website))
                        Directory.CreateDirectory("Data/Pictures/Covers/" + manga.Website);


                    if (tabcontrolMain.SelectedIndex == 0)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var req = WebRequest.Create(manga.CoverUrl);
                        var stream = req.GetResponse().GetResponseStream();
                        if (stream != null)
                        {
                            var img = Image.FromStream(stream);
                            pictureBox1.Image = img;



                            var imgPath = "Data/Pictures/Covers/" + manga.Website + "/" + manga.UniqueId + "-" +
                                          filename;

                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(new Uri(manga.CoverUrl),imgPath );
                            }
                            //img.Save(imgPath);
                            
                        }
                        Cursor.Current = Cursors.Default;
                        //anga.LocalImage = true;
                    }
                    //pictureBox1.ImageLocation = "http://" + manga.ImagePath;
                }
                else
                {
                    var imgPath =  "Data/Pictures/Covers/" + manga.Website + "/" + manga.UniqueId +"-"+filename;
                    pictureBox1.ImageLocation = imgPath;
                }
            }
            else
                Invoke(new Action(() => ShowMangaInfo(manga)));
        }

        private void SaveCoversCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox) sender).Checked)
            {
                var dialogResult =
                    MessageBox.Show("This will make the process much slower, are you sure you want to enable this?", "",
                        MessageBoxButtons.YesNo);
                ((CheckBox) sender).Checked = dialogResult == DialogResult.Yes;
            }
        }

      

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //iterate over mangalist and save to mangalist, either that or come up with some other way to determine wether is localfile


            SaveCompletedToFile();
        }

        private void SaveCompletedToFile()
        {
            foreach (var s in CompletedMangaToBeSaved)
            {
                _listhandler.WriteToFile(@"Data\Lists\CompletedDownloads.List", s);
            }
        }

        private void InitializeList(List<Manga> list)
        {
            ListviewMangas.UseFiltering = true;
            ListviewMangas.SetObjects(list);
            ListviewMangas.ModelFilter = new ModelFilter(delegate(object x)
            {
                if (((Manga)x).Website == WebsiteDropdown.SelectedItem.ToString())
                    return true;
                else
                    return false;

            });
            //ListviewMangas.Objects = list;
        }

        private void ListviewMangas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListviewMangas.SelectedItem != null)
            {
                var index = ListviewMangas.SelectedIndex;
               
                var m = (Manga) ListviewMangas.VirtualListDataSource.GetNthObject(index);
                //ThreadPool.QueueUserWorkItem(ShowMangaInfo, m);
                TagListbox.Items.Clear();
                ShowMangaInfo(m);
                //ShowMangaInfo(m);
            }
        }

        private void ListviewMangas_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            ContextmenuMangalist.Show(MousePosition);
        }

       

        private void ListviewCompletedDownloads_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextmenuCompletedDownloads.Show(MousePosition);
            }
        }

        public void AddCustomTag(string text)
        {
            

            TextboxCustomFilter.AppendText(text + ";");
            
            ApplyFilter();
        }

        private void TagToolstripFilterByThis_Click(object sender, EventArgs e)
        {
            var selectedTag = TagListbox.SelectedItem.ToString();
            AddCustomTag(selectedTag);
        }

        private void TextboxCustomFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyFilter();
        }

     

       

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //_setting.ChosenWebsites.Add(e.Node.Text);
            _setting.Save();


            WebsiteDropdown.Items.Clear();
            UpdateWebsiteDropdown();


            //e.Node.Checked
            //if (e.Node.Text == "Reddit")
            //{ 
            //    if(e.Node.Checked)
            //    {
            //        if(_setting.FirstSubreddit)
            //            MessageBox.Show(Resources.First_Subreddit_Message_string);

            //        TreeNode node = new TreeNode();
            //        //e.Node.Nodes.Add(node);
            //        treeView1.Nodes.Add(node);
            //        node.Checked = true;
            //        node.BeginEdit();
            //        if (!node.IsEditing)
            //        {
            //            node.BeginEdit();
            //        }
            //        e.Node.Checked = false;
            //    }
            //}
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    e.Node.Text = e.Label;
                    e.Node.EndEdit(false);
                    //_setting.ChosenWebsites.Add(e.Node.Text);
                    _setting.FirstSubreddit = false;
                    _setting.Save();

                    WebsiteDropdown.Items.Clear();
                    UpdateWebsiteDropdown();
                }
                else
                {
                    e.Node.Remove();
                    //Uncheck reddit one
                }
            }
            else
            {
                e.Node.Remove();
            }
            //e.Node.Remove();
        }

        

        private void WebsiteDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearInfoBox();

            //string selectedText = WebsiteDropdown.SelectedValue.ToString();
            DownloadButton.Text = "Download List(" + WebsiteDropdown.SelectedItem + ")";
            //FilterByWebsite(WebsiteDropdown.SelectedItem.ToString());
            InitializeList(_mangaList);
            ListviewMangas.SelectObject(0);
        }

        #region FilterRegion

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void FilterByWebsite(string website)
        {
            if (_filteredList.Count != 0)
            {
                List<Manga> tempList = new List<Manga>();
                foreach (var m in _filteredList)
                {
                    if (m.Website == website)
                        tempList.Add(m);
                }
                _filteredList = tempList;
            }
            else
            {
                foreach (var m in _mangaList)
                {
                    if (m.Website == website)
                        _filteredList.Add(m);
                }
            }
            

        }

        public void FilterByPages()
        {
           // _filteredList.Clear();
            _filteredList = new List<Manga>();
            //ListviewMangas.Clear();
            if (CheckboxFilterByPages.Checked)
            {
                foreach (var m in _mangaList)
                {
                    if (m.Pages >= numericFilterPageCount.Value)
                        _filteredList.Add(m);
                }
            }
            else
            {
                ListviewMangas.SetObjects(_mangaList);
            }
        }

        public void FilterByTags()
        {
            var tagsDontInclude = new List<string>();
            var tagsInclude = new List<string>();

            if (_filteredList.Count == 0)
            {
                foreach (var cb in groupBoxTags.Controls.OfType<CheckBox>())
                {
                    var searchFor = cb.Text;

                    if (cb.CheckState == CheckState.Checked)
                        tagsInclude.Add(cb.Text);
                    else if (cb.CheckState == CheckState.Indeterminate)
                        tagsDontInclude.Add(cb.Text);
                }

                if (TextboxCustomFilter.Text != "")
                {
                    var filterString = TextboxCustomFilter.Text;
                    var explodedTagString = filterString.Split(';');

                    foreach (var tag in explodedTagString)
                    {
                        if (tag != string.Empty)
                        {
                            var searchFor = tag.TrimStart('!');
                            if (tag.StartsWith("!"))
                            {
                                tagsDontInclude.Add(searchFor);
                            }
                            else
                            {
                                tagsInclude.Add(searchFor);
                            }
                        }
                    }
                }

                _filteredList = _mangaList;
                foreach (var i in tagsInclude)
                {
                    var newList = new List<Manga>(); //_filteredList.Where(x => x.Tags.Contains(i.ToLower())).ToList();
                    foreach (var m in _filteredList)
                    {
                        if (m.Tags.Contains(i))
                        {
                            newList.Add(m);
                        }
                    }


                    _filteredList = newList;
                }
                foreach (var z in tagsDontInclude)
                {
                    var newList = _filteredList.Where(x => !x.Tags.Contains(z)).ToList();
                    _filteredList = newList;
                }
            }
            else
            {
                foreach (var cb in groupBoxTags.Controls.OfType<CheckBox>())
                {
                    var searchFor = cb.Text;
                    var tagIndex = _tagDictionary.FirstOrDefault(x => x.Value.ToLower() == searchFor.ToLower()).Key;
                    if (cb.CheckState == CheckState.Checked)
                        tagsInclude.Add(searchFor);
                    else if (cb.CheckState == CheckState.Indeterminate)
                        tagsDontInclude.Add(searchFor);
                }
                if (TextboxCustomFilter.Text != "")
                {
                    var filterString = TextboxCustomFilter.Text;
                    var explodedTagString = filterString.Split(';');

                    foreach (var tag in explodedTagString)
                    {
                        var searchFor = tag.TrimStart('!');
                        var tagIndex = _tagDictionary.FirstOrDefault(x => x.Value.ToLower() == searchFor.ToLower()).Key;
                        if (tag.StartsWith("!"))
                        {
                            tagsDontInclude.Add(searchFor);
                        }
                        else
                        {
                            tagsInclude.Add(searchFor);
                        }
                    }
                }
                foreach (var i in tagsInclude)
                {
                    var newList = _filteredList.Where(x => x.Tags.Contains(i)).ToList();
                    _filteredList = newList;
                }
                foreach (var z in tagsDontInclude)
                {
                    var newList = _filteredList.Where(x => !x.Tags.Contains(z)).ToList();
                    _filteredList = newList;
                }

            }
            int filteredOut = _mangaList.Count - _filteredList.Count;
            labelFilteredOut.Text = "Filtered out "+filteredOut+" mangas";
        }

        public void FilterOutDownloaded()
        {
            if (!FilterCheckbox_downloaded.Checked) return;


            var newList = _filteredList.Where(x => !_completedMangas.Contains(x.Title)).ToList();
            _filteredList = newList;
        }

        public void ApplyFilter()
        {
            
            FilterByPages();
            FilterByTags();
            FilterOutDownloaded();
            //FilterByWebsite(WebsiteDropdown.SelectedItem.ToString());
            InitializeList(_filteredList);
            ClearInfoBox();
            ListviewMangas.SelectedIndex = 0;
            if(ListviewMangas.SelectedObject != null)
                ShowMangaInfo(ListviewMangas.SelectedObject);
        }

        #endregion

        #region EventMetoder

        private void _listhandler_TagListLineRead(int key, string value)
        {
            _tagDictionary.Add(key, value);
        } //Happens after a line in tagfile is read

        private void _listhandler_MangaListReadFinished()
        {
           // ListviewMangas.SetObjects(_mangaList.ToArray());
        } //Happens when the manga list file read is finished

        private void _listhandler_MangaListRead(Manga m) //Happens when each manga from the file is read
        {
            if (m.Pages > MaxPages)
                MaxPages = m.Pages;

            _mangaList.Add(m);
        } //

        private void _listhandler_CompletedLineRead(string title, string date, string status, string timeTaken)
        {
            if (!InvokeRequired)
            {
                _completedMangas.Add(title);
                var item = new ListViewItem();
                var subItemStatus = new ListViewItem.ListViewSubItem();
                var subItemCompletedOn = new ListViewItem.ListViewSubItem();
                var subItemTimeTaken = new ListViewItem.ListViewSubItem();

                item.Text = title;
                subItemStatus.Text = status;
                subItemCompletedOn.Text = date;
                subItemTimeTaken.Text = timeTaken;


                item.SubItems.Add(subItemStatus);
                item.SubItems.Add(subItemCompletedOn);
                item.SubItems.Add(subItemTimeTaken);

                ListviewCompletedDownloads.Items.Add(item);
            }
            else
                Invoke(new Action(() => _listhandler_CompletedLineRead(title, date, status, timeTaken)));
        } //Happens after a line in completeddownloads is read


        private void _crawler_CrawlingUpdateProgressEvent(double percentage)
        {
            if (!InvokeRequired)
            {
                ToolstripProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
                ToolstripLabel.Text = percentage+"%";
            }
            else
                Invoke(new Action(() => _crawler_CrawlingUpdateProgressEvent(percentage)));
        } //Happens after a website page has been crawled

        private void _crawler_CrawlingStartedEvent(int maximum)
        {
            if (!InvokeRequired)
            {
                ToolstripProgress.Maximum = maximum;
                ToolstripProgress.Value = 1;
            }
            else
                Invoke(new Action(() => _crawler_CrawlingStartedEvent(maximum)));
        } //Happens when crawling is started

        private void _crawler_MangalistFinishedCrawlingEvent(List<Manga> list)
        {
            if (!InvokeRequired)
            {
                FilterByWebsite(WebsiteDropdown.SelectedItem.ToString());
                
                //ListviewMangas.Sort(((OLVColumn)ListviewMangas.Columns[0]),SortOrder.Ascending);

                _mangaList = list;
                FilterByTags();
                InitializeList(_filteredList);
                ToolstripProgress.Maximum = 0;
                ToolstripProgress.Value = 0;
                ToolstripLabel.Text = "";
                ToolstripProgress.Visible = false;
                ToolstripLabel.Visible = false;
            }


            else
                Invoke(new Action(() => _crawler_MangalistFinishedCrawlingEvent(list)));
        } //Happens when crawling is completed

        private void _crawler_MangaListCrawlingFailedEvent(string url)
        {
            if (!InvokeRequired)
                MessageBox.Show("Failed at getting the website " + url +
                                ". Make sure the website is up and running and try again");
            else
                Invoke(new Action(() => _crawler_MangaListCrawlingFailedEvent(url)));
        } //Happens if the crawler fails on a particular url


        private void _crawler_PictureCrawlingStartedEvent(string title, string status, string percentage, string pages)
        {
            if (!InvokeRequired)
            {
                var item = ListviewCurrentDownloads.FindItemWithText(title);
                // new ListViewItem {Text = title};


                item.SubItems[1].Text = status;
                item.SubItems[2].Text = percentage;
                item.SubItems[3].Text = pages;
            }

            else
            {
                Invoke(new Action(() => _crawler_PictureCrawlingStartedEvent(title, status, percentage, pages)));
            }
        } //Happens when the picture url crawling of manga starts.

        private void _crawler_PictureCrawlingUpdateProgressEvent(string title, int pageCount, int queueCount)
        {
            if (!InvokeRequired)
            {
                var finished = pageCount - queueCount;
                var percentage = String.Format("{0:P2}", ((double) finished/pageCount));

                var index = ListviewCurrentDownloads.FindItemWithText(title).Index;


                ListviewCurrentDownloads.Items[index].SubItems[2].Text = percentage;
                ListviewCurrentDownloads.Items[index].SubItems[3].Text = finished + " / " + pageCount;
            }
            else
            {
                Invoke(new Action(() => _crawler_PictureCrawlingUpdateProgressEvent(title, pageCount, queueCount)));
            }

            //this.Invoke(new Action(() => ListviewCurrentDownloads.Items[index].SubItems[2].Text = Percentage));
            //this.Invoke(new Action(() => ListviewCurrentDownloads.Items[index].SubItems[1].Text = finished + " / " + pageCount));
        } //Happens when picture url has been crawled.


        private void _crawler_PictureDownloadUpdateProgressEvent(string title, int pageCount, int queueCount)
        {
            if (!InvokeRequired)
            {
                var index = ListviewCurrentDownloads.FindItemWithText(title).Index;


                var finished = queueCount;
                var percentage = String.Format("{0:P2}", ((double) finished/pageCount));


                ListviewCurrentDownloads.Items[index].SubItems[2].Text = percentage;
                ListviewCurrentDownloads.Items[index].SubItems[3].Text = finished + " / " + pageCount;
            }
            else
            {
                Invoke(new Action(() => _crawler_PictureDownloadUpdateProgressEvent(title, pageCount, queueCount)));
            }
        } //Happens when picture has been downloaded


        private void _crawler_MangaDownloadFinishedEvent(string title, DateTime time, string timeTaken)
        {
            if (!InvokeRequired)
            {
                ListviewCurrentDownloads.FindItemWithText(title).Remove();
                var item = new ListViewItem();
                item.Text = title;

                var subItemState = new ListViewItem.ListViewSubItem();
                var subItemDate = new ListViewItem.ListViewSubItem();
                var subItemTimetaken = new ListViewItem.ListViewSubItem();

                subItemState.Text = "Downloaded";
                subItemDate.Text = time.ToString(CultureInfo.CurrentCulture);
                subItemTimetaken.Text = timeTaken;

                item.SubItems.Add(subItemState);
                item.SubItems.Add(subItemDate);
                item.SubItems.Add(subItemTimetaken);

                ListviewCompletedDownloads.Items.Add(item);
            }
            else
            {
                Invoke(new Action(() => _crawler_MangaDownloadFinishedEvent(title, time, timeTaken)));
            }
        } //Happens when manga has finished downloading.


        private void tagDownloader_Closed(object sender, EventArgs e)
        {
            _tagDictionary = _listhandler.ReadTagList();
        }


        private void downloader_PictureDownloadStartedEvent(string title, string pages)
        {
            if (!InvokeRequired)
            {
                var index = ListviewCurrentDownloads.FindItemWithText(title).Index;

                ListviewCurrentDownloads.Items[index].SubItems[1].Text = "Downloading";
                ListviewCurrentDownloads.Items[index].SubItems[2].Text = "0.0 %";
                ListviewCurrentDownloads.Items[index].SubItems[3].Text = "0 / " + pages;
            }
            else
            {
                Invoke(new Action(() => downloader_PictureDownloadStartedEvent(title, pages)));
            }
        }

        #endregion

        private void showMangasWithoutThisTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedTag = TagListbox.SelectedItem.ToString();
            AddCustomTag("!"+selectedTag);
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            TextboxCustomFilter.Clear();
            FilterByWebsite(WebsiteDropdown.SelectedText);
            ApplyFilter();
            
        }

       

       

    }

    public interface IModelFilter
    {
        bool Filter(object modelObject,string website);
    }

    public interface IListFilter
    {
        IEnumerable Filter(IEnumerable modelObjects);
    }
   
    public class SiteFilter : IModelFilter
    {
        public bool Filter(object modelObject,string website)
        {
            if (((Manga) modelObject).Website == website)
                return true;
            else
                return false;
        }
       
    }
    internal class Manga
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public string Info { get; set; }
        public string[] Tags { get; set; }
        public string ImagePath { get; set; }
        public string GalleryUrl { get; set; }
        public bool LocalImage { get; set; }
        public int Pages { get; set; }
        public string CoverUrl { get; set; }
        public string Website { get; set; }
        public string UniqueId { get; set; }
        public string[] PageLinks { get; set; }
    }

    internal class MasterSorter : Comparer<Manga>
    {
        private readonly OLVColumn _column;
        private readonly SortOrder _sortOrder;

        public MasterSorter(OLVColumn col, SortOrder order)
        {
            _column = col;
            _sortOrder = order;
        }

        public override int Compare(Manga x, Manga y)
        {
            var xValue = _column.GetValue(x) as IComparable;
            var yValue = _column.GetValue(y) as IComparable;

            int result;
            if (xValue == null || yValue == null)
            {
                if (xValue == null && yValue == null)
                    result = 0;

                else if (xValue != null)
                    result = 1;

                else
                    result = -1;
            }
            else
                result = xValue.CompareTo(yValue);

            if (_sortOrder == SortOrder.Ascending)
                return result;

            return 0 - result;
        }
    }

    internal class MangaListDataSource : AbstractVirtualListDataSource, IFilterableDataSource
    {
        private readonly List<Manga> _objects;

        public MangaListDataSource(VirtualObjectListView listview, List<Manga> objectList) : base(listview)
        {
            _objects = objectList;
        }

        

        public override int GetObjectIndex(object model)
        {
            return _objects.IndexOf((Manga) model);
        }

        public override object GetNthObject(int n)
        {
            try
            {
                var m = _objects[n%_objects.Count];
                return m;
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                return null;
            }
            catch (DivideByZeroException divideByZeroException)
            {
                return null;
            }
        }

        public override int GetObjectCount()
        {
            return _objects.Count;
        }

        public override void Sort(OLVColumn column, SortOrder order)
        {
            _objects.Sort(new MasterSorter(column, order));
        }

        public override int SearchText(string value, int first, int last, OLVColumn column)
        {
            //return DefaultSearchText(value, first, last, column, this);
            return 1;
        }
    }
}