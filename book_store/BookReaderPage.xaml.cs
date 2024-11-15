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
    /// Interaction logic for BookReaderPage.xaml
    /// </summary>
    public partial class BookReaderPage : Page
    {
        private string[] _pages;
        private int _currentPage;
        private int _book_id;
        private bs_user _user;
        user83_dbEntities _context;
        string _bookText;
        public BookReaderPage(int book_id, bs_user user)
        {
            InitializeComponent();

            _book_id = book_id;
            _user = user;
            _context = new user83_dbEntities();
            // Load the book text from the database
            _bookText = LoadBookTextFromDatabase();

            // Split the book text into pages
            _pages = SplitTextIntoPages(_bookText, Convert.ToInt32((900 / Convert.ToInt32(_user.font_size)) * (140 / Convert.ToInt32(_user.font_size))));
            bookTextBlock.FontSize = Convert.ToInt32(_user.font_size);
            //MessageBox.Show(_user.font_size.ToString());
            bookTextBlock.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + _user.font_color));

            // Show the first page
            
            if (_context.bs_user_edition.Any(r => r.id_edition == book_id && r.id_user == user.id && r.current_page != null && r.current_page > 0))
            {
                ShowPage((int)_context.bs_user_edition.FirstOrDefault(r => r.id_edition == book_id && r.id_user == user.id && r.current_page != null && r.current_page > 0).current_page);
            } else
            {
                ShowPage(0);
            }
        }

        private string LoadBookTextFromDatabase()
        {
            // Replace this with your actual database code
            
            return _context.bs_edition.Find(_book_id).text;
        }

        private string[] SplitTextIntoPages(string text, int charsPerPage)
        {
            string[] pages = new string[(text.Length + charsPerPage - 1) / charsPerPage];
            for (int i = 0; i < pages.Length; i++)
            {
                int start = i * charsPerPage;
                int end = Math.Min(start + charsPerPage, text.Length);
                pages[i] = text.Substring(start, end - start);
            }
            return pages;
        }

        private void ShowPage(int pageIndex)
        {
            _currentPage = pageIndex;
            _context.bs_user_edition.FirstOrDefault(r => r.id_edition == _book_id && r.id_user == _user.id).current_page = _currentPage;
            _context.SaveChanges();

            currPage.Content = (_currentPage + 1).ToString();
            if (pageIndex > _pages.Count() - 1)
            {
                pageIndex = _pages.Count() - 1;
            }
            if (pageIndex < 0)
            {
                pageIndex = 0;
            }
            bookTextBlock.Text = _pages[pageIndex];
            prevButton.IsEnabled = pageIndex > 0;
            nextButton.IsEnabled = pageIndex < _pages.Length - 1;
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(_currentPage - 1);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(_currentPage + 1);
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int new_font_size = Convert.ToInt32(((ComboBoxItem)FontSizeComboBox.SelectedItem).Tag);
            bookTextBlock.FontSize = new_font_size;
            //MessageBox.Show(new_font_size.ToString());
            _context.bs_user.FirstOrDefault(u => u.id == _user.id).font_size = new_font_size;
            _context.SaveChanges();
            _user.font_size = new_font_size;

            _pages = SplitTextIntoPages(_bookText, Convert.ToInt32((900 / new_font_size) * (140 / new_font_size)));
            ShowPage(_currentPage);
            bookTextBlock.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + _user.font_color));

        }

        private void FontColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string new_font_color = Convert.ToString(((ComboBoxItem)FontColorComboBox.SelectedItem).Tag);
            Color color = (Color)ColorConverter.ConvertFromString("#" + new_font_color);
            bookTextBlock.Foreground = new System.Windows.Media.SolidColorBrush(color);
            _context.bs_user.FirstOrDefault(u => u.id == _user.id).font_color = new_font_color;
            _context.SaveChanges();
            _user.font_color = new_font_color;
        }
    }
}
