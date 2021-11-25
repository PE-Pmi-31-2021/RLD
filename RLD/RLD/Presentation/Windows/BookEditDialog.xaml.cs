using Microsoft.Win32;
using RLD.BLL;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RLD.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for BookDialogWindow.xaml
    /// </summary>
    public partial class BookEditDialog : Window
    {
        byte[] image { get; set; }
        string newBookUrl { get; set; }
        string previousName { get; set; }

        bool imageChanged = false;
        bool urlChanged = false;

        public BookEditDialog(string bookName, string bookAuthor, string bookGenre, DateTime bookNewTime)
        {
            InitializeComponent();
            previousName = bookName;

            bookNameInput.Text = bookName;
            authorNameInput.Text = bookAuthor;
            bookGenreInput.Text = bookGenre;
            bookYearInput.SelectedDate = bookNewTime;
        }

        private void Book_Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var existingBook = db.Books.FirstOrDefault(item => item.Name == bookNameInput.Text);

                if (existingBook != null)
                {
                    if (bookNameInput.Text == "")
                        MessageBox.Show("Enter book name!");

                    else if (authorNameInput.Text == "")
                        MessageBox.Show("Enter author name!");

                    else if (bookGenreInput.Text == "")
                        MessageBox.Show("Enter book genre!");

                    else if (bookYearInput.SelectedDate == null)
                        MessageBox.Show("Enter book release date!");

                    else
                    {
                        existingBook.Name = bookNameInput.Text;
                        existingBook.Author = authorNameInput.Text;
                        existingBook.Genre = bookGenreInput.Text;
                        existingBook.YearOfRelease = bookYearInput.SelectedDate.Value;

                        if (imageChanged)
                            existingBook.Picture = image;

                        if (urlChanged)
                            existingBook.bookURL = newBookUrl;

                        db.Update(existingBook);
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
                else
                {
                    var previousBook= db.Books.FirstOrDefault(item => item.Name == previousName);
                    if (previousBook != null)
                    {
                        image = previousBook.Picture;
                        newBookUrl = previousBook.bookURL;
                    }

                    if (bookNameInput.Text == "")
                        MessageBox.Show("Enter book name!");

                    else if (authorNameInput.Text == "")
                        MessageBox.Show("Enter author name!");

                    else if (bookGenreInput.Text == "")
                        MessageBox.Show("Enter book genre!");

                    else if (bookYearInput.SelectedDate == null)
                        MessageBox.Show("Enter book release date!");

                    else
                    {
                        var book = new Book();
                        book.Name = bookNameInput.Text;
                        book.Author = authorNameInput.Text;
                        book.Genre = bookGenreInput.Text;
                        book.YearOfRelease = bookYearInput.SelectedDate.Value;
                        book.Picture = image;
                        book.bookURL = newBookUrl;

                        db.Books.Add(book);
                        db.Books.Remove(db.Books.FirstOrDefault(item => item.Name == previousName));
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Browse_Book(object sender, RoutedEventArgs e)
        {
            var choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Pdf Files|*.pdf";
            choofdlog.ShowDialog();
            try
            {
                newBookUrl = choofdlog.FileName;
                urlChanged = true;
            }
            catch (Exception)
            {
                return;
            }
        }
        private void Browse_Image(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Image";
            dialog.DefaultExt = ".png";
            dialog.Filter = "Image (.png)|*.png";

            bool? result = dialog.ShowDialog();
            Stream file;
            try
            {
                file = dialog.OpenFile();
                imageChanged = true;

                using (var db = new ApplicationContext())
                {
                    byte[] fileData = null;

                    using (var binaryReader = new BinaryReader(file))
                    {
                        fileData = binaryReader.ReadBytes((int)file.Length);
                    }

                    if (fileData != null)
                    {
                        image = fileData;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
