using MetroFramework;
using MetroFramework.Components;
using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;


namespace IntegrateOS
{
    public sealed class DismProgress : IDisposable
    {

        private readonly DismProgressCallback _callback;
        private readonly EventWaitHandle _eventHandle;
        internal DismProgress(DismProgressCallback callback, object userData)
        {
            _callback = callback;
            UserData = userData;
            _eventHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        public bool Cancel
        {
            get;
            set;
        }
        public int Current
        {
            get;
            private set;
        }

        public int Total
        {
            get;
            private set;
        }
        public object UserData
        {
            get;
            private set;
        }

        internal SafeWaitHandle EventHandle => _eventHandle.SafeWaitHandle;
        public void Dispose()
        {
            _eventHandle?.Dispose();
        }
    }


    public delegate void DismProgressCallback(DismProgress progress);
    public static class DISMAPI
    {
        
        internal delegate void DismProgressCallback(UInt32 current, UInt32 total, IntPtr userData);
        public enum DismLogLevel
        {
            LogErrors = 0,
            LogErrorsWarnings,
            LogErrorsWarningsInfo,
        }

        [DllImport("dismapi.dll")]
        public static extern int DismGetPackages(uint Session, out IntPtr PackageBufPtr, out uint PackageCount);

        [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Error)]
        public static extern uint DismInitialize(DismLogLevel logLevel, string logFilePath, string scratchDirectory);

        [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Error)]
        public static extern uint DismShutdown();

        public static bool DismInitialize()
        {
            uint t = DismInitialize(DismLogLevel.LogErrors, null, null);
            
            if(t != ERROR_SUCCESS)
            {
                MessageBox.Show("Error initialze, code " + t.ToString(), "Error");
                return false;
            }
            return true;
        }

        public static void Shutdown()
        {
            DismShutdown();
        }


        public const uint DISM_MOUNT_READONLY = 0x00000001;
        public const uint DISM_MOUNT_READWRITE = 0x00000000;

        public struct DismMountMode
        {
            public static uint ReadWrite = DISM_MOUNT_READWRITE;
            public static uint ReadOnly = DISM_MOUNT_READONLY;
        }

        public const uint DISMAPI_E_DISMAPI_NOT_INITIALIZED = 0xC0040001;

        public enum DismImageIdentifier
        {
            ImageIndex = 0,
            ImageName,
        }


        [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Error)]
        private static extern uint DismMountImage(string imageFilePath, string mountPath, UInt32 imageIndex, string imageName, DismImageIdentifier imageIdentifier, UInt32 flags, SafeWaitHandle cancelEvent, DismProgressCallback progress, IntPtr userData);


        [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Error)]
        private static extern int DismUnmountImage(string mountPath, UInt32 flags, SafeWaitHandle cancelEvent, DismProgressCallback progress, IntPtr userData);


        internal const int ERROR_SUCCESS = 0x00000000;

        public const uint DISM_DISCARD_IMAGE = 0x00000001;
        public const uint DISM_COMMIT_IMAGE = 0x00000000;

        public static async Task<bool> DismUnmountImage(string mountPath, bool save)
        {
                DismProgress progress = new DismProgress(null, null);
                uint saved = (save == false) ? DISM_DISCARD_IMAGE : DISM_COMMIT_IMAGE;
                int t = 0;
                await Task.Run(() =>
                {
                    DismInitialize();
                    t = DismUnmountImage(mountPath, saved, progress.EventHandle, null, IntPtr.Zero);
                    Shutdown();
                });
            if (t == ERROR_SUCCESS) return true;

            MessageBox.Show("Error unmounting. Code: " + t);
            return false;
        }

        public async static Task<bool> DismMountImage(string imageFilePath, string mountPath, UInt32 imageIndex, bool write)
        {
            uint result_uint = DISMAPI_E_OPEN_HANDLES_UNABLE_TO_MOUNT_IMAGE_PATH;
            await Task.Run(() =>
            {
                DismInitialize();
                DismProgress progress = new DismProgress(null, null);
                uint write_n = 0;
                if (write == true)
                    write_n = DismMountMode.ReadWrite;
                else
                    write_n = DismMountMode.ReadOnly;

                
                result_uint = DismMountImage(imageFilePath, mountPath, imageIndex, null, DismImageIdentifier.ImageIndex, write_n, progress.EventHandle, null, IntPtr.Zero);
            });

            if (result_uint == 134246400)
            {
                MessageBox.Show("Warning: Not enough memory resources are available to complete this operation. Code [0x8007000e]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Shutdown();
                return true;
            }
            if (result_uint == ERROR_SUCCESS || result_uint == 0)
            {
                Shutdown();
                return true;
            }
            Shutdown();
            return false;
        }

        public const uint DISMAPI_E_OPEN_HANDLES_UNABLE_TO_MOUNT_IMAGE_PATH = 3221487627;
    }


    public class Wow64Interop
    {
        const string Kernel32dll = "Kernel32.Dll";

        [DllImport(Kernel32dll, EntryPoint = "Wow64DisableWow64FsRedirection")]
        public static extern bool DisableWow64FSRedirection(ref IntPtr ptr);

        [DllImport(Kernel32dll, EntryPoint = "Wow64RevertWow64FsRedirection")]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);
    }
    public static class Generate_Colors
    {
        public static System.Drawing.Color Generate(int color)
        {
            switch (color)
            {
                case 1:
                    return MetroColors.Blue;
                case 2:
                    return MetroColors.Brown;
                case 3:
                    return MetroColors.Green;
                case 4:
                    return MetroColors.Lime;
                case 5:
                    return MetroColors.Magenta;
                case 6:
                    return MetroColors.Orange;
                case 7:
                    return MetroColors.Pink;
                case 8:
                    return MetroColors.Purple;
                case 9:
                    return MetroColors.Red;
                case 10:
                    return MetroColors.Teal;
                case 11:
                    return MetroColors.Yellow;
                default:
                    return MetroColors.Blue;
            }
        }

        public static MetroColorStyle Generate_Metro(int color)
        {
            switch (color)
            {
                case 1:
                    return MetroColorStyle.Blue;
                case 2:
                    return MetroColorStyle.Brown;
                case 3:
                    return MetroColorStyle.Green;
                case 4:
                    return MetroColorStyle.Lime;
                case 5:
                    return MetroColorStyle.Magenta;
                case 6:
                    return MetroColorStyle.Orange;
                case 7:
                    return MetroColorStyle.Pink;
                case 8:
                    return MetroColorStyle.Purple;
                case 9:
                    return MetroColorStyle.Red;
                case 10:
                    return MetroColorStyle.Teal;
                case 11:
                    return MetroColorStyle.Yellow;
                default:
                    return MetroColorStyle.Blue;
            }
        }


        public static string Generate_String(int color)
        {
            switch (color)
            {
                case 1:
                    return "Blue";
                case 2:
                    return "Brown";
                case 3:
                    return "Green";
                case 4:
                    return "Lime";
                case 5:
                    return "Magenta";
                case 6:
                    return "Orange";
                case 7:
                    return "Pink";
                case 8:
                    return "Purple";
                case 9:
                    return "Red";
                case 10:
                    return "Teal";
                case 11:
                    return "Yellow";
                default:
                    return "Blue";
            }
        }

        public static MetroThemeStyle Generate_MetroTheme(int color)
        {
            switch (color)
            {
                case 1:
                    return MetroThemeStyle.Light;
                case 2:
                    return MetroThemeStyle.Dark;
                default:
                    return MetroThemeStyle.Default;
            }
        }


    }

  

    public class CMD_Process_Class
    {

        /// <summary>
        /// OBJECT METHOD
        /// </summary>
        public CMD_Process_Class(){}
        public List<string> process_t = new List<string>();
        public void Process_CMD(string argv)
        {
            int ok = 0;
            System.ComponentModel.BackgroundWorker background = new System.ComponentModel.BackgroundWorker
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
        protected void Save_data(string s)
        {
            process_t.Add(s);
        }

        public List<string> Get()
        {
            return process_t;
        }


        /// <summary>
        /// STATIC METHOD
        /// </summary>

        public static void Process_CMD(string dism, string progr)
        {
            System.ComponentModel.BackgroundWorker background = new System.ComponentModel.BackgroundWorker
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
    class IntegrateOS_var
    {
        public static int dark;
        public static string color_string = "Blue";
        public static int color_t = 1;
        public static MetroFramework.MetroColorStyle color;
        public static MetroFramework.MetroThemeStyle theme;
        public static int program_mode = 3;
    }
    class Tools_location
    {
        public static class Conversion
        {
            public static string convert_path, to_convert_path;
            public static int index, conversion_code;
            public static string convert_path_type, to_convert_part_type;
            public static float swm_partition_type = 0;
        }

        public static class Mount
        {
            public static string path_to_mount;
            public static string path_to_be_mounted;
        }
    }

    public static class Themes
    {
        public static MetroStyleManager Generate(MetroColorStyle mcs, MetroThemeStyle mts)
        {
            return new MetroStyleManager {Theme = mts, Style = mcs};
        }
    }
}
