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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            if(Manager.AuthEmployee.JobTitle_id == 1)
            {
                BtnDel.Visibility = Visibility.Hidden;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2((sender as Button).DataContext as Car));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2(null));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var carsForRemoving = DGridZhiguli.SelectedItems.Cast<Car>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {carsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ZhiguliEntities.GetContext().Car.RemoveRange(carsForRemoving);
                    ZhiguliEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridZhiguli.ItemsSource = ZhiguliEntities.GetContext().Car.ToList();
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message.ToString());
                }
            }

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ZhiguliEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridZhiguli.ItemsSource = ZhiguliEntities.GetContext().Car.ToList();
            }
        }
    }
}
