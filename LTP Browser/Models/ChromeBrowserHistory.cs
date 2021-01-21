using System;

namespace LTP_Browser.Models
{
    class ChromeBrowserHistory : BrowserHistory
    {
        public ChromeBrowserHistory()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";
            query = @"SELECT url AS URL, title AS Title, time(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')),'unixepoch', 'localtime') AS Time, date(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')),'unixepoch') AS Date 
              FROM urls ORDER BY last_visit_time DESC LIMIT 50";
            name = "Chrome";
        }
    }
}
