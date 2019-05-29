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
using WinForms = System.Windows.Forms;
using System.IO;

namespace moriasapp
{
    /// <summary>
    /// Interaction logic for regform.xaml
    /// </summary>
    public partial class regform : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\moriasapp\moriasapp\Data\moriaDb.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;

       
        //string ImageName;
        string Gender;
        //string pathstr;
       // string folderpath = @"C:\Users\user\source\repos\moriasapp\moriasapp\images2\";

        public regform()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(name.Text != "" && age.Text != "" && grade.Text != "")
            {
                cmd = new SqlCommand("delete from student where ID='"+id.Text+"'", sqlcon);
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "Male";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Gender = "Female";
        }

        private void btn_insert__Click(object sender, RoutedEventArgs e)
        {
            sqlcon.Open();
            bool exists = false;
            using (SqlCommand cmd = new SqlCommand("select count(*) from [student] where name =  @nm", sqlcon))
            {
                cmd.Parameters.AddWithValue("nm", name.Text);
                exists = (int)cmd.ExecuteScalar() > 0;
            }
            if (exists)
            {
                MessageBox.Show("name already exisit");
            }
        
                if (name.Text != "" && age.Text != "" && grade.Text != "" && Gender != "")
                {



                    cmd = new SqlCommand("insert into student(ID,name,age,grade,Gender,entry) values('" + id.Text + "','" + name.Text + "','" + age.Text + "','" + grade.Text + "','" + Gender + "','" + this.datapicker.Text + "')", sqlcon);
                    cmd.Parameters.AddWithValue("@Id", id.Text);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@age", age.Text);
                    cmd.Parameters.AddWithValue("@grade", grade.Text);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@entry", datapicker.Text);


                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show("Record Inserted Successfully");
                    DisplayData();
                    ClearData();



                }


                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }



        public void DisplayData()
        {

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from student", sqlcon);
            adapt.Fill(dt);
            datagridstu.ItemsSource = dt.DefaultView;
            adapt.Update(dt);
            sqlcon.Close();
         
        }
        public void ClearData()
        {
            name.Text = "";
            age.Text = "";
            id.Text = "";
        }

        private void Datagridstu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
                
            
        }
      
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != "" && age.Text != "" && grade.Text != "" && Gender != "")
            {
                
                cmd = new SqlCommand("update student set name='" + name.Text + "',age='" + age.Text + "',grade='" + grade.Text + "',Gender='" + Gender + "',entry='" + this.datapicker.Text + "' where ID='"+ id.Text +"'", sqlcon);
                sqlcon.Open();
                cmd.Parameters.AddWithValue("@ID", id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                 cmd.Parameters.AddWithValue("@age", age.Text);
                 cmd.Parameters.AddWithValue("@grade", grade.Text);
                 cmd.Parameters.AddWithValue("@Gender", Gender);
                 cmd.Parameters.AddWithValue("@entry", datapicker.Text);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully");
                sqlcon.Close();
                DisplayData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void Datagridstu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRowIndex = datagridstu.SelectedIndex;
            if(selectedRowIndex != -1)
            {
                DataRowView datrow = (DataRowView)datagridstu.SelectedItem;
                id.Text = datrow[0].ToString();
                name.Text = datrow[1].ToString();
                age.Text = datrow[2].ToString();
                grade.Text = datrow[3].ToString();
              
                datapicker.Text = datrow[4].ToString();
            }
            
        }
        void fillDataGridView()
        {
            if(sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
                adapt = new SqlDataAdapter("student", sqlcon);
                sqlcon.Close();
            }
        }

       /* private void Button_Click(object sender, RoutedEventArgs e)
        {
            WinForms.OpenFileDialog op = new WinForms.OpenFileDialog();
            op.Title = "select image";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
           
            if (op.ShowDialog() == WinForms.DialogResult.OK)
            {
                 ImageName = op.FileName;
                imageviewr2.Source = new BitmapImage(new Uri(op.FileName));
            }
            pathstr = System.IO.Path.GetFileName(ImageName);
            File.Copy(ImageName, System.IO.Path.Combine(folderpath, System.IO.Path.GetFileName(pathstr)), true);

            sqlcon.Open();

        }*/
        
        private void home_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            adminpage page = new adminpage();
            page.Show();
        }

        private void chilreg_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            regform page1 = new regform();
            page1.Show();
        }

        private void parreg_btn_b_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            parregform page2 = new parregform();
            page2.Show();
        }

        private void record_btn_click(object sender, RoutedEventArgs e)
        {
            
            record page3 = new record();
            page3.Show();
        }

     

        private void Grade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select ID,name,age,grade,Gender,entry from student where name='" + searchbox.Text + "'", sqlcon);
            adapt.Fill(dt);
            datagridstu.ItemsSource = dt.DefaultView;
            adapt.Update(dt);

        }

        private void gallery_btn_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Id_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
    }
    

    