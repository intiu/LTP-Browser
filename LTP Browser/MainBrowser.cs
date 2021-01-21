using EasyTabs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTP_Browser
{
    public partial class MainBrowser : Form
    {
        public MainBrowser()
        {
            InitializeComponent();
            // Nâng cấp trình duyệt web mặc định
            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                Key.SetValue(appName, 99999, RegistryValueKind.DWord);

            // mở google .com
            webBrowser1.Navigate("https://www.google.com/");
            //Gecko.Xpcom.Initialize(Application.StartupPath + "\\gecko");
        }

        // 2. Quan trọng: Khai báo ParentTabs
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        string _url;
        public string VideoID
        {
            get
            {
                var yMatch = new Regex(@"http(?:s?)://(?:www\.)?youtu(?:be\.com/watch\?v=|\.be/)([\w\-]+)(&(amp;)?[\w\?=]*)?").Match(_url);
                return yMatch.Success ? yMatch.Groups[1].Value : String.Empty;
            }
        }

        private void txtSerachOrUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSerachOrUrl.Text.Trim().Length > 0)
            {
                // phát hiện url
                if (txtSerachOrUrl.Text.Contains("."))
                {
                    // đó là một đường dẫn
                    webBrowser1.Navigate(txtSerachOrUrl.Text.Trim());

                }
                else
                {
                    // đó là một tìm kiếm
                    webBrowser1.Navigate("https://www.google.com/search?client=opera&q=" + txtSerachOrUrl.Text.Trim().Replace(" ", "+") + "&sourceid=opera&ie=UTF-8&oe=UTF-8");
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnRefresh.Image = imgRefresh.Image;
            txtSerachOrUrl.Text = webBrowser1.Url.AbsoluteUri;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack) webBrowser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward) webBrowser1.GoForward();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            btnRefresh.Image = imgSpinner.Image;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            btnRefresh.Image = imgRefresh.Image;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://accounts.google.com/signin/v2/identifier?passive=1209600&continue=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&followup=https%3A%2F%2Faccounts.google.com%2Fb%2F0%2FAddMailService&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.youtube.com/watch?v=-G1zl73ZmFk");
            /*_url = txtSerachOrUrl.Text;
            webBrowser1.DocumentText = String.Format("<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"100%\" height=\"315\" src=\"https://www.youtube.com/embed/{0}?autoplay=1\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>", VideoID);*/
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/maps");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://news.google.com/topstories?hl=en-US&gl=US&ceid=US:en");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://translate.google.com/");
        }

        private void txtSerachOrUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            About about = new About();
            //this.Hide();
            about.Show();
            this.Show();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            HistoryBrowser historyBrowser = new HistoryBrowser();
            //this.Hide();
            historyBrowser.Show();
            this.Show();
        }
    }
}
