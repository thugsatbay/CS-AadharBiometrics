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
    public partial class Form5 : Form
    {
        int lg,mode;
        public Form5()
        {
            InitializeComponent();
            lg=3;
        }

        public Form5(int md):this()
        {
            mode = 1;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point((width / 2) - 150, ((height / 2) - 150));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user=textBox1.Text;
            String password = textBox2.Text;
            if (mode == 1)
            {
                if (password.Length == 16)
                {
                    Read vb = new Read(1,password);
                    MessageBox.Show("Login To User", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    vb.ShowDialog();
                    this.Close();
                    
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    --lg;
                    if (lg == 0) //Not login more than 3 times
                    {
                        this.Close();
                    }
                    MessageBox.Show("Wrong Login. " + lg.ToString() + " more attempt left", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (user == "Admin")
            {
                if (password == Properties.Settings.Default.Read_Password) //Read Biometric Data Login
                {
                    Read vb = new Read();
                    MessageBox.Show("Login To Read", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    vb.ShowDialog();
                    this.Close();
                    
                    
                }
                else if (password == Properties.Settings.Default.Write_Password) //Write Biometric Data Login
                {
                    Write vb = new Write();
                    MessageBox.Show("Login To Write", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    vb.ShowDialog();
                    this.Close();
                    
                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    --lg;
                    if (lg == 0) //Not login more than 3 times
                    {
                        this.Close();
                    }
                    MessageBox.Show("Wrong Login. " + lg.ToString() + " more attempt left", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                --lg;
                if (lg == 0)//Not login more than 3 times
                {
                    this.Close();
                }
                MessageBox.Show("Wrong Login. " + lg.ToString() + " more attempt left", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
    }
}
