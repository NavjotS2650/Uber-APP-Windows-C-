using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace VRANDER_01
{
    public partial class CarRegistration : Form
    {
        private SqlConnection conn = new SqlConnection();
        private string conString = "Server=Lenovo-PC\\SQLEXPRESS; Database=InClassExercise; User=PrimeUser; Password=12345";
        SqlCommand cmd;
        public CarRegistration()
        {
            InitializeComponent();
        }

        private void CarRegistration_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            refreshData();
        }

        private void refreshData()
        {
            //SqlConnection conn = new SqlConnection();

            //the following line provides information to connect to the database
            conn.ConnectionString = conString;

            //we need a command object to execute a query
            cmd = conn.CreateCommand();

            try
            {
                string query = "Select * from CAR;";
                cmd.CommandText = query;
                conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();
                //There is data in the reader object.
                //We need to convert the data to an object the gridview can read!


                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                comboBox3.DisplayMember = "driver_id";
                comboBox3.ValueMember = "ID";
                comboBox3.DataSource = dt;
                reader.Close();

            }
            catch (Exception ex)
            {
                handleException(ex);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string car_id = textBox1.Text;
            string model = textBox5.Text;
            string brand = textBox4.Text;
            string carseats = comboBox2.SelectedItem.ToString();
            string licence = comboBox1.SelectedItem.ToString();
            string driver_id = textBox2.Text;
            if ((driver_id == "") || (car_id == "") || (carseats == "") || (licence == "") || (model == ""))
            {
                string msg = "No text box can be empty";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();

                try
                {
                    string query = "Insert into CAR values ('"
                                   + car_id + "','"
                                   + model + "','"
                                   + brand + "','"
                                   + licence + "','"
                                   + carseats + "','"
                                   + driver_id + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    string msg = "CAR added successfully";
                    string caption = "Success";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    handleException(ex);

                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        private void handleException(Exception ex)
        {
            throw new NotImplementedException();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            refreshData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   this.Hide();
       //     Form2 frm = new Form2();
         //   frm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
