using System;
using System.IO;
using System.Text;

namespace ZarkiaIntegratedSystem_Tax
{
    public class clsSalTax
    {
        public static bool CreateTextFile(string path, string txtFile)
        {
            try
            {
                bool exitFile = File.Exists(path);
                if (exitFile && !frmSalTax.showMessageBoxQuestion("این فایلی با همین نام در این مسیر وجود دارد آیا می خواهید فایل قبلی پاک شود؟", "اخطار"))
                    return false;

                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(txtFile);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
                return true;
            }
            catch { return false; }
        }
    }

    public partial class AghlameHoghohVaDastMozd
    {
        public int CodeMeli { get; set; }
        public int NoePardakht { get; set; }
        public int TedadMahKarkerdVagheee { get; set; }
        public int InMahAkharinMahAst { get; set; }
        public int NoeArz { get; set; }
        public int TarikhTaseereArz { get; set; }
        public int TarikhShoeKar { get; set; }
        public int TarikhPayaneKar { get; set; }
        public int VazeeyateKarmand { get; set; }
        public int VazeeyateMahaleKhedmat { get; set; }
        public int NakhaleseHoghoogh { get; set; }
        public int PardakhteMostamerMoalagh { get; set; }
        public int Maskan { get; set; }
        public int MablagheKasrShodeAzHoghoogh { get; set; }
        public int VasileyeNaghliyeh { get; set; }
    }

    public partial class TaxPersonal
    {
        public int Tabeeyat { get; set; }
        public int NoeEtelaat { get; set; }
        public string CodeMeli { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public int Keshvar { get; set; }
        public string ShenaseKarmand { get; set; }
        public int Madrak { get; set; }
        public string Semat { get; set; }
        public int NoeBimeh { get; set; }
        public string NameBimeh { get; set; }
        public decimal CodePosti { get; set; }
        public string Address { get; set; }
        public int TarikhEstekhdam { get; set; }
        public int NoeEstkdam { get; set; }
        public string MahaleKhedmat { get; set; }
        public int VazeeyateMahaleKhedmat { get; set; }
        public int NoeGharardad { get; set; }
        public int TarikhPayanKar { get; set; }
        public decimal VazeeyateKarmand { get; set; }
        public decimal Mobile { get; set; }
        public string Email { get; set; }
    }
}
