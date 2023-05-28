using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static PInvoke.User32;

namespace MSNLD_Chat_Client
{
    public class WhisperManager
    {
        public event EventHandler<WhisperEventArgs>? WhisperWindowOpened;
        public event EventHandler<WhisperEventArgs>? WhisperWindowClosed;
        Dictionary<IntPtr, string> WhisperWindows = new Dictionary<IntPtr, string>();

        public WhisperManager()
        {
            SetWinEventHook(WindowsEventHookType.EVENT_OBJECT_CREATE, WindowsEventHookType.EVENT_OBJECT_DESTROY, IntPtr.Zero, Wineventproc, 0, 0, WindowsEventHookFlags.WINEVENT_OUTOFCONTEXT);
            // The following could be useful should we wish to hook menus in the future.
            //SetWinEventHook(WindowsEventHookType.EVENT_SYSTEM_MENUSTART, WindowsEventHookType.EVENT_SYSTEM_MENUPOPUPEND, IntPtr.Zero, Wineventproc, 0, 0, WindowsEventHookFlags.WINEVENT_OUTOFCONTEXT);
            // eg. Nicklist Popup Menu
            // Event: EVENT_OBJECT_CREATE 00250DD0 0 0 36444 - Hwnd of ATL:37243F28 which contains both of the ATL:MSNChatListView4 and the Subclassbutton (away)
            // Event: EVENT_SYSTEM_MENUSTART 00390E20 0 0 36444
            // Event: EVENT_SYSTEM_MENUPOPUPSTART 00250DD0 - 4 0 36444
            // -
            // Event: EVENT_SYSTEM_MENUPOPUPEND 00250DD0 - 4 0 36444
            // Event: EVENT_OBJECT_DESTROY 00250DD0 0 0 36444
            // Event: EVENT_SYSTEM_MENUEND 00390E20 0 0 36444
        }

        private void Wineventproc(IntPtr hWinEventHook, WindowsEventHookType @event, IntPtr hwnd, int idObject, int idChild, int dwEventThread, uint dwmsEventTime)
        {
            if (idObject == 0 && idChild == 0)
            {
                if (@event == WindowsEventHookType.EVENT_OBJECT_CREATE)
                {
                    var len = GetWindowTextLength(hwnd);
                    if (len > 0)
                    {
                        char[] windowText = new char[len];
                        if (GetWindowText(hwnd, windowText, len) > 0)
                        {
                            var windowTextBytes = Encoding.UTF8.GetBytes(windowText);
                            var utf8WindowText = Encoding.UTF8.GetString(windowTextBytes, 0, windowTextBytes.Length);

                            //TODO: Will this work in other locales?
                            Regex validWindowRegex = new Regex(@"^(?<nickname>.*): 1 to 1 whisper$");
                            MatchCollection matchedWindowTitle = validWindowRegex.Matches(utf8WindowText);
                            if (matchedWindowTitle.Count > 0)
                            {
                                String nickname = matchedWindowTitle[0].Groups["nickname"].Value;
                                WhisperWindows.Add(hwnd, nickname);
                                WhisperEventArgs args = new WhisperEventArgs();
                                args.hwnd = hwnd;
                                args.title = nickname;
                                OnWhisperWindowOpened(args);
                            }
                        }
                    }
                }
                else if (@event == WindowsEventHookType.EVENT_OBJECT_DESTROY)
                {
                    if (WhisperWindows.ContainsKey(hwnd))
                    {
                        WhisperEventArgs args = new WhisperEventArgs();
                        args.hwnd = hwnd;
                        args.title = WhisperWindows.GetValueOrDefault(hwnd, "");
                        WhisperWindows.Remove(hwnd);
                        OnWhisperWindowClosed(args);
                    }
                }
            }
        }

        protected virtual void OnWhisperWindowOpened(WhisperEventArgs e)
        {
            WhisperWindowOpened?.Invoke(this, e);
        }

        protected virtual void OnWhisperWindowClosed(WhisperEventArgs e)
        {
            WhisperWindowClosed?.Invoke(this, e);
        }
    }

    public class WhisperEventArgs : EventArgs
    {
        public IntPtr hwnd { get; set; }
        public string? title { get; set; }
    }
}
