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

            MainDataGrid.ItemsSource = contex.Roles.ToList();
        }


    }
}
