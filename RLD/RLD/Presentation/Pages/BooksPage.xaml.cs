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
        BitmapImage booksIcon = new BitmapImage();
        BitmapImage cardsIcon = new BitmapImage();
        BitmapImage radiosIcon = new BitmapImage();
        BitmapImage RLDIcon = new BitmapImage();
        BitmapImage settingsIcon = new BitmapImage();
        BitmapImage defaultBooksIcon = new BitmapImage();
        BitmapImage searchIcon = new BitmapImage();

        public List<Book> booksList { get; set; }
        public WebBrowser browser { get; set; }
        

        public BooksPage()
        {
            InitializeComponent();

            using (var db2 = new ApplicationContext())
            {
                if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                    RLDLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    radiosLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    booksLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    cardsLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    RLDButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    radiosButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    booksButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    cardsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    settingsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));

                    RLDButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    radiosButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    booksButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    cardsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    settingsButton.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(Icons.IconsResources.BooksIconDark);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(Icons.IconsResources.CardsIconDark);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(Icons.IconsResources.RadiosIconDark);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(Icons.IconsResources.RLDIconDark);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(Icons.IconsResources.SettingsIconDark);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    defaultBooksIcon.BeginInit();
                    defaultBooksIcon.StreamSource = new MemoryStream(Icons.IconsResources.DefaultBooksIconLight);
                    defaultBooksIcon.EndInit();
                    bookImage.Source = defaultBooksIcon;

                    searchIcon.BeginInit();
                    searchIcon.StreamSource = new MemoryStream(Icons.IconsResources.SearchIconLight);
                    searchIcon.EndInit();
                    searchIconXAML.Source = searchIcon;
                }

                else if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
                {
                    RLDLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    radiosLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    booksLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    cardsLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    settingsLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    RLDButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    radiosButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    booksButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    cardsButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    settingsButton.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(Icons.IconsResources.BooksIconLight);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(Icons.IconsResources.CardsIconLight);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(Icons.IconsResources.RadiosIconLight);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(Icons.IconsResources.RLDIconLight);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(Icons.IconsResources.SettingsIconLight);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    defaultBooksIcon.BeginInit();
                    defaultBooksIcon.StreamSource = new MemoryStream(Icons.IconsResources.DefaultBooksIconLight);
                    defaultBooksIcon.EndInit();
                    bookImage.Source = defaultBooksIcon;

                    searchIcon.BeginInit();
                    searchIcon.StreamSource = new MemoryStream(Icons.IconsResources.SearchIconLight);
                    searchIcon.EndInit();
                    searchIconXAML.Source = searchIcon;


                }
            }

            browser = new WebBrowser();

            booksList = new List<Book> { };

            var db = new ApplicationContext(); ;
            db.Books.Load();
            booksList = db.Books.Local.ToList();
            booksDate.ItemsSource = booksList;
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
                        bookImage.Source = defaultBooksIcon;
                }
            }
            else
                bookImage.Source = defaultBooksIcon;
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
