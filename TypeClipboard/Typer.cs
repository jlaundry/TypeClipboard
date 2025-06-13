using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace TypeClipboard
{
    public class Typer
    {
        private const int INTERKEY_DELAY = 50;

        private bool _typeEnter = false;
        private string _typeMethod = "SendInput";
        public bool TypeEnter { get => _typeEnter; set => _typeEnter = value; }

        public string TypeMethod { get => _typeMethod; set => _typeMethod = value; }

        public void Type(String str, int delay = 2000)
        {
            Thread.Sleep(delay);
            NativeMethods.BlockInput(true);
            //KeyboardTyper.Reset();

            KeyboardTyper.Type(str, _typeEnter, INTERKEY_DELAY);

            NativeMethods.BlockInput(false);

        }

        public void TypeWithSendKeys(String str, int delay)
        {
            Thread.Sleep(delay);
            foreach (Char c in str.ToCharArray())
            {
                // Some characters have special meaning
                // https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/sendkeys-statement
                switch (c)
                {
                    case '\n':
                        if (_typeEnter)
                        {
                            SendKeys.Send("{ENTER}");
                            break;
                        }
                        else
                        {
                            return;
                        }
                    case '\r':
                        if (_typeEnter)
                        {
                            break;
                        }
                        else
                        {
                            return;
                        }
                    case '{':
                        SendKeys.Send("{{}");
                        break;
                    case '}':
                        SendKeys.Send("{}}");
                        break;
                    case '+':
                        SendKeys.Send("{+}");
                        break;
                    case '^':
                        SendKeys.Send("{^}");
                        break;
                    case '%':
                        SendKeys.Send("{%}");
                        break;
                    case '~':
                        SendKeys.Send("{~}");
                        break;
                    case '(':
                        SendKeys.Send("{(}");
                        break;
                    case ')':
                        SendKeys.Send("{)}");
                        break;
                    default:
                        SendKeys.Send(c.ToString());
                        break;
                }
                Thread.Sleep(INTERKEY_DELAY);
            }
        }

        public void TypeClipboard(int delay = 2000)
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                String clipboard = Clipboard.GetText(TextDataFormat.UnicodeText);
                if (_typeMethod == "SendKeys")
                {
                    TypeWithSendKeys(clipboard, delay);
                }
                else
                {
                    // SendInput is default
                    Type(clipboard, delay);
                }
            }
        }
    }

    // https://gist.github.com/obviliontsk/90403a0fea8c24258570f3a577704864

    /// <summary>
    /// Native methods
    /// </summary>
    public static partial class NativeMethods
    {
        // See http://msdn.microsoft.com/en-us/library/ms649021%28v=vs.85%29.aspx
        public const int WM_CLIPBOARDUPDATE = 0x031D;
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);

        // See http://msdn.microsoft.com/en-us/library/ms632599%28VS.85%29.aspx#message_only
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        // See http://msdn.microsoft.com/en-us/library/ms633541%28v=vs.85%29.aspx
        // See http://msdn.microsoft.com/en-us/library/ms649033%28VS.85%29.aspx
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //User32 wrappers cover API's used for Mouse input
        #region User32
        // Two special bitMasks we define to be able to grab
        // shift and character information out of a VKey.
        internal const int VKeyShiftMask = 0x0100;
        internal const int VKeyCharMask = 0x00FF;

        // Various Win32 constants
        internal const int KeyeventfExtendedkey = 0x0001;
        internal const int KeyeventfKeyup = 0x0002;
        internal const int KeyeventfUnicode = 0x0004;
        internal const int KeyeventfScancode = 0x0008;


        internal const int MouseeventfVirtualdesk = 0x4000;

        internal const int SMXvirtualscreen = 76;
        internal const int SMYvirtualscreen = 77;
        internal const int SMCxvirtualscreen = 78;
        internal const int SMCyvirtualscreen = 79;

        internal const int XButton1 = 0x0001;
        internal const int XButton2 = 0x0002;
        internal const int WheelDelta = 120;

        internal const int InputMouse = 0;
        internal const int InputKeyboard = 1;

        // Various Win32 data structures
        [StructLayout(LayoutKind.Sequential)]
        internal struct INPUT
        {
            internal int type;
            internal INPUTUNION union;
        };

        [StructLayout(LayoutKind.Explicit)]
        internal struct INPUTUNION
        {
            [FieldOffset(0)]
            internal MOUSEINPUT mouseInput;
            [FieldOffset(0)]
            internal KEYBDINPUT keyboardInput;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            internal int dx;
            internal int dy;
            internal int mouseData;
            internal int dwFlags;
            internal int time;
            internal IntPtr dwExtraInfo;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT
        {
            internal short wVk;
            internal short wScan;
            internal int dwFlags;
            internal int time;
            internal IntPtr dwExtraInfo;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public readonly int X;
            public readonly int Y;
        }

        [Flags]
        internal enum SendMouseInputFlags
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            Absolute = 0x8000,
        };

        // Importing various Win32 APIs that we need for input
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        // DllImport CharSet = CharSet.Auto -> Unicode / Utf.16 for windows, so 'W'
        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyW")]
        public static extern int MapVirtualKey(int nVirtKey, int nMapType);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendInput(int nInputs, ref INPUT mi, int cbSize);

        [DllImport("user32.dll", EntryPoint = "BlockInput")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(out POINT lpPoint);

        #endregion
    }

    /// <summary>
    /// Exposes a simple interface to common keyboard operations, allowing the user to simulate keyboard input.
    /// </summary>
    /// <example>
    /// The following code types "Hello world" with the specified casing,
    /// and then types "hello, capitalized world" which will be in all caps because
    /// the left shift key is being held down.
    /// To send input with hotkeys use BlockInput method (app will need admin rights) to block all users inputs
    /// and reset inputs state, so they won't interfere
    /// <code>
    /**
            NativeMethods.BlockInput(true);
            Keyboard.Reset();

            Keyboard.Type("Hello world");
            Keyboard.Press(Key.LeftShift);
            Keyboard.Type("hello, capitalized world");
            Keyboard.Release(Key.LeftShift);

            NativeMethods.BlockInput(false);
    */
    /// </code>
    /// </example>
    public static class KeyboardTyper
    {
        #region Public Members

        /// <summary>
        /// Presses down a key.
        /// </summary>
        /// <param name="key">The key to press.</param>
        public static void Press(Key key)
        {
            SendKeyboardInput(key, true);
        }

        /// <summary>
        /// Releases a key.
        /// </summary>
        /// <param name="key">The key to release.</param>
        public static void Release(Key key)
        {
            SendKeyboardInput(key, false);
        }

        /// <summary>
        /// Presses down a key.
        /// </summary>
        /// <param name="input">The key to press.</param>
        public static void Press(char input)
        {
            SendKeyboardInput(input, true);
        }

        /// <summary>
        /// Releases a key.
        /// </summary>
        /// <param name="input">The key to release.</param>
        public static void Release(char input)
        {
            SendKeyboardInput(input, false);
        }

        /// <summary>
        /// Resets the system keyboard to a clean state.
        /// </summary>
        public static void Reset()
        {
            return;
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                // TODO System.Windows.Input.Keyboard exists from WPF, this is WinForms...
                //if (key != Key.None && (System.Windows.Input.Keyboard.GetKeyStates(key) & KeyStates.Down) > 0)
                //{
                //    Release(key);
                //}
            }
        }

        /// <summary>
        /// Performs a press-and-release operation for the specified key, which is effectively equivalent to typing.
        /// </summary>
        /// <param name="key">The key to press.</param>
        /// <param name="releaseDelayMs">Delay before key release</param>
        /// <exception cref="ArgumentOutOfRangeException">releaseDelayMs less than 0</exception>
        public static void Type(Key key, int releaseDelayMs = 0)
        {
            if (releaseDelayMs < 0) throw new ArgumentOutOfRangeException(nameof(releaseDelayMs), releaseDelayMs, "Less than zero");
            Press(key);
            if (releaseDelayMs > 0)
                Thread.Sleep(releaseDelayMs);
            Release(key);
        }

        /// <summary>
        /// Performs a press-and-release operation for the specified key specific amount of times.
        /// </summary>
        /// <param name="key">The key to press.</param>
        /// <param name="amountToType"></param>
        /// <param name="inputDelayMs">Delay after releasing key</param>
        /// <param name="releaseDelayMs">Delay before key release</param>
        /// <exception cref="ArgumentOutOfRangeException">releaseDelayMs less than 0 or amountToType less than 1 or inputDelayMs less than 0</exception>
        public static void TypeKeyNTimes(Key key, int amountToType = 1, int inputDelayMs = 0, int releaseDelayMs = 0)
        {
            if (amountToType < 1) throw new ArgumentOutOfRangeException(nameof(amountToType), amountToType, "Less than one");
            if (inputDelayMs < 0) throw new ArgumentOutOfRangeException(nameof(inputDelayMs), releaseDelayMs, "Less than zero");
            for (int i = 0; i < amountToType; i++)
            {
                Type(key, releaseDelayMs);
                if (inputDelayMs > 0)
                    Thread.Sleep(releaseDelayMs);
            }
        }

        /// <summary>
        /// Types the specified text.
        /// </summary>
        /// <param name="text">The text to type.</param>
        /// <param name="inputDelayMs">Delay between typing each key</param>
        /// <param name="releaseDelayMs">Delay before key release</param>
        /// <exception cref="ArgumentOutOfRangeException">releaseDelayMs less than 0 or inputDelayMs less than 0</exception>
        public static void Type(string text, bool typeEnter = false, int inputDelayMs = 0, int releaseDelayMs = 0)
        {
            int delay = 0;

            if (text.Length > 1)
                delay = inputDelayMs;
            foreach (char c in text)
            {
                switch (c)
                {
                    case '\n':
                        if (typeEnter)
                        {
                            Press(Key.Return);
                            if (releaseDelayMs > 0) Thread.Sleep(releaseDelayMs);
                            Release(Key.Return);
                            break;
                        }
                        else
                            // Stop at the first line break
                            return;
                    case '\r':
                        break;
                    default:
                        Type(c, releaseDelayMs);
                        break;
                }

                if (delay > 0) Thread.Sleep(delay);
            }
        }

        /// <summary>
        /// Types the specified char.
        /// </summary>
        /// <param name="input">The char to type.</param>
        /// <param name="releaseDelayMs">Delay before key release</param>
        /// <exception cref="ArgumentOutOfRangeException">releaseDelayMs less than 0 or inputDelayMs less than 0</exception>
        public static void Type(char input, int releaseDelayMs = 0)
        {
            if (releaseDelayMs < 0) throw new ArgumentOutOfRangeException(nameof(releaseDelayMs), releaseDelayMs, "Less than zero");
            Press(input);
            if (releaseDelayMs > 0) Thread.Sleep(releaseDelayMs);
            Release(input);
        }

        /// <summary>
        /// Types a key while a set of modifier keys are being pressed. Modifer keys
        /// are pressed in the order specified and released in reverse order.
        /// </summary>
        /// <param name="key">Key to type.</param>
        /// <param name="modifierKeys">Set of keys to hold down with key is typed.</param>
        /// <param name="releaseDelayMs">Delay before key release</param>
        public static void Type(Key key, Key[] modifierKeys, int releaseDelayMs = 0)
        {
            foreach (Key modifierKey in modifierKeys)
            {
                if (modifierKey == Key.None)
                    continue;
                Press(modifierKey);
            }

            Type(key, releaseDelayMs);

            foreach (Key modifierKey in modifierKeys.Reverse())
            {
                if (modifierKey == Key.None)
                    continue;
                Release(modifierKey);
            }
        }

        /// <summary>
        /// Types a key while a set of modifier keys are being pressed. Modifer keys
        /// are pressed in the order Ctrl->Shift->Alt->Win.
        /// </summary>
        /// <param name="key">Key to type.</param>
        /// <param name="modifierKeys">Set of ModifierKeys enum flags to hold down with key is typed. </param>
        /// <param name="releaseDelayMs">Delay before key release</param>
        public static void Type(Key key, ModifierKeys modifierKeys, int releaseDelayMs = 0)
        {
            var modifierKeysArray = ModifierKeysToArrayConverter(modifierKeys);
            Type(key, modifierKeysArray, releaseDelayMs);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Helper method to convert ModifierKeys enum flags to Key array
        /// </summary>
        /// <param name="modifierKeys">ModifierKeys enum flags</param>
        private static Key[] ModifierKeysToArrayConverter(ModifierKeys modifierKeys)
        {
            Key[] keys = new Key[4];
            if (modifierKeys.HasFlag(ModifierKeys.Control))
                keys.SetValue(Key.LeftCtrl, 0);
            if (modifierKeys.HasFlag(ModifierKeys.Shift))
                keys.SetValue(Key.LeftShift, 1);
            if (modifierKeys.HasFlag(ModifierKeys.Alt))
                keys.SetValue(Key.LeftAlt, 2);
            if (modifierKeys.HasFlag(ModifierKeys.Windows))
                keys.SetValue(Key.LWin, 3);

            return keys;
        }

        /// <summary>
        /// Injects keyboard input into the system.
        /// </summary>
        /// <param name="key">Indicates the key pressed or released. Can be one of the constants defined in the Key enum.</param>
        /// <param name="press">True to inject a key press, false to inject a key release.</param>
        private static void SendKeyboardInput(Key key, bool press)
        {
            NativeMethods.INPUT ki = new NativeMethods.INPUT
            {
                type = NativeMethods.InputKeyboard
            };
            ki.union.keyboardInput.wVk = (short)KeyInterop.VirtualKeyFromKey(key);
            ki.union.keyboardInput.wScan = (short)NativeMethods.MapVirtualKey(ki.union.keyboardInput.wVk, 0);

            int dwFlags = 0;

            if (ki.union.keyboardInput.wScan > 0)
            {
                dwFlags |= NativeMethods.KeyeventfScancode;
            }

            if (!press)
            {
                dwFlags |= NativeMethods.KeyeventfKeyup;
            }

            ki.union.keyboardInput.dwFlags = dwFlags;

            if (ExtendedKeys.Contains(key))
            {
                ki.union.keyboardInput.dwFlags |= NativeMethods.KeyeventfExtendedkey;
            }

            ki.union.keyboardInput.time = 0;
            ki.union.keyboardInput.dwExtraInfo = new IntPtr(0);

            if (NativeMethods.SendInput(1, ref ki, Marshal.SizeOf(ki)) == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Injects keyboard input into the system.
        /// </summary>
        /// <param name="input">Indicates the character pressed or released..</param>
        /// <param name="press">True to inject a key press, false to inject a key release.</param>
        private static void SendKeyboardInput(char input, bool press)
        {
            NativeMethods.INPUT ki = new NativeMethods.INPUT
            {
                type = NativeMethods.InputKeyboard
            };
            ki.union.keyboardInput.wVk = 0;
            ki.union.keyboardInput.wScan = (short)input;

            int dwFlags = 0;
            dwFlags |= NativeMethods.KeyeventfUnicode;

            if (!press)
            {
                dwFlags |= NativeMethods.KeyeventfKeyup;
            }

            ki.union.keyboardInput.dwFlags = dwFlags;
            ki.union.keyboardInput.time = 0;
            ki.union.keyboardInput.dwExtraInfo = new IntPtr(0);

            if (NativeMethods.SendInput(1, ref ki, Marshal.SizeOf(ki)) == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        // From the SDK:
        // The extended-key flag indicates whether the keystroke message originated from one of
        // the additional keys on the enhanced keyboard. The extended keys consist of the ALT and
        // CTRL keys on the right-hand side of the keyboard; the INS, DEL, HOME, END, PAGE UP,
        // PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; the NUM LOCK
        // key; the BREAK (CTRL+PAUSE) key; the PRINT SCRN key; and the divide (/) and ENTER keys in
        // the numeric keypad. The extended-key flag is set if the key is an extended key. 
        //
        // - docs appear to be incorrect. Use of Spy++ indicates that break is not an extended key.
        // Also, menu key and windows keys also appear to be extended.
        private static readonly Key[] ExtendedKeys = {
        Key.RightAlt,
        Key.RightCtrl,
        Key.NumLock,
        Key.Insert,
        Key.Delete,
        Key.Home,
        Key.End,
        Key.Prior,
        Key.Next,
        Key.Up,
        Key.Down,
        Key.Left,
        Key.Right,
        Key.Apps,
        Key.RWin,
        Key.LWin
    };
        // Note that there are no distinct values for the following keys:
        // numpad divide
        // numpad enter

        #endregion
    }
}
