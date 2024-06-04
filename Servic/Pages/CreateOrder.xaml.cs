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
        public CreateOrder()
        {
            InitializeComponent();
            applicationDB = new ApplicationDBContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Servic.Models.Application apl = new Servic.Models.Application()
            {
                startDate = DateOnly.FromDateTime(DateTime.Now),
                climateTechModel = txbModel.Text,
                climateTechType = txbObject.Text,
                proplemDescryption = txbObject.Text,
                clientID = AutoriseUser.AutorizeUser.UserID,
                applicationStatus = 3,
            };
            applicationDB.Application.Add(apl);
            applicationDB.SaveChanges();
            MessageBox.Show("зАКАЗ УСПЕШНО СОЗДАН");
            
            

        }
    }
}
