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
    public partial class Order : Form
    {
        private static string conString = "Server=Lenovo-PC\\SQLEXPRESS; Database=InClassExercise; User=PrimeUser; Password=12345";
        private SqlConnection connection = new SqlConnection(conString);
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataTable userTable = new DataTable();
        DataTable driverTable = new DataTable();

        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM UserInfo WHERE Username ='" + LoginInfo.username + "';", connection);
            adapter.Fill(userTable);
            showData(0);
        }

        public void showData(int index)
        {
            adapter = new SqlDataAdapter("SELECT * FROM Driver;", connection);
            adapter.Fill(driverTable);
            tbFirstname.Text = userTable.Rows[index][1].ToString();
            tbLastname.Text = userTable.Rows[index][2].ToString();
            tbEmail.Text = userTable.Rows[index][10].ToString();
            tbDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            for (int i = 0; i < driverTable.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = driverTable.Rows[i][1] + " " + driverTable.Rows[i][2];
                item.Value = driverTable.Rows[i][0];
                cmbDriverName.Items.Add(item);
            }

            cmbDriverName.SelectedIndex = 0;
            cmbMake.SelectedIndex = 0;
            cmbColour.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string firstname = tbFirstname.Text;
                string lastname = tbLastname.Text;
                string email = tbEmail.Text;
                string fromDest = tbFromDest.Text;
                string toDest = tbToDest.Text;
                string date = tbDate.Text;
                //string colour = cmbColour.SelectedItem.ToString();
                //string make = cmbMake.SelectedItem.ToString();
                string driverName = cmbDriverName.SelectedItem.ToString();
                ComboboxItem selectedDriver = (ComboboxItem)cmbDriverName.SelectedItem;
                int driverID = Convert.ToInt32(selectedDriver.Value);

                if (fromDest == "" || toDest == "")
                {
                    string msg = "No text box can be empty";
                    string caption = "Error";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string query = "Insert INTO CarOrder VALUES ('"
                                + fromDest + "','"
                                + toDest + "','"
                                + date + "',("
                                + " SELECT UserID FROM UserInfo "
                                + "WHERE Username = '" + LoginInfo.username + "'),'"
                                // TODO: This is temporarily hardcoded.
                                + "1'); "
                                + "INSERT INTO Feedback VALUES ("
                                + "NULL, (SELECT TOP 1 CarOrderID FROM CarOrder ORDER BY CarOrderID DESC));"
                                + "INSERT INTO History VALUES ("
                                + "(SELECT UserID FROM UserInfo WHERE Username = '" + LoginInfo.username + "'),"
                                + driverID + " , 1, "
                                + "(SELECT TOP 1 FeedbackID FROM Feedback ORDER BY FeedbackID DESC), "
                                + "(SELECT TOP 1 CarOrderID FROM CarOrder ORDER BY CarOrderID DESC));";
                
                connection.ConnectionString = conString;
                cmd = connection.CreateCommand();

                cmd.CommandText = query;
                connection.Open();
                cmd.ExecuteScalar();

                /*
                string msg = "Order added successfully";
                string caption = "Success";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                */

                cmd.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                string msg = "Error.";
                string caption = "Please try again.";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            /*try
            {
                
            }
                catch (Exception ex)
                {
                    handleException(ex);

                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }*/

            this.Close();

            Payment payment = new Payment();
            payment.Show();

        }

        private void cmbDriverName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbColour_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMake_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        /*private void handleException(Exception ex)
        {
            
               string msg = ex.Message.ToString();
               string caption = "Error";
               MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        */
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

