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
    public partial class Form2 : Form
    {
        //To Take Values of License as Returned by Form2_2_vehicles and Form2_4_vehicles
       public String [] recieve=new String[2];
       //To recieve The values of form1
        String[] back_form1 = new String[15];
        String[] store_data1 = new String[6];
        
        public Form2()
        {
            InitializeComponent();
            recieve[0] = "Not Entered";
            recieve[1] = "Not Entered";

            //Maximum Length Set
            permanent_address.MaxLength = 120;
            current_address.MaxLength = 120;
            emergency_contact.MaxLength = 45;
            emergency_contact_phone_number.MaxLength = 10;

        }
        public Form2(String[] s):this()
        {
            back_form1 = s;
        }

        private void next_Click(object sender, EventArgs e)
        {

            #region Field_Data

            //Collecting The User Data
            
            store_data1[0] = emergency_contact.Text;
            store_data1[1] = emergency_contact_phone_number.Text;
            store_data1[2] = current_address.Text;
            store_data1[3] = permanent_address.Text;

            //Local Variables
            int x;
            double xx = 0;
            bool test;
            //The flag boolean is individual detection for errors from all 15 fields of entries
            bool[] flag = new bool[4] { true, true, true, true };
            String message = "";

            #endregion 

            #region Code_Checker

            //Check Cases
            //Emergency Contact Name Checker - 0
            x = store_data1[0].Length;
            if (x < 10)
            { flag[0] = false; message += "Emergency Contact Name must be atleast 10 characters long.\n\n"; }

            //
            //Emergency Contact Mobile Number Checker - 1
            if (store_data1[1].Length != 10)
            { flag[1] = false; }

            else
            {
                test = double.TryParse(store_data1[1].Substring(0, 10), out xx);
                if (!test)   // Checks if the 10 characters are digits
                { flag[1] = false; }
            }

            if (!flag[1]) { message += "Mobile Number wrongly entered, it is 10 digits number.\n\n"; }

            //
            //Current Address Checker - 2
            x = store_data1[2].Length;
            if (x < 15)
            { flag[2] = false; message += "Current Address must be atleast 15 characters long.\n\n"; }

            //
            //Permanent Address Checker - 3
            x = store_data1[3].Length;
            if (x < 15)
            { flag[3] = false; message += "Permanent Address must be atleast 15 characters long.\n\n"; }

            //
            //Two Vehicles
            x = (int)(two_vehicles_counter.Value);
            if ((x > 0) && (recieve[0] == "Not Entered"))
            { message += "2 Wheeler Vehice License Plates Not Entered.\n\n"; }

            //
            //Four Vehicles
            x = (int)(four_vehicles_counter.Value);
            if ((x > 0) && (recieve[1] == "Not Entered"))
            { message += "4 Wheeler Vehice License Plates Not Entered.\n\n"; }

            #endregion

            #region Form_Jump

            if (message != "")
            {
                MessageBox.Show(message, "ERROR - Please resolve the below mentioned problems!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                message = "";
                for (int i = 0; i <= 3; ++i) //set all flags false
                {
                    flag[i] = true;
                }
            }
            else
            {
                String temporary = String.Format("Emergency Contact Name : {0}\nEmergency Contact Phone Number : {1}\nCurrent Address : {2}\nPermanent Address : {3}\n2 wheeler vehicles license plate : {4}\n4 wheeler vehicles license plate : {5}", store_data1[0],store_data1[1],store_data1[2],store_data1[3],recieve[0],recieve[1]);
                DialogResult ab = MessageBox.Show(temporary, "Are You Sure!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//Make Sure
                if (ab == DialogResult.Yes)
                {
                    this.Hide();
                    store_data1[4] = recieve[0];
                    store_data1[5]=recieve[1];
                    Form3 form3 = new Form3(back_form1,store_data1);
                    form3.ShowDialog();
                    this.Close();
                }
            }

            #endregion

        }

        private void two_vehicles_button_Click(object sender, EventArgs e)
        {
            int x = (int)(two_vehicles_counter.Value);
            if (x != 0)
            {
                Form2_2_vehicles form = new Form2_2_vehicles(x,this);
                form.ShowDialog();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 555), ((height / 2) - 324));
        }

        private void four_vehicles_button_Click(object sender, EventArgs e)
        {
            int x = (int)(four_vehicles_counter.Value);
            if (x != 0)
            {
                Form2_4_vehicles form = new Form2_4_vehicles(x, this);
                form.ShowDialog();
            }

        }


    }
}
