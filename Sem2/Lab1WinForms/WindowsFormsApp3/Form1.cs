using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        string leftop = "";
        string operation = "";
        string rightop = "";
        public Form1()
        {
            InitializeComponent();
            foreach (var button in Controls.OfType<Button>())
            {
                button.Click += Number_Click;
            }
        }

        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string s = btn.Text;
            textBox1.Text += btn.Text;
            int num;
            bool result = Int32.TryParse(s, out num);

            if (result == true)
            {

                if (operation == "")
                {

                    leftop += s;
                }
                else
                {

                    rightop += s;
                }
            }

            else
            {

                if (s == "=")
                {
                    Update_RightOp();
                    textBox1.Text += rightop;
                    operation = "";
                }

                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBox1.Text = "";
                }

                else
                {

                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);

            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
            }
        }
    }
    
}
