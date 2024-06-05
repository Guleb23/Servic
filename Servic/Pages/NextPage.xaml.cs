using App;
using Microsoft.EntityFrameworkCore;
using Servic;
using Servic.Models;
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


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrder(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var order = btn.DataContext as Models.Application;
            NavigationService.Navigate(new CreateOrder(order));
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            applicationDBContext = new ApplicationDBContext();
            List<Models.Application> orders = applicationDBContext.Application.ToList().Where(x => x.clientID == AutoriseUser.AutorizeUser.UserID).ToList();
            dtgr.DataContext = orders;
            dtgr.ItemsSource = orders;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var order = btn.DataContext as Models.Application;
            List<Comments> comment = applicationDBContext.Comments.Where(c => c.applicationID == order.RequestId).ToList();
            if(comment != null)
            {
                NavigationService.Navigate(new CommentsPage(comment));
            }
            else
            {
                MessageBox.Show("Простите, но для вас нету комментариев");
            }
            
        }
    }
}
