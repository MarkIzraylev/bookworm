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
    /// Interaction logic for CashierMenuPage.xaml
    /// </summary>
    public partial class CashierMenuPage : Page
    {
        public static MainWindow _mainWindow;
        bs_user _user;
        public CashierMenuPage(MainWindow mainWindow, bs_user user)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _user = user;
        }

        private void OrdersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new OrderCheckPage());
        }
    }
}
