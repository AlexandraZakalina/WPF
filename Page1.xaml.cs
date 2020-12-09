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

namespace UchP11
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            var tovars = baseEntities.GetContext().Tovar.ToList();
            ListViewTovar.ItemsSource = tovars;
        }
        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2((sender as Button).DataContext as Tovar));
        }

        private void updateTovars()
        {
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2(null));
        }
        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            var tovarsForRemoving = ListViewTovar.SelectedItems.Cast<Tovar>().ToList();
            if (MessageBox.Show($"Удалить выбранные Вами товары?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    baseEntities.GetContext().Tovar.RemoveRange(tovarsForRemoving);
                    baseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Удаление прошло успешно!");

                    ListViewTovar.ItemsSource = baseEntities.GetContext().Tovar.ToList();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                baseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListViewTovar.ItemsSource = baseEntities.GetContext().Tovar.ToList();
            }
        }
        private void ButtonHistoryClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page3());
        }
    }
}
