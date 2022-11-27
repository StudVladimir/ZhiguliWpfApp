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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Car _currentCar = new Car();
        public Page2(Car selectedcar)
        {
            InitializeComponent();

            if(selectedcar!= null)
                _currentCar= selectedcar;
            DataContext = _currentCar;
            ComboBoxModels.ItemsSource = ZhiguliEntities.GetContext().Model.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            //if (_currentCar.Model_id < 0)
             //   errors.AppendLine("Укажите id модели");

            if (_currentCar.Owner_id < 0)
                errors.AppendLine("Укажите владельца");

            if (string.IsNullOrWhiteSpace(_currentCar.Color))
                errors.AppendLine("Укажите цвет автомобиля");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentCar.Car_id == 0)
                ZhiguliEntities.GetContext().Car.Add(_currentCar);

            try
            {
                ZhiguliEntities.GetContext().SaveChanges();
                MessageBox.Show("Изменения сохранены");
                Manager.MainFrame.GoBack();
            }
            catch(Exception exeption)
            {
                MessageBox.Show(exeption.Message.ToString());
            }
        }
    }
}
