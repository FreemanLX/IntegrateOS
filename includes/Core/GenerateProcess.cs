using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;

namespace IntegrateOS
{
    public class GenerateProcess
    {

        /// <summary>
        /// OBJECT METHOD
        /// </summary>
        public GenerateProcess(){}
        public List<string> output = new List<string>();
        public void BackgroundWorker_Process(string argv)
        {
            int ok = 0;
            BackgroundWorker background = new BackgroundWorker {WorkerSupportsCancellation = true };
            background.DoWork += (sender, args) =>
            {
                if (background.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }

                Process working = Process.Start(new ProcessStartInfo("cmd.exe")
                {
                    Arguments = " /K " + argv + " &exit",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    
                });
                if(working != null)
                {
                    
                    working.OutputDataReceived += (s, a) =>
                    {

                        Save_data(a.Data + "\r\n");   
                        if(a.Data == null)
                        {
                            ok = 1;
                            background.CancelAsync();
                            return;
                        }
                    };
                    working.ErrorDataReceived += (s, a) =>
                    {

                        Save_data(a.Data + "\r\n");
                        if (a.Data == null)
                        {
                            ok = 1;
                            background.CancelAsync();
                            return;
                        }
                    };
                    working.BeginOutputReadLine();
                    working.BeginErrorReadLine();
                }
                if(ok == 1)
                {
                    return;
                }
            };
            background.RunWorkerAsync();
            if(ok == 1)
            {
                background.CancelAsync();
            }
        }
        protected void Save_data(string s) => output.Add(s);

        public List<string> Get => output;


        /// <summary>
        /// Metoda statica de a apela procesul, fara sa mai folosim un obiect
        /// </summary>

        public static void Static_BackgroundWorker_Process(string dism, string progr)
        {
            BackgroundWorker background = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            background.DoWork += (sender, args) =>
            {
                if (background.CancellationPending)
                {
                    args.Cancel = true;
                    return;
                }

                Process working = Process.Start(new ProcessStartInfo(progr)
                {
                    Arguments = " /K " + dism + " &exit",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                });     
             };
            background.RunWorkerAsync();
        }

        public void Dispose(){}
    }
}
