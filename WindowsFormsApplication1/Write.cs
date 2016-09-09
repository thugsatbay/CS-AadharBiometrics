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
    public partial class Write : Form
    {
        public Write()
        {
            InitializeComponent();
        }

        private void Write_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form4' table. You can move, or remove it, as needed.
            this.form4TableAdapter.Fill(this.dataSet_Biometric_DB1.Form4);
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form3' table. You can move, or remove it, as needed.
            this.form3TableAdapter.Fill(this.dataSet_Biometric_DB1.Form3);
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form2' table. You can move, or remove it, as needed.
            this.form2TableAdapter.Fill(this.dataSet_Biometric_DB1.Form2);
            // TODO: This line of code loads data into the 'dataSet_Biometric_DB1.Form1' table. You can move, or remove it, as needed.
            this.form1TableAdapter.Fill(this.dataSet_Biometric_DB1.Form1);

            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Width = width - 10;
            this.Height = height - 100;
            this.Location = new Point(((width / 2) - ((width - 10) / 2)), ((height / 2) - ((height - 100) / 2)));
        }

        private void Write_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Validate();
            this.bindingSource1.EndEdit();
            this.bindingSource2.EndEdit();
            this.bindingSource3.EndEdit();
            this.bindingSource4.EndEdit();
            this.tableAdapterManager1.UpdateAll(dataSet_Biometric_DB1);
        }
    }
}
