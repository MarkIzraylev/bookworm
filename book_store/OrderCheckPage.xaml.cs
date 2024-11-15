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
using System.Data.Entity;

namespace book_store
{
    /// <summary>
    /// Interaction logic for OrderCheckPage.xaml
    /// </summary>
    /// 
    public class UserItemEqualityComparer : IEqualityComparer<UserItem>
    {
        public bool Equals(UserItem x, UserItem y)
        {
            return x.FullName == y.FullName;
        }

        public int GetHashCode(UserItem obj)
        {
            return obj.FullName.GetHashCode();
        }
    }
    public class UserItem
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    public partial class OrderCheckPage : Page
    {
        user83_dbEntities _context = new user83_dbEntities();
        public OrderCheckPage()
        {
            InitializeComponent();
            var users = _context.bs_user_edition
            .Where(r => r.id_order != null)
            .Join(_context.bs_order, ue => ue.id_order, o => o.id, (ue, o) => new { ue, o })
            .Where(x => x.o.id_order_status < 5)
            .Join(_context.bs_user, x => x.ue.id_user, u => u.id, (x, u) => new UserItem
            {
                Id = u.id,
                FullName = u.last_name + " " + u.first_name
            })
            .GroupBy(u => u.FullName)
            .Select(g => new UserItem { Id = g.Min(u => u.Id), FullName = g.Key })
            .ToList();

            ClientFullName.ItemsSource = users.Select(u => new ComboBoxItem { Tag = u.Id.ToString(), Content = u.FullName });
        }

        private string GetFullName(int client_id)
        {
            var client = _context.bs_user.SingleOrDefault(u => u.id == client_id);
            return client.last_name + " " + client.first_name + " " + client.patronymic;
        }

        private bool ThisOrderIsActive(int id_order)
        {
            return _context.bs_order.SingleOrDefault(r => r.id == id_order).id_order_status < 5;
        }

        private void ReadOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int client_id = Convert.ToInt32(((ComboBoxItem)ClientFullName.SelectedItem).Tag);
            var orders = _context.bs_user_edition
            .Where(r => r.id_order != null && r.id_user == client_id)
            .Join(_context.bs_order, ue => ue.id_order, o => o.id, (ue, o) => new { ue, o })
            .Where(x => x.o.id_order_status < 5)
            .Join(_context.bs_edition, x => x.ue.id_edition, edition => edition.id, (x, edition) => x.ue.quantity + " x " + edition.name)
            .ToList();
            MessageBox.Show(string.Join("; ", orders));
        }

        private void ClientFullName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientFullName.SelectedIndex > -1)
            {
                ReadOrderButton.IsEnabled = true;
                Status.IsEnabled = true;
                SaveStatusButton.IsEnabled = true;
                int client_id = Convert.ToInt32(((ComboBoxItem)ClientFullName.SelectedItem).Tag);
                int order_id = Convert.ToInt32(_context.bs_user_edition
                .Where(r => r.id_order != null && r.id_user == client_id)
                .Join(_context.bs_order, ue => ue.id_order, o => o.id, (ue, o) => new { ue, o })
                .Where(x => x.o.id_order_status < 5)
                .GroupBy(x => x.ue.id_user)
                .Select(g => g.Min(x => x.ue.id_order))
                .FirstOrDefault());
                Status.SelectedIndex = _context.bs_order.FirstOrDefault(r => r.id == order_id).id_order_status - 1;
            }
        }

        private void SaveStatusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int client_id = Convert.ToInt32(((ComboBoxItem)ClientFullName.SelectedItem).Tag);
                var orders = _context.bs_user_edition
                    .Where(r => r.id_order != null && r.id_user == client_id)
                    .Join(_context.bs_order, ue => ue.id_order, o => o.id, (ue, o) => o)
                    .Where(o => o.id_order_status < 5)
                    .ToList();

                foreach (var order in orders)
                {
                    order.id_order_status = Convert.ToInt32(((ComboBoxItem)Status.SelectedItem).Tag);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                MessageBox.Show("222");
            }
        }
    }
}
