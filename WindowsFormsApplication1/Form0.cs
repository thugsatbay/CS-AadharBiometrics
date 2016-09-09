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
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            comboBox_state.Sorted = true;
            textBox_city.MaxLength = 30;

            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 240), ((height / 2) - 170));
        }

        private void button_register_begin_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.State = comboBox_state.Text;
            Properties.Settings.Default.City = textBox_city.Text;
            MessageBox.Show(comboBox_state.Text);
            this.Hide();
            Form1 fm = new Form1();
            fm.ShowDialog();
            this.Close();
           
        }
    }
}
