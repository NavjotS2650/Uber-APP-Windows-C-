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
    public partial class DriverSignIn : Form
    {
        private SqlConnection conn = new SqlConnection();
        private static string conString = "Server=(local); Database=InClassExercises; User=PrimeUser; Password=12345";
        SqlCommand cmd;
        public DriverSignIn()
        {
            InitializeComponent();
        }

        private void DriverSignIn_Load(object sender, EventArgs e)
        {
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
                string query = "Select * from driverUpdated;";
                cmd.CommandText = query;
                conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();
                //There is data in the reader object.
                //We need to convert the data to an object the gridview can read!


                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                cmbSelect.DisplayMember = "driver_name";
                cmbSelect.ValueMember = "driver_id";
                cmbSelect.DataSource = dt;


                reader.Close();
                query = "Select * from CAR;";
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);



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


        private void handleException(Exception ex)
        {
            string msg = ex.Message.ToString();
            string caption = "Error";
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int flID = Convert.ToInt32(cmbSelect.SelectedValue);
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Delete from driverUpdated where driver_id= " + flID;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteScalar();
                //if this works we deletyed a row!


                string msg = "Flight deleted";
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string driver_id = tbAirline.Text;
            string driver_name = tbFlightNum.Text;
            string driver_car_id = tbDestination.Text;
            string payment = cmbAirlineType.SelectedItem.ToString();
            string address = textBox1.Text;
            string phone_number = textBox2.Text;
            if ((driver_id == "") || (driver_name == "") || (driver_car_id == "") || (payment == "") || (address == ""))
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
                    string query = "Insert into driverUpdated values ('"
                                   + driver_id + "','"
                                   + driver_name + "','"
                                   + driver_car_id + "','"
                                   + address + "','"
                                   + phone_number + "','"
                                   + payment + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    string msg = "Flight added successfully";
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            int flID = Convert.ToInt32(cmbSelect.SelectedValue);
            string driver_id = tbAirline.Text;
            string driver_name = tbFlightNum.Text;
            string driver_car_id = tbDestination.Text;
            string payment = cmbAirlineType.SelectedItem.ToString();
            string address = textBox1.Text;
            string phone_number = textBox2.Text;

            if ((driver_id == "") || (driver_name == "") || (driver_car_id == ""))
            {
                string msg = "No empty boxes";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string query = "Update driverUpdated Set driver_id ="
                    + driver_id + ", driver_name='"
                    + driver_name + "',driver_car_id="
                    + driver_car_id + ",address='"
                      + address + "',phone_no='"
                       + phone_number + "',payment="
                    + payment +
                 " where driver_id=" + flID;

                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();

                try
                {
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    handleException(ex);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    refreshData();
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            refreshData();
        }

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
