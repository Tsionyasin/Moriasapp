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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace moriasapp
{
    /// <summary>
    /// Interaction logic for adminpage.xaml
    /// </summary>
    public partial class adminpage : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\moriasapp\moriasapp\Data\moriaDb.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public adminpage()
        {
            InitializeComponent();

        }
        private void chilreg_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            regform form = new regform();
            form.Show();

        }
        private void parreg_btn_b_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        parregform form2 = new parregform();
            form2.Show();

        }
        private void record_btn_click(object sender, RoutedEventArgs e)
        {
           
            record form3 = new record();
            form3.Show();

        }
        private void gallery_btn_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void home_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            adminpage admin = new adminpage();
            admin.Show();
        }
    }

    }

