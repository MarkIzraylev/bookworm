using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace book_store
{
    /// <summary>
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private MainWindow _mainWindow;
        private HomeHeaderPage _homeHeaderPage;

        public SignInPage(MainWindow mainWindow, HomeHeaderPage homeHeaderPage)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _homeHeaderPage = homeHeaderPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailInput.Text;
            string password = PasswordInput.Password;
            var user = GetUser(email, password);
            if (user == null)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Такого аккаунта нет или учётные данные введены некорректно.",
                    "Ошибка авторизации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            switch (user.id_role)
            {
                case 1: // клиент
                    _homeHeaderPage.NavBar.Navigate(new ClientMenuPage(_mainWindow, user));
                    _mainWindow.MainFrame.Navigate(new BookSearchPage(user, _mainWindow));
                    break;
                case 3: // кассир
                    _homeHeaderPage.NavBar.Navigate(new CashierMenuPage(_mainWindow, user));
                    _mainWindow.MainFrame.Navigate(new OrderCheckPage());
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show(
                        "Роль, принадлежащая учётной записи, не найдена. Пожалуйста, обратитесь к тех. поддержке для решения проблемы со входом в аккаунт.",
                        "Ошибка авторизации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;
            }
            
        }

        private bs_user GetUser(string email, string password)
        {
            return App.db.bs_user.FirstOrDefault(u => u.email == email && u.password == password);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new SignUpPage(_mainWindow, _homeHeaderPage));
        }
    }
}
