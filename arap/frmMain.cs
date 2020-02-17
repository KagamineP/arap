using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using AutoUpdaterDotNET;
using arap.Handler;

namespace arap
{
    public partial class frmMain : Form
    {
        private ChromiumWebBrowser chromeBrowser;

        public frmMain()
        {
#if DEBUG
            MessageBox.Show("CefSharp version: " + AssemblyInfo.AssemblyVersion, "Debug configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
            InitializeComponent();
            InitializeChromium();
        }

        public ChromiumWebBrowser ChromeBrowser { get => chromeBrowser; set => chromeBrowser = value; }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            ChromeBrowser = new ChromiumWebBrowser("http://router.asus.com");
            this.Controls.Add(ChromeBrowser);
            ChromeBrowser.Dock = DockStyle.Fill;
            ChromeBrowser.MenuHandler = new menuHandler();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
#if DEBUG
            AutoUpdater.Start("http://kagaminep.ru/arap/insider/insider.xml");
#else
            AutoUpdater.Start("http://kagaminep.ru/arap/release/release.xml");
#endif
        }
    }
}
