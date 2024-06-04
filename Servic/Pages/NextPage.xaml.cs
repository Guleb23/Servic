using App;
using Servic;
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
    /// Логика взаимодействия для NextPage.xaml
    /// </summary>
    public partial class NextPage : Page
    {
        ApplicationDBContext applicationDBContext;
        public NextPage()
        {
            InitializeComponent();
            txbName.Text = AutoriseUser.AutorizeUser.UserFIO;
            applicationDBContext = new ApplicationDBContext();
            var orders = applicationDBContext.Application.ToList().Where(x => x.clientID == AutoriseUser.AutorizeUser.UserID);
            dtgr.DataContext = orders;
            dtgr.ItemsSource = orders;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            miniFrame.Navigate(new CreateOrder());
        }
    }
}
