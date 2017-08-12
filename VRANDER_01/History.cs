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
    public partial class History : Form
    {
        private static string conString = "Server=(local); Database=InClassExercises; User=PrimeUser; Password=12345";
        private SqlConnection connection = new SqlConnection(conString);
        SqlDataAdapter adapter;
        DataTable table = new DataTable();
        int pos = 0;
       // SqlCommand cmd;

        public History()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void History_Load(object sender, EventArgs e)
        {
            try
            {
                //  adapter = new SqlDataAdapter("SELECT * FROM History",connection);
                adapter = new SqlDataAdapter("SELECT c.Date, u.FirstName, u.LastName, d.FirstName, " +
                "c.FromDest, c.ToDest, f.Feedback " +
                "FROM CarOrder c, UserInfo u, Driver d, Feedback f, History h " +
                "WHERE c.UserID = u.UserID AND " +
                "d.DriverID = h.DriverID AND " +
                "u.UserID = h.UserID AND " +
                "f.FeedbackID = h.FeedbackID AND " +
				"f.CarOrderID = c.CarOrderID AND " +
                "u.Username = '" + LoginInfo.username +
                "';", connection);

                adapter.Fill(table);
                showData(pos);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No history. Place an order!");
               
            }
        }

        public void showData(int index)
        {
            tbDate.Text = table.Rows[index][0].ToString();
            tbFirstname.Text = table.Rows[index][1].ToString();
            tbLastname.Text = table.Rows[index][2].ToString();
            tbDriverName.Text = table.Rows[index][3].ToString();
            tbFromDest.Text = table.Rows[index][4].ToString();
            tbToDest.Text = table.Rows[index][5].ToString();
            rtbFeedback.Text = table.Rows[index][6].ToString();
            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            showData(pos);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < table.Rows.Count)
            {
                showData(pos);
            }
            else
            {
                MessageBox.Show("End");
                pos = table.Rows.Count - 1;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                showData(pos);
            } else {
                pos = 0;
                MessageBox.Show("End");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pos = table.Rows.Count - 1;
            showData(pos);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbLastname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
