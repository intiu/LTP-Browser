using EasyTabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTP_Browser
{
    public partial class NewTab : TitleBarTabs
    {
        public NewTab()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                // Nội dung sẽ là một thể hiện của một Form khác
                // Trong ví dụ của chúng tôi, chúng tôi sẽ tạo một phiên bản mới của Form
                Content = new MainBrowser
                {
                    Text = "New Tab"
                }
            };
        }
    }
}
