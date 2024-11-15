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
    /// Interaction logic for ClientMenuPage.xaml
    /// </summary>
    public partial class ClientMenuPage : Page
    {
        public static MainWindow _mainWindow;
        bs_user _user;
        public ClientMenuPage(MainWindow mainWindow, bs_user user)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _user = user;
        }

        private void SearchMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new BookSearchPage(_user, _mainWindow));
        }

        private void ShelfMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new BookSearchPage(_user, _mainWindow, "shelf"));
        }

        private void CartMenuSubItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new BookSearchPage(_user, _mainWindow, "cart"));
        }

        private void ActiveMenuSubItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new BookSearchPage(_user, _mainWindow, "active"));
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new HomePage());
            _mainWindow.HeaderFrame.Navigate(new HomeHeaderPage(_mainWindow));
        }

        private void FinishedMenuSubItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new BookSearchPage(_user, _mainWindow, "finished"));
        }
    }
}
