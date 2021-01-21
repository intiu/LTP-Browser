using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTP_Browser.Models;
namespace LTP_Browser
{
    public partial class HistoryBrowser : Form
    {
        public HistoryBrowser()
        {
            InitializeComponent();
        }

        private void HistoryBrowser_Load(object sender, EventArgs e)
        {
            ChromeBrowserHistory chrome = new ChromeBrowserHistory();
            chromeDataGrid.DataSource = chrome.GetDataTable();
        }
    }
}
