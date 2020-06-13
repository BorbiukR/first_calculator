using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if ((TextBox_Result.Text == "0") || (isOperationPerformed))
                TextBox_Result.Clear();         // забирає 0 при кліку 
            Button button = (Button)sender;                         // виводить клік в TextBox_Result

            if (button.Text == ".")         // не дозволяє нажимати багато разів "."
            {
                if (!TextBox_Result.Text.Contains("."))
                    TextBox_Result.Text = TextBox_Result.Text + button.Text;
            }
            else
                TextBox_Result.Text = TextBox_Result.Text + button.Text;

            isOperationPerformed = false;


        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                EqualsButton.PerformClick();

                operationPerformed = button.Text;
                isOperationPerformed = true;
                LabelCurrentOperation.Text = resultValue + " " + operationPerformed; // виводить в label значення + дію
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(TextBox_Result.Text);
                isOperationPerformed = true;
                LabelCurrentOperation.Text = resultValue + " " + operationPerformed; // виводить в label значення + дію
            }
        }

        private void CE_Button_Click(object sender, EventArgs e)   // clear
        {
            TextBox_Result.Text = "0";
            LabelCurrentOperation.Text = "";
        }

        private void C_Button_Click(object sender, EventArgs e)     // clear
        {
            TextBox_Result.Text = "0";
            LabelCurrentOperation.Text = "";
            resultValue = 0;
        }

        private void EqualsButton_Click(object sender, EventArgs e)             // викончує дію
        {
            switch (operationPerformed)
            {
                case "+":
                    TextBox_Result.Text = (resultValue + Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "-":
                    TextBox_Result.Text = (resultValue - Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "*":
                    TextBox_Result.Text = (resultValue * Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "/":
                    TextBox_Result.Text = (resultValue / Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(TextBox_Result.Text);        // вводить норм label
            LabelCurrentOperation.Text = "";
        }
    }
}
