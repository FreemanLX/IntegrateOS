using System;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedWimLib
{

    #region IterateDirTreeCallback
    public delegate CallbackStatus IterateDirTreeCallback(DirEntry dentry, object userData);

    public class ManagedIterateDirTreeCallback
    {
        private readonly IterateDirTreeCallback _callback;
        private readonly object _userData;

        internal NativeMethods.NativeIterateDirTreeCallback NativeFunc { get; }

        public ManagedIterateDirTreeCallback(IterateDirTreeCallback callback, object userData)
        {
            _callback = callback;
            _userData = userData;
            NativeFunc = NativeCallback;
        }

        private CallbackStatus NativeCallback(IntPtr entryPtr, IntPtr userCtx)
        {
            CallbackStatus ret = CallbackStatus.CONTINUE;
            if (_callback == null)
                return ret;

            DirEntryBase b = Marshal.PtrToStructure<DirEntryBase>(entryPtr);
            DirEntry dentry = new DirEntry
            {
                FileName = b.FileName,
                DosName = b.DosName,
                FullPath = b.FullPath,
                Depth = b.Depth,
                SecurityDescriptor = b.SecurityDescriptor,
                Attributes = b.Attributes,
                ReparseTag = b.ReparseTag,
                NumLinks = b.NumLinks,
                NumNamedStreams = b.NumNamedStreams,
                HardLinkGroupId = b.HardLinkGroupId,
                CreationTime = b.CreationTime,
                LastWriteTime = b.LastWriteTime,
                LastAccessTime = b.LastAccessTime,
                UnixUserId = b.UnixUserId,
                UnixGroupId = b.UnixGroupId,
                UnixMode = b.UnixMode,
                UnixRootDevice = b.UnixRootDevice,
                ObjectId = b.ObjectId,
                Streams = new StreamEntry[b.NumNamedStreams + 1],
            };

            IntPtr baseOffset = IntPtr.Add(entryPtr, Marshal.SizeOf<DirEntryBase>());
            for (int i = 0; i < dentry.Streams.Length; i++)
            {
                IntPtr offset = IntPtr.Add(baseOffset, i * Marshal.SizeOf<StreamEntry>());
                dentry.Streams[i] = Marshal.PtrToStructure<StreamEntry>(offset);
            }

            ret = _callback(dentry, _userData);

            return ret;
        }
    }
    #endregion

    #region IterateLookupTableCallback
    public delegate CallbackStatus IterateLookupTableCallback(ResourceEntry resource, object userCtx);

    public class ManagedIterateLookupTableCallback
    {
        private readonly IterateLookupTableCallback _callback;
        private readonly object _userData;

        internal NativeMethods.NativeIterateLookupTableCallback NativeFunc { get; }

        public ManagedIterateLookupTableCallback(IterateLookupTableCallback callback, object userData)
        {
            _callback = callback;
            _userData = userData;

            // Avoid GC by keeping ref here
            NativeFunc = NativeCallback;
        }

        private CallbackStatus NativeCallback(ResourceEntry resource, IntPtr userCtx)
        {
            if (_callback == null)
                return CallbackStatus.CONTINUE;

            return _callback(resource, _userData);
        }
    }
    #endregion

    #region StringHelper
    internal class StringHelper
    {
        public static string ReplaceEx(string str, string oldValue, string newValue, StringComparison comp)
        {
            if (oldValue.Length == 0)
                return str;
            if (str.IndexOf(oldValue, comp) == -1)
                return str;

            int idx = 0;
            StringBuilder b = new StringBuilder();
            while (idx < str.Length)
            {
                int vIdx = str.IndexOf(oldValue, idx, comp);
                if (vIdx == -1)
                {
                    b.Append(str.Substring(idx));
                    break;
                }

                b.Append(str.Substring(idx, vIdx - idx));
                b.Append(newValue);
                idx = vIdx + oldValue.Length;
            }
            return b.ToString();
        }
    }
    #endregion


    #region WimLibException
    [Serializable]
    public class WimLibException : Exception
    {
        public ErrorCode ErrorCode;

        public WimLibException(ErrorCode errorCode)
            : base(ForgeErrorMessages(errorCode, true))
        {
            ErrorCode = errorCode;
        }

        internal static string ForgeErrorMessages(ErrorCode errorCode, bool full)
        {
            StringBuilder b = new StringBuilder();

            if (full)
                b.Append($"[{errorCode}] ");

            b.Append(Wim.GetLastError() ?? Wim.GetErrorString(errorCode));

            return b.ToString();
        }

        internal static void CheckWimLibError(ErrorCode ret)
        {
            if (ret != ErrorCode.SUCCESS)
                throw new WimLibException(ret);
        }
    }
    #endregion
}
