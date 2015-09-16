using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRSSFeedReader
{
    public class Rss
    {
        [Serializable]
        public struct Items
        {
            public string Title;

            public string Description;

            public string Link;

            public DateTime PubDate;
        }
    }
}
