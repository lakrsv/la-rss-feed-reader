using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace LaRSSFeedReader
{
    class BookmarkHandler
    {
        public static Dictionary<string, string> BookMarks = new Dictionary<string, string>();
        public void CreateBookmark(string name, string url)
        {
            Bookmark.Item bookmark = new Bookmark.Item();
            bookmark.Name = name;
            bookmark.Url = url;

            BookMarks.Add(bookmark.Name, bookmark.Url);
            SaveBookmarks();
        }
        public void RemoveBookmark(string name)
        {
            BookMarks.Remove(name);
            SaveBookmarks();
        }
        private void SaveBookmarks()
        {
            File.WriteAllText("Bookmarks.txt", JsonConvert.SerializeObject(BookMarks));
        }
        public static void GetBookmarks()
        {
            if (File.Exists("Bookmarks.txt"))
            {
                BookMarks = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("Bookmarks.txt"));
            }
        }
    }
}
