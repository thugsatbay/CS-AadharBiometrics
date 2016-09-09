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
    public partial class Read : Form
    {
        int mode;
        String id;
        public Read()
        {

            InitializeComponent();
        }

        public Read(int md,String vlue)
        {
            InitializeComponent();
            mode = md;
            id = vlue;
            
        }

        private void keep_id()
        {
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form4' table. You can move, or remove it, as needed.
            this.form4TableAdapter.Fill(this.dataSet_Biometric_DB1.Form4);
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form3' table. You can move, or remove it, as needed.
            this.form3TableAdapter.Fill(this.dataSet_Biometric_DB1.Form3);
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form2' table. You can move, or remove it, as needed.
            this.form2TableAdapter.Fill(this.dataSet_Biometric_DB1.Form2);
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form1' table. You can move, or remove it, as needed.
            this.form1TableAdapter.Fill(this.dataSet_Biometric_DB1.Form1);

            //MessageBox.Show(dataGridView1.Rows.Count.ToString());
            
            if (mode == 1)
            {
                int temp = 0, temp0 = dataGridView1.Rows.Count;
                for (int i = 0; i < temp0 - 1; ++i)
                {
                    //MessageBox.Show(dataGridView1.Rows[temp].Cells[0].Value.ToString());
                    if (dataGridView1.Rows[temp].Cells[0].Value.ToString() == id)
                    {
                        temp = 1;
                    }
                    dataGridView1.Rows.RemoveAt(temp);
                    dataGridView2.Rows.RemoveAt(temp);
                    dataGridView3.Rows.RemoveAt(temp);
                }
                
                temp0=dataGridView4.Rows.Count;
                
                for (int i = 0; i < temp0; ++i)
                {
                    dataGridView4.Rows.RemoveAt(0);
                }
                
            }
        }

        private void Read_Load(object sender, EventArgs e)
        {

            keep_id();

            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Width = width - 10;
            this.Height = height - 100;
            this.Location = new Point(((width / 2) - ((width - 10) / 2)), ((height / 2) - ((height - 100) / 2)));

        
        }


    }
}
