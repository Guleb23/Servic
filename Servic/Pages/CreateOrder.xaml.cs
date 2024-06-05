using App;
using Servic.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Servic.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Page
    {
        ApplicationDBContext applicationDB;
        Servic.Models.Application apl = new Models.Application();
        bool isUpdate = false;
        public CreateOrder(Servic.Models.Application selectedApplication)
        {
            
            InitializeComponent();
            if (selectedApplication != null)
            {
                isUpdate = true;
                apl = selectedApplication;
            }
            DataContext = apl;
            applicationDB = new ApplicationDBContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            apl.startDate = DateOnly.FromDateTime(DateTime.Now);
            apl.clientID = AutoriseUser.AutorizeUser.UserID;
            apl.applicationStatus = "Новая заявка";
            if(isUpdate)
            {
                applicationDB.Update(apl);
            }
            else
            {
                apl.carModel = txbModel.Text;
                apl.carType = txbObject.Text;
                apl.proplemDescryption = txbDescr.Text;
                applicationDB.Application.Add(apl);
            }
            applicationDB.SaveChanges();
            MessageBox.Show("зАКАЗ УСПЕШНО СОЗДАН");
            NavigationService.GoBack();


        }
    }
}
