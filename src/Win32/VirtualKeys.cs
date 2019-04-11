// ***********************************************************************
// Author   : ElektroStudios
// Modified : 10-April-2019
// ***********************************************************************

#region  Virtual Keys 

namespace WalkingBreak.Win32 {

    /// ----------------------------------------------------------------------------------------------------
    /// <summary>
    /// Specifies virtual-key codes.
    /// </summary>
    /// ----------------------------------------------------------------------------------------------------
    /// <remarks>
    /// <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731%28v=vs.85%29.aspx"/>
    /// </remarks>
    /// ----------------------------------------------------------------------------------------------------
    public enum VirtualKeys: byte {

        // ***********************************************************************
        // THIS ENUMERATION IS NOT COMPLETE.
        // SOME VALUES HAVE BEEN REMOVED TO FIT THE NEEDS OF THIS LIBRARY.
        // ***********************************************************************

        /// <summary>
        /// VK_MBUTTON
        /// <para></para>
        /// Middle mouse button (three-button mouse).
        /// </summary>
        MouseButtonMiddle = 0x4,

        /// <summary>
        /// VK_XBUTTON1
        /// <para></para>
        /// X1 mouse button.
        /// </summary>
        MouseButtonX1 = 0x5,

        /// <summary>
        /// VK_XBUTTON2
        /// <para></para>
        /// X2 mouse button.
        /// </summary>
        MouseButtonX2 = 0x6,

        /// <summary>
        /// VK_BACK
        /// <para></para>
        /// BACKSPACE key.
        /// </summary>
        BackSpace = 0x8,

        /// <summary>
        /// VK_TAB
        /// <para></para>
        /// TAB key.
        /// </summary>
        Tabulation = 0x9,

        /// <summary>
        /// VK_RETURN
        /// <para></para>
        /// ENTER key.
        /// </summary>
        Enter = 0xD,

        /// <summary>
        /// VK_SHIFT
        /// <para></para>
        /// SHIFT key.
        /// </summary>
        Shift = 0x10,

        /// <summary>
        /// VK_CONTROL
        /// <para></para>
        /// CTRL key.
        /// </summary>
        Control = 0x11,

        /// <summary>
        /// VK_MENU
        /// <para></para>
        /// ALT key.
        /// </summary>
        Alt = 0x12,

        /// <summary>
        /// VK_PAUSE
        /// <para></para>
        /// PAUSE key.
        /// </summary>
        Pause = 0x13,

        /// <summary>
        /// VK_CAPITAL
        /// <para></para>
        /// CAPS LOCK key.
        /// </summary>
        CapsLock = 0x14,

        /// <summary>
        /// VK_ESCAPE
        /// <para></para>
        /// ESC key.
        /// </summary>
        Escape = 0x1B,

        /// <summary>
        /// VK_SPACE
        /// <para></para>
        /// SPACEBAR.
        /// </summary>
        Space = 0x20,

        /// <summary>
        /// VK_PRIOR
        /// <para></para>
        /// PAGE UP key.
        /// </summary>
        PageUp = 0x21,

        /// <summary>
        /// VK_NEXT
        /// <para></para>
        /// PAGE DOWN key.
        /// </summary>
        PageDown = 0x22,

        /// <summary>
        /// VK_END
        /// <para></para>
        /// END key.
        /// </summary>
        End = 0x23,

        /// <summary>
        /// VK_HOME
        /// <para></para>
        /// HOME key.
        /// </summary>
        Home = 0x24,

        /// <summary>
        /// VK_SELECT
        /// <para></para>
        /// SELECT key.
        /// </summary>
        Select = 0x29,

        /// <summary>
        /// VK_PRINT
        /// <para></para>
        /// PRINT key.
        /// </summary>
        Print = 0x2A,

        /// <summary>
        /// VK_EXECUTE
        /// <para></para>
        /// EXECUTE key.
        /// </summary>
        Execute = 0x2B,

        /// <summary>
        /// VK_SNAPSHOT
        /// <para></para>
        /// PRINT SCREEN key.
        /// </summary>
        PrintScreen = 0x2C,

        /// <summary>
        /// VK_INSERT
        /// <para></para>
        /// INS key.
        /// </summary>
        Insert = 0x2D,

        /// <summary>
        /// VK_DELETE
        /// <para></para>
        /// DEL key.
        /// </summary>
        Delete = 0x2E,

        /// <summary>
        /// VK_HELP
        /// <para></para>
        /// HELP key.
        /// </summary>
        Help = 0x2F,

        /// <summary>
        /// The numeric 0 key.
        /// </summary>
        D0 = 0x30,

        /// <summary>
        /// The numeric 1 key.
        /// </summary>
        D1 = 0x31,

        /// <summary>
        /// The numeric 2 key.
        /// </summary>
        D2 = 0x32,

        /// <summary>
        /// The numeric 3 key.
        /// </summary>
        D3 = 0x33,

        /// <summary>
        /// The numeric 4 key.
        /// </summary>
        D4 = 0x34,

        /// <summary>
        /// The numeric 5 key.
        /// </summary>
        D5 = 0x35,

        /// <summary>
        /// The numeric 6 key.
        /// </summary>
        D6 = 0x36,

        /// <summary>
        /// The numeric 7 key.
        /// </summary>
        D7 = 0x37,

        /// <summary>
        /// The numeric 8 key.
        /// </summary>
        D8 = 0x38,

        /// <summary>
        /// The numeric 9 key.
        /// </summary>
        D9 = 0x39,

        /// <summary>
        /// VK_LWIN
        /// <para></para>
        /// Left Windows key (Natural keyboard) .
        /// </summary>
        LeftWin = 0x5B,

        /// <summary>
        /// VK_RWIN
        /// <para></para>
        /// Right Windows key (Natural keyboard).
        /// </summary>
        RightWin = 0x5C,

        /// <summary>
        /// VK_NUMPAD0
        /// <para></para>
        /// Numeric keypad 0 key.
        /// </summary>
        Numpad0 = 0x60,

        /// <summary>
        /// VK_NUMPAD1
        /// <para></para>
        /// Numeric keypad 1 key.
        /// </summary>
        Numpad1 = 0x61,

        /// <summary>
        /// VK_NUMPAD2
        /// <para></para>
        /// Numeric keypad 2 key.
        /// </summary>
        Numpad2 = 0x62,

        /// <summary>
        /// VK_NUMPAD3
        /// <para></para>
        /// Numeric keypad 3 key.
        /// </summary>
        Numpad3 = 0x63,

        /// <summary>
        /// VK_NUMPAD4
        /// <para></para>
        /// Numeric keypad 4 key.
        /// </summary>
        Numpad4 = 0x64,

        /// <summary>
        /// VK_NUMPAD5
        /// <para></para>
        /// Numeric keypad 5 key.
        /// </summary>
        Numpad5 = 0x65,

        /// <summary>
        /// VK_NUMPAD6
        /// <para></para>
        /// Numeric keypad 6 key.
        /// </summary>
        Numpad6 = 0x66,

        /// <summary>
        /// VK_NUMPAD7
        /// <para></para>
        /// Numeric keypad 7 key.
        /// </summary>
        Numpad7 = 0x67,

        /// <summary>
        /// VK_NUMPAD8
        /// <para></para>
        /// Numeric keypad 8 key.
        /// </summary>
        Numpad8 = 0x68,

        /// <summary>
        /// VK_NUMPAD9
        /// <para></para>
        /// Numeric keypad 9 key.
        /// </summary>
        Numpad9 = 0x69,

        /// <summary>
        /// VK_MULTIPLY
        /// <para></para>
        /// Multiply key.
        /// </summary>
        Multiply = 0x6A,

        /// <summary>
        /// VK_ADD
        /// <para></para>
        /// Add key.
        /// </summary>
        Add = 0x6B,

        /// <summary>
        /// VK_SEPARATOR
        /// <para></para>
        /// Separator key.
        /// </summary>
        Separator = 0x6C,

        /// <summary>
        /// VK_SUBTRACT
        /// <para></para>
        /// Subtract key.
        /// </summary>
        Subtract = 0x6D,

        /// <summary>
        /// VK_DECIMAL
        /// <para></para>
        /// Decimal key.
        /// </summary>
        Decimal = 0x6E,

        /// <summary>
        /// VK_DIVIDE
        /// <para></para>
        /// Divide key.
        /// </summary>
        Divide = 0x6F,

        /// <summary>
        /// VK_F1
        /// <para></para>
        /// F1 key.
        /// </summary>
        F1 = 0x70,

        /// <summary>
        /// VK_F2
        /// <para></para>
        /// F2 key.
        /// </summary>
        F2 = 0x71,

        /// <summary>
        /// VK_F3
        /// <para></para>
        /// F3 key.
        /// </summary>
        F3 = 0x72,

        /// <summary>
        /// VK_F4
        /// <para></para>
        /// F4 key.
        /// </summary>
        F4 = 0x73,

        /// <summary>
        /// VK_F5
        /// <para></para>
        /// F5 key.
        /// </summary>
        F5 = 0x74,

        /// <summary>
        /// VK_F6
        /// <para></para>
        /// F6 key.
        /// </summary>
        F6 = 0x75,

        /// <summary>
        /// VK_F7
        /// <para></para>
        /// F7 key.
        /// </summary>
        F7 = 0x76,

        /// <summary>
        /// VK_F8
        /// <para></para>
        /// F8 key.
        /// </summary>
        F8 = 0x77,

        /// <summary>
        /// VK_F9
        /// <para></para>
        /// F9 key.
        /// </summary>
        F9 = 0x78,

        /// <summary>
        /// VK_NUMLOCK
        /// <para></para>
        /// NUM LOCK key.
        /// </summary>
        Numlock = 0x90,

        /// <summary>
        /// VK_SCROLL
        /// <para></para>
        /// SCROLL LOCK key.
        /// </summary>
        ScrollLock = 0x91,

        /// <summary>
        /// VK_LSHIFT
        /// <para></para>
        /// Left SHIFT key.
        /// </summary>
        LeftShit = 0xA0,

        /// <summary>
        /// VK_RSHIFT
        /// <para></para>
        /// Right SHIFT key.
        /// </summary>
        RightShift = 0xA1,

        /// <summary>
        /// VK_LCONTROL
        /// <para></para>
        /// Left CONTROL key.
        /// </summary>
        LeftControl = 0xA2,

        /// <summary>
        /// VK_RCONTROL
        /// <para></para>
        /// Right CONTROL key.
        /// </summary>
        RightControl = 0xA3,

        /// <summary>
        /// VK_LMENU
        /// <para></para>
        /// Left MENU key.
        /// </summary>
        LeftMenu = 0xA4,

        /// <summary>
        /// VK_RMENU
        /// <para></para>
        /// Right MENU key.
        /// </summary>
        RightMenu = 0xA5,

        /// <summary>
        /// VK_BROWSER_BACK
        /// <para></para>
        /// Browser Back key.
        /// </summary>
        BrowserBack = 0xA6,

        /// <summary>
        /// VK_BROWSER_FORWARD
        /// <para></para>
        /// Browser Forward key.
        /// </summary>
        BrowserForward = 0xA7,

        /// <summary>
        /// VK_BROWSER_REFRESH
        /// <para></para>
        /// Browser Refresh key.
        /// </summary>
        BrowserRefresh = 0xA8,

        /// <summary>
        /// VK_BROWSER_STOP
        /// <para></para>
        /// Browser Stop key.
        /// </summary>
        BrowserStop = 0xA9,

        /// <summary>
        /// VK_BROWSER_SEARCH
        /// <para></para>
        /// Browser Search key.
        /// </summary>
        BrowserSearch = 0xAA,

        /// <summary>
        /// VK_BROWSER_FAVORITES
        /// <para></para>
        /// Browser Favorites key.
        /// </summary>
        BrowserFavorites = 0xAB,

        /// <summary>
        /// VK_BROWSER_HOME
        /// <para></para>
        /// Browser Start and Home key.
        /// </summary>
        BrowserHome = 0xAC,

        /// <summary>
        /// VK_VOLUME_MUTE
        /// <para></para>
        /// Volume Mute key.
        /// </summary>
        VolumeMute = 0xAD,

        /// <summary>
        /// VK_VOLUME_DOWN
        /// <para></para>
        /// Volume Down key.
        /// </summary>
        VolumeDown = 0xAE,

        /// <summary>
        /// VK_VOLUME_UP
        /// <para></para>
        /// Volume Up key.
        /// </summary>
        VolumeUP = 0xAF,

        /// <summary>
        /// VK_MEDIA_NEXT_TRACK
        /// <para></para>
        /// Next Track key.
        /// </summary>
        MediaNextTrack = 0xB0,

        /// <summary>
        /// VK_MEDIA_PREV_TRACK
        /// <para></para>
        /// Previous Track key.
        /// </summary>
        MediaPreviousTrack = 0xB1,

        /// <summary>
        /// VK_MEDIA_STOP
        /// <para></para>
        /// Stop Media key.
        /// </summary>
        MediaStop = 0xB2,

        /// <summary>
        /// VK_MEDIA_PLAY_PAUSE
        /// <para></para>
        /// Play/Pause Media key.
        /// </summary>
        MediaPlayPause = 0xB3,

        /// <summary>
        /// VK_LAUNCH_MAIL
        /// <para></para>
        /// Start Mail key.
        /// </summary>
        LaunchMail = 0xB4,

        /// <summary>
        /// VK_LAUNCH_MEDIA_SELECT
        /// <para></para>
        /// Select Media key.
        /// </summary>
        LaunchMediaSelect = 0xB5,

        /// <summary>
        /// VK_LAUNCH_APP1
        /// <para></para>
        /// Start Application 1 key.
        /// </summary>
        LaunchApp1 = 0xB6,

        /// <summary>
        /// VK_LAUNCH_APP2
        /// <para></para>
        /// Start Application 2 key.
        /// </summary>
        LaunchApp2 = 0xB7,

        /// <summary>
        /// VK_OEM_PLUS
        /// <para></para>
        /// For any country/region, the '+' key.
        /// </summary>
        OemPlus = 0xBB,

        /// <summary>
        /// VK_OEM_COMMA
        /// <para></para>
        /// For any country/region, the ',' key.
        /// </summary>
        OemComma = 0xBC,

        /// <summary>
        /// VK_OEM_MINUS
        /// <para></para>
        /// For any country/region, the '-' key.
        /// </summary>
        OemMinus = 0xBD,

        /// <summary>
        /// VK_OEM_PERIOD
        /// <para></para>
        /// For any country/region, the '.' key.
        /// </summary>
        OemPeriod = 0xBE,

        /// <summary>
        /// VK_EREOF
        /// <para></para>
        /// Erase EOF key.
        /// </summary>
        EraseEOF = 0xF9,

        /// <summary>
        /// VK_PLAY
        /// <para></para>
        /// Play key.
        /// </summary>
        Play = 0xFA,

        /// <summary>
        /// VK_ZOOM
        /// <para></para>
        /// Zoom key.
        /// </summary>
        Zoom = 0xFB

    }

}

#endregion
