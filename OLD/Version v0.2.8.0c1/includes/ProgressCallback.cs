using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

#pragma warning disable 649
#pragma warning disable IDE0044

namespace ManagedWimLib
{
    #region ProgressCallback delegate
    public delegate CallbackStatus ProgressCallback(ProgressMsg msg, object info, object progctx);
    #endregion

    #region ManagedWimLibCallback
    internal class ManagedProgressCallback
    {
        private readonly ProgressCallback _callback;
        private readonly object _userData;

        internal NativeMethods.NativeProgressFunc NativeFunc { get; }

        public ManagedProgressCallback(ProgressCallback callback, object userData)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
            _userData = userData;
            NativeFunc = NativeCallback;
        }

        private CallbackStatus NativeCallback(ProgressMsg msgType, IntPtr info, IntPtr progctx)
        {
            object pInfo = null;

            if (_callback == null)
                return CallbackStatus.CONTINUE;

            switch (msgType)
            {
                case ProgressMsg.WRITE_STREAMS:pInfo = Marshal.PtrToStructure<ProgressInfo_WriteStreams>(info); break;
                case ProgressMsg.SCAN_BEGIN:
                case ProgressMsg.SCAN_DENTRY:
                case ProgressMsg.SCAN_END:pInfo = Marshal.PtrToStructure<ProgressInfo_Scan>(info); break;
                case ProgressMsg.EXTRACT_SPWM_PART_BEGIN:
                case ProgressMsg.EXTRACT_IMAGE_BEGIN:
                case ProgressMsg.EXTRACT_TREE_BEGIN:
                case ProgressMsg.EXTRACT_FILE_STRUCTURE:
                case ProgressMsg.EXTRACT_STREAMS:
                case ProgressMsg.EXTRACT_METADATA:
                case ProgressMsg.EXTRACT_TREE_END:
                case ProgressMsg.EXTRACT_IMAGE_END:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_Extract>(info);
                    break;
                case ProgressMsg.RENAME:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_Rename>(info);
                    break;
                case ProgressMsg.UPDATE_BEGIN_COMMAND:
                case ProgressMsg.UPDATE_END_COMMAND:
                    ProgressInfo_UpdateBase _base = Marshal.PtrToStructure<ProgressInfo_UpdateBase>(info);
                    pInfo = _base.ToManaged();
                    break;
                case ProgressMsg.VERIFY_INTEGRITY:
                case ProgressMsg.CALC_INTEGRITY:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_Integrity>(info);
                    break;
                case ProgressMsg.SPLIT_BEGIN_PART:
                case ProgressMsg.SPLIT_END_PART:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_Split>(info);
                    break;
                case ProgressMsg.REPLACE_FILE_IN_WIM:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_Replace>(info);
                    break;
                case ProgressMsg.WIMBOOT_EXCLUDE:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_WimBootExclude>(info);
                    break;
                case ProgressMsg.UNMOUNT_BEGIN:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_Unmount>(info);
                    break;
                case ProgressMsg.DONE_WITH_FILE:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_DoneWithFile>(info);
                    break;
                case ProgressMsg.BEGIN_VERIFY_IMAGE:
                case ProgressMsg.END_VERIFY_IMAGE:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_VerifyImage>(info);
                    break;
                case ProgressMsg.VERIFY_STREAMS:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_VerifyStreams>(info);
                    break;
                case ProgressMsg.TEST_FILE_EXCLUSION:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_TestFileExclusion>(info);
                    break;
                case ProgressMsg.HANDLE_ERROR:
                    pInfo = Marshal.PtrToStructure<ProgressInfo_HandleError>(info);
                    break;
            }

            return _callback(msgType, pInfo, _userData);

        }
    }
    #endregion

    #region ProgressInfo    
    #region struct ProgressInfo_WriteStreams
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_WriteStreams
    {
        public ulong TotalBytes;
        public ulong TotalStreams;
        public ulong CompletedBytes;
        public ulong CompletedStreams;
        public uint NumThreads;
        public CompressionType CompressionType;
        public uint TotalParts;
        public uint CompletedParts;
    }
    #endregion

    #region struct ProgressInfo_Scan

    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_Scan
    {

        public enum ScanDentryStatus : uint
        {
            OK = 0,
            EXCLUDED = 1,
            UNSUPPORTED = 2,
            FIXED_SYMLINK = 3,
            NOT_FIXED_SYMLINK = 4,
        }

        public string Source => NativeMethods.MarshalPtrToString(_sourcePtr);
        private IntPtr _sourcePtr;
        public string CurPath => NativeMethods.MarshalPtrToString(_curPathPtr);
        private IntPtr _curPathPtr;
        public ScanDentryStatus Status;
        public string WimTargetPathSymlinkTarget => NativeMethods.MarshalPtrToString(_wimTargetPathSymlinkTargetPtr);
        private IntPtr _wimTargetPathSymlinkTargetPtr;
        public ulong NumDirsScanned, NumNonDirsScanned, NumBytesScanned;
    }
    #endregion

    #region struct ProgressInfo_Extract
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_Extract
    {

        public uint Image;
        public uint ExtractFlags;
        public string WimFileName => NativeMethods.MarshalPtrToString(_wimFileNamePtr);
        private IntPtr _wimFileNamePtr;
        public string ImageName => NativeMethods.MarshalPtrToString(_imageNamePtr);
        private IntPtr _imageNamePtr;
        public string Target => NativeMethods.MarshalPtrToString(_targetPtr);
        private IntPtr _targetPtr;
        private IntPtr _reserved;
        public ulong TotalBytes, CompletedBytes, TotalStreams, CompletedStreams, PartNumber, TotalParts;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Guid;
        public ulong CurrentFileCount;
        public ulong EndFileCount;
    }
    #endregion

    #region struct ProgressInfo_Rename
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_Rename
    {

        public string From => NativeMethods.MarshalPtrToString(_fromPtr);
        private IntPtr _fromPtr;
        public string To => NativeMethods.MarshalPtrToString(_toPtr);
        private IntPtr _toPtr;
    }
    #endregion

    #region struct ProgressInfo_Update
    public struct ProgressInfo_Update
    {
        public UpdateCommand Command;
        public uint CompletedCommands, TotalCommands;
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct ProgressInfo_UpdateBase
    {
        private IntPtr _cmdPtr;
        private UpdateCommand32 Cmd32 => Marshal.PtrToStructure<UpdateCommand32>(_cmdPtr);
        private UpdateCommand64 Cmd64 => Marshal.PtrToStructure<UpdateCommand64>(_cmdPtr);
        public UpdateCommand Command
        {
            get
            {
                switch (IntPtr.Size)
                {
                    case 4:
                        return Cmd32.ToManagedClass();
                    case 8:
                        return Cmd64.ToManagedClass();
                    default:
                        throw new PlatformNotSupportedException();
                }
            }
        }

        public uint CompletedCommands, TotalCommands;

        [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
        public ProgressInfo_Update ToManaged()
        {
            return new ProgressInfo_Update
            {
                Command = this.Command,
                CompletedCommands = this.CompletedCommands,
                TotalCommands = this.TotalCommands,
            };
        }
    }
    #endregion

    #region struct ProgressInfo_Integrity
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_Integrity
    {
        public ulong TotalBytes, CompletedBytes, TotalChunks, CompletedChunks, ChunkSize;
        public string FileName => NativeMethods.MarshalPtrToString(_fileNamePtr);
        private IntPtr _fileNamePtr;
    }
    #endregion

    #region struct ProgressInfo_Split
    /// <summary>
    /// Valid on messages SPLIT_BEGIN_PART and SPLIT_END_PART.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_Split
    {
        public ulong TotalBytes;
        public ulong CompletedBytes;
        public uint CurPartNumber;
        public uint TotalParts;
        public string PartName => NativeMethods.MarshalPtrToString(_partNamePtr);
        private IntPtr _partNamePtr;
    }
    #endregion

    #region struct ProgressInfo_Replace
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_Replace
    {
        public string PathInWim => NativeMethods.MarshalPtrToString(_pathInWimPtr);
        private IntPtr _pathInWimPtr;
    }
    #endregion

    #region ProgressInfo_WimBootExclude
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_WimBootExclude
    {

        public string PathInWim => NativeMethods.MarshalPtrToString(_pathInWimPtr);
        private IntPtr _pathInWimPtr;
        public string ExtractionInWim => NativeMethods.MarshalPtrToString(_extractionInWimPtr);
        private IntPtr _extractionInWimPtr;
    }
    #endregion

    #region struct ProgressInfo_Unmount
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_Unmount
    {
        public string MountPoint => NativeMethods.MarshalPtrToString(_mountPointPtr);
        private IntPtr _mountPointPtr;
        public string MountedWim => NativeMethods.MarshalPtrToString(_mountedWimPtr);
        private IntPtr _mountedWimPtr;
        public uint MountedImage;
        public uint MountFlags;
        public uint UnmountFlags;
    }
    #endregion

    #region struct ProgressInfo_DoneWithFile
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_DoneWithFile
    {
        public string PathToFile => NativeMethods.MarshalPtrToString(_pathToFilePtr);
        private IntPtr _pathToFilePtr;
    }
    #endregion

    #region struct ProgressInfo_VerifyImage
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_VerifyImage
    {
        public string WimFile => NativeMethods.MarshalPtrToString(_wimFilePtr);
        private IntPtr _wimFilePtr;
        public uint TotalImages;
        public uint CurrentImage;
    }
    #endregion

    #region struct ProgressInfo_VerifyStreams
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_VerifyStreams
    {
        public string WimFile => NativeMethods.MarshalPtrToString(_wimFilePtr);
        private IntPtr _wimFilePtr;
        public uint TotalStreams;
        public uint TotalBytes;
        public uint CurrentStreams;
        public uint CurrentBytes;
    }
    #endregion

    #region struct ProgressInfo_TestFileExclusion

    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_TestFileExclusion
    {
 
        public string Path => NativeMethods.MarshalPtrToString(_pathPtr);
        private IntPtr _pathPtr;
        public bool WillExclude;
    }
    #endregion

    #region struct ProgressInfo_HandleError
    [StructLayout(LayoutKind.Sequential)]
    public struct ProgressInfo_HandleError
    {
        public string Path => NativeMethods.MarshalPtrToString(_pathPtr);
        private IntPtr _pathPtr;
        public int ErrorCode;
        public bool WillIgnore;
    }
    #endregion
    #endregion
}
