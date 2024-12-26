using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {
            var contex = new ApplicationContext();

            var user = contex.Users.FirstOrDefault(u => u.Email == EmailBox.Text);

            if (user != null)
            {
                MessageBox.Show("Такой email уже зарегистрирован");
                return;
            }

            if (!IsValidBoxes())
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!IsValidData())
            {
                MessageBox.Show("Некоректные данные!");
                return;
            }

            var newUser = new User
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                MiddleName = MiddleNameBox.Text,
                Email = EmailBox.Text,
                Password = PasswordBox.Password,
                RoleId = 2
            };

            contex.Users.Add(newUser);
            contex.SaveChanges();

            MessageBox.Show("Пользователь создан!");

            NavigationService.GoBack();
        }

        private bool IsValidData()
        {
            var resultEmail = Regex.IsMatch(EmailBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            var resultPhone = Regex.IsMatch(PhoneBox.Text, @"^\+?\d{0,2}-?\d{4,5}-?\d{5,6}$");

            if (resultEmail && resultPhone)
            {
                return true;
            }

            return false;
        }

        private bool IsValidBoxes()
        {
            if (!string.IsNullOrEmpty(LastNameBox.Text) && !string.IsNullOrEmpty(FirstNameBox.Text)
                && !string.IsNullOrEmpty(MiddleNameBox.Text) && !string.IsNullOrEmpty(PasswordBox.Password))
            {

                return true;
            }

            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
