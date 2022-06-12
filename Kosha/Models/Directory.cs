using System.IO;

namespace FishHoghoghi.Models
{
    public class Directory
    {
        public static bool ExistOrNot(string filePath)
        {
            if (File.Exists(filePath))
                System.IO.Directory.CreateDirectory(filePath);

            return true;
        }
    }
}