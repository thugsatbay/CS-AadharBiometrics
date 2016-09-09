using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using PatternRecognition.FingerprintRecognition.Core;

namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        String fingerprint_link,photo_link;
        SqlConnection abc;

        readonly Dictionary<Type, Type> featTypeByDisplay = new Dictionary<Type, Type>();
        readonly Dictionary<Type, List<Type>> extractorsByFeatType = new Dictionary<Type, List<Type>>();
        private IFeatureDisplay currFeatDisplay;
        private IFeatureExtractor currExtractor;
        private Bitmap img = null;
        public Form6()
        {
            InitializeComponent();
            fingerprint_link = "";
            photo_link = "";

            try
            {
                string sql = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\brick\\Documents\\Visual Studio 2010\\Projects\\WindowsFormsApplication1\\Biometrics.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";
                //Establsih SQL Connection
                abc = new SqlConnection(sql);
                abc.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show("");
                   
            }

            cbxFeatureExtractors.Size = new System.Drawing.Size(0, 0);

            #region minutiae display
            Assembly thisAss = Assembly.GetExecutingAssembly();
            string dir = Path.GetDirectoryName(thisAss.Location);
            foreach (string fileName in Directory.GetFiles(dir))
            {
                string fileExtension = Path.GetExtension(fileName);
                if (fileExtension == ".dll")
                {
                    try
                    {
                        Assembly currAssembly = Assembly.LoadFile(fileName);
                        foreach (Type type in currAssembly.GetExportedTypes())
                        {
                            var currInterface = type.GetInterface("IFeatureDisplay`1");
                            if (type.IsClass && !type.IsAbstract && currInterface != null)
                            {
                                var featType = currInterface.GetGenericArguments()[0];
                                featTypeByDisplay.Add(type, featType);

                            }

                            currInterface = type.GetInterface("IFeatureExtractor`1");
                            if (type.IsClass && !type.IsAbstract && currInterface != null)
                            {
                                var featType = currInterface.GetGenericArguments()[0];
                                if (!extractorsByFeatType.ContainsKey(featType))
                                    extractorsByFeatType.Add(featType, new List<Type>());
                                extractorsByFeatType[featType].Add(type);
                            }
                        }

                    }
                    catch { }

                }
            }


            #endregion
        }

        private void display_minutiae_features()
        {
            if (img == null)
            {
                return;
            }
            else
            {
                pictureBox_fingerprint.Image = img.Clone() as Bitmap;
                Graphics g = Graphics.FromImage(pictureBox_fingerprint.Image);
                try
                {
                    var features = currExtractor.ExtractFeatures(img);
                    currFeatDisplay.Show(features, g);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Displaying error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            cbxFeatureDisplayers.DataSource = new List<Type>(featTypeByDisplay.Keys);
            cbxFeatureDisplayers.DisplayMember = "Name";
            cbxFeatureDisplayers.ValueMember = "Name";

            textBox_uid.MaxLength = 16;

            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 440), ((height / 2) - 250)); 
        }

        private void pictureBox_fingerprint_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            //To load Image of the person
            dlg.InitialDirectory = Properties.Settings.Default.Initial_fingerprint_location_dialog;
            dlg.Title = "Open Image";
            dlg.Filter = "tiff files (*.tif)|*.tif|jpg files (*.jpg)|*.jpg|jpeg files(*.jpeg)|*.jpeg|png files(*.png)|*.png|bmp files (*.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fingerprint_link = dlg.FileName;
                img = ImageLoader.LoadImage(dlg.FileName);
                pictureBox_fingerprint.Image = img;
            }
            dlg.Dispose();
            display_minutiae_features();
        }

        private void cbxFeatureTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            object selectedValue = ((ComboBox)sender).SelectedItem;
            if (selectedValue != null)
            {
                Type selectedType = (Type)selectedValue;
                currFeatDisplay = Activator.CreateInstance(selectedType) as IFeatureDisplay;
                Type currFeatType = featTypeByDisplay[selectedType];
                cbxFeatureExtractors.DataSource = extractorsByFeatType[currFeatType];
                cbxFeatureExtractors.DisplayMember = "Name";
                cbxFeatureExtractors.ValueMember = "Name";
            }
            display_minutiae_features();

        }

        private void cbxFeatureExtractors_SelectedValueChanged(object sender, EventArgs e)
        {
            object selectedValue = ((ComboBox)sender).SelectedItem;
            if (selectedValue != null)
            {
                Type selectedType = (Type)selectedValue;
                currExtractor = Activator.CreateInstance(selectedType) as IFeatureExtractor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox_uid.TextLength == 16)&&(fingerprint_link!=""))
            {
                
                SqlCommand comm = new SqlCommand();
                comm.Connection = abc;
                String query = String.Format("SELECT * FROM Form4 WHERE uid='{0}'", textBox_uid.Text);
                comm.CommandText = query;
                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    String temp_name = "TEST";
                    photo_link = dr["photo_path"].ToString().Trim();
                    bool val = Biometric_Verify.Finger(fingerprint_link, temp_name, dr["fingerprint_path"].ToString(), "Probe XYZ " + textBox_uid.Text);
                    dr.Close();

                    SqlCommand comm0 = new SqlCommand();
                    comm0.Connection = abc;
                    query = String.Format("SELECT first_name,last_name FROM Form1 WHERE uid='{0}'", textBox_uid.Text);
                    comm0.CommandText = query;
                    SqlDataReader dr0 = comm0.ExecuteReader();
                    if (dr0.Read())
                    {
                        //MessageBox.Show("yoyo");
                        temp_name = dr0["first_name"].ToString().Trim() + " " + dr0["last_name"].ToString().Trim();
                    }

                    if (val)
                    {
                        MessageBox.Show(val.ToString() + " Identification of " + temp_name, "Successful Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pictureBox_photo.Image = Image.FromFile(photo_link);
                    }
                    else
                    {
                        MessageBox.Show(val.ToString() + " Identification", "Unsuccessful Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_uid.Text = "";
                        pictureBox_fingerprint.Image = Properties.Resources.fingerprint;
                    }
                }
                else
                {
                    MessageBox.Show("UID Incorrect", "Unsuccessful Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_uid.Text = "";
                    pictureBox_fingerprint.Image = Properties.Resources.fingerprint;
                }
                
            }
            else
            {
                MessageBox.Show("UID Too short Or No Test FingerPrint Loaded", "Unsuccessful Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_uid.Text = "";
                pictureBox_fingerprint.Image = Properties.Resources.fingerprint;
            }
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Code Having Debug Problems
            //UID ud = new UID();
            //this.Hide();
            //ud.ShowDialog();
            //this.Close();
        }
    }
}
