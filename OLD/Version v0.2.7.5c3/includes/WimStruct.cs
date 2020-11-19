using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;


namespace ManagedWimLib
{
    #region WimStruct
    [SuppressMessage("ReSharper", "RedundantExplicitArraySize")]
    public class Wim : IDisposable
    { 

        public const int NoImage = 0, AllImages = -1, DefaultThreads = 0;
        private IntPtr _ptr;
        private ManagedProgressCallback _managedCallback;
        public static bool Loaded => NativeMethods.Loaded;
        public static string ErrorFile => NativeMethods.ErrorFile;
        public static string PathSeparator => NativeMethods.UseUtf16 ? @"\" : @"/";
        public static string RootPath => NativeMethods.UseUtf16 ? @"\" : @"/";

        private Wim(IntPtr ptr)
        {
            if (!NativeMethods.Loaded) throw new InvalidOperationException(NativeMethods.MsgInitFirstError);
            _ptr = ptr;
        }


        #region Disposable Pattern
        ~Wim()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_ptr == IntPtr.Zero) return;

            RegisterCallback(null, null);
            NativeMethods.Free(_ptr);
            _ptr = IntPtr.Zero;
        }
        #endregion

        #region Global - (Static) GlobalInit, GlobalCleanup
        public static void GlobalInit(string libPath) => GlobalInit(libPath, InitFlags.DEFAULT);
        public static void GlobalInit(string libPath, InitFlags initFlags)
        {
            if (NativeMethods.Loaded)
                throw new InvalidOperationException(NativeMethods.MsgAlreadyInit);
            {
                NativeMethods.UseUtf16 = true;
                NativeMethods.LongBitType = NativeMethods.LongBits.Long32;

                if (libPath == null)
                    throw new ArgumentNullException(nameof(libPath));

                libPath = Path.GetFullPath(libPath);
                if (!File.Exists(libPath))
                    throw new ArgumentException("Specified .dll file does not exist");

                string libDir = Path.GetDirectoryName(libPath);
                if (libDir != null && !libDir.Equals(AppDomain.CurrentDomain.BaseDirectory))
                    NativeMethods.Win32.SetDllDirectory(libDir);

                NativeMethods.hModule = NativeMethods.Win32.LoadLibrary(libPath);
                if (NativeMethods.hModule == IntPtr.Zero)
                    throw new ArgumentException($"Unable to load [{libPath}]", new Win32Exception());

                NativeMethods.Win32.SetDllDirectory(null);
                if (NativeMethods.Win32.GetProcAddress(NativeMethods.hModule, nameof(NativeMethods.Utf16.wimlib_open_wim)) == IntPtr.Zero)
                {
                    GlobalCleanup();
                    throw new ArgumentException($"[{libPath}] is not a valid wimlib-15.dll");
                }
            }


            try
            {
                NativeMethods.LoadFunctions();
                NativeMethods.ErrorFile = Path.GetTempFileName();
                WimLibException.CheckWimLibError(NativeMethods.SetErrorFile(NativeMethods.ErrorFile));
                SetPrintErrors(true);
                ErrorCode ret = NativeMethods.GlobalInit(initFlags);
                WimLibException.CheckWimLibError(ret);
            }
            catch (Exception)
            {
                GlobalCleanup(); throw;
            }
        }

        public static void GlobalCleanup()
        {
            if (NativeMethods.Loaded)
            {
                NativeMethods.GlobalCleanup();
                NativeMethods.ResetFunctions();
                int ret = NativeMethods.Win32.FreeLibrary(NativeMethods.hModule);
                Debug.Assert(ret != 0);
                NativeMethods.hModule = IntPtr.Zero;
                if (File.Exists(ErrorFile)) File.Delete(ErrorFile);
            }
            else
            {
                throw new InvalidOperationException(NativeMethods.MsgInitFirstError);
            }
        }
        #endregion

        #region Error - (Static) GetErrorString, GetLastError, SetPrintErrors
        public static string GetErrorString(ErrorCode code)
        {
            if (!NativeMethods.Loaded) throw new InvalidOperationException(NativeMethods.MsgInitFirstError);

            IntPtr ptr = NativeMethods.GetErrorString(code);
            return NativeMethods.MarshalPtrToString(ptr);
        }

        public static string[] GetErrors()
        {
            if (NativeMethods.ErrorFile == null) return null;
            if (!NativeMethods.PrintErrorsEnabled) return null;

            using (FileStream fs = new FileStream(NativeMethods.ErrorFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader r = new StreamReader(fs, NativeMethods.Encoding, false))
            {
                return r.ReadToEnd().Split('\n').Select(x => x.Trim()).Where(x => 0 < x.Length).ToArray();
            }
        }

        public static string GetLastError()
        {
            if (NativeMethods.ErrorFile == null)
                return null;
            if (!NativeMethods.PrintErrorsEnabled)
                return null;

            using (FileStream fs = new FileStream(NativeMethods.ErrorFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader r = new StreamReader(fs, NativeMethods.Encoding, false))
            {
                var lines = r.ReadToEnd().Split('\n').Select(x => x.Trim()).Where(x => 0 < x.Length);
                return lines.LastOrDefault();
            }
        }

        public static void ResetErrorFile()
        {
            if (NativeMethods.ErrorFile == null) return;
            if (!NativeMethods.PrintErrorsEnabled) return;
            using (FileStream fs = new FileStream(NativeMethods.ErrorFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter w = new StreamWriter(fs, NativeMethods.Encoding))
            {
                w.WriteLine();
            }
        }

        public static void SetPrintErrors(bool showMessages)
        {
            if (!NativeMethods.Loaded)
                throw new InvalidOperationException(NativeMethods.MsgInitFirstError);

            ErrorCode ret = NativeMethods.SetPrintErrors(showMessages);
            WimLibException.CheckWimLibError(ret);

            NativeMethods.PrintErrorsEnabled = showMessages;
        }
        #endregion

        #region Add - AddEmptyImage, AddImage, AddImageMultiSource, AddTree
        public int AddEmptyImage(string name)
        {
            WimLibException.CheckWimLibError(NativeMethods.AddEmptyImage(_ptr, name, out int newIdx));
            return newIdx;
        }

        public void AddImage(string source, string name, string configFile, AddFlags addFlags)
        {
            WimLibException.CheckWimLibError(NativeMethods.AddImage(_ptr, source, name, configFile, addFlags));
        }

        public void AddImageMultiSource(IEnumerable<CaptureSource> sources, string name, string configFile, AddFlags addFlags)
        {
            CaptureSource[] srcArr = sources.ToArray();
            WimLibException.CheckWimLibError(NativeMethods.AddImageMultiSource(_ptr, srcArr, new IntPtr(srcArr.Length), name, configFile, addFlags));
        }

        public void AddTree(int image, string fsSourcePath, string wimTargetPath, AddFlags addFlags)
        {
            WimLibException.CheckWimLibError(NativeMethods.AddTree(_ptr, image, fsSourcePath, wimTargetPath, addFlags));
        }
        #endregion

        public static Wim CreateNewWim(CompressionType compType)
        {
            if (!NativeMethods.Loaded) throw new InvalidOperationException(NativeMethods.MsgInitFirstError);
            WimLibException.CheckWimLibError(NativeMethods.CreateNewWim(compType, out IntPtr wimPtr));
            return new Wim(wimPtr);
        }

        public void DeleteImage(int image)
        {
            WimLibException.CheckWimLibError(NativeMethods.DeleteImage(_ptr, image));
        }
        public void DeletePath(int image, string path, DeleteFlags deleteFlags)
        {
            WimLibException.CheckWimLibError(NativeMethods.DeletePath(_ptr, image, path, deleteFlags));
        }

        public void ExportImage(int srcImage, Wim destWim, string destName, string destDescription, ExportFlags exportFlags)
        {
            ErrorCode ret = NativeMethods.ExportImage(_ptr, srcImage, destWim._ptr, destName, destDescription, exportFlags);
            WimLibException.CheckWimLibError(ret);
        }

        #region Extract - ExtractImage, ExtractPath, ExtractPaths, ExtractPathList
        public void ExtractImage(int image, string target, ExtractFlags extractFlags)
        {
            WimLibException.CheckWimLibError(NativeMethods.ExtractImage(_ptr, image, target, extractFlags));
        }

        public void ExtractPath(int image, string target, string path, ExtractFlags extractFlags)
        {
            WimLibException.CheckWimLibError(NativeMethods.ExtractPaths(_ptr, image, target, new string[1] { path }, new IntPtr(1), extractFlags));
        }

        public void ExtractPaths(int image, string target, IEnumerable<string> paths, ExtractFlags extractFlags)
        {
            string[] pathArr = paths.ToArray();
            WimLibException.CheckWimLibError(NativeMethods.ExtractPaths(_ptr, image, target, pathArr, new IntPtr(pathArr.Length), extractFlags));
        }

        public void ExtractPathList(int image, string target, string pathListFile, ExtractFlags extractFlags)
        {
            WimLibException.CheckWimLibError(NativeMethods.ExtractPathList(_ptr, image, target, pathListFile, extractFlags));
        }
        #endregion

        #region GetImageInfo - GetImageDescription, GetImageName, GetImageProperty

        public string GetImageDescription(int image)
        {
            IntPtr ptr = NativeMethods.GetImageDescription(_ptr, image);
            return ptr == IntPtr.Zero ? null : NativeMethods.MarshalPtrToString(ptr);
        }

        public string GetImageName(int image)
        {
            IntPtr ptr = NativeMethods.GetImageName(_ptr, image);
            return ptr == IntPtr.Zero ? null : NativeMethods.MarshalPtrToString(ptr);
        }
        public string GetImageProperty(int image, string propertyName)
        {
            IntPtr ptr = NativeMethods.GetImageProperty(_ptr, image, propertyName);
            return ptr == IntPtr.Zero ? null : NativeMethods.MarshalPtrToString(ptr);
        }
        #endregion

        #region GetWimInfo - GetWimInfo, IsImageNameInUse
        public WimInfo GetWimInfo()
        {
            IntPtr infoPtr = Marshal.AllocHGlobal(Marshal.SizeOf<WimInfo>());
            try
            {
                NativeMethods.GetWimInfo(_ptr, infoPtr); return Marshal.PtrToStructure<WimInfo>(infoPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(infoPtr);
            }
        }

        public bool IsImageNameInUse(string name)
        {
            return NativeMethods.IsImageNameInUse(_ptr, name);
        }

        #endregion


        #region Iterate - IterateDirTree, IterateLookupTable

        public void IterateDirTree(int image, string path, IterateFlags iterateFlags, IterateDirTreeCallback callback, object userData = null)
        {
            ManagedIterateDirTreeCallback cb = new ManagedIterateDirTreeCallback(callback, userData);
            WimLibException.CheckWimLibError(NativeMethods.IterateDirTree(_ptr, image, path, iterateFlags, cb.NativeFunc, IntPtr.Zero));
        }
        public void IterateLookupTable(IterateLookupTableCallback callback) => IterateLookupTable(callback, null);
        public void IterateLookupTable(IterateLookupTableCallback callback, object userData)
        {
            ManagedIterateLookupTableCallback cb = new ManagedIterateLookupTableCallback(callback, userData);

            ErrorCode ret = NativeMethods.IterateLookupTable(_ptr, 0, cb.NativeFunc, IntPtr.Zero);
            WimLibException.CheckWimLibError(ret);
        }
        #endregion

        #region Join - (Static) Join
        public static void Join(IEnumerable<string> swms, string outputPath, OpenFlags swmOpenFlags, WriteFlags wimWriteFlags)
        {
            string[] swmArr = swms.ToArray();
            ErrorCode ret = NativeMethods.Join(swmArr, (uint)swmArr.Length, outputPath, swmOpenFlags, wimWriteFlags);
            WimLibException.CheckWimLibError(ret);
        }
        public static void Join(IEnumerable<string> swms, string outputPath, OpenFlags swmOpenFlags, WriteFlags wimWriteFlags,
            ProgressCallback callback)
        {
            Join(swms, outputPath, swmOpenFlags, wimWriteFlags, callback, null);
        }

        public static void Join(IEnumerable<string> swms, string outputPath, OpenFlags swmOpenFlags, WriteFlags wimWriteFlags,
            ProgressCallback callback, object userData)
        {
            ManagedProgressCallback mCallback = new ManagedProgressCallback(callback, userData);

            string[] swmArr = swms.ToArray();
            ErrorCode ret = NativeMethods.JoinWithProgress(swmArr, (uint)swmArr.Length, outputPath, swmOpenFlags, wimWriteFlags,
                mCallback.NativeFunc, IntPtr.Zero);
            WimLibException.CheckWimLibError(ret);
        }
        #endregion

        #region Open - (Static) OpenWim
        /// <summary>
        /// Open a WIM file and create a instance of Wim class for it.
        /// </summary>
        /// <param name="wimFile">The path to the WIM file to open.</param>
        /// <param name="openFlags">Bitwise OR of flags prefixed with WIMLIB_OPEN_FLAG.</param>
        /// <returns>
        /// On success, a new instance of Wim class backed by the specified
        ///	on-disk WIM file is returned. This instance must be disposed 
        ///	when finished with it.
        ///	</returns>
        ///	<exception cref="WimLibException">wimlib did not return ErrorCode.SUCCESS.</exception>
        public static Wim OpenWim(string wimFile, OpenFlags openFlags)
        {
            if (!NativeMethods.Loaded)
                throw new InvalidOperationException(NativeMethods.MsgInitFirstError);

            ErrorCode ret = NativeMethods.OpenWim(wimFile, openFlags, out IntPtr wimPtr);
            WimLibException.CheckWimLibError(ret);

            return new Wim(wimPtr);
        }

        /// <summary>
        /// Same as OpenWim(), but allows specifying a progress function and progress context.  
        /// </summary>
        /// <remarks>
        /// If successful, the progress function will be registered in the newly open WimStruct,
        /// as if by an automatic call to Wim.RegisterCallback().
        /// 
        /// In addition, if OpenFlags.CHECK_INTEGRITY is specified in openFlags,
        /// then the callback function will receive ProgressMsg.VERIFY_INTEGRITY messages while checking the WIM file's integrity.
        /// </remarks>
        /// <param name="wimFile">The path to the WIM file to open.</param>
        /// <param name="openFlags">Bitwise OR of flags prefixed with WIMLIB_OPEN_FLAG.</param>
        /// <param name="callback">Callback function to receive progress report</param>
        /// <param name="userData">Data to be passed to callback function</param>
        /// <returns>
        /// On success, a new instance of Wim class backed by the specified on-disk WIM file is returned.
        ///	This instance must be disposed when finished with it.
        ///	</returns>
        ///	<exception cref="WimLibException">wimlib did not return ErrorCode.SUCCESS.</exception>
        public static Wim OpenWim(string wimFile, OpenFlags openFlags, ProgressCallback callback, object userData = null)
        {
            if (!NativeMethods.Loaded)
                throw new InvalidOperationException(NativeMethods.MsgInitFirstError);

            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            ManagedProgressCallback mCallback = new ManagedProgressCallback(callback, userData);

            ErrorCode ret = NativeMethods.OpenWimWithProgress(wimFile, openFlags, out IntPtr wimPtr, mCallback.NativeFunc, IntPtr.Zero);
            WimLibException.CheckWimLibError(ret);

            return new Wim(wimPtr)
            {
                _managedCallback = mCallback
            };
        }
        #endregion

        #region Reference - ReferenceResourceFiles, ReferenceResources, ReferenceTemplateImage
        public void ReferenceResourceFile(string resourceWimFile, RefFlags refFlags, OpenFlags openFlags)
        {
            if (resourceWimFile == null) throw new ArgumentNullException(nameof(resourceWimFile));
            List<string> resources = new List<string>();
            string dirPath = Path.GetDirectoryName(resourceWimFile);
            string wildcard = Path.GetFileName(resourceWimFile);
            if (dirPath == null) dirPath = @"\";
            if (dirPath.Length == 0) dirPath = ".";
            if ((refFlags & RefFlags.GLOB_ENABLE) != 0 && wildcard.IndexOfAny(new[] { '*', '?' }) != -1)
            { // Contains Wildcard
                string removeAsterisk = StringHelper.ReplaceEx(resourceWimFile, "*", string.Empty, StringComparison.Ordinal);
                var files = Directory.EnumerateFiles(dirPath, wildcard, SearchOption.AllDirectories);
                resources.AddRange(files.Where(x => !x.Equals(removeAsterisk, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                resources.Add(resourceWimFile);
            }

            if (resources.Count == 0 &&
                (refFlags & RefFlags.GLOB_ENABLE) != 0 && (refFlags & RefFlags.GLOB_ERR_ON_NOMATCH) != 0)
                throw new WimLibException(ErrorCode.GLOB_HAD_NO_MATCHES);

            ErrorCode ret = NativeMethods.ReferenceResourceFiles(_ptr, resources.ToArray(), (uint)resources.Count, RefFlags.DEFAULT, openFlags);
            WimLibException.CheckWimLibError(ret);
        }

        public void ReferenceResourceFiles(IEnumerable<string> resourceWimFiles, RefFlags refFlags, OpenFlags openFlags)
        {
            List<string> resources = new List<string>();
            foreach (string f in resourceWimFiles)
            {
                if (f == null)
                    throw new ArgumentNullException(nameof(resourceWimFiles));

                string dirPath = Path.GetDirectoryName(f);
                string wildcard = Path.GetFileName(f);
                if (dirPath == null) dirPath = @"\";
                if (dirPath.Length == 0) dirPath = ".";
                if ((refFlags & RefFlags.GLOB_ENABLE) != 0 && wildcard.IndexOfAny(new[] { '*', '?' }) != -1)
                { 
                    string removeAsterisk = StringHelper.ReplaceEx(f, "*", string.Empty, StringComparison.Ordinal);
                    var files = Directory.EnumerateFiles(dirPath, wildcard, SearchOption.AllDirectories);
                    resources.AddRange(files.Where(x => !x.Equals(removeAsterisk, StringComparison.OrdinalIgnoreCase)));
                }
                else
                {
                    resources.Add(f);
                }
            }

            if (resources.Count == 0 &&
                (refFlags & RefFlags.GLOB_ENABLE) != 0 && (refFlags & RefFlags.GLOB_ERR_ON_NOMATCH) != 0)
                throw new WimLibException(ErrorCode.GLOB_HAD_NO_MATCHES);

            ErrorCode ret = NativeMethods.ReferenceResourceFiles(_ptr, resources.ToArray(), (uint)resources.Count, RefFlags.DEFAULT, openFlags);
            WimLibException.CheckWimLibError(ret);
        }

       
        public void ReferenceResources(IEnumerable<Wim> resourceWims)
        {
            IntPtr[] wims = resourceWims.Select(x => x._ptr).ToArray();
            ErrorCode ret = NativeMethods.ReferenceResources(_ptr, wims, (uint)wims.Length, 0);
            WimLibException.CheckWimLibError(ret);
        }

        public void ReferenceTemplateImage(int newImage, int templateImage)
        {
            ErrorCode ret = NativeMethods.ReferenceTemplateImage(_ptr, newImage, _ptr, templateImage, 0);
            WimLibException.CheckWimLibError(ret);
        }

        public void ReferenceTemplateImage(int newImage, Wim template, int templateImage)
        {
            ErrorCode ret = NativeMethods.ReferenceTemplateImage(_ptr, newImage, template._ptr, templateImage, 0);
            WimLibException.CheckWimLibError(ret);
        }
        #endregion

        #region Callback - RegisterCallback
        public void RegisterCallback(ProgressCallback callback) => RegisterCallback(callback, null);
        public void RegisterCallback(ProgressCallback callback, object userData)
        {
            if (callback != null)
            { 
                _managedCallback = new ManagedProgressCallback(callback, userData);
                NativeMethods.RegisterProgressFunction(_ptr, _managedCallback.NativeFunc, IntPtr.Zero);
            }
            else
            { 
                _managedCallback = null;
                NativeMethods.RegisterProgressFunction(_ptr, null, IntPtr.Zero);
            }
        }
        #endregion
        
        public void SetOutputChunkSize(uint chunkSize)
        {
            WimLibException.CheckWimLibError(NativeMethods.SetOutputChunkSize(_ptr, chunkSize));
        }

        public void SetOutputPackChunkSize(uint chunkSize)
        {
            WimLibException.CheckWimLibError(NativeMethods.SetOutputPackChunkSize(_ptr, chunkSize));
        }

        public void SetOutputCompressionType(CompressionType compType)
        {
            WimLibException.CheckWimLibError(NativeMethods.SetOutputCompressionType(_ptr, compType));
        }

        public void SetOutputPackCompressionType(CompressionType compType)
        {
            WimLibException.CheckWimLibError(NativeMethods.SetOutputPackCompressionType(_ptr, compType));
        }

        public void Split(string swmName, ulong partSize, WriteFlags writeFlags)
        {
            WimLibException.CheckWimLibError(NativeMethods.Split(_ptr, swmName, partSize, writeFlags));
        }

        public void VerifyWim()
        {
            WimLibException.CheckWimLibError(NativeMethods.VerifyWim(_ptr, 0));
        }

       
        public void UpdateImage(int image, UpdateCommand cmd, UpdateFlags updateFlags)
        {
            ErrorCode ret;
            switch (IntPtr.Size)
            {
                case 4:
                    UpdateCommand32[] cmds32 = new UpdateCommand32[1] { cmd.ToNativeStruct32() };
                    try
                    {
                        ret = NativeMethods.UpdateImage32(_ptr, image, cmds32, 1u, updateFlags);
                    }
                    finally
                    {
                        cmds32[0].Free();
                    }
                    break;
                case 8:
                    UpdateCommand64[] cmds64 = new UpdateCommand64[1] { cmd.ToNativeStruct64() };
                    try
                    {
                        ret = NativeMethods.UpdateImage64(_ptr, image, cmds64, 1u, updateFlags);
                    }
                    finally
                    {
                        cmds64[0].Free();
                    }
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
            WimLibException.CheckWimLibError(ret);
        }
        public void UpdateImage(int image, IEnumerable<UpdateCommand> cmds, UpdateFlags updateFlags)
        {
            ErrorCode ret;
            int bits;
            switch (IntPtr.Size)
            {
                case 4:
                    bits = 32;
                    break;
                case 8:
                    bits = 64;
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
            switch (bits)
            {
                case 32:
                    UpdateCommand32[] cmds32 = cmds.Select(x => x.ToNativeStruct32()).ToArray();
                    try
                    {
                        ret = NativeMethods.UpdateImage32(_ptr, image, cmds32, (uint)cmds32.Length, updateFlags);
                    }
                    finally
                    {
                        foreach (UpdateCommand32 cmd32 in cmds32)
                            cmd32.Free();
                    }
                    break;
                case 64:
                    UpdateCommand64[] cmds64 = cmds.Select(x => x.ToNativeStruct64()).ToArray();
                    try
                    {
                        ret = NativeMethods.UpdateImage64(_ptr, image, cmds64, (ulong)cmds64.Length, updateFlags);
                    }
                    finally
                    {
                        foreach (UpdateCommand64 cmd64 in cmds64)
                            cmd64.Free();
                    }
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }

            WimLibException.CheckWimLibError(ret);
        }
#endregion

        public void Write(string path, int image, WriteFlags writeFlags, uint numThreads)
        {
            WimLibException.CheckWimLibError(NativeMethods.Write(_ptr, path, image, writeFlags, numThreads));
        }

        public void Overwrite(WriteFlags writeFlags, uint numThreads)
        {
            WimLibException.CheckWimLibError(NativeMethods.Overwrite(_ptr, writeFlags, numThreads));
        }

        public bool FileExists(int image, string wimFilePath)
        {
            bool exists = false;
            CallbackStatus ExistCallback(DirEntry dentry, object userData)
            {
                if ((dentry.Attributes & FileAttribute.DIRECTORY) == 0) exists = true;

                return CallbackStatus.CONTINUE;
            }

            try
            {
                IterateDirTree(image, wimFilePath, IterateFlags.DEFAULT, ExistCallback, null);
                return exists;
            }
            catch (WimLibException e) when (e.ErrorCode == ErrorCode.PATH_DOES_NOT_EXIST)
            {
                return false;
            }
        }

        public bool DirExists(int image, string wimDirPath)
        {
            bool exists = false;
            CallbackStatus ExistCallback(DirEntry dentry, object userData)
            {
                if ((dentry.Attributes & FileAttribute.DIRECTORY) != 0) exists = true;
                return CallbackStatus.CONTINUE;
            }

            try
            {
                IterateDirTree(image, wimDirPath, IterateFlags.DEFAULT, ExistCallback, null);
                return exists;
            }
            catch (WimLibException e) when (e.ErrorCode == ErrorCode.PATH_DOES_NOT_EXIST)
            {
                return false;
            }
        }

        public bool PathExists(int image, string wimPath) 
        {
            try
            {
                IterateDirTree(image, wimPath, IterateFlags.DEFAULT, null, null);
                return true;
            }
            catch (WimLibException e) when (e.ErrorCode == ErrorCode.PATH_DOES_NOT_EXIST)
            {
                return false;
            }
        }

    }


}
