using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SourceAFIS.Simple; // import namespace SourceAFIS.Simple

namespace WindowsFormsApplication1
{
    class Biometric_Verify
    {
        // Inherit from Fingerprint in order to add Filename field
        [Serializable]
        class MyFingerprint : Fingerprint
        {
            public string Filename;
        }

        // Inherit from Person in order to add Name field
        [Serializable]
        class MyPerson : Person
        {
            public string Name;
        }

        // Initialize path to images
        static readonly string ImagePath = Path.Combine(Path.Combine("..", ".."), "images");

        // Shared AfisEngine instance (cannot be shared between different threads though)
        static AfisEngine Afis;

        // Take fingerprint image file and create Person object from the image
        static MyPerson Enroll(string filename, string name)
        {

            // Initialize empty fingerprint object and set properties
            MyFingerprint fp = new MyFingerprint();
            fp.Filename = filename;
            // Load image from the file
            BitmapImage image = new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));
            fp.AsBitmapSource = image;
            // Above update of fp.AsBitmapSource initialized also raw image in fp.Image
            // Check raw image dimensions, Y axis is first, X axis is second
            Console.WriteLine(" Image size = {0} x {1} (width x height)", fp.Image.GetLength(1), fp.Image.GetLength(0));

            // Initialize empty person object and set its properties
            MyPerson person = new MyPerson();
            person.Name = name;
            // Add fingerprint to the person
            person.Fingerprints.Add(fp);

            // Execute extraction in order to initialize fp.Template
            Afis.Extract(person);

            return person;
        }

        public static bool Finger(String candidate_fingerprint,String candidate_name,String probe_fingerprint,String probe_name)
        {

            // Initialize SourceAFIS
            Afis = new AfisEngine();

            // Enroll some people
            List<MyPerson> database = new List<MyPerson>();
            database.Add(Enroll(candidate_fingerprint, candidate_name));

            // Save the database to disk and load it back, just to try out the serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = File.Open("database.dat", FileMode.Create))
                formatter.Serialize(stream, database);

            //Reloading Database
            using (FileStream stream = File.OpenRead("database.dat"))
                database = (List<MyPerson>)formatter.Deserialize(stream);

            // Enroll visitor with unknown identity
            MyPerson probe = Enroll(probe_fingerprint, probe_name);

            // Look up the probe using Threshold = 10
            Afis.Threshold = 60;
            
            //TEST CASE
            //MessageBox.Show(String.Format("Identifying {0} in database of {1} persons...", probe.Name, database.Count));
            
            MyPerson match = Afis.Identify(probe, database).FirstOrDefault() as MyPerson;
            // Null result means that there is no candidate with similarity score above threshold
            if (match == null)
            {
                //TEST CASE
                //MessageBox.Show("No matching person found.");
                return false;
            }
            // Print out any non-null result
            //TEST CASE
            //MessageBox.Show(String.Format("Probe {0} matches registered person {1}", probe.Name, match.Name));

            // Compute similarity score
            float score = Afis.Verify(probe, match);

            //TEST CASE
            //MessageBox.Show(String.Format("Similarity score between {0} and {1} = {2}", probe.Name, match.Name, score));
            
            return true;
        }
    }
}
