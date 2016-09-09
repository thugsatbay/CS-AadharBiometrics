using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Collections.Specialized;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        String message;
        String [] form1_data = new String[15];
        String [] form2_data = new String[6];

        public Form3()
        {
            InitializeComponent();
            
            //Test Case to run directly from Form3
            //for (int i = 0; i < 15; ++i)
            //{ form1_data[i]="NA";
            //if (i < 6)
            //{ form2_data[i] = "NA"; }
            //}

            //Fill in Years
            DateTime dt = DateTime.Now;
            for (int i = dt.Year - 90; i <= (dt.Year+5); ++i)
            {
                comboBox_graduation.Items.Add(i);
                comboBox_high_school.Items.Add(i);
                comboBox_post_graduation.Items.Add(i);
            }

            //Default Value
            comboBox_graduation.SelectedItem = dt.Year;
            comboBox_high_school.SelectedItem=dt.Year;
            comboBox_post_graduation.SelectedItem=dt.Year;

            //Initial year Selection
            comboBox_graduation.Enabled = false;
            comboBox_high_school.Enabled = false;
            comboBox_post_graduation.Enabled = false;

            //Sort the job list in order
            comboBox_job.Sorted = true;
            comboBox_job.Items.Add("Select Job");
            comboBox_job.SelectedItem = "Select Job";

            message = "";

        }
        public Form3(String [] fm3_1,String [] fm3_2):this()
        {
            form1_data=fm3_1;
            form2_data=fm3_2;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 555), ((height / 2) - 275)); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Local Variables
                double xx;
                bool test;
                int x;
                String temporary="";

            #region Checker
                
                // Selects Education Parameters
                bool[] flag = new bool[3];
                flag[0] = checkBox1.Checked;
                flag[1] = checkBox2.Checked;
                flag[2] = checkBox3.Checked;

                //
                //JOB checker
                try
                {
                    if (comboBox_job.SelectedItem.ToString() == "Select Job")
                    { message += "Please Select Appropriate Job\n\n"; }
                }
                catch (Exception ee)//If unknow value entered
                {
                    message += "Please Select Appropriate Job\n\n"; 
                }

                //
                //Salary Checker
                
                test = double.TryParse( income_anually.Text, out xx);
                if (!test)   // Checks if the salary are digits
                { message += "Salary Incorrect\n\n"; }

                //
                //Poverty Checker
                x = listBox_poverty.SelectedIndex;
                if (x == -1)
                {
                    message += "Select Poverty Line Status";
                }

            #endregion

            //Final Decision
            if (message != "")
            {
                MessageBox.Show(message, "ERROR - Please resolve the below mentioned problems!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                message = "";
            }
            else
            {
                
                #region Information 
                    
                    //Collecting Final Information
                try
                {
                    if (flag[0])
                    {
                        temporary += "High School : " + comboBox_high_school.SelectedItem.ToString() + "\n\n";
                    }
                    if (flag[1] && flag[0])
                    {
                        temporary += "Graduation : " + comboBox_graduation.SelectedItem.ToString() + "\n\n";
                    }
                    if (flag[2] && flag[1] && flag[0])
                    {
                        temporary += "Post Graduation : " + comboBox_post_graduation.SelectedItem.ToString() + "\n\n";
                    }
                }
                catch (Exception ee)//If unknow value entered
                { }

                    temporary+="JOB :"+comboBox_job.SelectedItem.ToString()+"\n\n";
                    
                    if (double.Parse(income_anually.Text) > 9999) //Salary entered must be equal to or above 10000 or will be treated as 0
                    {
                        temporary += "Salary :" + income_anually.Text + "\n\n";
                    }
                    else
                    { temporary += "Salary : 0" + "\n\n"; }
                    
                    temporary+="Number Of Family members :"+family_members.Value.ToString()+"\n\n";
                    temporary+="Poverty Line Status :"+listBox_poverty.SelectedItem.ToString()+"\n\n";
                    
                    //Display of Information
                    DialogResult ab = MessageBox.Show(temporary, "Are You Sure!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//Make Sure
                    if (ab == DialogResult.Yes)
                    {
                        //Form 3 Data Sort
                        String temp = "NA", temp00 = "NA", temp0 = "NA", query = "";
                        if (flag[0])
                        {
                            temp = comboBox_high_school.SelectedItem.ToString();
                        }
                        if (flag[1])
                        {
                            temp0 = comboBox_graduation.SelectedItem.ToString();
                        }
                        if (flag[2])
                        {
                            temp00 = comboBox_post_graduation.SelectedItem.ToString();
                        }

                        MessageBox.Show("Successful registeration Of EID", "Successful registeration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //No of successful entries
                        x = 0;
                        
                        //Database Path
                        string sql = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\brick\\Documents\\Visual Studio 2010\\Projects\\WindowsFormsApplication1\\Biometrics.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";
                        //Establsih SQL Connection
                        SqlConnection abc = new SqlConnection(sql);
                        abc.Open();
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = abc;

                        //UID logic
                        String uid_temp=UID_generator.generate_uid(form1_data[8], listBox_poverty.SelectedItem.ToString());
                        
                        //TEST CODE
                        //MessageBox.Show(uid_temp);
                        
                        //Form1 Database Entry
                        query = string.Format("Insert into Form1(uid,first_name,last_name,middle_name,father_name,mother_name,marital_status,spouse_name,dob,gender,pan_id,driver_license,passport_id,rashion_id,mobile_number,landline_number) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", uid_temp.ToString(), form1_data[0], form1_data[1], form1_data[2], form1_data[3], form1_data[4], form1_data[5], form1_data[6], form1_data[7], form1_data[8], form1_data[9], form1_data[10], form1_data[11], form1_data[12], form1_data[13], form1_data[14]);
                        comm.CommandText = query;
                        x = x + comm.ExecuteNonQuery();

                        //Form2 Database Entry
                        query = string.Format("Insert into Form2(uid,emergency_contact,emergency_number,current_address,permanent_address,two_wheeler,four_wheeler) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", uid_temp.ToString(), form2_data[0], form2_data[1], form2_data[2], form2_data[3], form2_data[4], form2_data[5]);
                        comm.CommandText = query;
                        x = x + comm.ExecuteNonQuery();

                        //Form3 Database Entry
                        query = string.Format("Insert into Form3(uid,high_school,graduation,post_graduation,job,salary,family_members,poverty_status) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", uid_temp.ToString(), temp, temp0, temp00, comboBox_job.SelectedItem.ToString(), income_anually.Text, family_members.Value.ToString(), listBox_poverty.SelectedItem.ToString());
                        comm.CommandText = query;
                        x = x + comm.ExecuteNonQuery();
                        
                        //TEST CODE
                        //MessageBox.Show(x + " Record Inserted");

                        MessageBox.Show("Your EID is " + uid_temp, "Your EID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        abc.Close();

                        Form4 fm = new Form4(uid_temp);
                        this.Hide();
                        fm.ShowDialog();
                        this.Close();

                    }

                #endregion

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //High School Year entrance Logic
            if (checkBox1.Checked == true)
            { comboBox_high_school.Enabled = true; }
            else
            { comboBox_high_school.Enabled = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Graduation Year entrance Logic
            if (checkBox2.Checked == true)
            { comboBox_graduation.Enabled = true; }
            else
            { comboBox_graduation.Enabled = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //Post Graduation Year entrance Logic
            if (checkBox3.Checked == true)
            { comboBox_post_graduation.Enabled = true; }
            else
            { comboBox_post_graduation.Enabled = false; }
        }
    }
}
