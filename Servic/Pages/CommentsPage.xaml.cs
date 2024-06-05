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
    /// Логика взаимодействия для CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        public CommentsPage(List<Comments> comm)
        {
            InitializeComponent();
            string comment = "";
            foreach(var mess in comm)
            {
                comment += mess.message;
            };
            txbComm.Text = comment;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
