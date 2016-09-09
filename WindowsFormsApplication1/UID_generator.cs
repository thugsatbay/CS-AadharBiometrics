using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    static class UID_generator
    {
        public static String generate_uid(String gender,String poverty)
        {
                //---FORMAT---
                //The ID will be a 16 digit Number. 
                //First 1 will be I
                //Next 3 will indicate <State> 
                //Next 3 will indicate <District/City>
                //Next digit will classify sexuality (M/F) 
                //Next digit will indicate people below & above poverty line (B/A)
                //The last 7 digits indicate unique id given to Indian citizens
                //------------
            
            //GET The name of State and city where this module of UID is run
            String state = Properties.Settings.Default.State;
            String city = Properties.Settings.Default.City;
            
            //Identify Gender Character
            if (gender == "0")
            {
                gender = "M";
            }
            else
            {
                gender = "F";
            }

            String id = "I";
            
            //State and City codes
            id += Properties.Settings.Default.State.Substring(0, 3).ToUpper();
            id += Properties.Settings.Default.City.Substring(0, 3).ToUpper();
            
            //TEST CODE
            //id += "STTCTY";
            
            id += gender;
            id += poverty[0].ToString();
            
            //Unique Digit through XML file
            Decimal temp=++Properties.Settings.Default.uid;
            Properties.Settings.Default.Save();
            int temp0 = (int)temp;
            int x = 0;

            //Find Number of characters in the uniqe digit
            while (temp0 != 0)
            {
                ++x;
                temp0 /= 10;
            }

            //TEST CASE
            //MessageBox.Show(x.ToString()+","+temp.ToString());
            
            //Add number of zeroes to unique digit to make UID 16 digit number
            String zeros = "";
            for (int i = 0; i < 7 - x; ++i)
            {
                zeros += "0";
            }
            id += zeros + ((int)temp).ToString();
            
            //TEST CASE
            //MessageBox.Show(id);

            return id;
        }
    }
}
