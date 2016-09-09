namespace WindowsFormsApplication1
{
    partial class Form0
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_state = new System.Windows.Forms.ComboBox();
            this.textBox_city = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_register_begin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "State / Capital";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "City";
            // 
            // comboBox_state
            // 
            this.comboBox_state.DropDownHeight = 150;
            this.comboBox_state.FormattingEnabled = true;
            this.comboBox_state.IntegralHeight = false;
            this.comboBox_state.Items.AddRange(new object[] {
            "Andhra Pradesh - Hyderabad",
            "Arunachal Pradesh - Itanagar",
            "Assam - Dispur",
            "Bihar - Patna",
            "Chhatisgarh - Raipur",
            "Goa - Panaji",
            "Gujarat - Gandhinagar",
            "Haryana - Chandigarh",
            "Himachal Pradesh - Shimla",
            "Jammu & Kashmir - Srinagar",
            "Jharkhand - Ranchi",
            "Karnataka - Bangalore",
            "Kerala - Thiruvananthapuram",
            "Madhya Pradesh - Bhopal",
            "Maharashtra - Mumbai",
            "Manipur - Imphal",
            "Meghalaya - Shillong",
            "Mizoram - Aizawl",
            "Nagaland - Kohima",
            "Orissa - Bhubaneswar",
            "Punjab - Chandigarh",
            "Rajasthan - Jaipur",
            "Sikkim - Gangtok",
            "Tamil Nadu - Chennai",
            "Tripura - Agartala",
            "Uttar Pradesh - Lucknow",
            "Uttaranchal - Dehradun",
            "West Bengal - Kolkata",
            "Andaman & Nicobar Islands - Port Blair",
            "Chandigarh - Chandigarh",
            "Dadra & Nagar Haveli - Silvasa",
            "Daman & Diu - Daman",
            "Delhi - Delhi",
            "Lakshadweep - Kavaratti",
            "Pondicherry - Pondicherry"});
            this.comboBox_state.Location = new System.Drawing.Point(127, 94);
            this.comboBox_state.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_state.Name = "comboBox_state";
            this.comboBox_state.Size = new System.Drawing.Size(325, 24);
            this.comboBox_state.TabIndex = 2;
            // 
            // textBox_city
            // 
            this.textBox_city.Location = new System.Drawing.Point(213, 166);
            this.textBox_city.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_city.Name = "textBox_city";
            this.textBox_city.Size = new System.Drawing.Size(173, 23);
            this.textBox_city.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(150, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "STATE AND CITY";
            // 
            // button_register_begin
            // 
            this.button_register_begin.Location = new System.Drawing.Point(132, 242);
            this.button_register_begin.Name = "button_register_begin";
            this.button_register_begin.Size = new System.Drawing.Size(196, 23);
            this.button_register_begin.TabIndex = 5;
            this.button_register_begin.Text = "Proceed To Registeration";
            this.button_register_begin.UseVisualStyleBackColor = true;
            this.button_register_begin.Click += new System.EventHandler(this.button_register_begin_Click);
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 304);
            this.ControlBox = false;
            this.Controls.Add(this.button_register_begin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_city);
            this.Controls.Add(this.comboBox_state);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form0";
            this.Text = "EID Form Select Location / Begin ";
            this.Load += new System.EventHandler(this.Form0_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_state;
        private System.Windows.Forms.TextBox textBox_city;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_register_begin;
    }
}