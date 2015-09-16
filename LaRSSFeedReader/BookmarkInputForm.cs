using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaRSSFeedReader
{
    public partial class BookmarkInputForm : Form
    {
        private BookmarkHandler bookMarkHandler = new BookmarkHandler();
        public BookmarkInputForm()
        {
            InitializeComponent();
            PopulateBookmarks();
        }

        private void addbookmarkbutton_Click(object sender, EventArgs e)
        {
            string name = bookmarkname.Text;
            string url = bookmarkurl.Text;

            if (name.Length == 0 || url.Length == 0)
            {
                MessageBox.Show("You must provide Name and URL!");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("You must provide a Name!");
                return;
            }
            else if (url.Length == 0)
            {
                MessageBox.Show("You must provide an URL!");
                return;
            }
            bookMarkHandler.CreateBookmark(name, url);
            this.Close();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removebookmarkbutton_Click(object sender, EventArgs e)
        {
            if (bookmarkremovelist.Text.Length > 0 && bookmarkremovelist.Text != "Choose Bookmark")
            {
                bookMarkHandler.RemoveBookmark(bookmarkremovelist.Text);
                bookmarkremovelist.Items.Remove(bookmarkremovelist.Items[bookmarkremovelist.SelectedIndex]);
                bookmarkremovelist.Text = "Choose Bookmark";
            }
        }
        private void PopulateBookmarks()
        {
            foreach (KeyValuePair<string, string> bookmark in BookmarkHandler.BookMarks)
            {
                bookmarkremovelist.Items.Add(bookmark.Key);
            }
        }

        private void bookmarkremovelist_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
