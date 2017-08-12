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
    public partial class Edit : Form
    {
        private static string conString = "Server=(local); Database=InClassExercises; User=PrimeUser; Password=12345";
        private SqlConnection connection = new SqlConnection(conString);
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataTable table = new DataTable();

        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message+"No history!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
               
            }
        
        }

        public void showData(int index)
        {
            
            tbFirstname.Text = table.Rows[index][1].ToString();
            tbLastname.Text = table.Rows[index][2].ToString();
            tbUsername.Text = table.Rows[index][3].ToString();
            tbPassword.Text = table.Rows[index][4].ToString();
            tbAddress.Text = table.Rows[index][5].ToString();
            tbCity.Text = table.Rows[index][6].ToString();
            tbProvince.Text = table.Rows[index][7].ToString();
            tbPostal.Text = table.Rows[index][8].ToString();
            cbCountry.Text = table.Rows[index][9].ToString();
            tbEmail.Text = table.Rows[index][10].ToString();
            tbPhone.Text = table.Rows[index][11].ToString();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {

            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string firstname = tbFirstname.Text;
            string lastname = tbLastname.Text;
            string street = tbAddress.Text;
            string city = tbCity.Text;
            string province = tbProvince.Text;
            string postal = tbPostal.Text;
            string country = cbCountry.Text;
            string email = tbEmail.Text;
            string phone = tbPhone.Text;

            cmd = new SqlCommand("UPDATE UserInfo SET "+
                " FirstName ='"+firstname+"', LastName ='"+lastname+"', Username = '"+username+"', Password='"+password+
            "', Street ='"+street+"', City ='"+city+"', Province = '"+province+"', PostalCode ='"+postal+"', Country ='"+country+
            "', Email = '"+email+"', Phone = '"+phone+"' WHERE Username = '"+LoginInfo.username+"'", connection);
            cmd.Connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            
            if (i != 0)
            {
                LoginInfo.username = username;
                MessageBox.Show("Account Succesfully Updated!");
                //  signup.Close();
            }



        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
