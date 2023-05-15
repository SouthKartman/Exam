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

namespace GlazkiProgram.pages
{
    /// <summary>
    /// Логика взаимодействия для AgentsPage.xaml
    /// </summary>
    public partial class AgentsPage : Page
    {
        public AgentsPage()
        {
            InitializeComponent();
            MyListBox.ItemsSource = core.db.Agent.ToList();
            SortCB.SelectedIndex = 0;
            FiltrCB.SelectedIndex = 0;
        }

        private void SearchCB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Title.StartsWith(SearchCB.Text) || s.Title.EndsWith(SearchCB.Text) || s.Title.Contains(SearchCB.Text)).ToList();
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Phone.StartsWith(SearchCB.Text) || s.Phone.EndsWith(SearchCB.Text) || s.Phone.Contains(SearchCB.Text)).ToList();
            }
            catch (Exception)
            {

            }
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedIndex == 0)
            {
                MyListBox.ItemsSource = core.db.Agent.ToList();
            }
            if (SortCB.SelectedIndex == 1)
            {
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Priority > 0 && s.Priority < 51).ToList();
            }
            if (SortCB.SelectedIndex == 2)
            {
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Priority > 51 && s.Priority < 251).ToList();
            }
            if (SortCB.SelectedIndex == 3)
            {
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Priority >250).ToList();
            }
        }

        private void FiltrCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FiltrCB.SelectedIndex == 0)
            {
                MyListBox.ItemsSource = core.db.Agent.ToList();
            }
            if (FiltrCB.SelectedIndex == 1)
            {
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Priority == 0).ToList();
            }
            if (FiltrCB.SelectedIndex == 2)
            {
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Priority == 1).ToList();
            }
            if (FiltrCB.SelectedIndex == 3)
            {
                MyListBox.ItemsSource = core.db.Agent.Where(s => s.Priority == 1).ToList();
            }
        }

        private void AddServiceBt_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new pages.AddPageAgent());
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = MyListBox.SelectedItem as Agent;
            if (item != null)
            {
                NavigationService.Navigate(new pages.AddPage(item));
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = MyListBox.SelectedItem as Agent;
            if (item != null)
            {
                core.db.Agent.Remove(item);
                core.db.SaveChanges();
                MyListBox.ItemsSource = core.db.Agent.ToList();
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MyListBox.ItemsSource = core.db.Agent.ToList();
            }
        }
    }
}
