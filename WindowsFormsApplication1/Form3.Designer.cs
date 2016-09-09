namespace WindowsFormsApplication1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.family_members = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.income_anually = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_post_graduation = new System.Windows.Forms.ComboBox();
            this.comboBox_graduation = new System.Windows.Forms.ComboBox();
            this.comboBox_high_school = new System.Windows.Forms.ComboBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.listBox_poverty = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_job = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.family_members)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "EID Enrollment Form\r\n";
            // 
            // family_members
            // 
            this.family_members.Location = new System.Drawing.Point(277, 149);
            this.family_members.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.family_members.Name = "family_members";
            this.family_members.Size = new System.Drawing.Size(120, 23);
            this.family_members.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Number Of Family No.";
            // 
            // income_anually
            // 
            this.income_anually.Location = new System.Drawing.Point(277, 111);
            this.income_anually.Name = "income_anually";
            this.income_anually.Size = new System.Drawing.Size(198, 23);
            this.income_anually.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.comboBox_post_graduation);
            this.panel2.Controls.Add(this.comboBox_graduation);
            this.panel2.Controls.Add(this.comboBox_high_school);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(3, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 250);
            this.panel2.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(347, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Year of Passing";
            // 
            // comboBox_post_graduation
            // 
            this.comboBox_post_graduation.DropDownHeight = 150;
            this.comboBox_post_graduation.FormattingEnabled = true;
            this.comboBox_post_graduation.IntegralHeight = false;
            this.comboBox_post_graduation.Location = new System.Drawing.Point(342, 185);
            this.comboBox_post_graduation.Name = "comboBox_post_graduation";
            this.comboBox_post_graduation.Size = new System.Drawing.Size(121, 24);
            this.comboBox_post_graduation.TabIndex = 7;
            // 
            // comboBox_graduation
            // 
            this.comboBox_graduation.DropDownHeight = 150;
            this.comboBox_graduation.FormattingEnabled = true;
            this.comboBox_graduation.IntegralHeight = false;
            this.comboBox_graduation.Location = new System.Drawing.Point(342, 132);
            this.comboBox_graduation.Name = "comboBox_graduation";
            this.comboBox_graduation.Size = new System.Drawing.Size(121, 24);
            this.comboBox_graduation.TabIndex = 5;
            // 
            // comboBox_high_school
            // 
            this.comboBox_high_school.DropDownHeight = 150;
            this.comboBox_high_school.FormattingEnabled = true;
            this.comboBox_high_school.IntegralHeight = false;
            this.comboBox_high_school.Location = new System.Drawing.Point(342, 77);
            this.comboBox_high_school.Name = "comboBox_high_school";
            this.comboBox_high_school.Size = new System.Drawing.Size(121, 24);
            this.comboBox_high_school.TabIndex = 3;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(57, 191);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(132, 20);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "Post Graduation";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(57, 134);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 20);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Graduation";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(57, 79);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(170, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "High School / Diploma";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(78, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(207, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Education Qualification";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(103, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "Income Anually";
            // 
            // listBox_poverty
            // 
            this.listBox_poverty.FormattingEnabled = true;
            this.listBox_poverty.ItemHeight = 16;
            this.listBox_poverty.Items.AddRange(new object[] {
            "APL",
            "BPL"});
            this.listBox_poverty.Location = new System.Drawing.Point(277, 187);
            this.listBox_poverty.Name = "listBox_poverty";
            this.listBox_poverty.Size = new System.Drawing.Size(58, 36);
            this.listBox_poverty.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(72, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 16);
            this.label15.TabIndex = 7;
            this.label15.Text = "Poverty Line Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "JOB";
            // 
            // comboBox_job
            // 
            this.comboBox_job.DropDownHeight = 200;
            this.comboBox_job.DropDownWidth = 200;
            this.comboBox_job.IntegralHeight = false;
            this.comboBox_job.Items.AddRange(new object[] {
            "Accounting ",
            "Manufacturing",
            "Admin & Clerical",
            "Franchise",
            "Nonprofit",
            "Banking & Finance",
            "Government",
            "Student",
            "Part Time",
            "Business Opportunities",
            "Health Care",
            "Retail",
            "Contract & Freelance",
            "Hospitality",
            "Sales & Marketing",
            "Human Resources",
            "Science & Biotech",
            "Diversity Opportunities",
            "Information Technology",
            "Transportation",
            "Internships & College",
            "General Business",
            "General Labor",
            "Pharmaceutical",
            "Automotive",
            "Government",
            "Professional Services",
            "Banking",
            "Grocery",
            "Purchasing",
            "Procurement",
            "Biotech",
            "Health Care",
            "Quality Control",
            "Broadcast",
            "Journalism",
            "Hotel",
            "Real Estate",
            "Business Development",
            "Human Resources",
            "Research",
            "Construction",
            "Information Technology",
            "Restaurant",
            "Food Service",
            "Consultant",
            "Installation",
            "Repair",
            "Retail",
            "Customer Service",
            "Insurance",
            "Sales",
            "Design",
            "Inventory",
            "Science",
            "Distribution"});
            this.comboBox_job.Location = new System.Drawing.Point(277, 72);
            this.comboBox_job.Name = "comboBox_job";
            this.comboBox_job.Size = new System.Drawing.Size(198, 24);
            this.comboBox_job.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox_job);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.family_members);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.income_anually);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.listBox_poverty);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(567, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 250);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Self Description";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Final Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 512);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "EID Enrollment Form 3/3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.family_members)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown family_members;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox income_anually;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_post_graduation;
        private System.Windows.Forms.ComboBox comboBox_graduation;
        private System.Windows.Forms.ComboBox comboBox_high_school;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBox_poverty;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_job;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}