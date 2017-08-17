using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Threading;
using System.Text.RegularExpressions;
using LaRSSFeedReader.Scripts;

namespace LaRSSFeedReader
{
    public partial class Form1 : Form
    {
        Form BookmarkForm;
        BackgroundWorker progressWorker = new BackgroundWorker();
        RssHandler handler = new RssHandler();
        Collection<Item> list;
        DataGridViewRow row;
        public static ProgressBar TheProgressBar;
        public Form1()
        {
            InitializeComponent();
            bookmarks.MouseWheel += bookmarks_MouseWheel;
            BookmarkHandler.GetBookmarks();
            handler.theEvent += handler_theEvent;
            handler.failureEvent += handler_failureEvent;
            this.pictureBox1.Enabled = false;
            progressWorker.WorkerReportsProgress = true;
            progressWorker.WorkerSupportsCancellation = true;
            progressWorker.DoWork += new DoWorkEventHandler(handler.GetFeed);
            progressWorker.ProgressChanged += new ProgressChangedEventHandler(progressWorker_ProgressChanged);
            handler.theBackgroundWorker = progressWorker;
        }

        void bookmarks_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void progressWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void urlbutton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pictureBox1.Enabled = true;
                if (TheProgressBar == null)
                {
                    TheProgressBar = progressBar1;
                }
                progressBar1.Value = 0;
                if (row == null)
                {
                    row = (DataGridViewRow)feedbox.Rows[0].Clone();
                    feedbox.AllowUserToAddRows = false;
                }
                handler.Dispose();
                CleanFeedBox();
                list = null;
                //Thread t = new Thread(new ThreadStart(GetFeedCollectionMethods));
                //t.Start();
                GetFeedCollectionMethods();
            }
            catch (Exception ex)
            {
                this.pictureBox1.Enabled = false;
                MessageBox.Show(ex.ToString());
            }
        }
        private void GetFeedCollectionMethods()
        {
            handler.Url = urlinput.Text;
            //handler.GetFeed();
            if (!progressWorker.IsBusy) { progressWorker.RunWorkerAsync(); }
        }
        private void handler_theEvent()
        {
            this.Invoke((MethodInvoker)delegate { this.pictureBox1.Enabled = false; });
            list = handler.RssItems;
            for (int i = 0; i < list.Count; i++)
            {
                string title = list[i].Title;
                string date = list[i].PubDate;
                DataGridViewRow clonerow = (DataGridViewRow)row.Clone();
                clonerow.Cells[0].Value = title;
                clonerow.Cells[1].Value = date;

                this.Invoke((MethodInvoker)delegate { feedbox.Rows.Add(clonerow); });
                //feedbox.Rows.Add(row);


            }
        }
        private void handler_failureEvent()
        {
            //If the handler fails, fire this event.
            //this.pictureBox1.Enabled = false;
        }

        private void feedbox_DoubleClick(object sender, EventArgs e)
        {
            if (feedbox.Rows.Count > 1)
            {
                string url = list[feedbox.CurrentCell.RowIndex].Link;
                System.Diagnostics.Process.Start(url);
            }
        }

        private void feedbox_SelectionChanged(object sender, EventArgs e)
        {
            if (feedbox.Rows.Count > 1)
            {
                int index = feedbox.CurrentCell.RowIndex;
                if (index > list.Count - 1)
                {
                    return;
                }
                //string description = ClearHTMLTagsFromString(list[index].Description);
                string description = list[index].Description;
                feedinfo.DocumentText = description;
                //feedinfo.Text = description;
            }
        }
        //private string ClearHTMLTagsFromString(string htmlString)
        //{
        //    string regEx = @"\<[^\<\>]*\>";
        //    string tagless = Regex.Replace(htmlString, regEx, string.Empty);

        //    // remove rogue leftovers
        //    tagless = tagless.Replace("<", string.Empty).Replace(">", string.Empty);

        //    return tagless;
        //}
        private void CleanFeedBox()
        {
            while (feedbox.Rows.Count != 0)
            {
                feedbox.Rows.RemoveAt(0);
            }
        }

        private void bookmarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Disable editing of bookmarks box.
            e.Handled = true;
        }

        private void bookmarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookmarks.Text == "Add/Remove Bookmark")
            {
                //Display Bookmarkform
                BookmarkForm = null;
                BookmarkForm = new BookmarkInputForm();
                BookmarkForm.Show();
                bookmarks.Text = "Bookmarks";
            }
            else if (bookmarks.Text.Length > 0)
            {
                string url = BookmarkHandler.BookMarks[bookmarks.Text];
                urlinput.Text = url;
                urlbutton_Click(null, null);
            }
        }

        private void bookmarks_DropDown(object sender, EventArgs e)
        {
            bookmarks.Items.Clear();
            bookmarks.Items.Add("Add/Remove Bookmark");

            foreach (KeyValuePair<string, string> bookmark in BookmarkHandler.BookMarks)
            {
                bookmarks.Items.Add(bookmark.Key);
            }
        }
    }
}
