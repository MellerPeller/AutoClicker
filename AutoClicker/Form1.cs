using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        

        InputSimulator input = new InputSimulator();
        int oldCount = 0;
        bool getPos = false;
        bool getPos1 = false;
        Random rng = new Random();  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox3.Text, out oldCount);
            timer1.Start();

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            getPos = true;
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            {
                if (getPos)
                {
                    textBox1.Text = Cursor.Position.X.ToString();
                    textBox2.Text = Cursor.Position.Y.ToString();

                    getPos = false;
                }
                if (getPos1)
                {
                    textBox4.Text = Cursor.Position.X.ToString();
                    textBox5.Text = Cursor.Position.Y.ToString();

                    getPos1 = false;
                }
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int X);
            int.TryParse(textBox2.Text, out int Y);
            int.TryParse(textBox3.Text, out int Count);
            int.TryParse(textBox4.Text, out int x);
            int.TryParse(textBox5.Text, out int y);
            X = rng.Next(X, x);
            Y = rng.Next(Y, y);

            X = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Width) * X);
            Y = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Height) * Y);
            x = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Width) * x);
            y = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Height) * y);


            if (Count == 0)
            {
                timer1.Stop();
                textBox3.Text = oldCount.ToString();
            }
            else
            {
                Count--;
                textBox3.Text = Count.ToString();
                input.Mouse.MoveMouseTo(X, Y);
               

                input.Mouse.LeftButtonClick();
            }

            if(Count >= 10000)
            {
                MessageBox.Show("No need to cheat so much you stupid smelly burgerfat fuck groundhog eating fucking shitty man!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getPos1 = true;
        }
    }
}
