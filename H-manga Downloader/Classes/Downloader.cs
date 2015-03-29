using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Crawler2._0.Properties;

namespace Crawler2._0.Classes
{
    internal class Downloader
    {
        private readonly bool _createSubfolder;
        private readonly Settings _settings = new Settings();

        public Downloader()
        {
            _createSubfolder = _settings.CreateSubfolders;
            //
            
            // ReSharper disable once ObjectCreationAsStatement
        }

        internal bool Download(string url, string downloadPath, string folderName, string title, int pages,
            int queueCount)
        {
            var name = Path.GetFileName(url);
            var sanitizedPath = CreateSanitizedFolderName(downloadPath, folderName);

            if (!Directory.Exists(sanitizedPath))
                Directory.CreateDirectory(sanitizedPath);
            var localFilename = CreateSanitizedFileName(sanitizedPath, name);
            if (!File.Exists(localFilename))
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(url, localFilename);
                        Loghandler.LogToFile("Downloaded " + url + " To " + localFilename, 2);
                        Debugger.Log(1, "Download", "Finished : " + url + Environment.NewLine);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Loghandler.LogToFile(ex.Message + " - " + url, 3);
                        return false;
                    }
                }
            }
            return true;
        }

        private string CreateSanitizedFolderName(string rootpath, string foldername)
        {
            //use regex and remove [] anmd whats between
            var reg = new Regex(@"\[(.*?)\]|\((.*?)\)");
            foldername = reg.Replace(foldername, "");
            foldername = foldername.Trim();

            if (_createSubfolder)
            {
                var path = rootpath +
                           Path.GetInvalidFileNameChars()
                               .Aggregate(foldername, (current, c) => current.Replace(c.ToString(), string.Empty));

                return path;
            }
            return rootpath;
            
        }

        private static string CreateSanitizedFileName(string filepath, string origFileName)
        {
            try
            {
                new FileInfo(filepath + origFileName);
                return filepath + "//" + origFileName;
            }
            catch (PathTooLongException)
            {
                var ext = Path.GetExtension(origFileName);
                var reg = new Regex("([0-9]*)" + ext);
                return filepath + "//" + reg.Match(origFileName).Groups[0].Value;
            }
        }

    }

    
}