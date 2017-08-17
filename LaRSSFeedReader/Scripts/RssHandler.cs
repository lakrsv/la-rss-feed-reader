using System;
using System.Xml;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml.Linq;
using System.Linq;
using System.ServiceModel.Syndication;

namespace LaRSSFeedReader.Scripts
{
    class RssHandler : IDisposable
    {
        public delegate void failureEventHandler();
        public event failureEventHandler failureEvent;
        public delegate void myEventHandler();
        public event myEventHandler theEvent;
        private string _url, _title, _description;
        private Collection<Item> _rssItems = new Collection<Item>();
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
        public Collection<Item> RssItems
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
            if (string.IsNullOrEmpty(Url))
            {
                MessageBox.Show("You must provide a feed URL!");
                failureEvent?.Invoke();
                return;
            }

            try
            {
                using (XmlReader reader = XmlReader.Create(Url))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    var feedit = feed.Items;
                    var feedItems = feed.Items.Select(i => new Item
                    {
                        Title = i.Title?.Text,
                        Description = i.Summary?.Text,
                        Link = i.Links[0]?.Uri.ToString(),
                        PubDate = i.LastUpdatedTime.ToString()
                    }).ToList();

                    feedItems.ForEach(i => _rssItems.Add(i));
                }
                theEvent?.Invoke();
            }
            catch (Exception ex)
            {
                //throw new ArgumentException(ex.ToString());
                MessageBox.Show("This is not a valid feed URL!" + "\n" + "Error: " + ex.ToString());
                failureEvent?.Invoke();
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