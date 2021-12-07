using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using RLD.BLL;

namespace RLD.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for BookDialogWindow.xaml.
    /// </summary>
    public partial class BookEditDialog : Window
    {
        private byte[] Image { get; set; }
        private string NewBookUrl { get; set; }
        private string PreviousName { get; set; }

        private bool imageChanged;
        private bool urlChanged;

        public BookEditDialog(string bookName, string bookAuthor, string bookGenre, DateTime bookNewTime)
        {
            InitializeComponent();

            using (var db = new ApplicationContext())
            {
                if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                    var darkColor = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    var lightColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    Background = darkColor;
                    Foreground = lightColor;

                    bookGenreInput.Background = darkColor;
                    bookGenreInput.Foreground = lightColor;
                    bookNameInput.Background = darkColor;
                    bookNameInput.Foreground = lightColor;
                    authorNameInput.Background = darkColor;
                    authorNameInput.Foreground = lightColor;
                    bookYearInput.Background = darkColor;
                    bookYearInput.Foreground = darkColor;

                    browseBookButton.Background = darkColor;
                    browseBookButton.Foreground = lightColor;
                    browseIconButton.Background = darkColor;
                    browseIconButton.Foreground = lightColor;
                    OKButton.Background = darkColor;
                    OKButton.Foreground = lightColor;
                    cancelButton.Background = darkColor;
                    cancelButton.Foreground = lightColor;
                }
                else if (db.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
                {
                    var lightColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    var darkColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    Background = lightColor;
                    Foreground = darkColor;

                    bookGenreInput.Background = lightColor;
                    bookGenreInput.Foreground = darkColor;
                    bookNameInput.Background = lightColor;
                    bookNameInput.Foreground = darkColor;
                    authorNameInput.Background = lightColor;
                    authorNameInput.Foreground = darkColor;
                    bookYearInput.Background = lightColor;
                    bookYearInput.Foreground = darkColor;

                    browseBookButton.Background = lightColor;
                    browseBookButton.Foreground = darkColor;
                    browseIconButton.Background = lightColor;
                    browseIconButton.Foreground = darkColor;
                    OKButton.Background = lightColor;
                    OKButton.Foreground = darkColor;
                    cancelButton.Background = lightColor;
                    cancelButton.Foreground = darkColor;
                }
            }

            PreviousName = bookName;

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
                    if (bookNameInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter book name!");
                    }
                    else if (authorNameInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter author name!");
                    }
                    else if (bookGenreInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter book genre!");
                    }
                    else if (bookYearInput.SelectedDate == null)
                    {
                        MessageBox.Show("Enter book release date!");
                    }
                    else
                    {
                        existingBook.Name = bookNameInput.Text;
                        existingBook.Author = authorNameInput.Text;
                        existingBook.Genre = bookGenreInput.Text;
                        existingBook.YearOfRelease = bookYearInput.SelectedDate.Value;

                        if (imageChanged)
                        {
                            existingBook.Picture = Image;
                        }

                        if (urlChanged)
                        {
                            existingBook.BookURL = NewBookUrl;
                        }

                        db.Update(existingBook);
                        db.SaveChanges();
                        this.DialogResult = true;
                    }
                }
                else
                {
                    var previousBook = db.Books.FirstOrDefault(item => item.Name == PreviousName);
                    if (previousBook != null)
                    {
                        Image = previousBook.Picture;
                        NewBookUrl = previousBook.BookURL;
                    }

                    if (bookNameInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter book name!");
                    }
                    else if (authorNameInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter author name!");
                    }
                    else if (bookGenreInput.Text == string.Empty)
                    {
                        MessageBox.Show("Enter book genre!");
                    }
                    else if (bookYearInput.SelectedDate == null)
                    {
                        MessageBox.Show("Enter book release date!");
                    }
                    else
                    {
                        var book = new Book();
                        book.Name = bookNameInput.Text;
                        book.Author = authorNameInput.Text;
                        book.Genre = bookGenreInput.Text;
                        book.YearOfRelease = bookYearInput.SelectedDate.Value;
                        book.Picture = Image;
                        book.BookURL = NewBookUrl;

                        db.Books.Add(book);
                        db.Books.Remove(db.Books.FirstOrDefault(item => item.Name == PreviousName));
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
                NewBookUrl = choofdlog.FileName;
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
                        Image = fileData;
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
