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
using System.Text.RegularExpressions;

namespace book_store
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        MainWindow _mainWindow;
        private HomeHeaderPage _homeHeaderPage;

        public SignUpPage(MainWindow mainWindow, HomeHeaderPage homeHeaderPage)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _homeHeaderPage = homeHeaderPage;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string su_last_name = LastNameInput.Text;
            string su_first_name = FirstNameInput.Text;
            string su_patronymic = PatronymicInput.Text;
            string su_email = EmailInput.Text;
            string su_password = PasswordInput.Password;
            string su_date_of_birth = DateOfBirthInput.SelectedDate.ToString();
            string su_passport = PassportInput.Text;
            string su_phone = PhoneInput.Text;
            if (su_first_name == "" || su_email == "" || su_password == "" || su_date_of_birth == "" || su_passport == "" || su_phone == "")
            {
                MessageBox.Show("Все поля, отмеченные звёздочкой (*), должны быть заполнены.");
                return;
            }
            if (su_first_name.Length > 50 || su_last_name.Length > 50 || su_patronymic.Length > 50)
            {
                MessageBox.Show("Поля \"Фамилия\", \"Имя\", \"Отчество\" должны содержать не более 50 символов каждое.");
                return;
            }
            if (su_password.Length > 50)
            {
                MessageBox.Show("Поле \"Пароль\" должно содержать не более 50 символов.");
                return;
            }
            Regex passport_regex = new Regex(@"^\d{10}$");
            if (!passport_regex.IsMatch(su_passport))
            {
                MessageBox.Show("Поле с серией и номером паспорта должно содержать ровно 10 цифр без пробелов или других разделителей.");
                return;
            }
            if (su_phone.Length > 20)
            {
                MessageBox.Show("Поле \"Номер телефона\" должно содержать не более 20 символов.");
                return;
            }
            DateTime selectedDate = DateOfBirthInput.SelectedDate.Value;
            DateTime threeYearsAgo = DateTime.Now.AddYears(-3);
            if (selectedDate >= threeYearsAgo)
            {
                MessageBox.Show("Кажется, у Вас пока что слишком малый возраст для пользования услугами приложения. Возвращайтесь чуть позже или зарегистрируйтесь, указав данные родителя (законного представителя) с его согласия.");
                return;
            }
            Regex email_regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!email_regex.IsMatch(su_email))
            {
                MessageBox.Show("Эл. почта не является действительной.");
                return;
            }
            Regex phone_regex = new Regex(@"^\+?\d+$");
            if (!phone_regex.IsMatch(su_phone))
            {
                MessageBox.Show("Номер телефона должен быть введён в следующем формате: вначале знак плюса (необязательно), затем некоторое количество цифр подряд без пробелов или других разделителей. Максимальное количество символов в номере телефона - 20.");
                return;
            }
            user83_dbEntities _context = new user83_dbEntities();
            bs_user new_user = new bs_user
            {
                last_name = su_last_name,
                first_name = su_first_name,
                patronymic = su_patronymic,
                email = su_email,
                id_role = 1,
                sign_up_date = DateTime.Now,
                password = su_password,
                date_of_birth = selectedDate,
                passport = su_passport,
                phone = su_phone,
                font_size = 16,
                font_color = "FF2B241F"
            };
            _context.bs_user.Add(new_user);
            _context.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно! Перенаправляем Вас в личный кабинет...", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            _homeHeaderPage.NavBar.Navigate(new ClientMenuPage(_mainWindow, new_user));
            _mainWindow.MainFrame.Navigate(new BookSearchPage(new_user, _mainWindow));
        }
    }
}
