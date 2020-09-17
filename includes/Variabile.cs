using System.IO;

namespace WindowsSetup
{
    class Variabile
    {

        public void Clear()
        {
            try
            {
                if (File.Exists(@"1.txt"))
                {
                    File.Delete(@"1.txt");
                }
                if (File.Exists(@"2.txt"))
                {
                    File.Delete(@"2.txt");
                }
                if (File.Exists(@"disk.txt"))
                {
                    File.Delete(@"disk.txt");
                }
                if (File.Exists(@"done.dll"))
                {
                    File.Delete(@"done.dll");
                }
                File.Delete("drive.txt");
                File.Delete("edit.dll");
                File.Delete("error.dll");
                File.Delete("fix.txt");
                File.Delete("format1.txt");
                File.Delete("hdd.dll");
                if (File.Exists("hdd1.dll"))
                {
                    File.Delete("hdd1.dll");
                }
                File.Delete("location.txt");
                File.Delete("temp.dll");
                File.Delete("upv.dll");
                File.Delete("verify.dll");
                File.Delete("wimdone.dll");
                File.Delete("work.dll");
                File.Delete("index.dll");
                File.Delete("indice.dll");
                File.Delete("fedition.txt");
                File.Delete("edition.txt");
            }
            catch { }

        }
        public static string var;
        public static string format;
        public static string fix;
        public static string locatie;
        public static int space_gb_ver = 0;
        public static string version;
    }
}
