using System;
using System.Runtime.InteropServices;

namespace IntegrateOS
{
        public static class NativeStructures
        {
            public enum DismLogLevel
            {
                LogErrors = 0, LogErrorsWarnings, LogErrorsWarningsInfo,
            }

            public enum DismImageIdentifier
            {
                ImageIndex = 0, ImageName,
            }

            public struct DismMountMode
            {
                public static uint ReadWrite = NativeConstants.DISM_MOUNT_READWRITE;
                public static uint ReadOnly = NativeConstants.DISM_MOUNT_READONLY;
            }

            public enum DismImageBootable
            {
                ImageBootableYes = 0, ImageBootableNo, ImageBootableUnknown,
            }

            public enum ProcessorArchitecture
            {
                None = -1, Intel = 0, IA64 = 6, AMD64 = 9, ARM = 5, ARM64 = 12, Neutral = 11,
            }

            public enum ImageFileType
            {
                Unsupported = -1, Wim = 0, Vhd = 1,
            }
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
            internal struct DismImageInfo_
            {
                public ImageFileType ImageType;
                public uint ImageIndex;
                public string ImageName;
                public string ImageDescription;
                public ulong ImageSize;
                public ProcessorArchitecture Architecture;
                public string ProductName;
                public string EditionId;
                public string InstallationType;
                public string Hal;
                public string ProductType;
                public string ProductSuite;
                public uint MajorVersion;
                public uint MinorVersion;
                public uint Build;
                public uint SpBuild;
                public uint SpLevel;
                public DismImageBootable Bootable;
                public string SystemRoot;
                public IntPtr Language;
                public uint LanguageCount;
                public uint DefaultLanguageIndex;
                public IntPtr CustomizedInfo;
            }

            public enum WimApplyImageOptions : uint
            {
                FileInfo = 0x00000080,
                Index = 0x00000004, NoApply = 0x00000008, None = 0,
                DisableDirectoryAcl = 0x00000010, DisableFileAcl = 0x00000020,
                DisableRPFix = 0x00000100, Verify = 0x00000002,
            }

            [Flags]
            public enum WimCreateFileOptions : uint
            {
                None = 0, Chunked = 0x20000000, ShareWrite = 0x00000040, Verify = 0x00000002,
            }

            public enum WimCreationDisposition : uint
            {
                CreateAlways = 0x00000002, CreateNew = 0x00000001, OpenAlways = 0x00000004, OpenExisting = 0x00000003,
            }

            public enum WimCreationResult : uint
            {
                CreatedNew = 0, OpenedExisting = 1,
            }

            public enum WimCompressionType : uint
            {
               Lzms = 3, Lzx = 2, Xpress = 1, None = 0,
            }

            [Flags]
            public enum WimFileAccess : uint
            {
                Mount = 0x20000000, Query = 0, Read = 0x20000000, Write = 0x40000000,
            }

            public enum WimExportImageOptions : uint
            {
                AllowDuplicates = 0x00000001,
                MetadataOnly = 0x00000004,
                None = 0,
                ResourcesOnly = 0x00000002,
            }

        }
}
