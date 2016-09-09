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
    public partial class Form4 : Form
    {
        readonly Dictionary<Type, Type> featTypeByDisplay = new Dictionary<Type, Type>();
        readonly Dictionary<Type, List<Type>> extractorsByFeatType = new Dictionary<Type, List<Type>>();
        private IFeatureDisplay currFeatDisplay;
        private IFeatureExtractor currExtractor;
        private Bitmap img = null;

        String Bio_uid;
        String photo_link, fingerprint_link;

        public Form4()
        {
            InitializeComponent();
            photo_link = "";
            fingerprint_link = "";

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

            cbxFeatureExtractors.Size = new System.Drawing.Size(0, 0);

        }
        public Form4(String uid_frm3):this()
        {
            Bio_uid = uid_frm3;
        }

        private void pictureBox_photo_Click(object sender, EventArgs e)
        {
            Cam cm = new Cam(Bio_uid);
            cm.ShowDialog();
            pictureBox_photo.Load("C:\\photo_database\\" + Bio_uid + ".png");
            photo_link = "C:\\photo_database\\" + Bio_uid + ".png";
        }

        private void pictureBox_fingerprint_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //To load Fingerprint of the person
            dlg.InitialDirectory = Properties.Settings.Default.Initial_fingerprint_location_dialog;
            dlg.Title = "Open Image";
            dlg.Filter = "tiff files (*.tif)|*.tif|jpg files (*.jpg)|*.jpg|jpeg files(*.jpeg)|*.jpeg|png files(*.png)|*.png|bmp files (*.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fingerprint_link = dlg.FileName;
                img = ImageLoader.LoadImage(dlg.FileName);
                pictureBox_fingerprint.Image = img;
                // Stores global value of filename
                Properties.Settings.Default.Photo_id = dlg.FileName;
            }
            dlg.Dispose();
            display_minutiae_features();
            
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

        private void Form4_Load(object sender, EventArgs e)
        {


            cbxFeatureDisplayers.DataSource = new List<Type>(featTypeByDisplay.Keys);
            cbxFeatureDisplayers.DisplayMember = "Name";
            cbxFeatureDisplayers.ValueMember = "Name";

            UID_fetched.Text = Bio_uid;
            
            //To Load The Form In The Center Of The Screen
            int width, height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(((width / 2) - 450), ((height / 2) - 250));

            
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
                //MessageBox.Show(cbxFeatureExtractors.SelectedItem.ToString());
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

            if ((fingerprint_link != "") && (photo_link != ""))
            {
                //Database Path
                string sql = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\brick\\Documents\\Visual Studio 2010\\Projects\\WindowsFormsApplication1\\Biometrics.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";
                //Establsih SQL Connection
                SqlConnection abc = new SqlConnection(sql);
                abc.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = abc;
                String query = String.Format("Insert INTO Form4(uid,photo_path,fingerprint_path) values ('{0}','{1}','{2}')", Bio_uid, photo_link, fingerprint_link);
                comm.CommandText = query;
                int x = comm.ExecuteNonQuery();

                //TEST CODE
                //MessageBox.Show(x.ToString());

                abc.Close();
                MessageBox.Show("UID BIometrics Registered Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                UID ud = new UID();
                ud.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Biometrics Information Incomplete", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
