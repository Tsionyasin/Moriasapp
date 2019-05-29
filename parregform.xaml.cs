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
using WinForms= System.Windows.Forms;
using System.IO;

namespace moriasapp
{
    /// <summary>
    /// Interaction logic for parregform.xaml
    /// </summary>
    public partial class parregform : Window
    {

        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\moriasapp\moriasapp\Data\moriaDb.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        //ID variable used in Updating and Deleting Record  
       
        string Gender;
       

        public parregform()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btn_insert__Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != "" && age.Text != "" )
            {
                cmd = new SqlCommand("insert into parenttable(name,age,Gender,entry) values('" + name.Text + "','" + age.Text + "','" + Gender + "','" + this.datapicker.Text + "')", sqlcon);
                sqlcon.Open();
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@age", age.Text);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@entry", datapicker.Text);
              
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("provide data");
            }
        }
        public void DisplayData()
        {

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from parenttable", sqlcon);
            adapt.Fill(dt);
            datagridpar.ItemsSource = dt.DefaultView;
            adapt.Update(dt);
            sqlcon.Close();
        }
        public void ClearData()
        {
            name.Text = "";
            age.Text = "";
            id.Text = "";
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
        
                if (name.Text != "" && age.Text != "" )
                {
                    cmd = new SqlCommand("delete from student where ID='" + id.Text + "'", sqlcon);
                    sqlcon.Open();

                    cmd.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Record Deleted Successfully!");
                    DisplayData();
                ClearData();

                }
                else
                {
                    MessageBox.Show("Please Select Record to Delete");
                }
            }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Gender = "Female";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Male";
        }

        private void chilreg_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            regform form = new regform();
            form.Show();
        }

        private void home_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            adminpage page = new adminpage();
            page.Show();
        }

        private void parreg_btn_b_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            parregform form = new parregform();
            form.Show();
        }

        private void record_btn_click(object sender, RoutedEventArgs e)
        {
            
            record form = new record();
            form.Show();
        }

        private void gallery_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if(name.Text != "" && age.Text != "") { 
            cmd = new SqlCommand("update student set name='" + name.Text + "',age='" + age.Text + "',Gender='" + Gender + "',entry='" + this.datapicker.Text + "' where ID='" + id.Text + "'", sqlcon);
            sqlcon.Open();
            cmd.Parameters.AddWithValue("@ID", id.Text);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@age", age.Text);
           
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@entry", datapicker.Text);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record updated successfully");
            sqlcon.Close();
            DisplayData();
                ClearData();
        }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }

}

        private void Datagridstu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRowIndex = datagridpar.SelectedIndex;
            if (selectedRowIndex != -1)
            {
                DataRowView datrow = (DataRowView)datagridpar.SelectedItem;
                id.Text = datrow[0].ToString();
                name.Text = datrow[1].ToString();
                age.Text = datrow[2].ToString();
                

                datapicker.Text = datrow[4].ToString();
            }

        
    }

        private void Datagridstu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select ID,name,age,Gender,entry from parenttable where name='" + searchbox.Text + "'", sqlcon);
            adapt.Fill(dt);
            datagridpar.ItemsSource = dt.DefaultView;
            adapt.Update(dt);
            ClearData();

        }
    }

  

     
 

    /* private void Button_Click(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog op = new WinForms.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == WinForms.DialogResult.OK)
            {
                imageviewer.Source = new BitmapImage(new Uri(op.FileName));
            }*/
        }       
 