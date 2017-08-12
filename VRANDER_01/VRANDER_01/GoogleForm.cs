using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech;
namespace VRANDER_01
{
    public partial class GoogleForm : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        //  SpeechRecognitionEngine recognizer2 = new SpeechRecognitionEngine();
        SpeechSynthesizer ss = new SpeechSynthesizer();
     
        public GoogleForm()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void GoogleForm_Load(object sender, EventArgs e)
        {


            Choices colors = new Choices();
            colors.Add(new string[] { "number two", "number one", "Add", "Multiply", "Subtract", "Divide", "Close", "Map It", "Change to Map", "Change to Calculator", "Style" });
            string[] numberString = { "zero", "one", "two", "three", "four", "five",
                            "six", "seven", "eight", "nine","Ten","India"+"Punjab"};
            Choices numberChoices = new Choices();
            for (int i = 0; i < numberString.Length; i++)
            {
                colors.Add(new SemanticResultValue(numberString[i], i));
            }
            colors.Add(new SemanticResultValue("India", "India"));
            colors.Add(new SemanticResultValue("Punjab", "Punjab"));
            colors.Add(new SemanticResultValue("Brampton", "Brampton"));
            colors.Add(new SemanticResultValue("Toronto", "Toronto"));
            Grammar g = new Grammar(new GrammarBuilder(colors));
            recognizer.LoadGrammarAsync(g);
            // Create a GrammarBuilder object and append the Choices object.
            recognizer.SetInputToDefaultAudioDevice();
            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized += sre_SpeechRecognized;
            //     new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            button2.Enabled = false;

        }



      







        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {



            switch (e.Result.Text.ToString())
            {
                case "number one":
                    this.ActiveControl = tbNum1;
                    // MessageBox.Show("Hello how Are");
                    break;
                case "number two":
                    // MessageBox.Show("Hello how Are 2");
                    this.ActiveControl = tbNum2;
                    break;
                case "Add":
                    btCalculate_Click(e.Result.Text);
                    break;
                case "Multiply":
                    btCalculate_Click(e.Result.Text);
                    break;
                case "Subtract":
                    btCalculate_Click(e.Result.Text);
                    break;
                case "Divide":
                    btCalculate_Click(e.Result.Text);
                    break;
                case "Change to Map":
                    label1.Text = "From";
                    label2.Text = "To";
                    break;
                case "Change to Calculator":
                    label1.Text = "Number 1";
                    label2.Text = "Number 2";
                    break;
                case "Map It":
                    gMapsAPI(tbNum1.Text + "/" + tbNum2.Text);
                    break;
                case "Close":
                    Close();
                    break;
            }



            if (e.Result.Text != "Close" && e.Result.Text != "Box One" &&
                   e.Result.Text != "Box Two")
            {
                this.ActiveControl.Text += Convert.ToString(e.Result.Semantics.Value);
            }















        }

        private void gMapsAPI(string s)
        {
            try
            {
                StringBuilder queryA = new StringBuilder();
                //queryA.Append("https://www.google.ca/maps/dir/"+tbNum1.Text+"/"+tbNum2.Text+"/");
                // queryA.Append(s);
                queryA.Append("https://www.flysfo.com/to-from/driving-directions?travelMode=DRIVING&start=" + tbNum1.Text + "&end=" + tbNum2.Text);
                webBrowser1.Navigate(queryA.ToString());
                //  webBrowser1.Navigate("file:///C:/Users/jaspreet/Documents/Visual%20Studio%202013/Projects/WindowsFormsApplication3/WindowsFormsApplication3/HTMLPage1.html");
            }
            catch (Exception e)
            {
            }

        }




        private void btCalculate_Click(String o)
        {

            double num1 = Convert.ToDouble(tbNum1.Text);
            double num2 = Convert.ToDouble(tbNum2.Text);
            double calculate = 0;
            if (o == "Add")
            {
                calculate = num1 + num2;
            }
            else if (o == "Multiply")
            {
                calculate = num1 * num2;
            }
            else if (o == "Subtract")
            {
                calculate = num1 - num2;
            }
            else if (o == "Divide")
            {
                calculate = num1 / num2;
            }

            // calculate = num1+num2;
            MessageBox.Show("The Added NUmbers Are:" + calculate, "Calculate");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\mywavfile.wav");
            //player.Play();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            recognizer.RecognizeAsyncStop();
            //    recognizer2.RecognizeAsync();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            gMapsAPI("hello");
            ss.SelectVoiceByHints(VoiceGender.Female);
            ss.SpeakAsync("Welcome JASPREET THE DIRECTION YOU HAVE CHOSEN ARE FROM:" + tbNum1.Text + " TO: " + tbNum2.Text);
        }

    }
}
