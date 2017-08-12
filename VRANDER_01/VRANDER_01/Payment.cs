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
    public partial class Payment : Form
    {
        private static string conString = "Server=Lenovo-PC\\SQLEXPRESS; Database=InClassExercise; User=PrimeUser; Password=12345";
        private SqlConnection connection = new SqlConnection(conString);
        SqlDataAdapter adapter;
        DataTable table = new DataTable();

        public Payment()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e) //submit button
        {
            if (tbCardNumber.Text == "" || tbCVV.Text == "")
            {
                string msg = "Must fill in all fields";
                string caption = "Try again.";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            else
            {
                string msg = "Order added successfully";
                string caption = "Success";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void Payment_Load(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message+"Error!");
               
            }
        
        }

        public void showData(int index)
        {
            
            tbFirstname.Text = table.Rows[index][1].ToString();
            tbLastname.Text = table.Rows[index][2].ToString();
            tbAddress.Text = table.Rows[index][5].ToString();
            tbCity.Text = table.Rows[index][6].ToString();
            tbProvince.Text = table.Rows[index][7].ToString();
            tbPostal.Text = table.Rows[index][8].ToString();
            cbCountry.Text = table.Rows[index][9].ToString();
            tbEmail.Text = table.Rows[index][10].ToString();
            tbPhone.Text = table.Rows[index][11].ToString();
        }

        }
    }

