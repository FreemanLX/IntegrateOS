using System.Diagnostics;
using System;
using System.Linq;


namespace WindowsSetup
{
    public class CMD_Process_Class
    {

        internal static void Process_Powershell(string dism, int e = 0)
        { ///aceasta functie creaza un proces ce apeleaza aplicatia powershell din windows 
            Process cmd = new Process();

            ///cum v am explicat in prezentare fiecare functie din obiectul proces, deci revenim 
            cmd.StartInfo.FileName = "powershell.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(dism);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            if (e == 1)
            {
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }
            return;
        }
        internal static int Process_CMD(string dism, int e = 0)
        {
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.RedirectStandardError = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                string stdError;
                try
                {
                    cmd.Start();
                    cmd.StandardInput.WriteLine(dism);
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.BeginOutputReadLine();
                    stdError = cmd.StandardError.ReadToEnd();
                    if (String.IsNullOrEmpty(stdError))
                    {
                        cmd.WaitForExit();
                        return 0;
                    }
                    else
                    {
                        throw new AccessViolationException();
                    }

                }
                catch (AccessViolationException)
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}
