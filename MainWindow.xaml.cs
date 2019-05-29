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
using System.Data.SqlClient;
using System.Data;

namespace moriasapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\moriasapp\moriasapp\Data\moriaDb.mdf;Integrated Security=True");
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\moriasapp\moriasapp\Data\moriaDb.mdf;Integrated Security=True");
            try
            {
                if (sqlcon.State == ConnectionState.Closed)

                    sqlcon.Open();
                String query = "SELECT Role FROM [dbo].[Table] WHERE username=@username AND password=@password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("username", text_username.Text);
                sqlcmd.Parameters.AddWithValue("password", text_password.Password);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 2)
                {
                    this.Hide();
                    adminpage page = new adminpage();
                    page.Show();
                }

                else if (count == 1)
                {
                    this.Hide();
                    userpage upage = new userpage();
                    upage.Show();
                }
                else
                {
                    MessageBox.Show("username or password incorrect");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void Text_username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
          }
}

