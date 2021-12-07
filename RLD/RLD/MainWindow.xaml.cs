using System.Linq;
using System.Windows;
using RLD.Pages;

namespace RLD
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                var startPage = db.Settings.FirstOrDefault(item => item.Name == "StartPage");
                if (startPage.Value == "Radios")
                {
                    RadiosPage radiosPage = new RadiosPage();
                    this.Content = radiosPage;
                }
                else if (startPage.Value == "Books")
                {
                    BooksPage booksPage = new BooksPage();
                    this.Content = booksPage;
                }
                else if (startPage.Value == "Cards")
                {
                    Cards cardsPage = new Cards();
                    this.Content = cardsPage;
                }
                else
                {
                    RadiosPage radiosPage = new RadiosPage();
                    this.Content = radiosPage;
                }
            }
        }
    }
}
