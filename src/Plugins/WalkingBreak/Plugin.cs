// ***********************************************************************
// Author   : ElektroStudios
// Modified : 13-April-2019
// ***********************************************************************

#region  Usings 

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using log4net;

using Zeta.Bot;
using Zeta.Common;
using Zeta.Common.Plugins;

using WalkingBreak.Win32;

#endregion

#region  Plugin 

namespace WalkingBreak {

    /// ----------------------------------------------------------------------------------------------------
    /// <summary>
    /// Plugin.
    /// </remarks>
    /// ----------------------------------------------------------------------------------------------------
    public sealed class Plugin : IPlugin {

#region  Public Fields 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// The virtual key used to pause the bot.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        public static VirtualKeys key = VirtualKeys.MouseButtonMiddle;

#endregion

#region  Private Fields 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// The logger instance.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        private readonly ILog log = Logger.GetLoggerInstanceForType();

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Flag to determine whether or not the bot is paused.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        private bool isBotPaused = false;

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Flag to determine whether or not the plugin is enabled.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        private bool isPluginEnabled = false;

#endregion

#region  Properties 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the plugin name.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        public string Name {
            get {
                return "Walking Break";
            }
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the plugin description.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        public string Description {
            get {
                return "Pause the bot using a custom keyboard key or mouse button to let you walk free.";
            }
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the plugin version.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        public Version Version {
            get {
                return new Version(1, 1);
            }
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the plugin author.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        public string Author {
            get {
                return "ElektroStudios";
            }
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the user-interface configuration window.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        public Window DisplayWindow {
            get {
                return Config.GetDisplayWindow();
            }
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the names of the available virtual keys.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        public static string[] VirtualKeyNames {
            get {
                return Enum.GetNames(typeof(VirtualKeys)).OrderBy((string value) => value).ToArray();
            }
        }

#endregion

#region  Event Invocators 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Called when this plugin is initialized.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        void IPlugin.OnInitialize() {
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Called when the bot sends a "pulse".
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        void IPlugin.OnPulse() {
            if (this.isPluginEnabled) {
                bool PauseRequested = this.PauseRequested();
                if ((PauseRequested && !BotMain.IsPaused)) {
                    BotMain.PauseWhile(() => this.PauseRequested());
                }            
            }
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Called when this plugin is enabled.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        void IPlugin.OnEnabled() {
            Plugin.key = Plugin.Deserialize();
            this.isPluginEnabled = true;
            this.log.Info("[Walking Break] Plugin enabled.");
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Called when this plugin is disabled.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        void IPlugin.OnDisabled() {
            this.isBotPaused = false;
            this.isPluginEnabled = false;
            this.log.Info("[Walking Break] Plugin disabled.");
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Called when the bot is shutting down.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        void IPlugin.OnShutdown() {
            this.isBotPaused = false;
            this.isPluginEnabled = false;
        }

#endregion

#region  Public Methods 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Indicates whether or not the current <see cref="IPlugin"/> is equal to another <see cref="IPlugin"/>.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <param name="other">
        /// An <see cref="IPlugin"/> to compare with this <see cref="IPlugin"/>.
        /// </param>
        /// ----------------------------------------------------------------------------------------------------
        /// <returns>
        /// <see langword="true" /> if the current <see cref="IPlugin"/> is equal to the <paramref name="other" /> parameter; 
        /// otherwise, <see langword="false" />.
        /// </returns>
        /// ----------------------------------------------------------------------------------------------------
        public bool Equals(IPlugin other) {
            string thisName = (this.Name + this.Author);
            string otherName = (other.Name + other.Author);
            return otherName.Equals(thisName, StringComparison.InvariantCultureIgnoreCase);
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deserializes the saved virtual-key.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <returns>
        /// The virtual-key.
        /// </returns>
        /// ----------------------------------------------------------------------------------------------------
        public static VirtualKeys Deserialize() {
            string assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string xmlPath = Path.Combine(assemblyPath, "Plugins", "WalkingBreak", "VirtualKey.xml");
            FileInfo file = new FileInfo(xmlPath);

            if (file.Exists) {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(VirtualKeys));

                try {
                    using (FileStream sr = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read)) {
                        return (VirtualKeys)serializer.Deserialize(sr);
                    }
                } catch (Exception ex) {
                }
            }

            return VirtualKeys.MouseButtonMiddle;
        }

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Serializes the selected virtual-key.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <param name="vKey">
        /// The virtual-key to be serialized.
        /// </param>
        /// ----------------------------------------------------------------------------------------------------
        public static void Serialize(VirtualKeys vKey) {
            string assemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string xmlPath = Path.Combine(assemblyPath, "Plugins", "WalkingBreak", "VirtualKey.xml");
            FileInfo file = new FileInfo(xmlPath);

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(VirtualKeys));
            using (FileStream sr = file.Open(FileMode.Create, FileAccess.Write, FileShare.Read)) {
                serializer.Serialize(sr, vKey);
            }
        }

#endregion

#region  Private Methods 

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether or not the user requested to pause the bot by pressing the virtual key specified at <see cref="Plugin.key"/> field.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <returns>
        /// <see langword="true" /> if user requested to pause the bot; otherwise, <see langword="false" />.
        /// </returns>
        /// ----------------------------------------------------------------------------------------------------
        private bool PauseRequested() {

            const int KEY_PRESSED = 0x8000;
            short keyState        = NativeMethods.GetKeyState(Plugin.key);
            bool  keyPressed      = Convert.ToBoolean(keyState & KEY_PRESSED);

            if (keyPressed) {
                Process[] d3procs = Process.GetProcessesByName(processName:"Diablo III");
                if (d3procs.Any()) {
                    int[] ids = (from pr in d3procs select pr.Id).ToArray();
                    IntPtr activeHwnd = NativeMethods.GetForegroundWindow();
                    int activeId = 0;
                    NativeMethods.GetWindowThreadProcessId(activeHwnd, out activeId);

                    if (activeId != 0) {
                        Process pr = Process.GetProcessById(activeId);
                        if (ids.Contains(pr.Id)) {
                            this.isBotPaused = !this.isBotPaused;
                            this.log.Info(string.Format("[WalkingBreak] Key down: '{0}', bot status changed to: '{1}'", Plugin.key.ToString(), (this.isBotPaused ? "Paused" : "Resumed")));
                            Thread.Sleep(300);
                        }
                    }
                }
            }
            return this.isBotPaused;
        }

#endregion

    }

}

#endregion
