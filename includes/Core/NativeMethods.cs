using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading;

namespace IntegrateOS
{
        public static class NativeMethods
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
                        get; set;
                    }
                    public int Current
                    {
                        get; private set;
                    }

                    public int Total
                    {
                        get; private set;
                    }
                    public object UserData
                    {
                        get; private set;
                    }

                    internal SafeWaitHandle EventHandle => _eventHandle.SafeWaitHandle;
                    public void Dispose() => _eventHandle?.Dispose();
                }


                public sealed class WimHandle : SafeHandleZeroOrMinusOneIsInvalid{

                    public static readonly WimHandle Null = new WimHandle();
                    internal WimHandle() : base(true) => handle = IntPtr.Zero;

                    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
                    protected override bool ReleaseHandle() => !IsInvalid && CloseHandle(handle);
                }

                internal static bool CloseHandle(IntPtr handle)
                {
                    if (!WIMCloseHandle(handle))
                    {
                        throw new System.ComponentModel.Win32Exception();
                    }
                    return true;
                }

            /// <summary>
            /// Splits a wim file
            /// </summary>
            /// <param name="hWim"></param>
            /// <param name="pszPartPath"></param>
            /// <param name="pliPartSize"></param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMSplitFile(WimHandle hWim, string pszPartPath, ref long pliPartSize, uint dwFlags);


            /// <summary>
            /// DismDelete - entrypoint from dismapi.dll
            /// Deletes a dism structure
            /// </summary>
            /// <param name="structure">Dism structure</param>
            /// <returns>Returns the error code if fail otherwise it returns 0</returns>
            [DllImport("dismapi.dll", CharSet = CharSet.Ansi)]
            [return: MarshalAs(UnmanagedType.Error)]
            public static extern int DismDelete(IntPtr structure);


            /// <summary>
            /// WimApplyImage - entrypoint function from wimgapi.dll
            /// Applies windows image to a partition
            /// </summary>
            /// <param name="wimHandle">A created handle for wim images, contains the wim location</param>
            /// <param name="path">The apply path</param>
            /// <param name="flags">The apply flags</param>
            /// <returns>Returns true when the function completed succesfully otherwise returns false (You need to use Win32Exception())</returns>            
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMApplyImage(WimHandle wimHandle, string path, uint flags);


            /// <summary>
            /// WimLoadImage - entrypoint function from wimgapi.dll
            /// Loads a selected Windows Edition from the selected wim.
            /// </summary>
            /// <param name="wimHandle">The wim handle, opened from the selected wim</param>
            /// <param name="ImageIndex">The selected number of selected windows edition</param>
            /// <returns>Returns a WimHandle based on the selected windows edition</returns>
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern WimHandle WIMLoadImage(WimHandle wimHandle, uint ImageIndex);


            /// <summary>
            /// Creates or opens a wim image 
            /// </summary>
            /// <param name="wimpath">Wim path</param>
            /// <param name="wimaccess">Wim access type</param>
            /// <param name="creationdisposition">Creating / opening flags</param>
            /// <param name="flags">Wim Flags</param>
            /// <param name="compression">Wim Compression Type</param>
            /// <param name="creationResult">Wim creation result</param>
            /// <returns>Wimhandle</returns>
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern WimHandle WIMCreateFile(string wimpath, uint wimaccess, uint creationdisposition, uint flags, uint compression, out NativeStructures.WimCreationResult creationResult);


            /// <summary>
            /// It is a progress call back, which measures how much it takes to complete a DISM operation
            /// </summary>
            /// <param name="current"></param>
            /// <param name="total"></param>
            /// <param name="userData"></param>
            public delegate void DismProgressCallback(uint current, uint total, IntPtr userData);
            

            /// <summary>
            /// GetImageInfo - entrypoint
            /// </summary>
            /// <param name="imageFilePath">The selected image file cand be wim / esd or swm</param>
            /// <param name="imageInfo">Returns a pointer that can be converted on a list</param>
            /// <param name="count">How many windows editions does have the selected image file</param>
            /// <returns>Error code</returns>
            [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Error)]
            public static extern int DismGetImageInfo(string imageFilePath, out IntPtr imageInfo, out UInt32 count);


            /// <summary>
            /// 
            /// </summary>
            /// <param name="logLevel"></param>
            /// <param name="logFilePath"></param>
            /// <param name="scratchDirectory"></param>
            /// <returns></returns>
            [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Error)]
            public static extern uint DismInitialize(NativeStructures.DismLogLevel logLevel, string logFilePath, string scratchDirectory);


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Error)]
            public static extern uint DismShutdown();


            /// <summary>
            /// 
            /// </summary>
            /// <param name="imageFilePath"></param>
            /// <param name="mountPath"></param>
            /// <param name="imageIndex"></param>
            /// <param name="imageName"></param>
            /// <param name="imageIdentifier"></param>
            /// <param name="flags"></param>
            /// <param name="cancelEvent"></param>
            /// <param name="progress"></param>
            /// <param name="userData"></param>
            /// <returns></returns>
            [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Error)]
            public static extern uint DismMountImage(string imageFilePath, string mountPath, uint imageIndex, string imageName, NativeStructures.DismImageIdentifier imageIdentifier, uint flags, SafeWaitHandle cancelEvent, DismProgressCallback progress, IntPtr userData);


            /// <summary>
            /// 
            /// </summary>
            /// <param name="mountPath"></param>
            /// <param name="flags"></param>
            /// <param name="cancelEvent"></param>
            /// <param name="progress"></param>
            /// <param name="userData"></param>
            /// <returns></returns>
            [DllImport("dismapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Error)]
            public static extern int DismUnmountImage(string mountPath, uint flags, SafeWaitHandle cancelEvent, DismProgressCallback progress, IntPtr userData);


            /// <summary>
            /// 
            /// </summary>
            /// <param name="hObject"></param>
            /// <returns></returns>
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMCloseHandle(IntPtr hObject);
            

            /// <summary>
            /// 
            /// </summary>
            /// <param name="hWim"></param>
            /// <param name="pszPath"></param>
            /// <returns></returns>
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMSetTemporaryPath(WimHandle hWim, [MarshalAs(UnmanagedType.LPWStr)]string pszPath);


            /// <summary>
            /// 
            /// </summary>
            /// <param name="hWim"></param>
            /// <returns></returns>
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern uint WIMGetImageCount(WimHandle hWim);


            /// <summary>
            /// 
            /// </summary>
            /// <param name="hImage"></param>
            /// <param name="hWim"></param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport("wimgapi.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WIMExportImage(WimHandle hImage, WimHandle hWim, UInt32 dwFlags);

        }
}
