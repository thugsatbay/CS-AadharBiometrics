namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.label4 = new System.Windows.Forms.Label();
            this.two_vehicles_counter = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.two_vehicles_button = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.emergency_contact_phone_number = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.emergency_contact = new System.Windows.Forms.TextBox();
            this.next = new System.Windows.Forms.Button();
            this.permanent_address = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.current_address = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.four_vehicles_counter = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.four_vehicles_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.two_vehicles_counter)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.four_vehicles_counter)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "EID Enrollment Form\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(16, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Number of 2 wheelers owned";
            // 
            // two_vehicles_counter
            // 
            this.two_vehicles_counter.Location = new System.Drawing.Point(240, 15);
            this.two_vehicles_counter.Name = "two_vehicles_counter";
            this.two_vehicles_counter.Size = new System.Drawing.Size(68, 23);
            this.two_vehicles_counter.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.two_vehicles_button);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.two_vehicles_counter);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(360, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 87);
            this.panel1.TabIndex = 4;
            // 
            // two_vehicles_button
            // 
            this.two_vehicles_button.Location = new System.Drawing.Point(127, 46);
            this.two_vehicles_button.Name = "two_vehicles_button";
            this.two_vehicles_button.Size = new System.Drawing.Size(75, 23);
            this.two_vehicles_button.TabIndex = 2;
            this.two_vehicles_button.Text = "OK";
            this.two_vehicles_button.UseVisualStyleBackColor = true;
            this.two_vehicles_button.Click += new System.EventHandler(this.two_vehicles_button_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(506, 99);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(238, 16);
            this.label23.TabIndex = 10;
            this.label23.Text = "Emergency Contact Mobile Number";
            // 
            // emergency_contact_phone_number
            // 
            this.emergency_contact_phone_number.Location = new System.Drawing.Point(758, 96);
            this.emergency_contact_phone_number.Margin = new System.Windows.Forms.Padding(4);
            this.emergency_contact_phone_number.Name = "emergency_contact_phone_number";
            this.emergency_contact_phone_number.Size = new System.Drawing.Size(298, 23);
            this.emergency_contact_phone_number.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 99);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Emergency Contact";
            // 
            // emergency_contact
            // 
            this.emergency_contact.Location = new System.Drawing.Point(193, 96);
            this.emergency_contact.Margin = new System.Windows.Forms.Padding(4);
            this.emergency_contact.Name = "emergency_contact";
            this.emergency_contact.Size = new System.Drawing.Size(298, 23);
            this.emergency_contact.TabIndex = 0;
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(510, 562);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 7;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // permanent_address
            // 
            this.permanent_address.Location = new System.Drawing.Point(307, 233);
            this.permanent_address.Multiline = true;
            this.permanent_address.Name = "permanent_address";
            this.permanent_address.Size = new System.Drawing.Size(546, 37);
            this.permanent_address.TabIndex = 3;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(153, 243);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(135, 16);
            this.label26.TabIndex = 12;
            this.label26.Text = "Permanent Address";
            // 
            // current_address
            // 
            this.current_address.Location = new System.Drawing.Point(307, 167);
            this.current_address.Multiline = true;
            this.current_address.Name = "current_address";
            this.current_address.Size = new System.Drawing.Size(546, 37);
            this.current_address.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(174, 177);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(114, 16);
            this.label24.TabIndex = 11;
            this.label24.Text = "Current Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(36, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Number of cars owned";
            // 
            // four_vehicles_counter
            // 
            this.four_vehicles_counter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.four_vehicles_counter.Location = new System.Drawing.Point(240, 16);
            this.four_vehicles_counter.Name = "four_vehicles_counter";
            this.four_vehicles_counter.Size = new System.Drawing.Size(68, 23);
            this.four_vehicles_counter.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.four_vehicles_button);
            this.panel2.Controls.Add(this.four_vehicles_counter);
            this.panel2.Controls.Add(this.label7);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(360, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 87);
            this.panel2.TabIndex = 5;
            // 
            // four_vehicles_button
            // 
            this.four_vehicles_button.Location = new System.Drawing.Point(127, 48);
            this.four_vehicles_button.Name = "four_vehicles_button";
            this.four_vehicles_button.Size = new System.Drawing.Size(75, 23);
            this.four_vehicles_button.TabIndex = 2;
            this.four_vehicles_button.Text = "OK";
            this.four_vehicles_button.UseVisualStyleBackColor = true;
            this.four_vehicles_button.Click += new System.EventHandler(this.four_vehicles_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(282, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(530, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Click OK to enter license plate numbers, if vehicles owned are 0 leave it.";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 610);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.permanent_address);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.current_address);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.next);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.emergency_contact_phone_number);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.emergency_contact);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1110, 648);
            this.MinimumSize = new System.Drawing.Size(1110, 648);
            this.Name = "Form2";
            this.Text = "EID Enrollment Form 2/3";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.two_vehicles_counter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.four_vehicles_counter)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown two_vehicles_counter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox emergency_contact_phone_number;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox emergency_contact;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.TextBox permanent_address;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox current_address;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button two_vehicles_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown four_vehicles_counter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button four_vehicles_button;
        private System.Windows.Forms.Label label2;
    }
}