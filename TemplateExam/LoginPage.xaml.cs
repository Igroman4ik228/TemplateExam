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
using TemplateExam.Models;

namespace TemplateExam
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            var context = new ApplicationContext();

            if (!IsValidBoxes())
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            var user = context.Users
                .Include("Role")
                .FirstOrDefault(u => u.Email == LoginBox.Text && u.Password == PasswordBox.Password);

            if (user == null)
            {
                MessageBox.Show("Неверные данные пользователя!");
            }

            if (user.Role.RoleName == "Admin")
            {
                NavigationService.Navigate(new AdminPage());
            }

            NavigationService.Navigate(new HomePage(user));
        }

        private bool IsValidBoxes()
        {
            if (!string.IsNullOrEmpty(LoginBox.Text) && !string.IsNullOrEmpty(PasswordBox.Password))
            {
                return true;
            }
            return false;
        }
    }
}
