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
    public partial class Options : Form
    {
        
        public Options()
        {
            InitializeComponent();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback();
            feedback.Show();
        }

        private void btnUpdateDelete_Click(object sender, EventArgs e)
        {
            Edit editUserInfo = new Edit();
            editUserInfo.Show();
        }

        private void btnBookCar_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Oops...
        }
    }
}
