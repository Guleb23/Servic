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
    /// Логика взаимодействия для EditApplication.xaml
    /// </summary>
    public partial class EditApplication : Page
    {
        ApplicationDBContext dBContext;
        Models.Application aplic = new Models.Application();
        public EditApplication(Models.Application apl)
        {
            InitializeComponent();
            dBContext = new ApplicationDBContext();
            aplic = apl;
            List<Users> master = dBContext.Users.Where(u => u.TypeId == 1).ToList();
            cmxStatus.ItemsSource = new List<string>()
            {
                "В работе",
                "Готова"
            };
            cmxMaster.DataContext = master;
            cmxMaster.ItemsSource = master;
            cmxMaster.DisplayMemberPath = "UserFIO";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedMaster = cmxMaster.SelectedValue as Users;
            aplic.masterID = selectedMaster.UserID;
            aplic.applicationStatus = cmxStatus.Text;
            dBContext.Update(aplic);
            dBContext.SaveChanges();
            MessageBox.Show($"Вы успешно обработали заявку над ней будет работать {selectedMaster.UserFIO}");
            NavigationService.GoBack();

        }
    }
}
