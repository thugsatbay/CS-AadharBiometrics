using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
     class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //TEST CASES Fingerprint Verification
            //Biometric.Finger();

            //TEST CASES UID Generator
            //UID_generator.generate_uid("1", "A");

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Read(1, "IUTTDEHMA0000046"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UID());
            
            //TEST CASE to store Biometrics
            //Application.Run(new Form4("IUTTDEHMA0000066"));
            
        }
    }
}
