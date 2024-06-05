using App;
using Microsoft.VisualBasic.ApplicationServices;
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

namespace Servic.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        ApplicationDBContext applicationDBContext;
        public LoginPage()
        {
            InitializeComponent();

            applicationDBContext = new ApplicationDBContext();
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var users = applicationDBContext.Users.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var autorizeUser = applicationDBContext.Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == txbPass.Password);
            if (autorizeUser != null)
            {
                int iterator = autorizeUser.TypeId;
                switch (iterator)
                {
                    case 1:
                        AutoriseUser.AutorizeUser = autorizeUser;
                        NavigationService.Navigate(new MasterPage());
                        break;
                    case 2:
                        AutoriseUser.AutorizeUser = autorizeUser;
                        NavigationService.Navigate(new NextPage());
                        break;
                    case 3:
                        AutoriseUser.AutorizeUser = autorizeUser;
                        NavigationService.Navigate(new ManagerPage());
                        break;
                    default:
                        AutoriseUser.AutorizeUser = autorizeUser;
                        NavigationService.Navigate(new OperatorPage());
                        break;
                    

                }

            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
    }
}
