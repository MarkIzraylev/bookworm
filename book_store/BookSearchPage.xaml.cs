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
using System.ComponentModel;
using System.Windows.Threading;
using System.Data.Entity;

namespace book_store
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public string ShortDescription { get; set; }
        public decimal Rating { get; set; }
        public bool IsDigital { get; set; }
        public string CoverImagePath { get; set; }
    }

    public class RelayCommand : ICommand
    {
        private Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }

    public class BookViewModel
    {
        public Book Book { get; set; }
        public ICommand ButtonCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }
        public int Id { get; set; }
        public string Quantity { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public string ShortDescription { get; set; }
        public decimal Rating { get; set; }
        public bool IsDigital { get; set; }
        public string CoverImagePath { get; set; }
        public BookSearchPage _bsp;
        public static MainWindow _mainWindow;
        public BookViewModel(Book book, bs_user user, string _type, BookSearchPage bsp, user83_dbEntities _context, MainWindow mainWindow)
        {
            Book = book;
            _bsp = bsp;
            _mainWindow = mainWindow;

            if (_type == "shelf") {
                ButtonText = "убрать с полки";
                ButtonCommand = new RelayCommand(() => RemoveFromShelf(book, user, _type));
                //ReadCommand = new RelayCommand(() => MessageBox.Show("read book with id " + book.Id.ToString()));
                ReadCommand = new RelayCommand(() => _mainWindow.MainFrame.Navigate(new BookReaderPage(book.Id, user)));
            } else if (_type == "cart") {
                ButtonText = "убрать из корзины";
                ButtonCommand = new RelayCommand(() => RemoveFromCart(book, user, _type));
            }
            else if (_type == "active")
            {
                var c = _context.bs_user_edition.OrderByDescending(r => r.id).Where(r => r.id_user == user.id && r.id_edition == book.Id && r.id_order != null);
                ButtonText = c.Select(r => r.quantity).Sum().ToString();
                var last_suitable_purchase = c.OrderByDescending(r => r.id).FirstOrDefault();
                int status_id = _context.bs_order.Where(r => r.id == last_suitable_purchase.id_order).FirstOrDefault().id_order_status;
                string status = _context.bs_order_status.Find(status_id).name;
                ButtonText += ": заказ " + status;
                ButtonCommand = new RelayCommand(() => { return; });
            }
            else if (_type == "finished")
            {
                var c = _context.bs_user_edition.OrderByDescending(r => r.id).Where(r => r.id_user == user.id && r.id_edition == book.Id && r.id_order != null);
                ButtonText = c.Select(r => r.quantity).Sum().ToString();
                var last_suitable_purchase = c.OrderByDescending(r => r.id).FirstOrDefault();
                int status_id = _context.bs_order.Where(r => r.id == last_suitable_purchase.id_order).FirstOrDefault().id_order_status;
                string status = _context.bs_order_status.Find(status_id).name;
                ButtonText += ": заказ " + status;
                ButtonCommand = new RelayCommand(() => { return; });
            }
            else if (book.IsDigital)
            {
                ButtonText = "на полку";
                ButtonCommand = new RelayCommand(() => { AddOnShelf(book, user, _type, _bsp); });
            }
            else
            {
                ButtonText = "в корзину";
                ButtonCommand = new RelayCommand(() => { AddToCart(book, user, _type, _bsp); });
            }
            Title = book.Title;
            AuthorName = book.AuthorName;
            ShortDescription = book.ShortDescription;
            Rating = book.Rating;
            CoverImagePath = book.CoverImagePath;
            
            var que = _context.bs_user_edition.FirstOrDefault(row => row.id_user == user.id && row.id_edition == book.Id && row.id_order == null);
            if (que != null && (_type == "" || _type == "cart"))
                Quantity = que.quantity.ToString() + " шт.";

            
        }

        private void AddOnShelf(Book book, bs_user user, string _type, BookSearchPage _bsp)
        {
            //MessageBox.Show("Книга добавлена на полку!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            AddUserEditionRow(book, user, "add onto shelf", _bsp);
        }

        private void RemoveFromShelf(Book book, bs_user user, string _type)
        {
            //MessageBox.Show("Книга убрана с полки!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            RemoveUserEditionRow(book, user, _type);
        }

        private void RemoveFromCart(Book book, bs_user user, string _type)
        {
            //MessageBox.Show("Книга убрана из корзины!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            RemoveUserEditionRow(book, user, _type);
        }

        private void AddToCart(Book book, bs_user user, string _type, BookSearchPage _bsp)
        {
            AddUserEditionRow(book, user, "add to cart", _bsp);
            user83_dbEntities _context = new user83_dbEntities();
            int new_quantity = (int)_context.bs_user_edition.FirstOrDefault(row => row.id_user == user.id && row.id_edition == book.Id && row.is_on_bookshelf == false && row.id_order == null).quantity;
            //MessageBox.Show("Книга добавлена в корзину! В корзине " + new_quantity.ToString() + " шт. данного произведения.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddUserEditionRow(Book book, bs_user user, string where_to_add, BookSearchPage _bsp)
        {
            user83_dbEntities _context = new user83_dbEntities();
            bool isOnBookshelf = true;
            if (where_to_add == "add to cart")
            {
                isOnBookshelf = false;
            }
            if (_context.bs_user_edition.Any(row => row.id_user == user.id && row.id_edition == book.Id && row.is_on_bookshelf == false && row.id_order == null))
            {
                _context.bs_user_edition.FirstOrDefault(row => row.id_user == user.id && row.id_edition == book.Id && row.is_on_bookshelf == false && row.id_order == null).quantity += 1;
            } else
            {
                _context.bs_user_edition.Add(new bs_user_edition
                {
                    id_user = user.id,
                    id_edition = book.Id,
                    current_page = 0,
                    quantity = 1,
                    is_on_bookshelf = isOnBookshelf,

                });
            }
            
            _context.SaveChanges();
            _bsp.Search(user);
        }

        private void RemoveUserEditionRow(Book book, bs_user user, string _type)
        {
            user83_dbEntities _context = new user83_dbEntities();
            _context.bs_user_edition
            .Where(row => row.id_edition == book.Id && row.id_user == user.id && (_type == "cart" ? row.id_order == null : true))
            .ToList()
            .ForEach(x => _context.bs_user_edition.Remove(x));
            _context.SaveChanges();
            _bsp.Search(user);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BookRepository
    {
        private BookSearchPage _bsp;
        private readonly user83_dbEntities _context;
        private bs_user _user;
        public static MainWindow _mainWindow;

        public BookRepository(user83_dbEntities context, BookSearchPage bsp, bs_user user, MainWindow mainWindow)
        {
            _context = context;
            _bsp = bsp;
            _user = user;
            _mainWindow = mainWindow;
        }

        public List<BookViewModel> GetAllBooks(string query_string = "", string _type = "")
        {
            List<BookViewModel> books = new List<BookViewModel>();
            //bs_edition entity = _context.ChangeTracker.Entries().;
            //_context.Entry().Reload();

            foreach (var edition in _context.bs_edition)
            {
                if (!edition.name.ToLower().Contains(query_string.ToLower()))
                {
                    continue;
                }

                string selected_release_form = ((ComboBoxItem)_bsp.FilterReleaseFormComboBox.SelectedItem).Tag.ToString();
                string selected_author = ((ComboBoxItem)_bsp.FilterAuthorComboBox.SelectedItem).Tag.ToString();
                string selected_publisher = ((ComboBoxItem)_bsp.FilterPublisherComboBox.SelectedItem).Tag.ToString();

                if (_type == "" && _context.bs_user_edition.Any(row => row.id_user == _user.id && row.id_edition == edition.id && row.is_on_bookshelf == true))
                {
                    continue;
                }

                if (selected_release_form == "digital" && edition.id_release_form != 1 || selected_release_form == "printed" && edition.id_release_form != 2)
                {
                    continue;
                }

                if (selected_author != "any" && edition.id_author != Convert.ToInt32(selected_author))
                {
                    continue;
                }

                if (selected_publisher != "any" && edition.id_publisher != Convert.ToInt32(selected_publisher))
                {
                    continue;
                }

                if (_type == "shelf" && !_context.bs_user_edition.Any(b => b.id_edition == edition.id && b.id_user == _user.id))
                {
                    continue;
                }

                if (_type == "shelf" && _context.bs_user_edition.Any(b => b.id_edition == edition.id && b.is_on_bookshelf == false))
                {
                    continue;
                }

                if (_type == "cart" && !_context.bs_user_edition.Any(b => b.id_edition == edition.id && b.is_on_bookshelf == false))
                {
                    continue;
                }

                if (_type == "cart" && !_context.bs_user_edition.Any(b => b.id_edition == edition.id && b.id_order == null))
                {
                    continue;
                }

                if (_type == "active" && !_context.bs_user_edition.Any(b => b.id_edition == edition.id && b.id_order != null && _context.bs_order.FirstOrDefault(x => x.id == b.id_order).id_order_status < 5))
                {
                    continue;
                }

                if (_type == "finished")
                {
                    var c = _context.bs_user_edition.OrderByDescending(r => r.id).Where(r => r.id_user == _user.id && r.id_edition == edition.id && r.id_order != null);
                    var last_suitable_purchase = c.FirstOrDefault();
                    if (last_suitable_purchase == null)
                    {
                        continue;
                    }
                    var smth = _context.bs_order.OrderByDescending(r => r.id).Where(r => r.id == last_suitable_purchase.id_order).FirstOrDefault();
                    if (smth == null)
                    {
                        continue;
                    }
                    int status_id = smth.id_order_status;
                    string status = _context.bs_order_status.Find(status_id).name;
                    if (status != "получен" && status != "отменён" && status != "отменен")
                    {
                        continue;
                    }
                    
                    
                }

                var author = _context.bs_author.FirstOrDefault(a => a.id == edition.id_author);
                string author_name = author.last_name + ' ' + author.first_name + ' ' + author.patronymic;

                Book book = new Book
                {
                    Id = edition.id,
                    Title = edition.name,
                    AuthorName = author_name,
                    ShortDescription = edition.description,
                    Rating = (decimal)edition.rating,
                    IsDigital = edition.id_release_form == 1,
                    CoverImagePath = @"~\..\img\books\" + edition.cover.ToString(),
                };
                
                books.Add(new BookViewModel(book, _user, _type, _bsp, _context, _mainWindow));
            }

            return books;
        }
    }

    

    /// <summary>
    /// Interaction logic for BookSearchPage.xaml
    /// </summary>
    public partial class BookSearchPage : Page
    {
        private void PopulateAuthorsComboBox()
        {
            user83_dbEntities _context = new user83_dbEntities();
            var authors = _context.bs_author.ToList();

            FilterAuthorComboBox.Items.Add(new ComboBoxItem
            {
                Content = "любой",
                Tag = "any"
            });

            FilterAuthorComboBox.SelectedIndex = 0;

            foreach (var author in authors)
            {
                var comboBoxItem = new ComboBoxItem
                {
                    Content = $"{author.last_name} {author.first_name} {author.patronymic}",
                    Tag = author.id
                };

                FilterAuthorComboBox.Items.Add(comboBoxItem);
            }
        }

        private void PopulatePublishersComboBox()
        {
            user83_dbEntities _context = new user83_dbEntities();
            var publishers = _context.bs_publisher.ToList();

            FilterPublisherComboBox.Items.Add(new ComboBoxItem
            {
                Content = "любое",
                Tag = "any"
            });

            FilterPublisherComboBox.SelectedIndex = 0;

            foreach (var publisher in publishers)
            {
                var comboBoxItem = new ComboBoxItem
                {
                    Content = publisher.name,
                    Tag = publisher.id
                };

                FilterPublisherComboBox.Items.Add(comboBoxItem);
            }
        }

        public BookRepository bookrep;
        bs_user _user;
        public string _type;
        public static MainWindow _mainWindow;
        public BookSearchPage(bs_user user, MainWindow mainWindow, string type = "")
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _type = type;
            if (_type == "shelf")
            {
                PageLabel.Content = "полка";
                SearchGrid.Visibility = Visibility.Collapsed;
                FiltersPanel.Visibility = Visibility.Collapsed;
            } else if (_type == "cart") {
                PageLabel.Content = "покупки > корзина";
                SearchGrid.Visibility = Visibility.Visible;
                FiltersPanel.Visibility = Visibility.Collapsed;
                SearchInput.Visibility = Visibility.Hidden;
                FilterButton.Visibility = Visibility.Hidden;
                SearchButton.Content = "оформить заказ";
            }
            else if (_type == "active")
            {
                PageLabel.Content = "покупки > заказы > активные";
                SearchGrid.Visibility = Visibility.Collapsed;
                FiltersPanel.Visibility = Visibility.Collapsed;
            }
            else if (_type == "finished")
            {
                PageLabel.Content = "покупки > заказы > завершённые";
                SearchGrid.Visibility = Visibility.Collapsed;
                FiltersPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                PageLabel.Content = "поиск";
                SearchGrid.Visibility = Visibility.Visible;
            }
            _user = user;
            bookrep = new BookRepository(new user83_dbEntities(), this, user, _mainWindow);
            PopulateAuthorsComboBox();
            PopulatePublishersComboBox();
            Search(user);
        }

        public void Search(bs_user user, string search_query = "")
        {
            bookrep = new BookRepository(new user83_dbEntities(), this, user, _mainWindow);
            var books = bookrep.GetAllBooks(search_query, _type);

            if (books.Count == 0)
            {
                BookListView.ItemsSource = null;
                if (_type == "shelf")
                {
                    MessageBox.Show("На полке пока что нет книг. Чтобы пополнить коллекцию, найдите электронную книгу во вкладке поиска и нажмите кнопку добавления на полку.");
                }
                else if (_type == "cart") {
                    SearchButton.Visibility = Visibility.Collapsed;
                    MessageBox.Show("В корзине пока что нет книг. Чтобы пополнить её, найдите печатную книгу во вкладке поиска и нажмите кнопку добавления в корзину.");
                }
                else if (_type == "active")
                {
                    SearchButton.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Активных заказов на данный момент нет.");
                }
                else if (_type == "finished")
                {
                    SearchButton.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Завершённых заказов на данный момент нет.");
                }
                else
                {
                    MessageBox.Show("Книги не найдены, попробуйте изменить поисковый запрос или фильтры.");
                }
                return;
            }
            BookListView.ItemsSource = null;
            BookListView.ItemsSource = books;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (FiltersPanel.Visibility != Visibility.Visible)
                FiltersPanel.Visibility = Visibility.Visible;
            else
                FiltersPanel.Visibility = Visibility.Collapsed;
        }

        private void CreateNewOrder(user83_dbEntities _context)
        {
            _context.bs_order.Add(new bs_order {
                order_date = DateTime.Now,
                id_order_status = 1
            });
            _context.SaveChanges();
        }

        private void MarkUserEditionRowsAsOrder(user83_dbEntities _context, int new_order_id)
        {
            foreach (bs_user_edition row in _context.bs_user_edition)
            {
                if (row.is_on_bookshelf == false && row.id_user == _user.id && row.id_order == null)
                {
                    row.id_order = new_order_id;
                }
            }
            _context.SaveChanges();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            user83_dbEntities _context = new user83_dbEntities();
            if (_type == "cart") {
                CreateNewOrder(_context);
                int new_order_id = _context.bs_order.OrderByDescending(x => x.id).First().id;
                MarkUserEditionRowsAsOrder(_context, new_order_id);
                MessageBox.Show("Заказ успешно оформлен! Его статус можно отслеживать во вкладке \"покупки > заказы > активные\".", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                Search(_user, "");
                return;
            }
            string search_query = SearchInput.Text;
            Search(_user, search_query);
        }
    }
}
