namespace WindowsFormsApplication1
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_uid = new System.Windows.Forms.TextBox();
            this.pictureBox_fingerprint = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox_photo = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxFeatureExtractors = new System.Windows.Forms.ComboBox();
            this.cbxFeatureDisplayers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fingerprint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(242, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verification Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter EID";
            // 
            // textBox_uid
            // 
            this.textBox_uid.Location = new System.Drawing.Point(127, 68);
            this.textBox_uid.Name = "textBox_uid";
            this.textBox_uid.Size = new System.Drawing.Size(177, 23);
            this.textBox_uid.TabIndex = 2;
            // 
            // pictureBox_fingerprint
            // 
            this.pictureBox_fingerprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_fingerprint.Image = global::WindowsFormsApplication1.Properties.Resources.fingerprint;
            this.pictureBox_fingerprint.Location = new System.Drawing.Point(36, 148);
            this.pictureBox_fingerprint.Name = "pictureBox_fingerprint";
            this.pictureBox_fingerprint.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_fingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_fingerprint.TabIndex = 3;
            this.pictureBox_fingerprint.TabStop = false;
            this.pictureBox_fingerprint.Click += new System.EventHandler(this.pictureBox_fingerprint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(143, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "FingerPrint";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(378, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox_photo
            // 
            this.pictureBox_photo.Image = global::WindowsFormsApplication1.Properties.Resources.default_facebook_avatar_male;
            this.pictureBox_photo.Location = new System.Drawing.Point(533, 148);
            this.pictureBox_photo.Name = "pictureBox_photo";
            this.pictureBox_photo.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_photo.TabIndex = 6;
            this.pictureBox_photo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(648, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Photo ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(462, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(390, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Enter EID and Fingerprint To verify and load your PhotoID";
            // 
            // cbxFeatureExtractors
            // 
            this.cbxFeatureExtractors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFeatureExtractors.FormattingEnabled = true;
            this.cbxFeatureExtractors.Location = new System.Drawing.Point(590, 63);
            this.cbxFeatureExtractors.Name = "cbxFeatureExtractors";
            this.cbxFeatureExtractors.Size = new System.Drawing.Size(188, 24);
            this.cbxFeatureExtractors.Sorted = true;
            this.cbxFeatureExtractors.TabIndex = 13;
            this.cbxFeatureExtractors.SelectedValueChanged += new System.EventHandler(this.cbxFeatureExtractors_SelectedValueChanged);
            // 
            // cbxFeatureDisplayers
            // 
            this.cbxFeatureDisplayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFeatureDisplayers.FormattingEnabled = true;
            this.cbxFeatureDisplayers.Location = new System.Drawing.Point(342, 262);
            this.cbxFeatureDisplayers.Name = "cbxFeatureDisplayers";
            this.cbxFeatureDisplayers.Size = new System.Drawing.Size(188, 24);
            this.cbxFeatureDisplayers.Sorted = true;
            this.cbxFeatureDisplayers.TabIndex = 12;
            this.cbxFeatureDisplayers.SelectedValueChanged += new System.EventHandler(this.cbxFeatureTypes_SelectedValueChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 462);
            this.Controls.Add(this.cbxFeatureExtractors);
            this.Controls.Add(this.cbxFeatureDisplayers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox_photo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox_fingerprint);
            this.Controls.Add(this.textBox_uid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form6";
            this.Text = "Verification Application Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form6_FormClosed);
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fingerprint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_uid;
        private System.Windows.Forms.PictureBox pictureBox_fingerprint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox_photo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxFeatureExtractors;
        private System.Windows.Forms.ComboBox cbxFeatureDisplayers;
    }
}