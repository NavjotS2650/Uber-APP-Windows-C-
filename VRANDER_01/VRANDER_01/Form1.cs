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
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech;

namespace VRANDER_01
{
    public partial class Form1 : Form
    {

        private static string conString = "Server=Lenovo-PC\\SQLEXPRESS; Database=InClassExercise; User=PrimeUser; Password=12345";
        private SqlConnection connection = new SqlConnection(conString);
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
       
        SpeechSynthesizer ss = new SpeechSynthesizer();
     

        SqlDataAdapter adapter;
        DataTable table = new DataTable();
      

        public Form1()
        {
            InitializeComponent();

            connection.ConnectionString = conString;

        
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //login button clicked
        {
            LoginInfo.username = tbUsername.Text;
            LoginInfo.password = tbPassword.Text;

            if (LoginInfo.authenticate())
            {

                Options options = new Options();
                options.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
           
     
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            Choices colors = new Choices();
            colors.Add(new string[] { "Access User Jaspreet,Access Password Code 1 1 2,Sign In"});
            Choices numberChoices = new Choices();

            colors.Add(new SemanticResultValue("Access User Jaspreet", "Jaspreet"));
            colors.Add(new SemanticResultValue("Access Password Code 1 1 2", "123456"));
            colors.Add(new SemanticResultValue("Brampton", "Brampton"));
            colors.Add(new SemanticResultValue("Toronto", "Toronto"));
            Grammar g = new Grammar(new GrammarBuilder(colors));
            recognizer.LoadGrammarAsync(g);
            // Create a GrammarBuilder object and append the Choices object.
            recognizer.SetInputToDefaultAudioDevice();
            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized += sre_SpeechRecognized;
            //     new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
          





            
}
        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show(e.Result.Text);
            switch (e.Result.Text.ToString())
            {
                case "Access User Jaspreet":
                    this.ActiveControl = tbUsername;
                    tbUsername.Text = e.Result.Semantics.Value.ToString();
                   
                    // MessageBox.Show("Hello how Are");
                    break;
                case"Access Password Code 1 1 2":
                    tbPassword.Text = e.Result.Semantics.Value.ToString();
                    break;
                case"Sign In":
                    button1.PerformClick();
                    break;
                case "Close":
                    Close();
                    break;

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();

        }

        private void loginGroup_Enter(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            MessageBox.Show("HELLO");
        }  
        }
       
    }

