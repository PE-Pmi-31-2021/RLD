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

            using (ApplicationContext db = new())
            {
                var startPage = db.Settings.FirstOrDefault(item => item.Name == "StartPage");
                if (startPage.Value == "Radios")
                {
                    RadiosPage radiosPage = new();
                    this.Content = radiosPage;
                }
                else if (startPage.Value == "Books")
                {
                    BooksPage booksPage = new();
                    this.Content = booksPage;
                }
                else if (startPage.Value == "Cards")
                {
                    Cards cardsPage = new();
                    this.Content = cardsPage;
                }
                else
                {
                    RadiosPage radiosPage = new();
                    this.Content = radiosPage;
                }
            }
        }
    }
}
