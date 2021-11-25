using RLD.BLL;
using RLD.Presentation;
using RLD.Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RLD.Pages
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public List<Book> booksList { get; set; }
        public WebBrowser browser { get; set; }
        BitmapImage defaultImage = new BitmapImage();

        public BooksPage()
        {
            InitializeComponent();

            browser = new WebBrowser();

            booksList = new List<Book> { };

            var db = new ApplicationContext(); ;
            db.Books.Load();
            booksList = db.Books.Local.ToList();
            booksDate.ItemsSource = booksList;

            defaultImage.BeginInit();
            defaultImage.UriSource = new Uri(@"../../Icons/DefaultRadioIcon.png", UriKind.Relative);
            defaultImage.EndInit();
        }

        private void txtNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txtOrig = txtNameToSearch.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var booksFiltered = from book in booksList
                                let ename = book.Name
                                where ename.StartsWith(lower) || ename.StartsWith(upper) || ename.Contains(txtOrig)
                                select book;

            booksDate.ItemsSource = booksFiltered;
        }

        private void SettingsMenu(object sender, RoutedEventArgs e)
        {
            Settings settingsPage = new Settings();
            this.Content = new Frame() { Content = settingsPage };
        }

        private void RadiosMenu(object sender, RoutedEventArgs e)
        {
            RadiosPage radiosPage = new RadiosPage();
            this.Content = new Frame() { Content = radiosPage };
        }

        private void CardsMenu(object sender, RoutedEventArgs e)
        {
            Cards cardsPage = new Cards();
            this.Content = new Frame() { Content = cardsPage };
        }
        private void addBook(object sender, RoutedEventArgs e)
        {
            var window = new BookDialogWindow();
            window.ShowDialog();

            using (var db = new ApplicationContext())
            {
                var query = from b in db.Books
                            select b;

                booksList = query.ToList();
                booksDate.ItemsSource = query.ToList();
            }
        }
        private void readBook(object sender, RoutedEventArgs e)
        {
            var currentBook = (Book)booksDate.SelectedItem;
            try
            {
                browserHost.Navigate(new Uri(String.Format("file:///" + currentBook.bookURL.Replace("\"", ""))));
            }
            catch
            {
                MessageBox.Show("Invalid book url");
            }

        }
        private void deleteBook(object sender, RoutedEventArgs e)
        {
            if (booksDate.SelectedItem != null)
            {
                var window = new BookConfirmDelete();
                window.ShowDialog();

                bool? result = window.DialogResult;

                if (result.HasValue && result == true)
                {
                    using (var db = new ApplicationContext())
                    {
                        var book = (Book)booksDate.SelectedItem;
                        db.Books.Remove(db.Books.FirstOrDefault(item => item.Name == book.Name));
                        db.SaveChanges();

                        var query = from b in db.Books
                                    select b;

                        booksList = query.ToList();
                        booksDate.ItemsSource = query.ToList();
                    }
                }
            }
        }

        private void BooksDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (booksDate.SelectedItem != null)
            {
                using (var db = new ApplicationContext())
                {
                    var currentBook  = (Book) booksDate.SelectedItem;

                    bookName.Text = currentBook.Name;
                    bookAuthor.Text = currentBook.Author;
                    bookGenre.Text = currentBook.Genre;
                    bookYear.Text = currentBook.YearOfRelease.Year.ToString();

                    if (currentBook.Picture != null)
                    {
                        var currentBookImage = new BitmapImage();
                        currentBookImage.BeginInit();
                        currentBookImage.StreamSource = new MemoryStream(currentBook.Picture);
                        currentBookImage.EndInit();
                        bookImage.Source = currentBookImage;
                    }
                    else
                        bookImage.Source = defaultImage;
                }
            }
            else
                bookImage.Source = defaultImage;
        }

        private void editBook(object sender, RoutedEventArgs e)
        {
            if (booksDate.SelectedItem != null)
            {
                var selectedBook = (Book) booksDate.SelectedItem;
                Book book;
                using (var db = new ApplicationContext())
                {
                    book = db.Books.FirstOrDefault(item => item.Name == selectedBook.Name);
                }

                var window = new BookEditDialog(book.Name, book.Author, book.Genre, book.YearOfRelease);
                window.ShowDialog();

                using (var db = new ApplicationContext())
                {
                    var query = from b in db.Books
                                select b;

                    booksList = query.ToList();
                    booksDate.ItemsSource = query.ToList();
                }
            }
        }
    }
}
