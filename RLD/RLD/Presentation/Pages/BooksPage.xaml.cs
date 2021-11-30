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
        BitmapImage RLDIcon = new BitmapImage();
        BitmapImage radiosIcon = new BitmapImage();
        BitmapImage booksIcon = new BitmapImage();
        BitmapImage cardsIcon = new BitmapImage();
        BitmapImage settingsIcon = new BitmapImage();
        BitmapImage searchIcon = new BitmapImage();
        BitmapImage defaultBooksIcon = new BitmapImage();
        
        public List<Book> booksList { get; set; }
        public WebBrowser browser { get; set; }
        

        public BooksPage()
        {
            InitializeComponent();

            using (var db2 = new ApplicationContext())
            {
                if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Dark")
                {
                    var darkColor = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                    var lightColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                    Background = darkColor;

                    RLDLabel.Foreground = lightColor;
                    radiosLabel.Foreground = lightColor;
                    booksLabel.Foreground = lightColor;
                    cardsLabel.Foreground = lightColor;
                    settingsLabel.Foreground = lightColor;

                    RLDButton.Background = darkColor;
                    radiosButton.Background = darkColor;
                    booksButton.Background = darkColor;
                    cardsButton.Background = darkColor;
                    settingsButton.Background = darkColor;

                    txtNameToSearch.Background = darkColor;
                    txtNameToSearch.Foreground = lightColor;

                    bookName.Foreground = lightColor;
                    bookGenre.Foreground = lightColor;
                    bookAuthor.Foreground = lightColor;
                    bookYear.Foreground = lightColor;

                    booksDate.Background = darkColor;
                    booksDate.Foreground = lightColor;

                    addButton.Background = darkColor;
                    addButton.Foreground = lightColor;
                    readButton.Background = darkColor;
                    readButton.Foreground = lightColor;
                    editButton.Background = darkColor;
                    editButton.Foreground = lightColor;
                    deleteButton.Background = darkColor;
                    deleteButton.Foreground = lightColor;

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    defaultBooksIcon.BeginInit();
                    defaultBooksIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.DefaultBook);
                    defaultBooksIcon.EndInit();
                    bookImage.Source = defaultBooksIcon;

                    searchIcon.BeginInit();
                    searchIcon.StreamSource = new MemoryStream(RLD.Resources.DarkThemeIcons.Search);
                    searchIcon.EndInit();
                    searchIconXAML.Source = searchIcon;
                }

                else if (db2.Settings.Where(item => item.Name == "Theme").FirstOrDefault().Value == "Light")
                {
                    var lightColor = new SolidColorBrush(Color.FromRgb(235, 235, 235));
                    var darkColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                    Background = lightColor;

                    RLDLabel.Foreground = darkColor;
                    radiosLabel.Foreground = darkColor;
                    booksLabel.Foreground = darkColor;
                    cardsLabel.Foreground = darkColor;
                    settingsLabel.Foreground = darkColor;

                    RLDButton.Background = lightColor;
                    radiosButton.Background = lightColor;
                    booksButton.Background = lightColor;
                    cardsButton.Background = lightColor;
                    settingsButton.Background = lightColor;

                    txtNameToSearch.Background = lightColor;
                    txtNameToSearch.Foreground = darkColor;

                    bookName.Foreground = darkColor;
                    bookGenre.Foreground = darkColor;
                    bookAuthor.Foreground = darkColor;
                    bookYear.Foreground = darkColor;

                    booksDate.Background = lightColor;
                    booksDate.Foreground = darkColor;

                    addButton.Background = lightColor;
                    addButton.Foreground = darkColor;
                    readButton.Background = lightColor;
                    readButton.Foreground = darkColor;
                    editButton.Background = lightColor;
                    editButton.Foreground = darkColor;
                    deleteButton.Background = lightColor;
                    deleteButton.Foreground = darkColor;

                    booksIcon.BeginInit();
                    booksIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Books);
                    booksIcon.EndInit();
                    booksIconXAML.Source = booksIcon;

                    cardsIcon.BeginInit();
                    cardsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Cards);
                    cardsIcon.EndInit();
                    cardsIconXAML.Source = cardsIcon;

                    radiosIcon.BeginInit();
                    radiosIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Radios);
                    radiosIcon.EndInit();
                    radiosIconXAML.Source = radiosIcon;

                    RLDIcon.BeginInit();
                    RLDIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.RLD);
                    RLDIcon.EndInit();
                    RLDIconXAML.Source = RLDIcon;

                    settingsIcon.BeginInit();
                    settingsIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Settings);
                    settingsIcon.EndInit();
                    settingsIconXAML.Source = settingsIcon;

                    defaultBooksIcon.BeginInit();
                    defaultBooksIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.DefaultBook);
                    defaultBooksIcon.EndInit();
                    bookImage.Source = defaultBooksIcon;

                    searchIcon.BeginInit();
                    searchIcon.StreamSource = new MemoryStream(RLD.Resources.LightThemeIcons.Search);
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
