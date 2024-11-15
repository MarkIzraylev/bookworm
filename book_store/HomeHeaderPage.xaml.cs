using System;
using System.Collections.Generic;
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

namespace book_store
{
    /// <summary>
    /// Interaction logic for HomeHeaderPage.xaml
    /// </summary>
    public partial class HomeHeaderPage : Page
    {
        private MainWindow _mainWindow;
        bs_user _user;

        public HomeHeaderPage(MainWindow mainWindow, bs_user user = null)
        {
            InitializeComponent();
            _user = user;
            if (_user != null)
            {
                SignIn.Visibility = Visibility.Collapsed;
            } else
            {
                SignIn.Visibility = Visibility.Visible;
            }
            _mainWindow = mainWindow;
            //NavBar.Source = new Uri("ClientMenuPage.xaml", UriKind.Relative);
        }
        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else
                {
                    Application.Current.MainWindow.DragMove();
                }
        }

        private void AdjustWindowSize()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn.Visibility = Visibility.Hidden;
            _mainWindow.MainFrame.Navigate(new SignInPage(_mainWindow, this));
            //_mainWindow.MainFrame.Source = new Uri("SignInPage.xaml", UriKind.Relative);
        }

        private void CompanyName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SignIn.Visibility = Visibility.Visible;
            _mainWindow.MainFrame.Source = new Uri("HomePage.xaml", UriKind.Relative);
            
        }
    }
}
