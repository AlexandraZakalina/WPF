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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Tovar tovar = new Tovar();
        public Page2(Tovar selectedtovar)
        {
            InitializeComponent();
            DataContext = tovar;
            ComboBox1.ItemsSource = baseEntities.GetContext().Proizvoditel.ToList();
            if (selectedtovar != null)
                tovar = selectedtovar;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
                baseEntities.GetContext().Tovar.Add(tovar);
                try
                {
                    baseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }
    }
}
