
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

#pragma warning disable 169
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable IDE0044

namespace ManagedWimLib
{
    #region Native WimLib Enums
    #region Enum CompressionType
    public enum CompressionType
    {
        NONE = 0,
        XPRESS = 1,
        LZX = 2,
        LZMS = 3,
    }
    #endregion

    #region Enum Progress
    public enum ProgressMsg
    {
        EXTRACT_IMAGE_BEGIN = 0,
        EXTRACT_TREE_BEGIN = 1,
        EXTRACT_FILE_STRUCTURE = 3,
        EXTRACT_STREAMS = 4,
        EXTRACT_SPWM_PART_BEGIN = 5,
        EXTRACT_METADATA = 6,
        EXTRACT_IMAGE_END = 7,
        EXTRACT_TREE_END = 8,
        SCAN_BEGIN = 9,
        SCAN_DENTRY = 10,
        SCAN_END = 11,
        WRITE_STREAMS = 12,
        WRITE_METADATA_BEGIN = 13,
        WRITE_METADATA_END = 14,
        RENAME = 15,
        VERIFY_INTEGRITY = 16,
        CALC_INTEGRITY = 17,
        SPLIT_BEGIN_PART = 19,
        SPLIT_END_PART = 20,
        UPDATE_BEGIN_COMMAND = 21,
        UPDATE_END_COMMAND = 22,
        REPLACE_FILE_IN_WIM = 23,
        WIMBOOT_EXCLUDE = 24,
        UNMOUNT_BEGIN = 25,
        DONE_WITH_FILE = 26,
        BEGIN_VERIFY_IMAGE = 27,
        END_VERIFY_IMAGE = 28,
        VERIFY_STREAMS = 29,
        TEST_FILE_EXCLUSION = 30,
        HANDLE_ERROR = 31,
    }
    public enum CallbackStatus : int
    {
        CONTINUE = 0,
        ABORT = 1,
    }
    #endregion

    #region Enum ErrorCode 
    public enum ErrorCode : int
    {
        SUCCESS = 0,
        ALREADY_LOCKED = 1,
        DECOMPRESSION = 2,
        FUSE = 6,
        GLOB_HAD_NO_MATCHES = 8,
        IMAGE_COUNT = 10,
        IMAGE_NAME_COLLISION = 11,
        INSUFFICIENT_PRIVILEGES = 12,
        INTEGRITY = 13,
        INVALID_CAPTURE_CONFIG = 14,
        INVALID_CHUNK_SIZE = 15,
        INVALID_COMPRESSION_TYPE = 16,
        INVALID_HEADER = 17,
        INVALID_IMAGE = 18,
        INVALID_INTEGRITY_TABLE = 19,
        INVALID_LOOKUP_TABLE_ENTRY = 20,
        INVALID_METADATA_RESOURCE = 21,
        INVALID_OVERLAY = 23,
        INVALID_PARAM = 24,
        INVALID_PART_NUMBER = 25,
        INVALID_PIPABLE_WIM = 26,
        INVALID_REPARSE_DATA = 27,
        INVALID_RESOURCE_HASH = 28,
        INVALID_UTF16_STRING = 30,
        INVALID_UTF8_STRING = 31,
        IS_DIRECTORY = 32,
        IS_SPLIT_WIM = 33,
        LINK = 35,
        METADATA_NOT_FOUND = 36,
        MKDIR = 37,
        MQUEUE = 38,
        NOMEM = 39,
        NOTDIR = 40,
        NOTEMPTY = 41,
        NOT_A_REGULAR_FILE = 42,
        NOT_A_WIM_FILE = 43,
        NOT_PIPABLE = 44,
        NO_FILENAME = 45,
        NTFS_3G = 46,
        OPEN = 47,
        OPENDIR = 48,
        PATH_DOES_NOT_EXIST = 49,
        READ = 50,
        READLINK = 51,
        RENAME = 52,
        REPARSE_POINT_FIXUP_FAILED = 54,
        RESOURCE_NOT_FOUND = 55,
        RESOURCE_ORDER = 56,
        SET_ATTRIBUTES = 57,
        SET_REPARSE_DATA = 58,
        SET_SECURITY = 59,
        SET_SHORT_NAME = 60,
        SET_TIMESTAMPS = 61,
        SPLIT_INVALID = 62,
        STAT = 63,
        UNEXPECTED_END_OF_FILE = 65,
        UNICODE_STRING_NOT_REPRESENTABLE = 66,
        UNKNOWN_VERSION = 67,
        UNSUPPORTED = 68,
        UNSUPPORTED_FILE = 69,
        WIM_IS_READONLY = 71,
        WRITE = 72,
        XML = 73,
        WIM_IS_ENCRYPTED = 74,
        WIMBOOT = 75,
        ABORTED_BY_PROGRESS = 76,
        UNKNOWN_PROGRESS_STATUS = 77,
        MKNOD = 78,
        MOUNTED_IMAGE_IS_BUSY = 79,
        NOT_A_MOUNTPOINT = 80,
        NOT_PERMITTED_TO_UNMOUNT = 81,
        FVE_LOCKED_VOLUME = 82,
        UNABLE_TO_READ_CAPTURE_CONFIG = 83,
        WIM_IS_INCOMPLETE = 84,
        COMPACTION_NOT_POSSIBLE = 85,
        IMAGE_HAS_MULTIPLE_REFERENCES = 86,
        DUPLICATE_EXPORTED_IMAGE = 87,
        CONCURRENT_MODIFICATION_DETECTED = 88,
        SNAPSHOT_FAILURE = 89,
        INVALID_XATTR = 90,
        SET_XATTR = 91,
    }
    #endregion

    #region Enum IterateFlags
    [Flags]
    public enum IterateFlags : uint
    {
        DEFAULT = 0x00000000,
        RECURSIVE = 0x00000001,
        CHILDREN = 0x00000002,
        RESOURCES_NEEDED = 0x00000004,
    }
    #endregion

    #region Enum AddFlags
    [Flags]
    public enum AddFlags : uint
    {
        DEFAULT = 0x00000000,
        NTFS = 0x00000001,
        DEREFERENCE = 0x00000002,
        VERBOSE = 0x00000004,
        BOOT = 0x00000008,
        UNIX_DATA = 0x00000010,
        NO_ACLS = 0x00000020,
        STRICT_ACLS = 0x00000040,
        EXCLUDE_VERBOSE = 0x00000080,
        RPFIX = 0x00000100,
        NORPFIX = 0x00000200,
        NO_UNSUPPORTED_EXCLUDE = 0x00000400,
        WINCONFIG = 0x00000800,
        WIMBOOT = 0x00001000,
        NO_REPLACE = 0x00002000,
        TEST_FILE_EXCLUSION = 0x00004000,
        SNAPSHOT = 0x00008000,
        FILE_PATHS_UNNEEDED = 0x00010000,
    }
    #endregion

    #region Enum ChangeFlags
    [Flags]
    public enum ChangeFlags : int
    {
        READONLY_FLAG = 0x00000001,
        GUID = 0x00000002,
        BOOT_INDEX = 0x00000004,
        RPFIX_FLAG = 0x00000008
    }
    #endregion

    #region Enum DeleteFlags
    [Flags]
    public enum DeleteFlags : uint
    {
        DEFAULT = 0x00000000,
        FORCE = 0x00000001,
        RECURSIVE = 0x00000002,
    }
    #endregion

    #region Enum ExportFlags
    [Flags]
    public enum ExportFlags : uint
    {
        DEFAULT = 0x00000000,
        BOOT = 0x00000001,
        NO_NAMES = 0x00000002,
        NO_DESCRIPTIONS = 0x00000004,
        GIFT = 0x00000008,
        WIMBOOT = 0x00000010,
    }
    #endregion

    #region Enum ExtractFlags
    [Flags]
    public enum ExtractFlags : uint
    {
        DEFAULT = 0x00000000,
        NTFS = 0x00000001,
        UNIX_DATA = 0x00000020,
        NO_ACLS = 0x00000040,
        STRICT_ACLS = 0x00000080,
        RPFIX = 0x00000100,
        NORPFIX = 0x00000200,
        TO_STDOUT = 0x00000400,
        REPLACE_INVALID_FILENAMES = 0x00000800,
        ALL_CASE_CONFLICTS = 0x00001000,
        STRICT_TIMESTAMPS = 0x00002000,
        STRICT_SHORT_NAMES = 0x00004000,
        STRICT_SYMLINKS = 0x00008000,
        GLOB_PATHS = 0x00040000,
        STRICT_GLOB = 0x00080000,
        NO_ATTRIBUTES = 0x00100000,
        NO_PRESERVE_DIR_STRUCTURE = 0x00200000,
        WIMBOOT = 0x00400000,
        COMPACT_XPRESS4K = 0x01000000,
        COMPACT_XPRESS8K = 0x02000000,
        COMPACT_XPRESS16K = 0x04000000,
        COMPACT_LZX = 0x08000000,
    }
    #endregion


    #region Enum OpenFlags
    [Flags]
    public enum OpenFlags : int
    {
        DEFAULT = 0x00000000,
        CHECK_INTEGRITY = 0x00000001,
        ERROR_IF_SPLIT = 0x00000002,
        WRITE_ACCESS = 0x00000004,
    }
    #endregion

    #region Enum UpdateFlags
    [Flags]
    public enum UpdateFlags : uint
    {
        SEND_PROGRESS = 0x00000001,
    }
    #endregion

    #region Enum WriteFlags
    [Flags]
    public enum WriteFlags : uint
    {
        DEFAULT = 0x00000000,
        CHECK_INTEGRITY = 0x00000001,
        NO_CHECK_INTEGRITY = 0x00000002,
        PIPABLE = 0x00000004,
        NOT_PIPABLE = 0x00000008,
        RECOMPRESS = 0x00000010,
        FSYNC = 0x00000020,
        REBUILD = 0x00000040,
        SOFT_DELETE = 0x00000080,
        IGNORE_READONLY_FLAG = 0x00000100,
        SKIP_EXTERNAL_WIMS = 0x00000200,
        RETAIN_GUID = 0x00000800,
        SOLID = 0x00001000,
        SEND_DONE_WITH_FILE_MESSAGES = 0x00002000,
        NO_SOLID_SORT = 0x00004000,
        UNSAFE_COMPACT = 0x00008000,
    }
    #endregion

    #region Enum InitFlags
    [Flags]
    public enum InitFlags : uint
    {
        DEFAULT = 0x00000000,
        DONT_ACQUIRE_PRIVILEGES = 0x00000002,
        STRICT_CAPTURE_PRIVILEGES = 0x00000004,
        STRICT_APPLY_PRIVILEGES = 0x00000008,
        DEFAULT_CASE_SENSITIVE = 0x00000010,
        DEFAULT_CASE_INSENSITIVE = 0x00000020,
    }
    #endregion

    #region Enum RefFlags
    [Flags]
    public enum RefFlags : int
    {
        DEFAULT = 0x00000000,
        GLOB_ENABLE = 0x00000001,
        GLOB_ERR_ON_NOMATCH = 0x00000002,
    }
    #endregion
    #endregion

    #region Native WimLib Structs
    #region Struct CaptureSource
    public struct CaptureSource
    {
        public string FsSourcePath;
        public string WimTargetPath;

        public CaptureSource(string fsSourcePath, string wimTargetPath)
        {
            FsSourcePath = fsSourcePath;
            WimTargetPath = wimTargetPath;
        }
    };

    #region Struct WimInfo
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Local")]
    [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable")]
    public struct WimInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Guid;
        public uint ImageCount;
        public uint BootIndex;
        public uint WimVersion;
        public uint ChunkSize;
        public ushort PartNumber;
        public ushort TotalParts;
        public CompressionType CompressionType
        {
            get => (CompressionType)CompressionTypeInt;
            set => CompressionTypeInt = (int)value;
        }
        private int CompressionTypeInt;
        public ulong TotalBytes;
        private uint _bitFlag;
        public bool HasIntegrityTable
        {
            get => NativeMethods.GetBitField(_bitFlag, 0);
            set => NativeMethods.SetBitField(ref _bitFlag, 0, value);
        }
        public bool OpenedFromFile
        {
            get => NativeMethods.GetBitField(_bitFlag, 1);
            set => NativeMethods.SetBitField(ref _bitFlag, 1, value);
        }
        public bool IsReadonly
        {
            get => NativeMethods.GetBitField(_bitFlag, 2);
            set => NativeMethods.SetBitField(ref _bitFlag, 2, value);
        }
        public bool HasRpfix
        {
            get => NativeMethods.GetBitField(_bitFlag, 3);
            set => NativeMethods.SetBitField(ref _bitFlag, 3, value);
        }
        public bool IsMarkedReadonly
        {
            get => NativeMethods.GetBitField(_bitFlag, 4);
            set => NativeMethods.SetBitField(ref _bitFlag, 4, value);
        }
        public bool Spanned
        {
            get => NativeMethods.GetBitField(_bitFlag, 5);
            set => NativeMethods.SetBitField(ref _bitFlag, 5, value);
        }
        public bool WriteInProgress
        {
            get => NativeMethods.GetBitField(_bitFlag, 6);
            set => NativeMethods.SetBitField(ref _bitFlag, 6, value);
        }

        public bool MetadataOnly
        {
            get => NativeMethods.GetBitField(_bitFlag, 7);
            set => NativeMethods.SetBitField(ref _bitFlag, 7, value);
        }

        public bool ResourceOnly
        {
            get => NativeMethods.GetBitField(_bitFlag, 8);
            set => NativeMethods.SetBitField(ref _bitFlag, 8, value);
        }

        public bool Pipable
        {
            get => NativeMethods.GetBitField(_bitFlag, 9);
            set => NativeMethods.SetBitField(ref _bitFlag, 9, value);
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        private uint[] _reserved;
    }
    #endregion

    #region Struct UpdateCommand 
    [Flags]
    public enum UpdateOp : uint
    {
        ADD = 0,
        DELETE = 1,
        RENAME = 2,
    }
    #endregion

    #region UpdateCommand
    public class UpdateCommand
    {
        #region Field - UpdateOp
        public UpdateOp Op;
        #endregion

        #region Field - UpdateAdd

        public string AddFsSourcePath;
        public string AddWimTargetPath;
        public string AddConfigFile;
        public AddFlags AddFlags;
        #endregion

        #region Field - UpdateDelete
        public string DelWimPath;
        public DeleteFlags DeleteFlags;
        #endregion

        #region Field - UpdateRename
        public string RenWimSourcePath;
        public string RenWimTargetPath;
        private int _renameFlags;
        #endregion

        #region Properties - Add, Delete, Rename
        public UpdateAdd Add
        {
            get
            {
                if (Op != UpdateOp.ADD)
                    throw new InvalidOperationException("Field [Op] should be [UpdateOp.ADD]");
                return new UpdateAdd(AddFsSourcePath, AddWimTargetPath, AddConfigFile, AddFlags);
            }
            set
            {
                Op = UpdateOp.ADD;
                AddFsSourcePath = value.FsSourcePath;
                AddWimTargetPath = value.WimTargetPath;
                AddConfigFile = value.ConfigFile;
                AddFlags = value.AddFlags;
            }
        }

        public UpdateDelete Delete
        {
            get
            {
                if (Op != UpdateOp.DELETE)
                    throw new InvalidOperationException("Field [Op] should be [UpdateOp.DELETE]");
                return new UpdateDelete(DelWimPath, DeleteFlags);
            }
            set
            {
                Op = UpdateOp.DELETE;
                DelWimPath = value.WimPath;
                DeleteFlags = value.DeleteFlags;
            }
        }

        public UpdateRename Rename
        {
            get
            {
                if (Op != UpdateOp.RENAME)
                    throw new InvalidOperationException("Field [Op] should be [UpdateOp.DELETE]");
                return new UpdateRename(RenWimSourcePath, RenWimTargetPath);
            }
            set
            {
                Op = UpdateOp.RENAME;
                RenWimSourcePath = value.WimSourcePath;
                RenWimTargetPath = value.WimTargetPath;
                _renameFlags = 0;
            }
        }
        #endregion

        #region Factory Methods
        public static UpdateCommand SetAdd(string fsSourcePath, string wimTargetPath, string configFile, AddFlags addFlags)
        {
            return new UpdateCommand
            {
                Op = UpdateOp.ADD,
                AddFsSourcePath = fsSourcePath,
                AddWimTargetPath = wimTargetPath,
                AddConfigFile = configFile,
                AddFlags = addFlags,
            };
        }

        public static UpdateCommand SetAdd(UpdateAdd add)
        {
            return new UpdateCommand
            {
                Op = UpdateOp.ADD,
                AddFsSourcePath = add.FsSourcePath,
                AddWimTargetPath = add.WimTargetPath,
                AddConfigFile = add.ConfigFile,
                AddFlags = add.AddFlags,
            };
        }

        public static UpdateCommand SetDelete(string wimPath, DeleteFlags deleteFlags)
        {
            return new UpdateCommand
            {
                Op = UpdateOp.DELETE,
                DelWimPath = wimPath,
                DeleteFlags = deleteFlags,
            };
        }

        public static UpdateCommand SetDelete(UpdateDelete del)
        {
            return new UpdateCommand
            {
                Op = UpdateOp.DELETE,
                DelWimPath = del.WimPath,
                DeleteFlags = del.DeleteFlags,
            };
        }

        public static UpdateCommand SetRename(string wimSourcePath, string wimTargetPath)
        {
            return new UpdateCommand
            {
                Op = UpdateOp.RENAME,
                RenWimSourcePath = wimSourcePath,
                RenWimTargetPath = wimTargetPath,
                _renameFlags = 0,
            };
        }

        public static UpdateCommand SetRename(UpdateRename ren)
        {
            return new UpdateCommand
            {
                Op = UpdateOp.RENAME,
                RenWimSourcePath = ren.WimSourcePath,
                RenWimTargetPath = ren.WimTargetPath,
                _renameFlags = 0,
            };
        }
        #endregion

        #region SubClass - UpdateAdd, UpdateDelete, UpdateRename
        public class UpdateAdd
        {
            /// <summary>
            /// Filesystem path to the file or directory tree to add.
            /// </summary>
            public string FsSourcePath;
            /// <summary>
            /// Destination path in the image.
            /// To specify the root directory of the image, use Wim.RootPath.
            /// </summary>
            public string WimTargetPath;
            /// <summary>
            /// Path to capture configuration file to use, or null if not specified.
            /// </summary>
            public string ConfigFile;
            /// <summary>
            /// Bitwise OR of AddFlags.
            /// </summary>
            public AddFlags AddFlags;

            public UpdateAdd(string fsSourcePath, string wimTargetPath, string configFile, AddFlags addFlags)
            {
                FsSourcePath = fsSourcePath;
                WimTargetPath = wimTargetPath;
                ConfigFile = configFile;
                AddFlags = addFlags;
            }
        }

        public class UpdateDelete
        {
            /// <summary>
            /// The path to the file or directory within the image to delete.
            /// </summary>
            public string WimPath;
            /// <summary>
            /// Bitwise OR of DeleteFlags.
            /// </summary>
            public DeleteFlags DeleteFlags;

            public UpdateDelete(string wimPath, DeleteFlags deleteFlags)
            {
                WimPath = wimPath;
                DeleteFlags = deleteFlags;
            }
        }

        public class UpdateRename
        {
            /// <summary>
            /// The path to the source file or directory within the image.
            /// </summary>
            public string WimSourcePath;
            /// <summary>
            /// The path to the destination file or directory within the image.
            /// </summary>
            public string WimTargetPath;

            public UpdateRename(string wimSourcePath, string wimTargetPath)
            {
                WimSourcePath = wimSourcePath;
                WimTargetPath = wimTargetPath;
            }
        }
        #endregion

        #region ToNativeStruct
        public UpdateCommand32 ToNativeStruct32()
        {
            switch (Op)
            {
                case UpdateOp.ADD:
                    return new UpdateCommand32
                    {
                        Op = UpdateOp.ADD,
                        AddFsSourcePath = AddFsSourcePath,
                        AddWimTargetPath = AddWimTargetPath,
                        AddConfigFile = AddConfigFile,
                        AddFlags = AddFlags,
                    };
                case UpdateOp.DELETE:
                    return new UpdateCommand32
                    {
                        Op = UpdateOp.DELETE,
                        DelWimPath = DelWimPath,
                        DeleteFlags = DeleteFlags,
                    };
                case UpdateOp.RENAME:
                    return new UpdateCommand32
                    {
                        Op = UpdateOp.RENAME,
                        RenWimSourcePath = RenWimSourcePath,
                        RenWimTargetPath = RenWimTargetPath,
                    };
                default:
                    throw new InvalidOperationException("Internal Logic Error at UpdateCommand.ToNativeStruct32()");
            }
        }

        public UpdateCommand64 ToNativeStruct64()
        {
            switch (Op)
            {
                case UpdateOp.ADD:
                    return new UpdateCommand64
                    {
                        Op = UpdateOp.ADD,
                        AddFsSourcePath = AddFsSourcePath,
                        AddWimTargetPath = AddWimTargetPath,
                        AddConfigFile = AddConfigFile,
                        AddFlags = AddFlags,
                    };
                case UpdateOp.DELETE:
                    return new UpdateCommand64
                    {
                        Op = UpdateOp.DELETE,
                        DelWimPath = DelWimPath,
                        DeleteFlags = DeleteFlags,
                    };
                case UpdateOp.RENAME:
                    return new UpdateCommand64
                    {
                        Op = UpdateOp.RENAME,
                        RenWimSourcePath = RenWimSourcePath,
                        RenWimTargetPath = RenWimTargetPath,
                    };
                default:
                    throw new InvalidOperationException("Internal Logic Error at UpdateCommand.ToNativeStruct64()");
            }
        }
        #endregion
    }
    #endregion

    #region UpdateCommand32
    [StructLayout(LayoutKind.Explicit)]
    public struct UpdateCommand32
    {
        [FieldOffset(0)]
        public UpdateOp Op;

        #region UpdateAddCommand
        [FieldOffset(4)]
        private IntPtr _addFsSourcePathPtr;
        public string AddFsSourcePath
        {
            get => NativeMethods.MarshalPtrToString(_addFsSourcePathPtr);
            set => UpdatePtr(ref _addFsSourcePathPtr, value);
        }

        [FieldOffset(8)]
        private IntPtr _addWimTargetPathPtr;
        public string AddWimTargetPath
        {
            get => NativeMethods.MarshalPtrToString(_addWimTargetPathPtr);
            set => UpdatePtr(ref _addWimTargetPathPtr, value);
        }

        [FieldOffset(12)]
        private IntPtr _addConfigFilePtr;
        public string AddConfigFile
        {
            get => NativeMethods.MarshalPtrToString(_addConfigFilePtr);
            set => UpdatePtr(ref _addConfigFilePtr, value);
        }

        [FieldOffset(16)]
        public AddFlags AddFlags;
        #endregion

        #region UpdateDeleteCommand
        /// <summary>
        /// The path to the file or directory within the image to delete.
        /// </summary>
        [FieldOffset(4)]
        private IntPtr _delWimPathPtr;
        public string DelWimPath
        {
            get => NativeMethods.MarshalPtrToString(_delWimPathPtr);
            set => UpdatePtr(ref _delWimPathPtr, value);
        }
        /// <summary>
        /// Bitwise OR of DeleteFlags.
        /// </summary>
        [FieldOffset(8)]
        public DeleteFlags DeleteFlags;
        #endregion

        #region UpdateRenameCommand
        /// <summary>
        /// The path to the source file or directory within the image.
        /// </summary>
        [FieldOffset(4)]
        private IntPtr _renWimSourcePathPtr;
        public string RenWimSourcePath
        {
            get => NativeMethods.MarshalPtrToString(_renWimSourcePathPtr);
            set => UpdatePtr(ref _renWimSourcePathPtr, value);
        }
        /// <summary>
        /// The path to the destination file or directory within the image.
        /// </summary>
        [FieldOffset(8)]
        private IntPtr _renWimTargetPathPtr;
        public string RenWimTargetPath
        {
            get => NativeMethods.MarshalPtrToString(_renWimTargetPathPtr);
            set => UpdatePtr(ref _renWimTargetPathPtr, value);
        }
        /// <summary>
        /// Reserved; set to 0. 
        /// </summary>
        [FieldOffset(12)]
        private int _renameFlags;
        #endregion

        #region Free
        public void Free()
        {
            switch (Op)
            {
                case UpdateOp.ADD:
                    FreePtr(ref _addFsSourcePathPtr);
                    FreePtr(ref _addWimTargetPathPtr);
                    FreePtr(ref _addConfigFilePtr);
                    break;
                case UpdateOp.DELETE:
                    FreePtr(ref _delWimPathPtr);
                    break;
                case UpdateOp.RENAME:
                    FreePtr(ref _renWimSourcePathPtr);
                    FreePtr(ref _renWimTargetPathPtr);
                    break;
            }
        }

        internal static void FreePtr(ref IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
                Marshal.FreeHGlobal(ptr);
            ptr = IntPtr.Zero;
        }

        internal static void UpdatePtr(ref IntPtr ptr, string str)
        {
            FreePtr(ref ptr);
            ptr = NativeMethods.MarshalStringToPtr(str);
        }
        #endregion

        #region ToManagedClass
        public UpdateCommand ToManagedClass()
        {
            switch (Op)
            {
                case UpdateOp.ADD:
                    return UpdateCommand.SetAdd(AddFsSourcePath, AddWimTargetPath, AddConfigFile, AddFlags);
                case UpdateOp.DELETE:
                    return UpdateCommand.SetDelete(DelWimPath, DeleteFlags);
                case UpdateOp.RENAME:
                    return UpdateCommand.SetRename(RenWimSourcePath, RenWimTargetPath);
                default:
                    throw new InvalidOperationException("Internal Logic Error at UpdateCommand32.Convert()");
            }
        }
        #endregion
    }
    #endregion

    #region UpdateCommand64
    [StructLayout(LayoutKind.Explicit)]
    public struct UpdateCommand64
    {
        [FieldOffset(0)]
        public UpdateOp Op;

        #region UpdateAddCommand
        /// <summary>
        /// Filesystem path to the file or directory tree to add.
        /// </summary>
        [FieldOffset(8)]
        private IntPtr _addFsSourcePathPtr;
        public string AddFsSourcePath
        {
            get => NativeMethods.MarshalPtrToString(_addFsSourcePathPtr);
            set => UpdatePtr(ref _addFsSourcePathPtr, value);
        }
        /// <summary>
        /// Destination path in the image.  To specify the root directory of the image, use Wim.RootPath.
        /// </summary>
        [FieldOffset(16)]
        private IntPtr _addWimTargetPathPtr;
        public string AddWimTargetPath
        {
            get => NativeMethods.MarshalPtrToString(_addWimTargetPathPtr);
            set => UpdatePtr(ref _addWimTargetPathPtr, value);
        }
        /// <summary>
        /// Path to capture configuration file to use, or null if not specified.
        /// </summary>
        [FieldOffset(24)]
        private IntPtr _addConfigFilePtr;
        public string AddConfigFile
        {
            get => NativeMethods.MarshalPtrToString(_addConfigFilePtr);
            set => UpdatePtr(ref _addConfigFilePtr, value);
        }
        /// <summary>
        /// Bitwise OR of AddFlags.
        /// </summary>
        [FieldOffset(32)]
        public AddFlags AddFlags;
        #endregion

        #region UpdateDeleteCommand
        /// <summary>
        /// The path to the file or directory within the image to delete.
        /// </summary>
        [FieldOffset(8)]
        private IntPtr _delWimPathPtr;
        public string DelWimPath
        {
            get => NativeMethods.MarshalPtrToString(_delWimPathPtr);
            set => UpdatePtr(ref _delWimPathPtr, value);
        }
        /// <summary>
        /// Bitwise OR of DeleteFlags.
        /// </summary>
        [FieldOffset(16)]
        public DeleteFlags DeleteFlags;
        #endregion

        #region UpdateRenameCommand
        /// <summary>
        /// The path to the source file or directory within the image.
        /// </summary>
        [FieldOffset(8)]
        private IntPtr _renWimSourcePathPtr;
        public string RenWimSourcePath
        {
            get => NativeMethods.MarshalPtrToString(_renWimSourcePathPtr);
            set => UpdatePtr(ref _renWimSourcePathPtr, value);
        }
        /// <summary>
        /// The path to the destination file or directory within the image.
        /// </summary>
        [FieldOffset(16)]
        private IntPtr _renWimTargetPathPtr;
        public string RenWimTargetPath
        {
            get => NativeMethods.MarshalPtrToString(_renWimTargetPathPtr);
            set => UpdatePtr(ref _renWimTargetPathPtr, value);
        }
        /// <summary>
        /// Reserved; set to 0. 
        /// </summary>
        [FieldOffset(24)]
        private int _renameFlags;
        #endregion

        #region Free
        public void Free()
        {
            switch (Op)
            {
                case UpdateOp.ADD:
                    FreePtr(ref _addFsSourcePathPtr);
                    FreePtr(ref _addWimTargetPathPtr);
                    FreePtr(ref _addConfigFilePtr);
                    break;
                case UpdateOp.DELETE:
                    FreePtr(ref _delWimPathPtr);
                    break;
                case UpdateOp.RENAME:
                    FreePtr(ref _renWimSourcePathPtr);
                    FreePtr(ref _renWimTargetPathPtr);
                    break;
            }
        }

        internal static void FreePtr(ref IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
                Marshal.FreeHGlobal(ptr);
            ptr = IntPtr.Zero;
        }

        internal static void UpdatePtr(ref IntPtr ptr, string str)
        {
            FreePtr(ref ptr);
            ptr = NativeMethods.MarshalStringToPtr(str);
        }
        #endregion

        #region ToManagedClass
        public UpdateCommand ToManagedClass()
        {
            switch (Op)
            {
                case UpdateOp.ADD:
                    return UpdateCommand.SetAdd(AddFsSourcePath, AddWimTargetPath, AddConfigFile, AddFlags);
                case UpdateOp.DELETE:
                    return UpdateCommand.SetDelete(DelWimPath, DeleteFlags);
                case UpdateOp.RENAME:
                    return UpdateCommand.SetRename(RenWimSourcePath, RenWimTargetPath);
                default:
                    throw new InvalidOperationException("Internal Logic Error at UpdateCommand64.Convert()");
            }
        }
        #endregion
    }
    #endregion
    #endregion

    #region Struct DirEntry
    /// <summary>
    /// Structure passed to the Wim.IterateDirTree() callback function.
    /// Roughly, the information about a "file" in the WIM image --- but really a directory entry ("dentry") because hard links are allowed.
    /// The HardLinkGroupId field can be used to distinguish actual file inodes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct DirEntryBase
    {
        /// <summary>
        /// Name of the file, or null if this file is unnamed. Only the root directory of an image will be unnamed.
        /// </summary>
        public string FileName => NativeMethods.MarshalPtrToString(_fileNamePtr);
        private IntPtr _fileNamePtr;
        /// <summary>
        /// 8.3 name (or "DOS name", or "short name") of this file; or null if this file has no such name.
        /// </summary>
        public string DosName => NativeMethods.MarshalPtrToString(_dosNamePtr);
        private IntPtr _dosNamePtr;
        /// <summary>
        /// Full path to this file within the image.
        /// Path separators will be Wim.PathSeparator.
        /// </summary>
        public string FullPath => NativeMethods.MarshalPtrToString(_fullPathPtr);
        private IntPtr _fullPathPtr;
        /// <summary>
        /// Depth of this directory entry, where 0 is the root, 1 is the root's children, ..., etc.
        /// </summary>
        public ulong Depth => DepthVal.ToUInt64();
        private UIntPtr DepthVal; // size_t
        /// <summary>
        /// Pointer to the security descriptor for this file, in Windows SECURITY_DESCRIPTOR_RELATIVE format,
        /// or null if this file has no security descriptor.
        /// </summary>
        public byte[] SecurityDescriptor
        {
            get
            {
                if (SecurityDescriptorPtr == IntPtr.Zero)
                    return null;

                byte[] buf = new byte[SecurityDescriptorSize];
                Marshal.Copy(SecurityDescriptorPtr, buf, 0, (int)_securityDescriptorSizeVal.ToUInt32());
                return buf;
            }
        }
        public IntPtr SecurityDescriptorPtr;
        /// <summary>
        /// Size of the above security descriptor, in bytes. 
        /// </summary>
        public ulong SecurityDescriptorSize => _securityDescriptorSizeVal.ToUInt64();
        private UIntPtr _securityDescriptorSizeVal; // size_t
        /// <summary>
        /// File attributes, such as whether the file is a directory or not.
        /// These are the "standard" Windows FILE_ATTRIBUTE_* values.
        /// </summary>
        public FileAttribute Attributes;
        /// <summary>
        /// If the file is a reparse point (FileAttribute.REPARSE_POINT set in the attributes), this will give the reparse tag.
        /// This tells you whether the reparse point is a symbolic link, junction point, or some other, more unusual kind of reparse point.
        /// </summary>
        public ReparseTag ReparseTag;
        /// <summary>
        /// Number of links to this file's inode (hard links).
        ///
        /// Currently, this will always be 1 for directories.
        /// However, it can be greater than 1 for nondirectory files.
        /// </summary>
        public uint NumLinks;
        /// <summary>
        /// Number of named data streams this file has.
        /// Normally 0.
        /// </summary>
        public uint NumNamedStreams;
        /// <summary>
        /// A unique identifier for this file's inode.
        /// However, as a special case, if the inode only has a single link (NumLinks == 1), this value may be 0.
        ///
        /// Note: if a WIM image is captured from a filesystem, this value is not
        /// guaranteed to be the same as the original number of the inode on the filesystem.
        /// </summary>
        public ulong HardLinkGroupId;
        /// <summary>
        /// Time this file was created.
        /// </summary>
        public DateTime CreationTime => _creationTimeVal.ToDateTime(_creationTimeHigh);
        private WimTimeSpec _creationTimeVal;
        /// <summary>
        /// Time this file was last written to.
        /// </summary>
        public DateTime LastWriteTime => _lastWriteTimeVal.ToDateTime(_lastWriteTimeHigh);
        private WimTimeSpec _lastWriteTimeVal;
        /// <summary>
        /// Time this file was last accessed.
        /// </summary>
        public DateTime LastAccessTime => _lastAccessTimeVal.ToDateTime(_lastAccessTimeHigh);
        private WimTimeSpec _lastAccessTimeVal;
        /// <summary>
        /// The UNIX user ID of this file.
        /// This is a wimlib extension.
        ///
        /// This field is only valid if UnixMode != 0.
        /// </summary>
        public uint UnixUserId;
        /// <summary>
        /// The UNIX group ID of this file.
        /// This is a wimlib extension.
        ///
        /// This field is only valid if UnixMode != 0.
        /// </summary>
        public uint UnixGroupId;
        /// <summary>
        /// The UNIX mode of this file.
        /// This is a wimlib extension.
        ///
        /// If this field is 0, then UnixUid, UnixGid, UnixMode, and UnixRootDevice are all unknown
        /// (fields are not present in the WIM/ image).
        /// </summary>
        public uint UnixMode;
        /// <summary>
        /// The UNIX device ID (major and minor number) of this file.
        /// This is a wimlib extension.
        ///
        /// This field is only valid if UnixMode != 0.
        /// </summary>
        public uint UnixRootDevice;
        /// <summary>
        /// The object ID of this file, if any.
        /// Only valid if WimObjectId.ObjectId is not all zeroes.
        /// </summary>
        public WimObjectId ObjectId;

        private int _creationTimeHigh;
        private int _lastWriteTimeHigh;
        private int _lastAccessTimeHigh;
        private int _reserved2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private ulong[] _reserved;
    }

    /// <summary>
    /// Structure passed to the Wim.IterateDirTree() callback function.
    /// Roughly, the information about a "file" in the WIM image --- but really a directory entry ("dentry") because hard links are allowed.
    /// The HardLinkGroupId field can be used to distinguish actual file inodes.
    /// </summary>
    /// <remarks>
    /// Wrapper of DirEntryBase
    /// </remarks>
    public struct DirEntry
    {
        /// <summary>
        /// Name of the file, or null if this file is unnamed. Only the root directory of an image will be unnamed.
        /// </summary>
        public string FileName;
        /// <summary>
        /// 8.3 name (or "DOS name", or "short name") of this file; or null if this file has no such name.
        /// </summary>
        public string DosName;
        /// <summary>
        /// Full path to this file within the image.
        /// Path separators will be Wim.PathSeparator.
        /// </summary>
        public string FullPath;
        /// <summary>
        /// Depth of this directory entry, where 0 is the root, 1 is the root's children, ..., etc.
        /// </summary>
        public ulong Depth;
        /// <summary>
        /// A security descriptor for this file, in Windows SECURITY_DESCRIPTOR_RELATIVE format,
        /// or null if this file has no security descriptor.
        /// </summary>
        public byte[] SecurityDescriptor;
        /// <summary>
        /// File attributes, such as whether the file is a directory or not.
        /// These are the "standard" Windows FILE_ATTRIBUTE_* values.
        /// </summary>
        public FileAttribute Attributes;
        /// <summary>
        /// If the file is a reparse point (FileAttribute.REPARSE_POINT set in the attributes), this will give the reparse tag.
        /// This tells you whether the reparse point is a symbolic link, junction point, or some other, more unusual kind of reparse point.
        /// </summary>
        public ReparseTag ReparseTag;
        /// <summary>
        /// Number of links to this file's inode (hard links).
        ///
        /// Currently, this will always be 1 for directories.
        /// However, it can be greater than 1 for nondirectory files.
        /// </summary>
        public uint NumLinks;
        /// <summary>
        /// Number of named data streams this file has.
        /// Normally 0.
        /// </summary>
        public uint NumNamedStreams;
        /// <summary>
        /// A unique identifier for this file's inode.
        /// However, as a special case, if the inode only has a single link (NumLinks == 1), this value may be 0.
        ///
        /// Note: if a WIM image is captured from a filesystem, this value is not
        /// guaranteed to be the same as the original number of the inode on the filesystem.
        /// </summary>
        public ulong HardLinkGroupId;
        /// <summary>
        /// Time this file was created.
        /// </summary>
        /// <summary>
        /// Time this file was created.
        /// </summary>
        public DateTime CreationTime;
        /// <summary>
        /// Time this file was last written to.
        /// </summary>
        public DateTime LastWriteTime;
        /// <summary>
        /// Time this file was last accessed.
        /// </summary>
        public DateTime LastAccessTime;
        /// <summary>
        /// The UNIX user ID of this file.
        /// This is a wimlib extension.
        ///
        /// This field is only valid if UnixMode != 0.
        /// </summary>
        public uint UnixUserId;
        /// <summary>
        /// The UNIX group ID of this file.
        /// This is a wimlib extension.
        ///
        /// This field is only valid if UnixMode != 0.
        /// </summary>
        public uint UnixGroupId;
        /// <summary>
        /// The UNIX mode of this file.
        /// This is a wimlib extension.
        ///
        /// If this field is 0, then UnixUid, UnixGid, UnixMode, and UnixRootDevice are all unknown
        /// (fields are not present in the WIM/ image).
        /// </summary>
        public uint UnixMode;
        /// <summary>
        /// The UNIX device ID (major and minor number) of this file.
        /// This is a wimlib extension.
        ///
        /// This field is only valid if UnixMode != 0.
        /// </summary>
        public uint UnixRootDevice;
        /// <summary>
        /// The object ID of this file, if any.
        /// Only valid if WimObjectId.ObjectId is not all zeroes.
        /// </summary>
        public WimObjectId ObjectId;
        /// <summary>
        /// Variable-length array of streams that make up this file.
        ///
        /// The first entry will always exist and will correspond to the unnamed data stream (default file contents), 
        /// so it will have (stream_name == null).
        /// Alternatively, for reparse point files, the first entry will correspond to the reparse data stream.
        /// Alternatively, for encrypted files, the first entry will correspond to the encrypted data.
        ///
        /// Then, following the first entry, there be NumNamedStreams additional entries that specify the named data streams,
        /// if any, each of which will have (stream_name != null).
        /// </summary>
        public StreamEntry[] Streams;
    }

    [Flags]
    public enum FileAttribute : uint
    {
        READONLY = 0x00000001,
        HIDDEN = 0x00000002,
        SYSTEM = 0x00000004,
        DIRECTORY = 0x00000010,
        ARCHIVE = 0x00000020,
        DEVICE = 0x00000040,
        NORMAL = 0x00000080,
        TEMPORARY = 0x00000100,
        SPARSE_FILE = 0x00000200,
        REPARSE_POINT = 0x00000400,
        COMPRESSED = 0x00000800,
        OFFLINE = 0x00001000,
        NOT_CONTENT_INDEXED = 0x00002000,
        ENCRYPTED = 0x00004000,
        VIRTUAL = 0x00010000,
    }

    public enum ReparseTag : uint
    {
        RESERVED_ZERO = 0x00000000,
        RESERVED_ONE = 0x00000001,
        MOUNT_POINT = 0xA0000003,
        HSM = 0xC0000004,
        HSM2 = 0x80000006,
        DRIVER_EXTENDER = 0x80000005,
        SIS = 0x80000007,
        DFS = 0x8000000A,
        DFSR = 0x80000012,
        FILTER_MANAGER = 0x8000000B,
        WOF = 0x80000017,
        SYMLINK = 0xA000000C,
    }
    #endregion

    #region Struct WimTimeSpec
    [StructLayout(LayoutKind.Sequential)]
    internal struct WimTimeSpec
    {
        /// <summary>
        /// Seconds since start of UNIX epoch (January 1, 1970)
        /// </summary>
        public long UnixEpoch => _unixEpochVal.ToInt64();
        private IntPtr _unixEpochVal; // int64_t in 64bit, int32_t in 32bit
        /// <summary>
        /// Nanoseconds (0-999999999)
        /// </summary>
        public int NanoSeconds;

        internal DateTime ToDateTime(int high)
        {
            // C# DateTime has a resolution of 100ns
            DateTime genesis = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            genesis = genesis.AddSeconds(UnixEpoch);
            genesis = genesis.AddTicks(NanoSeconds / 100);

            // wimlib provide high 32bit separately if timespec.tv_sec is only 32bit
            if (IntPtr.Size == 4)
            {
                long high64 = (long)high << 32;
                genesis = genesis.AddSeconds(high64);
            }

            return genesis;
        }
    }
    #endregion

    #region Struct WimObjectId
    /// <summary>
    /// Since wimlib v1.9.1: an object ID, which is an extra piece of metadata that may be associated with a file on NTFS filesystems. 
    /// See: https://msdn.microsoft.com/en-us/library/windows/desktop/aa363997(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WimObjectId
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ObjectId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BirthVolumeId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BirthObjectId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] DomainId;
    }
    #endregion

    #region Struct ResourceEntry
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class ResourceEntry
    {
        public ulong UncompressedSize;
        public ulong CompressedSize;
        public ulong Offset;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] SHA1;
        public uint PartNumber;
        public uint ReferenceCount;
        private uint _bitFlag;
        public bool IsCompressed => NativeMethods.GetBitField(_bitFlag, 0);
        public bool IsMetadata => NativeMethods.GetBitField(_bitFlag, 1);
        public bool IsFree => NativeMethods.GetBitField(_bitFlag, 2);
        public bool IsSpanned => NativeMethods.GetBitField(_bitFlag, 3);
        public bool IsMissing => NativeMethods.GetBitField(_bitFlag, 4);
        public bool Packed => NativeMethods.GetBitField(_bitFlag, 5);
        public ulong RawResourceOffsetInWim;
        public ulong RawResourceCompressedSize;
        public ulong RawResourceUncompressedSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        private ulong[] _reserved;
    }
    #endregion

    #region Struct StreamEntry
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct StreamEntry
    {
        public string StreamName;
        public ResourceEntry Resource;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]

        private ulong[] _reserved;
    }
    #endregion
    #endregion
}