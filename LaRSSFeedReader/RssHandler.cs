using System;
using System.Xml;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
namespace LaRSSFeedReader
{
    class RssHandler : IDisposable
    {
        public delegate void failureEventHandler();
        public event failureEventHandler failureEvent;
        public delegate void myEventHandler();
        public event myEventHandler theEvent;
        private string _url, _title, _description;
        private Collection<Rss.Items> _rssItems = new Collection<Rss.Items>();
        public BackgroundWorker theBackgroundWorker;
        private bool _isDisposed = false;

        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
        public Collection<Rss.Items> RssItems
        {
            get { return _rssItems; }
        }
        public string Title
        {
            get { return _title; }
        }
        public string Description
        {
            get { return _description; }
        }

        public void GetFeed(object sender, EventArgs e)
        {
            _isDisposed = false;
            if (String.IsNullOrEmpty(Url))
            {
                MessageBox.Show("You must provide a feed URL!");
                if (failureEvent != null)
                {
                    failureEvent();
                }
                return;
            }

            try
            {
                using (XmlReader reader = XmlReader.Create(Url))
                {

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(reader);

                    ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "title", ref _title);
                    ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "description", ref _description);

                    _rssItems.Clear();

                    XmlNodeList nodes = xmlDoc.SelectNodes("rss/channel/item");
                    int count = nodes.Count;
                    int parsed = 0;

                    foreach (XmlNode node in nodes)
                    {
                        ParseRSSNode(node);
                        parsed++;
                        //This doesn't work properly
                        theBackgroundWorker.ReportProgress(parsed / count * 100);
                    }


                }
                //Done getting feed.
                if (theEvent != null)
                {
                    //Notify subscribers.
                    theEvent();
                }
            }
            catch (Exception ex)
            {
                //throw new ArgumentException(ex.ToString());
                MessageBox.Show("This is not a valid feed URL!" + "\n" + "Error: " + ex.ToString());
                if (failureEvent != null)
                {
                    failureEvent();
                }
            }
        }

        public void ParseDocElements(XmlNode parent, string xPath, ref string property)
        {
            XmlNode node = parent.SelectSingleNode(xPath);
            if (node != null)
            {
                property = node.InnerText;
            }
            else
            {
                property = "Unresolvable";
            }
        }

        private void ParseRSSNode(XmlNode node)
        {
            Rss.Items item = new Rss.Items();
            ParseDocElements(node, "title", ref item.Title);
            ParseDocElements(node, "description", ref item.Description);
            ParseDocElements(node, "link", ref item.Link);
            string date = null;
            ParseDocElements(node, "pubDate", ref date);
            DateTime.TryParse(date, out item.PubDate);
            _rssItems.Add(item);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_isDisposed)
            {
                _rssItems.Clear();
                _url = null;
                _title = null;
                _description = null;
            }
            _isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
    ///Replacement Code?
//    public class Channel
//    {
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public string Link { get; set; }

//        public List<Item> Items { get; set; }
//    }
//    public class Item
//    {
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public string Link { get; set; }
//        public string PubDate { get; set; }
//    }
//}

//var channels = xml.Elements("channel")
//    .Select(c =>
//        new Channel
//        {
//            Title = (string) c.Element("title"),
//            Description = (string) c.Element("description"),
//            Link = (string) c.Element("link"),
//            Items = c.Elements("item").Select(i =>
//                new Item
//                {
//                    Title = (string) i.Element("title"),
//                    Description = (string) i.Element("description"),
//                    Link = (string) i.Element("link"),
//                }).ToList()
//        }).ToList();