using App;
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
    /// Логика взаимодействия для MasterEditPage.xaml
    /// </summary>
    public partial class MasterEditPage : Page
    {
        ApplicationDBContext dBContext;
        Models.Application apl;
        public MasterEditPage(Models.Application application)
        {
            InitializeComponent();
            dBContext = new ApplicationDBContext();

            apl = application;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            apl.repairParts = txbRepair.Text;
            apl.completionDate = DateOnly.Parse(txbDate.Text);
            dBContext.Update(apl);
            dBContext.SaveChanges();
            MessageBox.Show($"{AutoriseUser.AutorizeUser.UserFIO} ,вы успешно отправили заявку в работу");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Comments newComment = new Comments()
            {
                applicationID = apl.RequestId,
                masterID = AutoriseUser.AutorizeUser.UserID,
                message = txbComment.Text
            };
            dBContext.Comments.Add(newComment);
            dBContext.SaveChanges();
            MessageBox.Show("Вы успешно добавили комментарий!");
        }
    }
}
