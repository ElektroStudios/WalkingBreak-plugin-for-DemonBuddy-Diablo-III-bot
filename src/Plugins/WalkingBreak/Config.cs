// ***********************************************************************
// Author   : ElektroStudios
// Modified : 10-April-2019
// ***********************************************************************

#region  Usings 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using log4net;

using Zeta.Bot;
using Zeta.Common;
using Zeta.Common.Plugins;
using Zeta.Game;

using WalkingBreak.Win32;

#endregion

namespace WalkingBreak {

    /// ----------------------------------------------------------------------------------------------------
    /// <summary>
    /// Config.
    /// </summary>
    /// ----------------------------------------------------------------------------------------------------
    public partial class Config {

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// The logger instance.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        private static readonly ILog log = Logger.GetLoggerInstanceForType();

        /// ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the user-interface <see cref="Window"/> for this plugin.
        /// </summary>
        /// ----------------------------------------------------------------------------------------------------
        /// <returns>
        /// The user-interface <see cref="Window"/> for this plugin.
        /// </returns>
        /// ----------------------------------------------------------------------------------------------------
        public static Window GetDisplayWindow() {
            try {
                string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                string xamlPath = Path.Combine(assemblyPath, "Plugins", "WalkingBreak", "Config.xaml");
                string xamlContent = File.ReadAllText(xamlPath);
                xamlContent = xamlContent.Replace("xmlns:local=\"clr-namespace:WalkingBreak\"",
                                                  "xmlns:local=\"clr-namespace:WalkingBreak;assembly=" + assemblyName + "\"");

                UserControl mainControl = (UserControl)XamlReader.Load(new MemoryStream(Encoding.UTF8.GetBytes(xamlContent)));

                Window window = new Window();
                window.Content = mainControl;
                window.ResizeMode = ResizeMode.NoResize;
                window.SizeToContent = SizeToContent.WidthAndHeight;
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.Title = "Walking Break Settings";

                ComboBox cb = (ComboBox)mainControl.FindName("CB_KEY");

                window.ContentRendered += delegate {
                    cb.SelectedItem = Plugin.Deserialize().ToString();
                };

                cb.SelectionChanged += delegate {
                    Plugin.key = (VirtualKeys)Enum.Parse(typeof(VirtualKeys), cb.SelectedItem.ToString());
                    Plugin.Serialize(Plugin.key);
                };

                return window;
                
            } catch (Exception ex) {
                log.Error("[Walking Break] Error opening Config window: " + ex);
                return null;
            }
        }
    }
}
