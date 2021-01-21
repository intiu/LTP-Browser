using EasyTabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTP_Browser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NewTab newTab = new NewTab();

            // Thêm Tab ban đầu
            newTab.Tabs.Add(
                // Tab Đầu tiên của chúng tôi được tạo theo mặc định trong Ứng dụng sẽ có nội dung là Form
                new TitleBarTab(newTab)
                {
                    Content = new MainBrowser
                    {
                        Text = "New Tab"
                    }
                }
            );

            // Đặt tab đầu tiên là tab đầu tiên
            newTab.SelectedTabIndex = 0;

            // Tạo tab và khởi động ứng dụng
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(newTab);
            Application.Run(applicationContext);
            //Application.Run(new NewTab());
        }
    }
}
