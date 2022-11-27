using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для EntryPage.xaml
    /// </summary>
    public partial class EntryPage : Page
    {
        private int AccessDenied = 0;
        public EntryPage()
        {
            InitializeComponent();
            //if (AccessDenied==3)
                
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            foreach (Employees employee in ZhiguliEntities.GetContext().Employees.ToList())
            {
                if (employee.Login.ToString() == TBLogin.Text.ToString())
                {
                    if (employee.Password.ToString() == TBPassword.Text.ToString())
                    {
                        Manager.AuthEmployee = employee;
                        Manager.MainFrame.Navigate(new Page1());
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                        break;
                    }
                }
            }
            MessageBox.Show("Неверный логин");
            AccessDenied++;

        }
    }
}
