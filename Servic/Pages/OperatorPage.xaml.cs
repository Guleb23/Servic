using App;
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
    /// Логика взаимодействия для OperatorPage.xaml
    /// </summary>
    public partial class OperatorPage : Page
    {
        ApplicationDBContext dBContext;
        Models.Application application;
        public OperatorPage()
        {
            InitializeComponent();
            dBContext = new ApplicationDBContext();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Models.Application> applications = dBContext.Application.ToList();
            dtgr.DataContext = applications;
            dtgr.ItemsSource = applications;
            txbName.Text = AutoriseUser.AutorizeUser.UserFIO;
            var role = dBContext.Type.First(u => u.TypeID == AutoriseUser.AutorizeUser.TypeId);
            txbRole.Text = role.Name;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var aplic = btn.DataContext as Models.Application;
            NavigationService.Navigate(new EditApplication(aplic));
        }
    }
}
