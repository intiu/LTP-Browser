using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LTP_Browser.Models
{
    class BrowserHistory
    {
        protected String path { get; set; }
        protected String query { get; set; }
        protected String name { get; set; }
        public DataTable GetDataTable()
        {
            using (SQLiteConnection cn= new SQLiteConnection("Data Source=" + path + ";Version=3;New=False;Compress=True;"))
            {
                try
                {
                    cn.Open();
                    SQLiteDataAdapter sd = new SQLiteDataAdapter(query, cn);

                    DataTable dt = new DataTable();
                    sd.Fill(dt);

                    return dt;
                }
                catch
                {
                    MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure history file exists.");
                }
            }
            return null;
        }
    }
}
