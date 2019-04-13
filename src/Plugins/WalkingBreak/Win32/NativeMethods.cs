// ***********************************************************************
// Author   : ElektroStudios
// Modified : 10-April-2019
// ***********************************************************************

#region  Usings 

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

#endregion

#region  NativeMethods 

namespace WalkingBreak.Win32 {

    /// ----------------------------------------------------------------------------------------------------
    /// <summary>
    /// Platform Invocation methods (P/Invoke), access unmanaged code.
    /// <para></para>
    /// This class does not suppress stack walks for unmanaged code permission.
    /// <see cref="Global.System.Security.SuppressUnmanagedCodeSecurityAttribute"/> must not be applied to this class.
    /// <para></para>
    /// This class is for methods that can be used anywhere because a stack walk will be performed.
    /// </summary>
    /// ----------------------------------------------------------------------------------------------------
    /// <remarks>
    /// <see href="https://msdn.microsoft.com/en-us/library/ms182161.aspx"/>
    /// </remarks>
    /// ----------------------------------------------------------------------------------------------------
    internal sealed class NativeMethods {

#region  Constructors 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Prevents a default instance of the <see cref="NativeMethods"/> class from being created.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        [DebuggerNonUserCode]
        private NativeMethods() {
        }

#endregion

#region  user32.dll 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). 
        /// <para></para>
        /// The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms633505%28v=vs.85%29.aspx"/>
        /// </remarks>
        /// ----------------------------------------------------------------------------------------------------
        /// <returns>
        /// The return value is a handle to the foreground window.
        /// <para></para>
        /// The foreground window can be <see cref="IntPtr.Zero"/> in certain circumstances, such as when a window is losing activation.
        /// </returns>
        /// ----------------------------------------------------------------------------------------------------
        [SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", SetLastError=true)]
        internal extern static IntPtr GetForegroundWindow();

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the status of the specified virtual key.
        /// <para></para>
        /// The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms646301%28v=vs.85%29.aspx"/>
        /// </remarks>
        /// ----------------------------------------------------------------------------------------------------
        /// <param name="vKey">
        /// The virtual-key code.
        /// <para></para>
        /// You can use left- and right-distinguishing constants to specify certain keys.
        /// <para></para>
        /// See Virtual-Key Codes: 
        /// <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731%28v=vs.85%29.aspx"/>
        /// </param>
        /// ----------------------------------------------------------------------------------------------------
        /// <returns>
        /// If the high-order bit is <c>1</c>, the key is down; otherwise, it is up.
        /// <para></para>
        /// If the low-order bit is <c>1</c>, the key is toggled. 
        /// <para></para>
        /// A key, such as the <c>CAPS LOCK</c> key, is toggled if it is turned on. 
        /// The key is off and untoggled if the low-order bit is <c>0</c>.
        /// <para></para>
        /// A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        /// </returns>
        /// ----------------------------------------------------------------------------------------------------
        [SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", SetLastError=true)]
        internal extern static short GetKeyState(VirtualKeys vKey);

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retrieves the identifier of the thread that created the specified window 
        /// and, optionally, the identifier of the process that created the window.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <remarks>
        /// <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms633522%28v=vs.85%29.aspx"/>
        /// </remarks>
        /// ----------------------------------------------------------------------------------------------------
        /// <param name="hWnd">
        /// A <see cref="IntPtr"/> handle to the window.
        /// </param>
        /// 
        /// <param name="refPID">
        /// A pointer to a variable that receives the process identifier (PID). 
        /// <para></para>
        /// If this parameter is not <see langword="Nothing"/>, <see cref="NativeMethods.GetWindowThreadProcessId"/> copies the identifier of 
        /// the process to the variable; otherwise, it does not.
        /// </param>
        /// ----------------------------------------------------------------------------------------------------
        /// <returns>
        /// The identifier of the thread that created the window.
        /// </returns>
        /// ----------------------------------------------------------------------------------------------------
        [SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", SetLastError=true)]
        internal extern static int GetWindowThreadProcessId(IntPtr hWnd, out int refPID);

#endregion

    }

}

#endregion
