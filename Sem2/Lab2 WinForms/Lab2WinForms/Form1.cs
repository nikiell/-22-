using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2WinForms
{
    public partial class Form1 : Form
    {

        private Random rand = new Random();
        private List<int> randomNumbers = new List<int>();
        private List<Button> buttonList = new List<Button>();
        ProgressBar progress = new ProgressBar();
        Label finishGameLabel = new Label();


        private int count = 1;

        public Form1()
        {
            InitializeComponent();
            CreateNumberField();
        }

        //tab 1
        private void AddItem_Click(object sender, EventArgs e)
        {
            if (inputField.Text != "")
            {
                dropDownList.Items.Add(inputField.Text);
                inputField.Clear();
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (dropDownList.Items.Count != 0)
            {
                dropDownList.Items.RemoveAt(dropDownList.Items.Count - 1);
            }
        }
        //tab 1

        //tab 2

        private Button CreateButton(int xCoordinate, int yCoordinate)
        {
            Button button = new Button();
            button.Size = new Size(50, 50);
            button.Location = new Point(xCoordinate, yCoordinate);
            return button;
        }

        private void CreateNumberField()
        {
            Button b;
            int margin = 80;

            int X = (this.tabControl1.TabPages[1].Width / 2) - (margin + 65);
            int Y = 100;
            int counter = 0;

            for (int i = 0; i < 16; i++)
            {
                b = CreateButton(X, Y);

                counter++;
                X += margin;

                if (counter == 4)
                {
                    Y += 60;
                    X = (this.tabControl1.TabPages[1].Width / 2) - (margin + 65);
                    counter = 0;
                }

                b.Click += new EventHandler(NumberClick);

                this.tabControl1.TabPages[1].Controls.Add(b);
                buttonList.Add(b);


            }
            SetRandomNumbers(buttonList);

            //creating progress bar and label
            Y += 60;
            X = (this.tabControl1.TabPages[1].Width / 2) - (margin + 65);
            progress.Location = new Point(X, Y);
            progress.Size = new Size(290, 30);
            progress.Maximum = 112;
            this.tabControl1.TabPages[1].Controls.Add(progress);

            Y += 40;
            finishGameLabel.Location = new Point(X, Y);
            finishGameLabel.Size = new Size(290, 30);
            finishGameLabel.Text = "Click in the correct sequence!";
            finishGameLabel.Font = new Font("Roboto", 12f, FontStyle.Regular);
            this.tabControl1.TabPages[1].Controls.Add(finishGameLabel);

        }


        private void NumberClick(object sender, EventArgs e)
        {
            if ((sender as Button).Text == count.ToString())
            {
                this.tabControl1.TabPages[1].Controls.Remove(sender as Button);
                buttonList.Remove(sender as Button);
                count++;
                progress.Value += 7;
                SetRandomNumbers(buttonList);
                if (progress.Value == 112)
                {
                    finishGameLabel.Text = "Great job!!!";
                }
            }
            else
            {
                this.tabControl1.TabPages[1].Controls.Clear();
                buttonList.Clear();
                count = 1;
                progress.Value = 0;
                CreateNumberField();
            }
        }


        private void SetRandomNumbers(List<Button> list)
        {
            List<int> possible = new List<int>();


            for (int i = count; i <= 16; i++)
            {
                possible.Add(i);

            }


            int index;

            for (int i = 0; i < list.Count; i++)
            {
                index = rand.Next(0, possible.Count);
                list[i].Text = " ";
                list[i].Text = possible[index].ToString();
                possible.RemoveAt(index);

            }



        }




    }
}
