﻿using System;
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
   public static class Biometric
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
            Console.WriteLine("Enrolling {0}...", name);

            // Initialize empty fingerprint object and set properties
            MyFingerprint fp = new MyFingerprint();
            fp.Filename = filename;
            // Load image from the file
            Console.WriteLine(" Loading image from {0}...", filename);
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
            Console.WriteLine(" Extracting template...");
            Afis.Extract(person);
            // Check template size
            Console.WriteLine(" Template size = {0} bytes", fp.Template.Length);

            return person;
        }

       public static void Finger()
        {
         
            // Initialize SourceAFIS
            Afis = new AfisEngine();

            // Enroll some people
            List<MyPerson> database = new List<MyPerson>();
            database.Add(Enroll(Path.Combine(ImagePath, "candidate1.tif"), "Ankit Balyan"));
            database.Add(Enroll(Path.Combine(ImagePath, "candidate2.tif"), "Gurleen Singh"));
            database.Add(Enroll(Path.Combine(ImagePath, "candidate3.tif"), "Kunal Kholia"));

            // Save the database to disk and load it back, just to try out the serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = File.Open("database.dat", FileMode.Create))
                formatter.Serialize(stream, database);
            
           //Reloading Database
            using (FileStream stream = File.OpenRead("database.dat"))
                database = (List<MyPerson>)formatter.Deserialize(stream);
           
            // Enroll visitor with unknown identity
            MyPerson probe = Enroll(Path.Combine(ImagePath, "probe.tif"), "Visitor #12345");

            // Look up the probe using Threshold = 10
            Afis.Threshold = 60;
            MessageBox.Show(String.Format("Identifying {0} in database of {1} persons...", probe.Name, database.Count));
            MyPerson match = Afis.Identify(probe, database).FirstOrDefault() as MyPerson;
            // Null result means that there is no candidate with similarity score above threshold
            if (match == null)
            {
                MessageBox.Show("No matching person found.");
                return;
            }
            // Print out any non-null result
            MessageBox.Show(String.Format("Probe {0} matches registered person {1}", probe.Name, match.Name));

            // Compute similarity score
            float score = Afis.Verify(probe, match);
            MessageBox.Show(String.Format("Similarity score between {0} and {1} = {2:F3}", probe.Name, probe.Name, score));
            
        }
    }
}
