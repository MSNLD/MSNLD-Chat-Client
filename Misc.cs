using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PInvoke.User32;

namespace MSNLD_Chat_Client
{
    internal class Misc
    {
        internal static Icon? GetAppIcon(IntPtr hwnd)
        {
            // https://learn.microsoft.com/en-us/windows/win32/winmsg/wm-geticon
            const int ICON_BIG = 1; // Retrieve the large icon for the window.
            const int ICON_SMALL = 0; // Retrieve the small icon for the window.
            const int ICON_SMALL2 = 2; // Retrieves the small icon provided by the application. If the application does
                                       // not provide one, the system uses the system - generated icon for that window.

            IntPtr iconHandle = SendMessage(hwnd, PInvoke.User32.WindowMessage.WM_GETICON, ICON_SMALL2, 0);
            if (iconHandle == IntPtr.Zero)
                iconHandle = SendMessage(hwnd, PInvoke.User32.WindowMessage.WM_GETICON, ICON_SMALL, 0);
            if (iconHandle == IntPtr.Zero)
                iconHandle = SendMessage(hwnd, PInvoke.User32.WindowMessage.WM_GETICON, ICON_BIG, 0);
            if (iconHandle == IntPtr.Zero)
                return null;

            return Icon.FromHandle(iconHandle);
        }
    }
}
