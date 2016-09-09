namespace WindowsFormsApplication1
{
    partial class UID
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UID));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.register = new System.Windows.Forms.Button();
            this.record = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.verify = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 111;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.Color.DodgerBlue;
            this.register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register.FlatAppearance.BorderSize = 5;
            this.register.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.register.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register.ForeColor = System.Drawing.Color.DarkBlue;
            this.register.Location = new System.Drawing.Point(51, 93);
            this.register.Margin = new System.Windows.Forms.Padding(4);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(200, 65);
            this.register.TabIndex = 0;
            this.register.Text = "Register A New EID";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            this.register.MouseEnter += new System.EventHandler(this.register_MouseEnter);
            this.register.MouseLeave += new System.EventHandler(this.register_MouseLeave);
            // 
            // record
            // 
            this.record.BackColor = System.Drawing.Color.DodgerBlue;
            this.record.Cursor = System.Windows.Forms.Cursors.Hand;
            this.record.FlatAppearance.BorderSize = 5;
            this.record.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.record.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.record.ForeColor = System.Drawing.Color.DarkBlue;
            this.record.Location = new System.Drawing.Point(51, 193);
            this.record.Margin = new System.Windows.Forms.Padding(4);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(200, 65);
            this.record.TabIndex = 1;
            this.record.Text = "Records Login Database\r\n";
            this.record.UseVisualStyleBackColor = false;
            this.record.Click += new System.EventHandler(this.record_Click);
            this.record.MouseEnter += new System.EventHandler(this.record_MouseEnter);
            this.record.MouseLeave += new System.EventHandler(this.record_MouseLeave);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // verify
            // 
            this.verify.BackColor = System.Drawing.Color.DodgerBlue;
            this.verify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verify.FlatAppearance.BorderSize = 5;
            this.verify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.verify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.verify.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verify.ForeColor = System.Drawing.Color.DarkBlue;
            this.verify.Location = new System.Drawing.Point(334, 93);
            this.verify.Margin = new System.Windows.Forms.Padding(4);
            this.verify.Name = "verify";
            this.verify.Size = new System.Drawing.Size(200, 65);
            this.verify.TabIndex = 2;
            this.verify.Text = "Verify A EID To Access Account";
            this.verify.UseVisualStyleBackColor = false;
            this.verify.Click += new System.EventHandler(this.verify_Click);
            this.verify.MouseEnter += new System.EventHandler(this.verify_MouseEnter);
            this.verify.MouseLeave += new System.EventHandler(this.verify_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Location = new System.Drawing.Point(334, 193);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 65);
            this.button1.TabIndex = 3;
            this.button1.Text = "User Account Details";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.verify);
            this.Controls.Add(this.record);
            this.Controls.Add(this.register);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UID";
            this.Text = "EID";
            this.Load += new System.EventHandler(this.UID_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Button record;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button verify;
        private System.Windows.Forms.Button button1;
    }
}