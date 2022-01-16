using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Compression;


namespace FishHoghoghi.Extentions
{
    public static class ZipHelper
    {
        public static void CreateZipFile(string startPath, string zipPath)
        {

            ZipFile.CreateFromDirectory(startPath, zipPath);
        }
    }
}