using FishHoghoghi.Utilities;
using Microsoft.Office.Interop.Word;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Document = Microsoft.Office.Interop.Word.Document;
using Range = Microsoft.Office.Interop.Word.Range;

namespace FishHoghoghi.Models
{
    public static class Utility
    {
        public static void ReplaceBookMarkText(Document doc, string BookmarkName, string text)
        {
            if (doc.Bookmarks.Exists(BookmarkName))
            {
                object name = BookmarkName;

                Range range = doc.Bookmarks.get_Item(ref name).Range;

                range.Text = text;

                range.Bold = 0;

                range.Font.Bold = 0;

                //range.Font.Name = "Vazir Light FD";

                range.Font.Name = CommonHelper.GetConfigurationSetting("Font");

                object newRange = range;

                doc.Bookmarks.Add(BookmarkName, ref newRange);
            }
        }

        public static byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte[] ImageData = new byte[fs.Length];

            fs.Read(ImageData, 0, Convert.ToInt32(fs.Length));

            fs.Close();

            return ImageData;
        }

        public static string MoneyFormater(string money)
        {
            if (money.Contains("."))
            {
                money = money.Split('.')[0];

                return decimal.Parse(money).ToString("0,0", CultureInfo.InvariantCulture);
            }
            else
            {
                money = money.Split('/')[0];

                return decimal.Parse(money).ToString("0,0", CultureInfo.InvariantCulture);
            }
        }

        public static Document GetDocument(string filename, Application wordApp)
        {
            object fileName = filename;

            object confirmConversions = Type.Missing;

            object readOnly = Type.Missing;

            object addToRecentFiles = Type.Missing;

            object passwordDoc = Type.Missing;

            object passwordTemplate = Type.Missing;

            object revert = Type.Missing;

            object writepwdoc = Type.Missing;

            object writepwTemplate = Type.Missing;

            object format = Type.Missing;

            object encoding = Type.Missing;

            object visible = Type.Missing;

            object openRepair = Type.Missing;

            object docDirection = Type.Missing;

            object notEncoding = Type.Missing;

            object xmlTransform = Type.Missing;

            return wordApp.Documents.Open(

ref fileName, ref confirmConversions, ref readOnly, ref addToRecentFiles,

ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc,

ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair,

ref docDirection, ref notEncoding, ref xmlTransform);
        }
    }
}