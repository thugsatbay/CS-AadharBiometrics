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
    public partial class Form1 : Form
    {
        String[] store_data;
        public Form1()
        {
            InitializeComponent();

            store_data = new String[15];

            //Setting Minimum and Maximum Values for Date of Birth Field
            DateTime max_date = DateTime.Now;
            max_date = max_date.AddYears(-1);
            DateTime min_date = max_date.AddYears(-110);
            dob1.MaxDate = max_date;
            dob1.MinDate = min_date;

            //Maximum Length of each field
            f_name1.MaxLength = 15;
            l_name1.MaxLength = 15;
            m_name1.MaxLength = 15;
            fathers_name1.MaxLength = 45;
            mothers_name1.MaxLength = 45;
            spouse_name1.MaxLength = 50;
            pan_id1.MaxLength = 10;
            driver_license1.MaxLength = 16;
            passport_id1.MaxLength = 8;
            landline_number1.MaxLength = 11;
            mobile_number1.MaxLength = 10;
            rashion_id1.MaxLength = 16;
        }

        private void next_Click(object sender, EventArgs e)
        {

            #region Field_Data

            //Collecting the user data
               
               store_data[0]=f_name1.Text;
               store_data[1] = l_name1.Text;
               store_data[2] = m_name1.Text;
               store_data[3] = fathers_name1.Text;
               store_data[4] = mothers_name1.Text;
               store_data[5] = marital_status1.SelectedIndex.ToString();
               store_data[6] = spouse_name1.Text;
               store_data[7] = dob1.Text;
               store_data[8] = "0";
               store_data[9] = pan_id1.Text;
               store_data[10] = driver_license1.Text;
               store_data[11] = passport_id1.Text;
               store_data[12] = rashion_id1.Text;
               store_data[13] = mobile_number1.Text;
               store_data[14] = landline_number1.Text;

               //Local Varables
               int x;
               double xx;
               bool test;
               String message="";
               //The flag boolean is individual detection for errors from all 15 fields of entries
               bool[] flag = new bool[16] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };

            #endregion

            #region Code_Checker

            try
            {
                //
                //First Name Checker - 0
                x = store_data[0].Length;
                if (x < 4)
                { flag[0] = false; message += "First Name must be atleast 5 characters long.\n\n"; }

                //
                //Last Name Checker - 1
                x = store_data[1].Length;
                if (x < 4)
                { flag[1] = false; message += "Last be atleast 5 characters long.\n\n"; }

                //
                //Middle Name Checker - 2
                x = store_data[2].Length;
                    if ((x < 5) && (x != 0))
                { flag[2] = false; message += "Middle must be atleast 5 characters long.\n\n"; }

                //
                //Fathers Name Checker - 3
                x = store_data[3].Length;
                if (x < 10)
                { flag[3] = false; message += "Fathers Name must be atleast 10 characters long.\n\n"; }

                //
                //Mothers Name Checker - 4
                x = store_data[4].Length;
                if (x < 10)
                { flag[4] = false; message += "Mothers Name must be atleast 10 characters long.\n\n"; }

                //
                //Marital Checker - 5
                x = Int32.Parse(store_data[5]);
                if (x == -1)
                { flag[5] = false; message += "Marital Status not entered.\n\n"; }

                //
                //Spouse Checker - 6
                x = Int32.Parse(store_data[5]);
                if (x == 0)
                {
                    if ((store_data[6] == null) || (store_data[6] == "") || (store_data[6].Length < 10))
                    { flag[6] = false; message += "Spouse Name must be atleast 10 characters long.\n\n"; }
                }
                else if (x == 1)
                {
                    if ((store_data[6] != null) || (store_data[6] != ""))
                    { store_data[6] = null; }
                }

                //
                //DOB Checker - 7

                //
                //Gender Checker - 8
                x = Int32.Parse(store_data[8]);
                if (x == -1)
                { flag[8] = false; message += "Gender Status not entered.\n\n"; }

                //
                //Pan ID Checker - 9 - FORMAT - AAAAADDDDA
                if (store_data[9].Length != 10)
                { flag[9] = false; }

                else
                {
                    if (!((store_data[9].ToLower())[4] == (store_data[1].ToLower())[0]))  // The fifth place of PAN ID is the first letter of Surname/Last Name
                    { flag[9] = false; }

                    else if ((store_data[9].ToUpper())[3] != 'P')  // The fourth place of a PAN ID is always P (Person/Individual)
                    { flag[9] = false; }

                    // out is to be passed by reference

                    test = Int32.TryParse(store_data[9].Substring(5, 4), out x);
                    if (!test)   // Checks if the 6 to 9 characters are digits
                    { flag[9] = false; }

                    for (int i = 0; i < 5; ++i)
                    {
                        if (Int32.TryParse((store_data[9].Substring(0, 5)[i].ToString()), out x))  // Checks if the 1 to 5 characters are alphabets
                        { flag[9] = false; break; }
                    }

                    test = Int32.TryParse(store_data[9].Substring(9, 1), out x);
                    if (test)   // Checks if the last character is digit
                    { flag[9] = false; }
                }

                if (!flag[9]) { message += "PAN ID wrongly entered format is AAAAADDDDA, 10 digits.\n\n"; }

                //
                //Drivers License - 10 - FORMAT - AA(State Code)-(13digits)
                if (store_data[10].Length != 16)
                { flag[10] = false; }

                else
                {
                    for (int i = 0; i < 2; ++i)
                    {
                        if (Int32.TryParse((store_data[10].Substring(0, 2)[i].ToString()), out x))  // Checks if the first two characters are alphabets
                        { flag[10] = false; break; }
                    }

                    if (!(store_data[10][2] == '-'))
                    { flag[10] = false; }

                    test = double.TryParse(store_data[10].Substring(3, 13), out xx);
                    if (!test)   // Checks if the last 13 characters are digits
                    { flag[10] = false; }
                }

                if (!flag[10]) { message += "Drivers License wrongly entered format is AA(State Code)-(13digits), 16 digits.\n\n"; }

                //
                //Passport ID - 11 - FORMAT - ADDDDDDD
                if (store_data[11].Length != 8)
                { flag[11] = false; }
                
                else
                {
                    for (int i = 0; i < 1; ++i)
                    {
                        if (Int32.TryParse((store_data[11].Substring(0, 1)[i].ToString()), out x))  // Checks if the first character is a alphabet
                        { flag[11] = false; break; }
                    }

                    test = Int32.TryParse(store_data[11].Substring(1, 7), out x);
                    if (!test)   // Checks if the last 7 characters are digits
                    { flag[11] = false; }
                }

                if (!flag[11]) { message += "Passport ID wrongly entered format is ADDDDDDD, 8 digits.\n\n"; }

                //
                //Ration ID - 12 - FORMAT - 

                //
                //Mobile Number - 13
                if (store_data[13].Length != 10)
                { flag[13] = false; }

                else
                {
                    test = double.TryParse(store_data[13].Substring(0, 10), out xx);
                    if (!test)   // Checks if the 10 characters are digits
                    { flag[13] = false; }
                }

                if (!flag[13]) { message += "Mobile Number wrongly entered, it is 10 digits number.\n\n"; }

                //
                //Landline Number - 14
                if ((store_data[14].Length != 11)&&(store_data[14].Length != 10))
                { flag[14] = false; }

                else
                {
                    test = double.TryParse(store_data[14].Substring(0, (store_data[14].Length-1)), out xx);
                    if (!test)   // Checks if the 11 characters are digits
                    { flag[14] = false; }
                }

                if (!flag[14]) { message += "Landline Number wrongly entered, it is 11 digits number.\n\n"; }

                flag[15] = true;
            }
            catch(Exception ee)
            { MessageBox.Show("Please Fill The Complete Form Page To Proceed Further"); flag[15] = false; }

            #endregion

            #region Form_Jump

            if ((flag[15]) && (message != ""))
            { 
                MessageBox.Show(message, "ERROR - Please resolve the below mentioned problems!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                message = "";
                for (int i = 0; i <= 14; ++i) //set all flags false
                {
                    flag[i] = true;
                }
            }
            else
            {
                String temporary = String.Format("Name : {0} {1} {2}\nFather's Name : {3}\nMother's Name : {4}\nMarital Status : {5}\nSpouse Name : {6}\nDOB : {7}\nGender : {8}\nPAN ID : {9}\nDrivers License : {10}\nPassport ID : {11}\nRation ID : {12}\nMobile Number : {13}\nLandline Number : {14}\n", store_data);
                DialogResult ab=MessageBox.Show(temporary,"Are You Sure!",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);//Make Sure
                if (ab == DialogResult.Yes)
                {
                    this.Hide();
                    Form2 form2 = new Form2(store_data);
                    form2.ShowDialog();
                    this.Close();
                }
            }

            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 555), ((height / 2) - 335));
        }

        private void marital_status1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (marital_status1.SelectedIndex == 0)
            {
                spouse_name1.Enabled = true;
            }
            else 
                { spouse_name1.Enabled = false;  }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                store_data[8] = "0";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                store_data[8] = "1";
            }
        }

    }
}

