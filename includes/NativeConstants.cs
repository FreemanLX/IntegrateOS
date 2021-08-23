namespace IntegrateOS
{
     public static class NativeConstants
     {
            public const uint DISM_MOUNT_READONLY = 0x00000001;
            public const uint DISM_MOUNT_READWRITE = 0x00000000;
            public const uint DISMAPI_E_DISMAPI_NOT_INITIALIZED = 0xC0040001;
            internal const int ERROR_SUCCESS = 0x00000000;
            public const uint DISM_DISCARD_IMAGE = 0x00000001;
            public const uint DISM_COMMIT_IMAGE = 0x00000000;
     }
}
