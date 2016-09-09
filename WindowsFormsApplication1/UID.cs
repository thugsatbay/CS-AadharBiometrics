using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UID : Form
    {
        int x = 0,y=600,odd_even=0;
        Label banner_up,banner_down;
        Graphics grph;
        public UID()
        {
            
            InitializeComponent();
            banner_up = new Label();
            banner_down = new Label();
            this.Controls.Add(banner_up);
            this.Controls.Add(banner_down);
            this.banner_up.AutoSize = true;
            this.banner_up.Location = new System.Drawing.Point(160, 10);
            this.banner_up.Text = "Welcome To EID";
            this.banner_up.ForeColor = Color.Maroon;
            this.banner_up.Font = new Font("Verdana", (float)20, FontStyle.Bold);
            this.banner_down.AutoSize = true;
            this.banner_down.Location = new System.Drawing.Point(150,315);
            this.banner_down.Text = "Project Guide: Dr.Suneet Chaudhary";
            this.banner_down.ForeColor = Color.Maroon;
            this.banner_down.Font = new Font("Verdana", (float)12, FontStyle.Bold);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 10;
            
            if (x == 610)
            {
                x = -300;
            }
           
            //this.banner_up.Location = new System.Drawing.Point(x, 10);
            

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            grph = this.CreateGraphics();
            Pen pn = new Pen(Color.Black);
            pn.Width = 2;
            grph.DrawLine(pn, 0, 60, 600, 60);
            grph.DrawLine(pn, 0, 300, 600, 300);
        }

        private void register_MouseLeave(object sender, EventArgs e)
        {
            register.BackColor = Color.DodgerBlue;
        }

        private void register_MouseEnter(object sender, EventArgs e)
        {
            //register.BackColor = Color.FromArgb(255, 128, 255, 255);
        }

        private void record_MouseEnter(object sender, EventArgs e)
        {
            //record.BackColor = Color.FromArgb(255, 128, 255, 255);
        }

        private void record_MouseLeave(object sender, EventArgs e)
        {
            record.BackColor = Color.DodgerBlue;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            y -= 10;
            if (y == -650)
            {
                y = 610;
                ++odd_even;
            }
            if ((odd_even % 2 == 0))
            {
                //this.banner_down.Text = "Project Guide: Dr.Suneet Chaudhary";
            }
            else if ((odd_even % 2 != 0))
            {
                //this.banner_down.Text = "Project Team: Ankit Balyan, Kunal Kholia, Gurleen Singh, Narendar Singh";
            }
            //this.banner_down.Location = new System.Drawing.Point(y, 315);
        }

        private void register_Click(object sender, EventArgs e)
        {
            Form0 fm = new Form0();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void record_Click(object sender, EventArgs e)
        {
            Form5 fm = new Form5();
            this.Hide();
            fm.ShowDialog();
            this.Close();

        }

        private void UID_Load(object sender, EventArgs e)
        {
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point((width / 2) - 300, ((height / 2) - 200));
        }

        private void verify_MouseEnter(object sender, EventArgs e)
        {
            //verify.BackColor = Color.FromArgb(255, 128, 255, 255);
        }

        private void verify_MouseLeave(object sender, EventArgs e)
        {
            verify.BackColor = Color.DodgerBlue;
        }

        private void verify_Click(object sender, EventArgs e)
        {
            Form6 fm = new Form6();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 fm = new Form5(1);
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }
    }
}
