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
    public partial class Feedback : Form
    {
        private static string conString = "Server=Lenovo-PC\\SQLEXPRESS; Database=InClassExercise; User=PrimeUser; Password=12345";
        private SqlConnection connection = new SqlConnection(conString);
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataTable table = new DataTable();
        DataTable orderTable = new DataTable();

        public Feedback()
        {
            InitializeComponent();
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            try
            {
                //  adapter = new SqlDataAdapter("SELECT * FROM History",connection);
                adapter = new SqlDataAdapter("SELECT * FROM UserInfo WHERE Username ='" +LoginInfo.username+"';", connection);
                adapter.Fill(table);
                showData(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
               
            }
        
        }

        public void showData(int index)
        {
            adapter = new SqlDataAdapter("SELECT * FROM CarOrder WHERE UserID = (SELECT UserID FROM UserInfo WHERE Username ='" + LoginInfo.username + "');", connection);
            adapter.Fill(orderTable);

            for (int i = 0; i < orderTable.Rows.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = orderTable.Rows[i][0].ToString();
                item.Value = orderTable.Rows[i][0];
                cmbCarOrderID.Items.Add(item);
            }

            tbFirstname.Text = table.Rows[index][1].ToString();
            tbLastname.Text = table.Rows[index][2].ToString();
            tbEmail.Text = table.Rows[index][10].ToString();
        }

        private void label4_Click(object sender, EventArgs e) { }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
             try
            {
                string firstname = tbFirstname.Text;
                string lastname = tbLastname.Text;
                string email = tbEmail.Text;
                string feedback = rtbFeedback.Text;
                string orderNo = cmbCarOrderID.SelectedItem.ToString();
                ComboboxItem selectedDriver = (ComboboxItem)cmbCarOrderID.SelectedItem;
                int driverID = Convert.ToInt32(selectedDriver.Value);

                if (rtbFeedback.Text == "")
                {
                    string msg = "No field can be empty";
                    string caption = "Error";
                    MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string query = "UPDATE Feedback SET Feedback = '" + feedback + "' WHERE CarOrderID = " + orderNo + ";"
                             + "UPDATE History SET FeedbackID = (SELECT TOP 1 FeedbackID FROM Feedback ORDER BY CarOrderID DESC) WHERE CarOrderID = "+ orderNo + ";";
                                
                connection.ConnectionString = conString;
                cmd = connection.CreateCommand();

                cmd.CommandText = query;
                connection.Open();
                cmd.ExecuteScalar();

                cmd.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                string msg = "Error.";
                string caption = "Please try again.";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();


        }

        private void cmbCarOrderID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable feedbackTable = new DataTable();
            ComboboxItem selectedDriver = (ComboboxItem)cmbCarOrderID.SelectedItem;
            int selectedOrder = Convert.ToInt32(selectedDriver.Value);

            adapter = new SqlDataAdapter("SELECT * FROM Feedback WHERE CarOrderID = " + selectedOrder + ";", connection);
            adapter.Fill(feedbackTable);

           /* if (feedbackTable != null && feedbackTable.Rows.Count > 0)
            {
                rtbFeedback.Text = feedbackTable.Rows[0][1].ToString();
            } 
            else
            {
                rtbFeedback.Text = "";
            }*/

            if (feedbackTable != null && feedbackTable.Rows.Count > 0 && feedbackTable.Rows[0][1].ToString() != "")
            {
                rtbFeedback.Text = feedbackTable.Rows[0][1].ToString();
                rtbFeedback.Enabled = false;
                btnSubmit.Enabled = false;
            }
            else
            {
                rtbFeedback.Text = "";
                rtbFeedback.Enabled = true;
                btnSubmit.Enabled = true;
            }
        }
    }
}
    
