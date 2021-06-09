using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3WinForms
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int count = 0;

        private string blinkingMessage = "Click 'OK' button";
        public Form1()
        {

            InitializeComponent();

            SetTimer();

            button2.GotFocus += new EventHandler(DeleteFocusFromButton);

        }

        private void DeleteFocusFromButton(object sender, EventArgs e)
        {
            button1.Focus();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'OK' button was clicked");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.XCoord.Text = "X: " + button2.Location.X.ToString();
            this.YCoord.Text = "Y: " + button2.Location.Y.ToString();
            int speed = 10;
            int margin = 30;
            int height = button2.Height;
            int width = button2.Width;
            int bX = button2.Location.X;
            int bY = button2.Location.Y;

            if (e.X > bX - margin && e.X < bX && e.Y > bY && e.Y < bY + height)
            {
                button2.Location = new Point(button2.Location.X + speed, button2.Location.Y);
            }
            if (e.X > bX + width && e.X < bX + width + margin && e.Y > bY && e.Y < bY + height)
            {
                button2.Location = new Point(button2.Location.X - speed, button2.Location.Y);
            }
            if (e.X > bX && e.X < bX + width && e.Y > bY - margin && e.Y < bY)
            {
                button2.Location = new Point(button2.Location.X, button2.Location.Y + speed);
            }
            if (e.X > bX && e.X < bX + width && e.Y > bY + height && e.Y < bY + height + margin)
            {
                button2.Location = new Point(button2.Location.X, button2.Location.Y - speed);
            }
            if (e.X > bX - margin && e.X < bX && e.Y > bY - margin && e.Y < bY)
            {
                button2.Location = new Point(button2.Location.X + speed, button2.Location.Y + speed);
                ReduceButtonSize(button2);
            }
            if (e.X > bX + width && e.X < bX + width + margin && e.Y > bY - margin && e.Y < bY)
            {
                button2.Location = new Point(button2.Location.X - speed, button2.Location.Y + speed);
                ReduceButtonSize(button2);
            }
            if (e.X > bX - margin && e.X < bX && e.Y > bY + height && e.Y < bY + height + margin)
            {
                button2.Location = new Point(button2.Location.X + speed, button2.Location.Y - speed);
                ReduceButtonSize(button2);
            }
            if (e.X > bX + width && e.X < bX + width + margin && e.Y > bY + height && e.Y < bY + height + margin)
            {
                button2.Location = new Point(button2.Location.X - speed, button2.Location.Y - speed);
                ReduceButtonSize(button2);
            }

            if (bX < 1)
            {
                if (e.Y > bY + height / 2)
                    button2.Location = new Point(button2.Location.X + margin, button2.Location.Y - margin);
                else
                    button2.Location = new Point(button2.Location.X + margin, button2.Location.Y + margin);
            }
            if (bX + width + 10 > this.Width)
            {
                if (e.Y > bY + height / 2)
                    button2.Location = new Point(button2.Location.X - margin, button2.Location.Y - margin);
                else
                    button2.Location = new Point(button2.Location.X - margin, button2.Location.Y + margin);
            }
            if (bY > this.Height - height - 40)
            {
                if (e.X > bX + width / 2)
                    button2.Location = new Point(button2.Location.X - margin, button2.Location.Y - margin);
                else
                    button2.Location = new Point(button2.Location.X + margin, button2.Location.Y - margin);
            }
            if (bY < 0)
            {
                if (e.X > bX + width / 2)
                    button2.Location = new Point(button2.Location.X - margin, button2.Location.Y + margin);
                else
                    button2.Location = new Point(button2.Location.X + margin, button2.Location.Y + margin);
            }

        }

        private void ReduceButtonSize(Button b)
        {
            b.Width -= 1;
            b.Height -= 1;
            if (b.Width == 0 || b.Height == 0)
            {
                blinkingMessage = "'OK' button cannot be clicked :(";
                SetTimer();
            }
        }


        private void Blinking(object sender, EventArgs e)
        {
            count++;
            if (count % 2 == 0)
            {
                this.Text = blinkingMessage;
                this.ForeColor = Color.Green;
            }
            else
            {
                this.Text = "";
            }
            if (count == 17)
            {
                this.Text = blinkingMessage;
                timer.Stop();
            }
        }

        private void SetTimer()
        {
            count = 0;
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(Blinking);
            timer.Enabled = true;
            timer.Start();
        }



    }
}
