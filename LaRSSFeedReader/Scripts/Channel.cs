using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRSSFeedReader.Scripts
{
    public class Channel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public List<Item> Items { get; set; }
    }
}
