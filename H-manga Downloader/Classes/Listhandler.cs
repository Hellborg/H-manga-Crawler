using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Crawler2._0.Forms;

namespace Crawler2._0.Classes
{
    internal class Listhandler
    {
        //flytta alla metoder som hanterar .List filerna hit.
        private readonly string[] _separators = {"%#%"};
        public List<Manga> CompletedList;

        public void WriteToFile(string filePath, string value)
        {
            //if (!File.Exists(filePath))
            //File.Create(filePath);


            using (var sw = File.AppendText(filePath))
            {
                sw.WriteLine(value);
            }
        }

        public void WriteMangaList(List<Manga> mangaList, string website)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (var m in mangaList)
                {
                    if (m == null)
                        Debugger.Break();
                    var tagbuilder = new StringBuilder();
                    string tags;
                    if (m != null && m.Tags != null)
                    {
                        foreach (var x in m.Tags)
                        {
                            tagbuilder.Append(x + ",");
                        }
                        tags = tagbuilder.ToString().Trim(',');
                    }
                    else
                        tags = "1,2";

                    sb.AppendLine(m.Title + "%#%" + m.GalleryUrl + "%#%" + m.Pages + "%#%" + m.LocalImage +
                                  "%#%" +
                                  "http://" + m.ImagePath + "%#%" + tags + "%#%" + m.CoverUrl + "%#%" + m.Website +
                                  "%#%" + m.UniqueId);
                }
                if (!Directory.Exists("Data/Lists"))
                    Directory.CreateDirectory("Data/Lists");
                File.WriteAllText("Data/Lists/" + website + ".List", sb.ToString());
            }
            catch (IOException ioEx)
            {
                if (FailedMangaWrite != null)
                    FailedMangaWrite(ioEx);
            }
            //Finished writing event, update listview
        }

        public static List<Manga> ReadMangaList()
        {
            var tempList = new List<Manga>();
            //const string siteName = "Pururin";

            //Implement Check if show duplicates is enabled, if so only show the one with the most pages

            try
            {
                foreach (var siteName in Form1.SupportedSites)
                {
                    if (File.Exists("Data/Lists/" + siteName.ToLower() + ".List"))
                    {
                        using (var streamReader = new StreamReader("Data/Lists/" + siteName.ToLower() + ".List"))
                        {
                            string[] separator = {"%#%"};

                            var text = streamReader.ReadToEnd();
                            var lines = text.Split(new[] {"!%#%!"}, StringSplitOptions.RemoveEmptyEntries);


                            foreach (var line in lines)
                            {
                                var m = new Manga();
                                var explodedLine = line.Split(separator, StringSplitOptions.None);
                                m.Title = explodedLine[0];
                                m.GalleryUrl = explodedLine[1];
                                m.Pages = Convert.ToInt32(explodedLine[2]);
                                m.CoverUrl = explodedLine[6];
                                //if (m.pages > maxPages)
                                //  maxPages = m.pages;
                                m.Website = explodedLine[7];
                                m.Date = explodedLine[8];
                                if (m.Website == "Nhentai")
                                {
                                    m.UniqueId = explodedLine[9];
                                    m.PageLinks =
                                        explodedLine[10].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();


                                    
                                }


                                var filename = "Data/Pictures/Covers/" + Path.GetFileName(m.ImagePath);
                                //string localFile = 

                                if (File.Exists(filename))
                                {
                                    m.LocalImage = true;
                                    m.ImagePath = filename;
                                }
                                else
                                {
                                    m.LocalImage = Convert.ToBoolean(explodedLine[3]);
                                    m.ImagePath = explodedLine[4];
                                }
                                if (m.UniqueId == string.Empty)
                                    Debugger.Log(1, "reader",
                                        "title " + m.Title + " has no unique id, problem with json call?" +
                                        Environment.NewLine);
                                //2ebugger.Log(1,"",m.Title+Environment.NewLine);
                                var tagString = explodedLine[5].Split(',');
                                //var tagInts = tagString.Select(int.Parse).ToArray();

                                m.Tags = tagString.ToArray();

                                //if (MangaListLineRead != null)
                                //MangaListLineRead(m);
                                tempList.Add(m);
                                //MangaList.Add(m);
                                //AddToListview(m);
                            }
                        }
                    }
                }

                //if (MangaListReadFinished != null)
                //MangaListReadFinished();
            }
            catch (IndexOutOfRangeException iorException)
            {
                Debugger.Log(1, "", "inner exeption" + iorException.StackTrace);
            }
            return tempList;
        }

        public Dictionary<int, string> ReadTagList()
        {
            var tempDictionary = new Dictionary<int, string>();
            const string siteName = "Pururin";
            if (File.Exists("Data/Tags/" + siteName + ".Tags"))
            {
                using (var streamReaderTags = new StreamReader("Data/Tags/" + siteName + ".Tags"))
                {
                    string[] separator = {"=>"};
                    string line;
                    while ((line = streamReaderTags.ReadLine()) != null)
                    {
                        try
                        {
                            var explodedLine = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                            //Debugger.Log(1,"reader",Line+Environment.NewLine);
                            int tagKey;
                            int.TryParse(explodedLine[0], out tagKey);

                            var tagValue = explodedLine[1];

                            tempDictionary.Add(tagKey, tagValue);
                            //if (TagListLineRead != null)
                            //TagListLineRead(tagKey, tagValue);
                            //Fire eventTagDictionary.Add(TagKey, TagValue);
                        }
                        catch (Exception ex)
                        {
                            Debugger.Log(1, "Reader", ex.InnerException.ToString());
                        }
                    }
                }
                return tempDictionary;
            }
            return null;
        }

        public void ReadCompletedDownloads()
        {
            CompletedList = new List<Manga>();
            if (File.Exists("Data/Lists/CompletedDownloads.List"))
            {
                using (var streamReaderCompleted = new StreamReader("Data/Lists/CompletedDownloads.List"))
                {
                    string line;
                    while ((line = streamReaderCompleted.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            var explodedLine = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

                            var title = explodedLine[0];
                            var status = explodedLine[1];
                            var date = explodedLine[2];

                            
                            var timeTaken = explodedLine[5];


                            if (CompletedMangaLineRead != null)
                                CompletedMangaLineRead(title, date, status, timeTaken);
                        }
                    }
                }
            }
        }

        #region EventHandlers

        public delegate void CompletedMangaLineReadEventHandler(
            string title, string date, string status, string timeTaken);

        public event CompletedMangaLineReadEventHandler CompletedMangaLineRead;

        public delegate void MangaListLineReadEventHandler(Manga m);

        public delegate void MangaListReadFinishedEventHandler();

        public delegate void MangaListWriteFinishedEventHandler(List<Manga> list);


        public delegate void FailedMangaLineWriteEventHandler(Exception ex);

        public event FailedMangaLineWriteEventHandler FailedMangaWrite;

        public delegate void TagListLineReadEventHandler(int key, string value);

        //vill helst byta namn på dessa, blir för långa och jobbiga att läsa

        #endregion
    }
}