
    ///standard C# classes
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    ///integrateos classes
    using static IntegrateOS.Algorithms.Dism_Methods;
    using static IntegrateOS.NativeMethods;
    using static IntegrateOS.NativeStructures;
    using static IntegrateOS.NativeConstants;


namespace IntegrateOS
{
    public static class Algorithms
    {

        /// <summary>
        /// A function which converts from a pointer to a structure.
        /// </summary>
        /// <typeparam name="T">The type of struct</typeparam>
        /// <param name="ptr">The pointer</param>
        /// <returns>A structure</returns>
        public static T ToStructure<T>(this IntPtr ptr) => (T)Marshal.PtrToStructure(ptr, typeof(T));

        /// <summary>
        /// A function which converts a pointer returned from native methods in list.
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <typeparam name="TStruct">A class struct</typeparam>
        /// <param name="ptr">Pointer</param>
        /// <param name="count">How many i want to transfer</param>
        /// <param name="constructor">A function which represents the T's constructor</param>
        /// <param name="list">The list, created by this function, returned as a parameter</param>
        /// <returns>Returns true if function completes successfully, otherwise false</returns>
        public static bool ToList<T, TStruct>(this IntPtr ptr, int count, Func<TStruct, T> constructor, out List<T> list) where T : class
        {

            list = new List<T>(count);
            if (!(ptr != IntPtr.Zero && count > 0))
                return false;
            int structSize = Marshal.SizeOf(typeof(TStruct));
            long startPtr = ptr.ToInt64();
            for (int index = 0; index < count; index++)
                   list.Add(constructor(new IntPtr(startPtr + index * structSize).ToStructure<TStruct>()));

            return true;
        }


        /// <summary>
        /// The DISM class
        /// </summary>
        public class Dism_Methods
        {

            /// <summary>
            /// Initialize a new session of DISM
            /// </summary>
            /// <returns>True if initizialiezed otherwise false</returns>
            public static bool DismInitialize() => NativeMethods.DismInitialize(DismLogLevel.LogErrors, null, null) != ERROR_SUCCESS;

            /// <summary>
            /// Close the opened session of DISM
            /// </summary>
            public static void Shutdown() => DismShutdown();

            /// <summary>
            /// 
            /// </summary>
            /// <param name="mountPath"></param>
            /// <param name="save"></param>
            /// <returns></returns>
            public static bool DismUnmountImage(string mountPath, bool save)
            {
                DismProgress progress = new DismProgress(null, null);
                DismInitialize();
                int error = NativeMethods.DismUnmountImage(mountPath, (save == false) ? DISM_DISCARD_IMAGE : DISM_COMMIT_IMAGE, progress.EventHandle, null, IntPtr.Zero);
                Shutdown();
                return error == ERROR_SUCCESS;
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="imageFilePath"></param>
            /// <param name="mountPath"></param>
            /// <param name="imageIndex"></param>
            /// <param name="write"></param>
            /// <returns></returns>
            public static bool DismMountImage(string imageFilePath, string mountPath, uint imageIndex, bool write)
            {
                uint error = 0;
                DismInitialize();
                DismProgress progress = new DismProgress(null, null);
                error = NativeMethods.DismMountImage(imageFilePath, mountPath, imageIndex, null, DismImageIdentifier.ImageIndex,
                        (write == true) ? DismMountMode.ReadWrite : DismMountMode.ReadOnly, 
                        progress.EventHandle, null, IntPtr.Zero);
                Shutdown();
                return error == ERROR_SUCCESS;
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="path"></param>
            /// <param name="wimFileAccess"></param>
            /// <param name="creationDisposition"></param>
            /// <param name="fileOptions"></param>
            /// <param name="compressionType"></param>
            /// <returns></returns>
            public static bool CreateFile(string path, WimFileAccess wimFileAccess, WimCreationDisposition creationDisposition,
            WimCreateFileOptions fileOptions, WimCompressionType compressionType, out WimHandle wimHandle)
            {       
                wimHandle = WIMCreateFile(path, (uint)wimFileAccess, (uint)creationDisposition, (uint)fileOptions, (uint)compressionType, out _);
                return !(wimHandle == null || wimHandle.IsInvalid);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="wimHandle"></param>
            /// <param name="index"></param>
            /// <returns></returns>
            public static bool LoadImage(WimHandle wimHandle, int index, out WimHandle imageHandle)
            {
                if (wimHandle == null) throw new ArgumentNullException(nameof(wimHandle));
                if (index < 1 || index > WIMGetImageCount(wimHandle)) throw new IndexOutOfRangeException($"There is no image at index {index}.");

                imageHandle = WIMLoadImage(wimHandle, (uint)index);
                return !(imageHandle == null || imageHandle.IsInvalid);
            }

            /// <summary>
            /// 
            /// </summary>
            public sealed class DismImageInfo
            {
                private readonly DismImageInfo_ _imageInfo;
                internal DismImageInfo(DismImageInfo_ imageInfo)
                {
                    _imageInfo = imageInfo;
                    ProductVersion = new Version((int)imageInfo.MajorVersion, (int)imageInfo.MinorVersion, (int)imageInfo.Build, (int)imageInfo.SpBuild);
                }

                public ProcessorArchitecture Architecture => _imageInfo.Architecture;
                public DismImageBootable Bootable => _imageInfo.Bootable;
                public string ImageDescription => _imageInfo.ImageDescription;
                public string ImageName => _imageInfo.ImageName;
                public double ImageSize => _imageInfo.ImageSize / (1024 * 1024);
                public Version ProductVersion { get; }
            }

            
            public class GetImageInfo
            {
                public string wimpath;
                public GetImageInfo(string wimpath) => this.wimpath = wimpath;

                public bool Get(out List<DismImageInfo> path)
                {

                    bool ok = false;
                    path = null;
                    try
                    {
                        DismInitialize();
                        DismGetImageInfo(wimpath, out IntPtr imageInfoPtr, out uint imageInfoCount);
                        if (imageInfoPtr.ToList((int)imageInfoCount, (DismImageInfo_ i) => 
                        new DismImageInfo(i), out List<DismImageInfo> list_path) == true)
                        {
                            path = list_path;
                            ok = true;
                        }
                        DismDelete(imageInfoPtr);
                        Shutdown();
                    }
                    catch { }

                    return ok;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="imageHandle"></param>
            /// <param name="wimHandle"></param>
            /// <param name="options"></param>
            public static void ExportImage(WimHandle imageHandle, WimHandle wimHandle, WimExportImageOptions options)
            {
                if (imageHandle == null) throw new ArgumentNullException(nameof(imageHandle));
                if (wimHandle == null) throw new ArgumentNullException(nameof(wimHandle));
                if (!WIMExportImage(imageHandle, wimHandle, (uint)options)) throw new Win32Exception();   
            }

            
            public static void Split(string source_path, string convert_to_path, long partSize)
            {

                if(!CreateFile(source_path, WimFileAccess.Write | WimFileAccess.Read | WimFileAccess.Mount,
                                WimCreationDisposition.OpenExisting, 0, 0, out WimHandle wimHandle)) throw new Win32Exception();
                if (!Directory.Exists(Path.GetDirectoryName(convert_to_path)))
                {
                    throw new DirectoryNotFoundException($"Could not find part of the path '{Path.GetDirectoryName(convert_to_path)}'");
                }
                partSize = 0;
                if (!WIMSplitFile(wimHandle, convert_to_path, ref partSize, 0))
                {
                    if (Marshal.GetLastWin32Error() != 0x000000EA) ///error more data
                    {
                        throw new Win32Exception();
                    }
                }

            }
            public static void ConvertImage(string source_path, string convert_to_path, int index, WimCompressionType wimCompressionType = WimCompressionType.None)
            {
                try
                {
                    if (!CreateFile(convert_to_path, WimFileAccess.Write,
                                WimCreationDisposition.CreateAlways, 0, wimCompressionType, out WimHandle wimHandle)) throw new Win32Exception();

                    if (wimHandle == null || wimHandle.IsInvalid) throw new Win32Exception();
                    using (WimHandle wimhandle_copy = wimHandle)
                    {
                        if (CreateFile(source_path, WimFileAccess.Read | WimFileAccess.Mount, WimCreationDisposition.OpenExisting,
                            0, 0, out WimHandle handle_source_path) == true)
                        {

                            WIMSetTemporaryPath(handle_source_path, Path.GetTempPath());
                            if (LoadImage(handle_source_path, index, out WimHandle imageHandle) == true)
                            {
                                using (WimHandle imagehande_copy = imageHandle)
                                {
                                    WIMSetTemporaryPath(wimHandle, Path.GetTempPath());
                                    ExportImage(imagehande_copy, wimhandle_copy, WimExportImageOptions.None);
                                }
                            }
                        }
                        else throw new Win32Exception();
                    }
                }
                catch (Win32Exception w32)
                {
                    MessageBox.Show(w32.Message + ".  Error code: " + w32.NativeErrorCode);
                }

            }


            public static void Apply_image(string wimpath, string extractpath, int index)
            {
                if (CreateFile(wimpath, WimFileAccess.Read | WimFileAccess.Write
                                    | WimFileAccess.Mount, WimCreationDisposition.OpenExisting, 0, 0, out WimHandle wimHandle) == true
                                    && WIMSetTemporaryPath(wimHandle, Path.GetTempPath()) && LoadImage(wimHandle, index, out WimHandle imageHandle) == true)
                {
                            WIMApplyImage(imageHandle, extractpath,
                                         (uint)(WimApplyImageOptions.DisableDirectoryAcl |
                                         WimApplyImageOptions.DisableFileAcl |
                                         WimApplyImageOptions.Index));
                }
            }

        }

        public class WimFileSearch
        {
            List<string> files;
            public WimFileSearch() => files = new List<string>();
            public List<string> SearchingByExtension(string path, List<string> extensions)
            {
                string[] allfiles = Directory.GetFiles(path, "*.*").Where(f => extensions.IndexOf(Path.GetExtension(f)) >= 0).ToArray();
                foreach (string file_path in allfiles)
                {
                    try
                    {
                        GetImageInfo getImageInfo = new GetImageInfo(file_path);
                        if (getImageInfo.Get(out List<DismImageInfo> dismImageInfos) == true && dismImageInfos.Count > 0)
                        {
                            int count = 0;
                            foreach (DismImageInfo dismImageInfo in dismImageInfos)
                            {
                                if (dismImageInfo.Bootable == DismImageBootable.ImageBootableYes) count++;
                            }
                            if(count > 0) files.Add(file_path);
                              
                        }
                        
                    }
                    catch
                    {

                    }
                }
                string[] directories = Directory.GetDirectories(path);
                foreach(string directory in directories)
                {
                    try
                    {
                        SearchingByExtension(directory, extensions);
                    }
                    catch (Exception)
                    {
                       // MessageBox.Show(e.Message);
                    }
                }
                return files;
            }
        }

        public class BackgroundThread
        {
            Thread thread;
            public BackgroundThread(Thread thread) => this.thread = thread;

            public void Start()
            {
                thread.IsBackground = true;
                thread.Start();
                while (thread.IsAlive == true) Application.DoEvents();
            }

        }

    }
}
