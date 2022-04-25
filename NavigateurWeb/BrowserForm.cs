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

namespace NavigateurWeb
{
    public partial class BrowserForm : Form
    {
        ChromiumWebBrowser WebBrowser;
        NavigationEntry currentNavEntry;


        public BrowserForm()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {

        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.Locale = "fr";

            if (!Cef.IsInitialized)
            {
                Cef.Initialize(settings);
            }

            WebBrowser = new ChromiumWebBrowser("https://www.google.fr/");
            BrowserPanel.Controls.Add(WebBrowser);
            WebBrowser.LoadingStateChanged += WebBrowser_LoadingStateChanged;

        }

        private void InvokeNavEntry(string value)
        {
            if(InvokeRequired)
            {
                Invoke(new Action<string>(InvokeNavEntry), new object[] { value });
            }
            TbxUrl.Text = value;
        }

        private void InvokeNavEntryTitle(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(InvokeNavEntryTitle), new object[] { value });
            }
            Text = value;
        }

        private void WebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            currentNavEntry = WebBrowser.GetBrowserHost().GetVisibleNavigationEntry();
            if(!e.IsLoading)
            {
                InvokeNavEntry(currentNavEntry.DisplayUrl);
                InvokeNavEntryTitle(currentNavEntry.Title);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            WebBrowser.Forward();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            WebBrowser.Back();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            WebBrowser.Reload();
        }

        private void TbxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                WebBrowser.Load(TbxUrl.Text);
            }
        }
    }
}
