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
using System.Data;
using System.Data.SqlClient;

namespace moriasapp
{
    /// <summary>
    /// Interaction logic for record.xaml
    /// </summary>
    public partial class record : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\moriasapp\moriasapp\Data\moriaDb.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public record()
        {
            InitializeComponent();
            
            DisplayData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Parent");

        }
        public void DisplayData()
        {

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from student", sqlcon);
            adapt.Fill(dt);
            datagrid.ItemsSource = dt.DefaultView;
            adapt.Update(dt);
            sqlcon.Close();
        }
        public void DisplayData1()
        {

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from parenttable", sqlcon);
            adapt.Fill(dt);
            datagrid.ItemsSource = dt.DefaultView;
            adapt.Update(dt);
            sqlcon.Close();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DisplayData();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DisplayData1();
            }
        }

        private void Datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void doublclick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select ID,name,age,grade,Gender,entry from student where name='" + searchbox.Text + "'", sqlcon);
                adapt.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                adapt.Update(dt);
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select ID,name,age,Gender,entry from parenttable where name='" + searchbox.Text + "'", sqlcon);
                adapt.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                adapt.Update(dt);
            }
        }
    }
    }

