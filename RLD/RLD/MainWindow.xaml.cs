using System.Linq;
using System.Windows;
using log4net;
using RLD.Pages;

namespace RLD
{
    public partial class MainWindow : Window
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

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
