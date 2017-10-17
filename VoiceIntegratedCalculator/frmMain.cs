using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace VoiceIntegratedCalculator
{
    public partial class frmMain : Form
    {

        double value;
        string Operator;
        bool Operator_Pressed = false;
        bool DirtyBit = false;
        SpeechSynthesizer speak = new SpeechSynthesizer();

        public frmMain()
        {
            InitializeComponent();
        }
        
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            Operator_Pressed = false;
            DirtyBit = false;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TbxResult.Text = TbxResult.Text + btn.Text;
            DirtyBit = true;
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            TbxResult.Text = "";
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            SetOperator((Button)sender);
        }

        private void SetOperator(Button sender)
        {
            Button btn = sender;
            Operator = btn.Text;

            if (DirtyBit)
            {
                value = double.Parse(TbxResult.Text);
                SetInput(true);
            }
            else if (!DirtyBit) Message("Please Enter some valid input.");
            
        }

        private void Message(string v)
        {
            speak.Speak(v);
        }

        private void SetInput(bool v)
        {
            Operator_Pressed = v;
            lblvalue.Text = $"{value} {Operator}";
            TbxResult.Text = null;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            if (Operator_Pressed == true && TbxResult.Text != "") Operate(Operator);
            else if (Operator_Pressed == false || TbxResult.Text == "") Message("Please select an operate to perform operation.");
        }

        private void Operate(string @operator)
        {
            switch (@operator)
            {
                case "+":
                    TbxResult.Text = (value + double.Parse(TbxResult.Text)).ToString();
                    Message($"Addition result is {TbxResult.Text}");
                    break;
                case "-":
                    TbxResult.Text = (value - double.Parse(TbxResult.Text)).ToString();
                    Message($"Subtraction result is {TbxResult.Text}");
                    break;
                case "*":
                    TbxResult.Text = (value * double.Parse(TbxResult.Text)).ToString();
                    Message($"Multiplication result is {TbxResult.Text}");
                    break;
                case "/":
                    TbxResult.Text = (value / double.Parse(TbxResult.Text)).ToString();
                    Message($"Division result is {TbxResult.Text}");
                    break;
            }
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TbxResult.Text = null;
            lblvalue.Text = null;
        }

    }
}
