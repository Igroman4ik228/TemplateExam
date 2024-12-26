using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using TemplateExam.Models;

namespace TemplateExam
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(User user)
        {
            InitializeComponent();
            InfoLabel.Content = $"Login: {user.Email} Role: {user.Role.RoleName}";

            var contex = new ApplicationContext();

            var users = contex.Users.Include("Role").ToList();

            var usersDto = new List<UserDto>();

            foreach (var item in users)
            {
                var userDto = new UserDto
                {
                    UserId = item.UserId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MiddleName = item.MiddleName,
                    Email = item.Email,
                    RoleName = item.Role.RoleName
                };

                usersDto.Add(userDto);
            }

            MainDataGrid.ItemsSource = usersDto;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
