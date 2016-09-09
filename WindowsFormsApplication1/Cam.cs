using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class Cam : Form
    {
        String save;
        public Cam()
        {
            InitializeComponent();
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
        }

        public Cam(String s):this()
        {
            save = s;
        }

        WebCam webcam;
        private void mainWinForm_Load(object sender, EventArgs e)
        {
            
        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            webcam.Start();
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private void bntContinue_Click(object sender, EventArgs e)
        {
            webcam.Continue();
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            imgCapture.Image = imgVideo.Image;
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            imgCapture.Image.Save("C:\\photo_database\\"+save+".png");
            this.Close();
        }

        private void Cam_FormClosed(object sender, FormClosedEventArgs e)
        {
            webcam.Stop();
        }

        private void Cam_Load(object sender, EventArgs e)
        {
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 450), ((height / 2) - 250));
        }
    }
}
