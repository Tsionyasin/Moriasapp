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
    /// Interaction logic for userpage.xaml
    /// </summary>
    public partial class userpage : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\moriasapp\moriasapp\Data\moriaDb.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public userpage()
        {
            InitializeComponent();
            DisplayData();
            
        }
        private void DisplayData()
        {
            sqlcon.Open();

            adapt = new SqlDataAdapter("select * from studentinfo", sqlcon);
            DataTable dt = new DataTable("studentinfo");
            adapt.Fill(dt);

         //   dataGridViewstu.ItemsSource = dt.DefaultView;
            adapt.Update(dt);
            sqlcon.Close();
        }

      

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            record page = new record();
            page.Show();
        }

        private void history_butn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            userpage page = new userpage();
            page.Show();
        }

        private void switch_butn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
    }
