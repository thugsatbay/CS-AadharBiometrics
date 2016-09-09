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
    public partial class Form2_2_vehicles : Form
    {
        int items; //Total Number of Items to be entered
        int cnt; //Keeps the count of numbers entered
        String test;
        bool flag;
        int x;
        Form2 form2;

        public Form2_2_vehicles()
        {
            InitializeComponent();
            items = 0;
            test = "";
            flag = true;
            x = 0;
            cnt = 1;
            listBox.Items.Clear();
            license_plate_no.MaxLength = 9;
        }

        public Form2_2_vehicles(int y,Form2 f2)
            : this()
        {
            form2 = f2;//To return the values calculated by this form to its original form
            items = y;
        }


        private void enter_Click(object sender, EventArgs e)
        {
            test = license_plate_no.Text;

            //
            //Check if License entered is correct to - FORMAT - AADDADDDD
            if (test.Length != 9)
            { flag = false; }

            else
            {
                // out is to be passed by reference
                bool test1 = Int32.TryParse(test.Substring(5, 4), out x);
                if (!test1)   // Checks if the 6 to 9 characters are digits
                { flag = false; }

                for (int i = 0; i < 2; ++i)
                {
                    if (Int32.TryParse((test.Substring(0, 2)[i].ToString()), out x))  // Checks if the first two characters are alphabets
                    { flag = false; break; }
                }

                if (Int32.TryParse((test[4].ToString()), out x))  // Checks if the fifth character is a alphabet
                { flag = false; }
            }

            //
            //Add to List Box
            if (flag && (cnt <= items))
            {
                listBox.Items.Add(test.ToUpper());
                license_plate_no.Text = "";
                license_plate_no.Focus();
                ++cnt; //To check on the number of vehicles entered
            }

            //
            //Error In License Number Message
            else if (cnt <= items)
            {
                MessageBox.Show("License Number Entered Is Incorrect Please Try Again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                license_plate_no.Text = "";
                license_plate_no.Focus();
            }

            //
            //No further License Can be added
            else
            {
                MessageBox.Show("All Enteries Completed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                final_submit.Focus();
            }
            flag = true;

        }

        private void Form2_2_vehicles_Load(object sender, EventArgs e)
        {
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 212), ((height / 2) - 212));
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //removal of Wrong Entry
            x = listBox.SelectedIndex; 
            listBox.Items.RemoveAt(x);
            license_plate_no.Focus();
            --cnt;
        }

        private void license_plate_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            //For Quick Entries of License Numbers
            if (e.KeyChar == (char)13)
            { enter_Click(sender, e); }
        }

        private void final_submit_Click(object sender, EventArgs e)
        {
            //Only allows if all license numbers are entered
            if (cnt == (items + 1))
            {
                String temporary = "";
                //Extracts one by by all license numbers from the listbox
                for (int i = 0; i < items; ++i)
                {
                    listBox.SelectedIndex = i;
                    temporary += listBox.SelectedItem;
                    temporary += ","; 
                }
                temporary += items.ToString();
                form2.recieve[0] = temporary; //Stores all license numbers in form2
                this.Close();
            }

            else
            {
                MessageBox.Show("Enter "+(items-cnt+1).ToString()+" more vehicle No.s","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                license_plate_no.Focus();
            }
        }
    }
}
