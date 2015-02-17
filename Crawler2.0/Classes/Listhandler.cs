using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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




            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(value);
            }
            
        }

        public void WriteMangaList(List<Manga> mangaList, string website)
        {
            try
            {
                var debugCounter = 0;
                var sb = new StringBuilder();
                foreach (var m in mangaList)
                {
                    if(m == null)
                        Debugger.Break();
                    var tagbuilder = new StringBuilder();
                    string tags;
                    if (m.Tags != null)
                    {
                        foreach (var x in m.Tags)
                        {
                            tagbuilder.Append(x + ",");
                        }
                        tags = tagbuilder.ToString().Trim(',');
                    }
                    else
                        tags = "1,2";

                    debugCounter++;
                    //Debugger.Log(1, "Writer", "Current manga count: " + debugCounter+Environment.NewLine);
                    sb.AppendLine(m.Title + "%#%"  + m.GalleryUrl + "%#%" + m.Pages + "%#%" + m.LocalImage +
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
            List<Manga> tempList = new List<Manga>();
            //const string siteName = "Pururin";
            try
            {
                foreach (var siteName in Form1.SupportedSites)
                {
                    
                    if (File.Exists("Data/Lists/" + siteName.ToLower() + ".List"))
                    {
                        using (var streamReader = new StreamReader("Data/Lists/" + siteName.ToLower() + ".List"))
                        {
                            string[] separator = { "%#%" };
                            
                            string text = streamReader.ReadToEnd();
                            string[] lines = text.Split(new []{"!%#%!"}, StringSplitOptions.RemoveEmptyEntries);


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

                                if (m.Website == "Nhentai")
                                {
                                    m.UniqueId = explodedLine[8];
                                    m.PageLinks = explodedLine[9].Split(new []{','},StringSplitOptions.RemoveEmptyEntries).ToArray();
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
                                if(m.UniqueId == string.Empty)
                                    Debugger.Log(1,"reader","title "+m.Title+" has no unique id, problem with json call?"+Environment.NewLine);
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

        public void WriteTagList(Dictionary<string, string> tagDictionary)
        {
            var stringBuilderTagFile = new StringBuilder();


            foreach (var keyValuePair in tagDictionary)
            {
                if (keyValuePair.Value != null)
                {
                    var value = keyValuePair.Value.Replace("\n", " ");


                    stringBuilderTagFile.AppendLine(keyValuePair.Key + "=>" + value);
                }
            }
            File.WriteAllText("Data/Tags/Pururin.Tags", stringBuilderTagFile.ToString());
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

                            var downloadPath = explodedLine[3];
                            //string Pages= ExplodedLine[4];
                            var coverPath = explodedLine[4];
                            var timeTaken = explodedLine[5];


                            if (CompletedMangaLineRead != null)
                                CompletedMangaLineRead(title, date, status, timeTaken);
                        }


                        //add to listviewCompleted
                        //and to CompletedList
                    }
                }
            }
        }

        #region EventHandlers

        public delegate void CompletedMangaLineReadEventHandler(
            string title, string date, string status, string timeTaken);

        public event CompletedMangaLineReadEventHandler CompletedMangaLineRead;

        public delegate void MangaListLineReadEventHandler(Manga m);

        public event MangaListLineReadEventHandler MangaListLineRead;

        public delegate void MangaListReadFinishedEventHandler();

        public event MangaListReadFinishedEventHandler MangaListReadFinished;

        public delegate void MangaListWriteFinishedEventHandler(List<Manga> list);

        public event MangaListWriteFinishedEventHandler MangaListWriteFinished;

        public delegate void FailedMangaLineWriteEventHandler(Exception ex);

        public event FailedMangaLineWriteEventHandler FailedMangaWrite;

        public delegate void TagListLineReadEventHandler(int key, string value);

        public event TagListLineReadEventHandler TagListLineRead;
        //vill helst byta namn på dessa, blir för långa och jobbiga att läsa

        #endregion
    }
}