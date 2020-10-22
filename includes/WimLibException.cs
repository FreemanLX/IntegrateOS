using System;
using System.Text;

namespace ManagedWimLib
{
    #region WimLibException
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
