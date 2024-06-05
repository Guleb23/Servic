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
    /// Логика взаимодействия для MasterPage.xaml
    /// </summary>
    public partial class MasterPage : Page
    {
        ApplicationDBContext applicationDBContext;
        public MasterPage()
        {
            InitializeComponent();
            applicationDBContext = new ApplicationDBContext();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtgr.DataContext = applicationDBContext.Application.Where(x => x.masterID == AutoriseUser.AutorizeUser.UserID).ToList();
            dtgr.ItemsSource = applicationDBContext.Application.Where(x => x.masterID == AutoriseUser.AutorizeUser.UserID).ToList();
            txbCount.Text = applicationDBContext.Application.Where(x => x.masterID == AutoriseUser.AutorizeUser.UserID && x.applicationStatus == "Готова к выдаче").ToList().Count.ToString();
            txbName.Text = AutoriseUser.AutorizeUser.UserFIO;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var order = btn.DataContext as Models.Application;
            NavigationService.Navigate(new MasterEditPage(order));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var order = btn.DataContext as Models.Application;
            order.completionDate = DateOnly.FromDateTime(DateTime.Now);
            order.applicationStatus = "Готова к выдаче";
            applicationDBContext.SaveChanges();
            dtgr.DataContext = applicationDBContext.Application.Where(x => x.masterID == AutoriseUser.AutorizeUser.UserID).ToList();
            dtgr.ItemsSource = applicationDBContext.Application.Where(x => x.masterID == AutoriseUser.AutorizeUser.UserID).ToList();
            txbCount.Text = applicationDBContext.Application.Where(x => x.masterID == AutoriseUser.AutorizeUser.UserID && x.applicationStatus == "Готова к выдаче").ToList().Count.ToString();

        }
    }
}
