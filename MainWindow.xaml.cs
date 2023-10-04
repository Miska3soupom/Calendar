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

namespace To_do_list_wpf
{
    public partial class MainWindow : Window
    {
        public List<Zametka> Zametki = new List<Zametka>();
        public List<Zametka> DoToday = new List<Zametka>();
        public MainWindow()
        {
            InitializeComponent();
            Zametki = Jdaughter.Deserialize();
            Date.Text = DateTime.Now.ToString();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListBox1.SelectedItems.Count != 0)
            {
                DoToday[ListBox1.SelectedIndex].name = Name.Text;
                DoToday[ListBox1.SelectedIndex].description = Description.Text;
                clear();
                Name.Text = "";
                Description.Text = "";
            }
            else MessageBox.Show("Не выбрана заметка.");
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && Description.Text != "")
            {
                Zametka zametka = new Zametka(Name.Text, Description.Text, Convert.ToDateTime(Date.SelectedDate));
                Zametki.Add(zametka);
                clear();
                Name.Text = "";
                Description.Text = "";
            }
            else MessageBox.Show("Вы не ввели имя или описание заметки.");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListBox1.SelectedItems.Count != 0)
            {
                Zametki.RemoveAt(Zametki.IndexOf(DoToday[ListBox1.SelectedIndex]));
                clear();
                Name.Text = "";
                Description.Text = "";
            }
            else MessageBox.Show("Не выбрана заметка.");
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                Name.Text = DoToday[ListBox1.SelectedIndex].name;
                Description.Text = DoToday[ListBox1.SelectedIndex].description;
            }
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            clear();
        }
        private void clear()
        {
            ListBox1.Items.Clear();
            DoToday.Clear();
            foreach (Zametka item in Zametki)
            {
                if (Convert.ToDateTime(Date.SelectedDate).Day == item.data.Day)
                {
                    ListBox1.Items.Add(item.name);
                    DoToday.Add(item);
                }
            }
            Jdaughter.Serialize(Zametki);
        }
    }
}
