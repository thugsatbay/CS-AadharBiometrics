

using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace SourceAFIS.FingerPrint
{
    /// <summary>
    /// Summary description for CFinger.
    /// </summary>

    public class MyFingerprint
    {
        //used for image
        //for digital persona with kit
        //public int FP_IMAGE_WIDTH = 500;
        //public int FP_IMAGE_HEIGHT = 500;
        //for verifinger with kit  
        public int FP_IMAGE_WIDTH = 323;
        public int FP_IMAGE_HEIGHT = 352;
        //Used by template
        //be carefull the size of the array must always be 1 larger than a number divisable by 4
        public int FP_TEMPLATE_MAX_SIZE = 601;
        //used for matching
        //the max distance between to points when comparing two points to count as a match
        public int FP_MATCH_POINT_DISTANCE_MOVEMENT = 10;
        //the max rotation to use when comparint two points to count as a match
        public int FP_MATCH_POINT_ROTATION_MOVEMENT = 10;//10;
        //a percentage
        public int FP_MATCH_THRESHOLD = 55;
        //finger print classifications
        //Wirbel class
        public const int FP_CLASS_WHORL = 1;
        //lasso class
        public const int FP_CLASS_LEFT_LOOP = 2;
        public const int FP_CLASS_RIGHT_LOOP = 3;
        public const int FP_CLASS_ARCH = 4;
        public const int FP_CLASS_ARCH_TENTED = 5;
        //fingerprint template values
        private const int FP_TEMPLATE_SIZE = 0;
        private const int FP_TEMPLATE_ORIGIN_X = 1;
        private const int FP_TEMPLATE_ORIGIN_Y = 2;
        private const int FP_TEMPLATE_FEATURE_SIZE = 6;
        private const int FP_TEMPLATE_SEARCH_RADIUS = 1;
        //fingerprint origin values 
        //private int FP_ORIGIN_SEARCH_RADIUS = 5;
        //holds skeletinized image
        public byte[,] P = new byte[500, 500];

        public MyFingerprint()
        {
        }

        public MyFingerprint(int width, int height)
        {
            FP_IMAGE_WIDTH = width;
            FP_IMAGE_HEIGHT = height;
            P = new byte[width, height];
        }

        public MyFingerprint(int width, int height, int MatchPointDistanceMovement, int MatchPointRotationMovment, int MatchThreshold)
        {

            FP_IMAGE_WIDTH = width;
            FP_IMAGE_HEIGHT = height;
            FP_MATCH_POINT_DISTANCE_MOVEMENT = MatchPointDistanceMovement;
            FP_MATCH_POINT_ROTATION_MOVEMENT = MatchPointRotationMovment;
            FP_MATCH_THRESHOLD = MatchThreshold;
        }

        public void setFingerPrintImage(Bitmap m_image)
        {
            try
            {
                for (int i = 0; i <= FP_IMAGE_WIDTH - 1; i++)
                {
                    for (int j = 0; j <= FP_IMAGE_HEIGHT - 1; j++)
                    {
                        if ((m_image.GetPixel(i, j).B <= 127) && (m_image.GetPixel(i, j).R <= 127) && (m_image.GetPixel(i, j).G <= 127))
                        {
                            P[i, j] = 1;
                        }
                        else
                        {
                            P[i, j] = 0;
                        }

                    }
                }
                //set edges to 0
                for (int i = 0; i <= FP_IMAGE_WIDTH - 1; i++)
                {
                    P[i, 0] = 0;
                    P[i, FP_IMAGE_HEIGHT - 1] = 0;
                }
                for (int j = 0; j <= FP_IMAGE_HEIGHT - 1; j++)
                {
                    P[0, j] = 0;
                    P[FP_IMAGE_WIDTH - 1, j] = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Bitmap getFingerPrintImage()
        {
            Bitmap imageBuffer = new Bitmap(FP_IMAGE_WIDTH, FP_IMAGE_HEIGHT);
            for (int i = 0; i <= FP_IMAGE_WIDTH - 1; i++)
            {
                for (int j = 0; j <= FP_IMAGE_HEIGHT - 1; j++)
                {
                    if (P[i, j] == 1)
                    {
                        imageBuffer.SetPixel(i, j, Color.Blue);
                    }
                    else
                    {
                        imageBuffer.SetPixel(i, j, Color.White);
                    }
                }
            }
            return imageBuffer;
        }

        public Bitmap getFingerPrintImageDetail()
        {
            //set finger print image
            Bitmap imageBuffer = new Bitmap(FP_IMAGE_WIDTH, FP_IMAGE_HEIGHT);
            for (int i = 0; i <= FP_IMAGE_WIDTH - 1; i++)
            {
                for (int j = 0; j <= FP_IMAGE_HEIGHT - 1; j++)
                {
                    if (P[i, j] == 1)
                        imageBuffer.SetPixel(i, j, Color.Blue);
                    else
                        imageBuffer.SetPixel(i, j, Color.White);
                }
            }

            //get features
            double[] m_arr = this.getFingerPrintTemplate();
            //	int linelength = 5;
            //draw points
            Pen penBlue = new Pen(Color.Blue, 1);
            Pen penRed = new Pen(Color.Red, 1);
            Pen penGreen = new Pen(Color.Green, 1);
            Pen penGray = new Pen(Color.Gray, 1);
            //Graphics gf = Graphics.FromImage(Image.FromHbitmap(m_ImageBuffer.GetHbitmap() ));
            Graphics gf = Graphics.FromImage(imageBuffer);
            gf.CompositingMode = CompositingMode.SourceOver;

            for (int i = 7; i <= m_arr[0] - 1; i = i + 6)
            {
                if (m_arr[i + 4] > 1)
                {
                    gf.DrawRectangle(penRed, (int)m_arr[i] + (int)m_arr[1] - 3, (int)m_arr[i + 1] + (int)m_arr[2] - 2, 5, 5);
                }
                else if (m_arr[i + 4] == 1)
                {
                    gf.DrawEllipse(penGreen, (int)m_arr[i] + (int)m_arr[1] - 3, (int)m_arr[i + 1] + (int)m_arr[2] - 2, 5, 5);
                }


            }//end for
            //draws the origin
            gf.DrawLine(penGray, (int)m_arr[1] - 5, (int)m_arr[2], (int)m_arr[1] + 5, (int)m_arr[2]);
            gf.DrawLine(penGray, (int)m_arr[1], (int)m_arr[2] - 5, (int)m_arr[1], (int)m_arr[2] + 5);
            return imageBuffer;
        }//end getFingerPrintImageDetail()

        public void ThinningHilditch()
        {
            int change = 1;
            bool mbool = true;
            while (change != 0)
            {
                change = 0;
                for (int i = 2; i <= FP_IMAGE_WIDTH - 2; i++)
                {
                    for (int j = 2; j <= FP_IMAGE_HEIGHT - 2; j++)
                    {
                        if (P[i, j] == 1)
                        {
                            short c = 0;
                            //count surrounding 1
                            //a) Make sure pixel 1, has 2 to 6 (inclusive) neighbors
                            if (P[i, j + 1] == 1) { c++; }
                            if (P[i + 1, j + 1] == 1) { c++; }
                            if (P[i + 1, j] == 1) { c++; }
                            if (P[i + 1, j - 1] == 1) { c++; }
                            if (P[i, j - 1] == 1) { c++; }
                            if (P[i - 1, j - 1] == 1) { c++; }
                            if (P[i - 1, j] == 1) { c++; }
                            if (P[i - 1, j + 1] == 1) { c++; }

                            if ((c >= 2) && (c <= 6))
                            {
                                c = 0;
                                //b) starting from 2, go clockwise until 9, and count the
                                //'   number of 0 to 1 transitions.  This should be equal to 1.
                                if ((P[i - 1, j + 1] == 0) && (P[i, j + 1] == 1)) { c++; }
                                if ((P[i, j + 1] == 0) && (P[i + 1, j + 1] == 1)) { c++; }
                                if ((P[i + 1, j + 1] == 0) && (P[i + 1, j] == 1)) { c++; }
                                if ((P[i + 1, j] == 0) && (P[i + 1, j - 1] == 1)) { c++; }
                                if ((P[i + 1, j - 1] == 0) && (P[i, j - 1] == 1)) { c++; }
                                if ((P[i, j - 1] == 0) && (P[i - 1, j - 1] == 1)) { c++; }
                                if ((P[i - 1, j - 1] == 0) && (P[i - 1, j] == 1)) { c++; }
                                if ((P[i - 1, j] == 0) && (P[i - 1, j + 1] == 1)) { c++; }

                                if (c == 1)
                                {
                                    c = 0;
                                    if (mbool == true)
                                    {
                                        //c) 2*4*6=0  (ie either 2,4 ,or 6 is off)
                                        if ((P[i, j + 1] * P[i + 1, j] * P[i + 1, j - 1]) == 0)
                                        {
                                            //d) 4*6*8=0
                                            if ((P[i + 1, j] * P[i + 1, j - 1] * P[i - 1, j]) == 0)
                                            {
                                                P[i, j] = 0;
                                                change++;
                                            }
                                        }
                                        mbool = false;
                                    }
                                    else
                                    {
                                        //c) 2*6*8=0
                                        if ((P[i, j + 1] * P[i + 1, j - 1] * P[i - 1, j]) == 0)
                                        {
                                            //d) 2*4*8=0
                                            if ((P[i, j + 1] * P[i + 1, j] * P[i - 1, j]) == 0)
                                            {
                                                P[i, j] = 0;
                                                change++;
                                            }
                                        }
                                        mbool = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }//End While
        }//end ThinningHilditchAlgorithim

        public void ThinningHitAndMiss()
        {
            /*
            *    basicly you take all patterns
            *    111    X1X
            *    X1X or x11 so on
            *    000    xxX
            *    if these conditions are true then set the middle 1 to 0
            */
            int c = 1;
            while (c != 0)
            {
                c = 0;
                for (int i = 1; i <= FP_IMAGE_WIDTH - 1; i++)
                {
                    for (int j = 1; j <= FP_IMAGE_HEIGHT - 1; j++)
                    {
                        if ((P[i, j] == 1) && (i != 0) && (j != FP_IMAGE_HEIGHT - 1) && (j != 0) && (i != FP_IMAGE_WIDTH - 1))
                        {
                            if ((P[i - 1, j - 1] == 1) && (P[i, j - 1] == 1) && (P[i + 1, j - 1] == 1) && (P[i - 1, j + 1] == 0) && (P[i, j + 1] == 0) && (P[i + 1, j + 1] == 0))
                            {
                                P[i, j] = 0; //'1 on bottom
                                c++;
                            }
                            else if ((P[i - 1, j + 1] == 1) && (P[i, j + 1] == 1) && (P[i + 1, j + 1] == 1) && (P[i - 1, j - 1] == 0) && (P[i, j - 1] == 0) && (P[i + 1, j - 1] == 0))
                            {
                                P[i, j] = 0; //'1 on top
                                c++;
                            }
                            else if ((P[i - 1, j] == 1) && (P[i - 1, j - 1] == 1) && (P[i - 1, j + 1] == 1) && (P[i + 1, j] == 0) && (P[i + 1, j + 1] == 0) && (P[i + 1, j - 1] == 0))
                            {
                                P[i, j] = 0; //'1 on left
                                c++;
                            }
                            else if ((P[i + 1, j] == 1) && (P[i + 1, j - 1] == 1) && (P[i + 1, j + 1] == 1) && (P[i - 1, j] == 0) && (P[i - 1, j + 1] == 0) && (P[i - 1, j - 1] == 0))
                            {
                                P[i, j] = 0; //'1 on right
                                c++;
                            }
                            else if ((P[i - 1, j] == 1) && (P[i, j - 1] == 1) && (P[i, j + 1] == 0) && (P[i + 1, j + 1] == 0) && (P[i + 1, j] == 0))
                            {
                                //x00
                                //110
                                //x1x
                                P[i, j] = 0; //'1 on Bottem Left
                                c++;
                            }
                            else if ((P[i - 1, j] == 1) && (P[i, j + 1] == 1) && (P[i, j - 1] == 0) && (P[i + 1, j - 1] == 0) && (P[i + 1, j] == 0))
                            {
                                //x1x
                                //110
                                //x00
                                P[i, j] = 0; //'1 on Top Left
                                c++;
                            }
                            else if ((P[i, j + 1] == 1) && (P[i + 1, j] == 1) && (P[i - 1, j] == 0) && (P[i - 1, j - 1] == 0) && (P[i, j - 1] == 0))
                            {
                                //x1x
                                //011
                                //00x
                                P[i, j] = 0; //'1 on Top Right
                                c++;
                            }
                            else if ((P[i, j - 1] == 1) && (P[i + 1, j] == 1) && (P[i - 1, j] == 0) && (P[i - 1, j + 1] == 0) && (P[i, j + 1] == 0))
                            {
                                //00x
                                //011
                                //x1x
                                P[i, j] = 0; //'1 on Bottom Right
                                c++;
                            }
                        }
                    }//Next
                }//Next
            }//End While
        }//end ThinningHitAndMiss

        public void ChaneLinkAlgorithm(int ChainLinkDistance)
        {
            //short count1;
            for (int i = 1; i <= FP_IMAGE_WIDTH - 1; i++)
            {
                for (int j = 1; j <= FP_IMAGE_HEIGHT - 1; j++)
                {
                    //change second condition when changeing direction
                    //Horizontal
                    if ((P[i, j] == 1) && (i != FP_IMAGE_WIDTH - 1) && (i != 0) && (j != FP_IMAGE_HEIGHT - 1) && (j != 0))
                    {
                        if (P[i + 1, j] == 0)
                        {
                            short countX = 0;
                            //count Horizontal Hole
                            while (((i + countX) <= FP_IMAGE_WIDTH - 1) && (countX <= ChainLinkDistance))
                            {
                                if (((i + countX + 1) <= FP_IMAGE_WIDTH - 1) && ((countX + 1) <= ChainLinkDistance))
                                {
                                    if (P[i + countX + 1, j] == 0)
                                    {
                                        countX++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                            //Fill hole if it is wide enough
                            if ((countX != 0) && ((countX + 1) <= ChainLinkDistance))
                            {
                                for (int temp = 0; temp <= countX; temp++)
                                {
                                    P[i + temp, j] = 1;
                                }
                            }
                        }
                    }
                    //change second condition when changeing direction
                    //Vertical
                    if ((P[i, j] == 1) && (i != FP_IMAGE_WIDTH - 1) && (i != 0) && (j != FP_IMAGE_HEIGHT - 1) && (j != 0))
                    {
                        if (P[i, j + 1] == 0)
                        {
                            short countY = 0;
                            //count Horizontal Hole
                            while (((j + countY) <= FP_IMAGE_HEIGHT - 1) && (countY <= ChainLinkDistance))
                            {
                                if (((j + countY + 1) <= FP_IMAGE_HEIGHT - 1) && ((countY + 1) <= ChainLinkDistance))
                                {
                                    //i pu this here bacause it kept on crashing
                                    if (P[i, j + countY + 1] == 0)
                                    {
                                        countY++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                            //Fill hole if it is wide enough
                            if ((countY != 0) && (countY + 1 <= ChainLinkDistance))
                            {
                                for (int temp = 0; temp <= countY; temp++)
                                {
                                    P[i, j + temp] = 1;
                                }
                            }
                        }
                    }
                    //change second condition when changeing direction
                    //Vertical Horizontal
                    if ((P[i, j] == 1) && (i != FP_IMAGE_WIDTH - 1) && (i != 0) && (j != FP_IMAGE_HEIGHT - 1) && (j != 0))
                    {
                        if (P[i + 1, j + 1] == 0)
                        {
                            short countYX = 0; //1
                            //count Horizontal Hole
                            while ((j + countYX <= FP_IMAGE_HEIGHT - 1) && (i + countYX <= FP_IMAGE_WIDTH - 1) && (countYX <= ChainLinkDistance))
                            {
                                if (((j + countYX + 1) <= FP_IMAGE_HEIGHT - 1) && ((i + countYX + 1) <= FP_IMAGE_WIDTH - 1) && ((countYX + 1) <= ChainLinkDistance))
                                    if (P[i + countYX + 1, j + countYX + 1] == 0)
                                    {
                                        countYX++;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                else
                                {
                                    break;
                                }
                            }
                            //Fill hole if it is wide enough
                            if ((countYX != 0) && (countYX + 1 <= ChainLinkDistance))
                            {
                                for (int temp = 0; temp <= countYX; temp++)
                                {
                                    P[i + temp, j + temp] = 1;
                                }
                            }
                        }
                    }
                }
            }
        }


        /// 
        /// ################################
        /// #     Extract Origin           #
        /// ################################
        /// 
        
        private Point getFingerPrintOrigin()
        {
            Point m_Point = new Point();
            double gradcur = 0;
            double gradprev = 0;
            double gradchangebig = 0;
            double gradchange = 0;

            double graddistancebig = 0;
            double graddistance = 0;

            double prevx = 0;
            double prevy = 0;

            for (int j = 50; j <= FP_IMAGE_HEIGHT - 50; j++)
            {
                for (int i = 50; i <= FP_IMAGE_WIDTH - 50; i++)
                {
                    if (P[i, j] == 1)
                    {
                        //count surrounding pixels
                        int tc = 0;
                        int x1 = 0;
                        int y1 = 0;
                        int x2 = 0;
                        int y2 = 0;
                        //find surrounding 1s
                        for (int m = -1 * FP_TEMPLATE_SEARCH_RADIUS; m <= FP_TEMPLATE_SEARCH_RADIUS; m++)
                        {
                            for (int n = -1 * FP_TEMPLATE_SEARCH_RADIUS; n <= FP_TEMPLATE_SEARCH_RADIUS; n++)
                            {
                                if ((m == FP_TEMPLATE_SEARCH_RADIUS) || (m == (-1) * FP_TEMPLATE_SEARCH_RADIUS) || (n == FP_TEMPLATE_SEARCH_RADIUS) || (n == (-1) * FP_TEMPLATE_SEARCH_RADIUS))
                                {
                                    if (P[i + m, j + n] == 1)
                                    {
                                        tc++;
                                        if (tc == 1)
                                        {
                                            x1 = i + m;
                                            y1 = j + n;
                                        }
                                        if (tc == 2)
                                        {
                                            x2 = i + m;
                                            y2 = j + n;
                                        }
                                    }//end if
                                }//end if
                            }//end for n
                        } //end for m         
                        //does all the hard work of finding the greatest change in gradient
                        if (tc == 2)
                        {
                            if ((x2 - x1) > 0)
                            {
                                gradcur = (y2 - y1) / (x2 - x1);
                                //check to see gradient change by at least 270 degrees
                                if ((gradcur > 0) && (gradprev < 0))
                                {
                                    gradchange = Math.Abs(gradcur) + Math.Abs(gradprev);
                                    graddistance = Math.Abs(i) - Math.Abs(prevx);
                                    if (gradchangebig < gradchange)
                                    {
                                        if (graddistancebig < graddistance)
                                        {
                                            gradchangebig = gradchange;
                                            graddistancebig = graddistance;
                                            m_Point.X = i;//FP_ORIGIN_X =i;
                                            m_Point.Y = j;//FP_ORIGIN_Y =j;
                                        }
                                    }
                                    break;
                                }
                                //reset varibles for new checks
                                gradprev = gradcur;
                                gradcur = 0;
                                prevx = i;
                                prevy = j;
                            }//(x2-x1)>0
                        }//end if tc==2
                    }//end if P[x,y]==1
                }//end for i
            }//end for j
            //  JOptionPane.showMessageDialog (null,Integer.toString(FP_ORIGIN_X)+";"+Integer.toString(FP_ORIGIN_Y),"getFingerPrintOrigin",JOptionPane.PLAIN_MESSAGE);
            return m_Point;
        }

        private int getFingerPrintClassification()
        {
            Point m_Point = this.getFingerPrintOrigin();
            double gradcur = 0;

            //stores total gradient of corners
            double gradlt = 0;
            double gradrt = 0;
            double gradlb = 0;
            double gradrb = 0;

            //counts total of each corner gradient
            double cgradlt = 0;
            double cgradrt = 0;
            double cgradlb = 0;
            double cgradrb = 0;

            for (int j = 50; j <= FP_IMAGE_HEIGHT - 50; j++)
            {
                for (int i = 50; i <= FP_IMAGE_WIDTH - 50; i++)
                {
                    if (P[i, j] == 1)
                    {
                        //count surrounding pixels
                        int tc = 0;
                        int x1 = 0;
                        int y1 = 0;
                        int x2 = 0;
                        int y2 = 0;
                        //find surrounding 1s
                        for (int m = -1 * FP_TEMPLATE_SEARCH_RADIUS; m <= FP_TEMPLATE_SEARCH_RADIUS; m++)
                        {
                            for (int n = -1 * FP_TEMPLATE_SEARCH_RADIUS; n <= FP_TEMPLATE_SEARCH_RADIUS; n++)
                            {
                                if ((m == FP_TEMPLATE_SEARCH_RADIUS) || (m == (-1) * FP_TEMPLATE_SEARCH_RADIUS) || (n == FP_TEMPLATE_SEARCH_RADIUS) || (n == (-1) * FP_TEMPLATE_SEARCH_RADIUS))
                                {
                                    if (P[i + m, j + n] == 1)
                                    {
                                        tc++;
                                        if (tc == 1)
                                        {
                                            x1 = i + m;
                                            y1 = j + n;
                                        }
                                        if (tc == 2)
                                        {
                                            x2 = i + m;
                                            y2 = j + n;
                                        }
                                    }//end if
                                }//end if
                            }//end for n
                        } //end for m         
                        //does all the hard work of finding the greatest change in gradient
                        if (tc == 2)
                        {
                            if ((x2 - x1) > 0)
                            {
                                gradcur = (y2 - y1) / (x2 - x1);
                                //check to see gradient change by at least 270 degrees
                                if ((x2 < m_Point.X) && (y2 > m_Point.Y))
                                {
                                    gradlt = gradlt + gradcur;
                                    gradlt++;
                                }
                                else if ((x2 > m_Point.X) && (y2 > m_Point.Y))
                                {
                                    gradrt = gradrt + gradcur;
                                    gradrt++;
                                }
                                else if ((x2 < m_Point.X) && (y2 < m_Point.Y))
                                {
                                    gradlb = gradlb + gradcur;
                                    gradlb++;
                                }
                                else if ((x2 > m_Point.X) && (y2 < m_Point.Y))
                                {
                                    gradrb = gradrb + gradcur;
                                    gradrb++;
                                }

                            }//(x2-x1)>0
                        }//end if tc==2
                    }//end if P[x,y]==1
                }//end for i
            }//end for j
            //get average gradient for 4 corners
            gradlb = gradlb / cgradlb;
            gradrb = gradrb / cgradrb;
            gradlt = gradlt / cgradlt;
            gradrt = gradrt / cgradrt;
            //determin classification according to gradient
            //needs work
            if ((gradlt > 0) && (gradrt > 0) && (gradlb > 0) && (gradrb > 0))
            {
                return FP_CLASS_WHORL;
            }
            else if ((gradlt > 0) && (gradrt > 0) && (gradlb > 0) && (gradrb > 0))
            {
                return FP_CLASS_LEFT_LOOP;
            }
            else if ((gradlt > 0) && (gradrt > 0) && (gradlb > 0) && (gradrb > 0))
            {
                return FP_CLASS_RIGHT_LOOP;
            }
            else if ((gradlt > 0) && (gradrt > 0) && (gradlb > 0) && (gradrb > 0))
            {
                return FP_CLASS_ARCH;
            }
            else if ((gradlt > 0) && (gradrt > 0) && (gradlb > 0) && (gradrb > 0))
            {
                return FP_CLASS_ARCH_TENTED;
            }
            else
            {
                return 1;
            }
            //  JOptionPane.showMessageDialog (null,Integer.toString(FP_ORIGIN_X)+";"+Integer.toString(FP_ORIGIN_Y),"getFingerPrintOrigin",JOptionPane.PLAIN_MESSAGE);
        }

        
        
        /// 
        /// ################################
        /// #     Extract Template         #
        /// ################################
        



    

        public double[] getFingerPrintTemplate()
        {
            Double[,] A=new double[FP_IMAGE_WIDTH,FP_IMAGE_HEIGHT];
            Double[,] B=new double[FP_IMAGE_WIDTH, FP_IMAGE_HEIGHT];
            for (int i = 0; i < FP_IMAGE_WIDTH; i++)
            {
                for (int j = 0; j < FP_IMAGE_HEIGHT; j++)
                {
                    //B[i,j]=A[i][j]*
                }
            }

            // final int SEARCH_RADIUS = 1;   
            double x = 0;
            double y = 0;
            double r = 0;
            double d = 0;
            double[] m_arr = new double[FP_TEMPLATE_MAX_SIZE];

            this.ThinningHilditch();
            this.ThinningHitAndMiss();
            this.ThinningHilditch();
            this.ThinningHitAndMiss();

            Point origin = this.getFingerPrintOrigin();
            m_arr[1] = origin.X;
            m_arr[2] = origin.Y;

            int c = 7;
            int previ = 0;
            int prevj = 0;

            bool first = true;

            //start from 5 units in to avoid detection of edges of finger print and out of bound exceptions
            for (int j = 5; j <= FP_IMAGE_HEIGHT - 6; j++)
            {
                first = true;
                for (int i = 5; i <= FP_IMAGE_WIDTH - 6; i++)
                {
                    if ((c < FP_TEMPLATE_MAX_SIZE) && (P[i, j] == 1) && (i != FP_IMAGE_WIDTH - 1) && (i != 0) && (j != FP_IMAGE_HEIGHT - 1) && (j != 0))
                    {
                        /*  
                        *   Must not capture first and last feature because those are the edges of the finger print
                        *   and will provide no value to the template.
                        */
                        if (first == true)
                        {
                            first = false;
                            //cheak to see if previos item in array was aslo end
                            if ((c > 7) && ((m_arr[c - 6] + origin.X) == previ) && ((m_arr[c - 5] + origin.Y) == prevj))
                            {
                                //delete previos featue
                                m_arr[c--] = 0;
                                m_arr[c--] = 0;
                                m_arr[c--] = 0;
                                m_arr[c--] = 0;
                                m_arr[c--] = 0;
                                m_arr[c--] = 0;
                            }
                        }
                        else
                        {
                            int tc = 0;
                            for (int m = -1 * FP_TEMPLATE_SEARCH_RADIUS; m <= FP_TEMPLATE_SEARCH_RADIUS; m++)
                            {
                                for (int n = -1 * FP_TEMPLATE_SEARCH_RADIUS; n <= FP_TEMPLATE_SEARCH_RADIUS; n++)
                                {
                                    if ((m == FP_TEMPLATE_SEARCH_RADIUS) || (m == (-1) * FP_TEMPLATE_SEARCH_RADIUS) || (n == FP_TEMPLATE_SEARCH_RADIUS) || (n == (-1) * FP_TEMPLATE_SEARCH_RADIUS))
                                    {
                                        if (P[i + m, j + n] == 1)
                                        {
                                            tc++;
                                        }//end if
                                    }//end if
                                }//end for n
                            } //end for m         

                            //calculate parameters necesary for template
                            if ((tc == 1) || (tc == 3))
                            {
                                x = i - origin.X;
                                y = j - origin.Y;
                                r = Math.Sqrt(x * x + y * y);
                                if ((x > 0) && (y > 0))
                                {
                                    d = Math.Atan(y / x);
                                }
                                else if ((x < 0) && (y > 0))
                                {
                                    d = Math.Atan(y / x) - Math.PI;
                                }
                                else if ((x < 0) && (y < 0))
                                {
                                    d = Math.PI + Math.Atan(y / x);
                                }
                                else if ((x > 0) && (y < 0))
                                {
                                    d = 2 * Math.PI + Math.Atan(y / x);
                                }
                            }

                            //check to see if point already been captured
                            bool foundx = false;
                            bool foundy = false;
                            for (int m = 7; m <= c; m = m + 6)
                            {
                                if (m_arr[m + 4] == 3)
                                {
                                    if (Math.Abs(Math.Abs((int)m_arr[m]) - Math.Abs(x)) < 4)
                                    {
                                        foundx = true;
                                    }
                                    if (Math.Abs(Math.Abs((int)m_arr[m + 1]) - Math.Abs(y)) < 4)
                                    {
                                        foundy = true;
                                    }
                                }//end if
                            }//end for m


                            //1 surrounding 1s
                            if ((tc == 1) && (c <= FP_TEMPLATE_MAX_SIZE - 6) && (x != 0) && (y != 0) && ((foundx == false) || (foundy == false)))
                            {

                                if (P[i - 1, j + 1] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 135;
                                }
                                else if (P[i, j + 1] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 90;
                                }
                                else if (P[i + 1, j + 1] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 45;
                                }
                                else if (P[i + 1, j] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 0;
                                }
                                else if (P[i + 1, j - 1] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 315;
                                }
                                else if (P[i, j - 1] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 270;
                                }
                                else if (P[i - 1, j - 1] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 225;
                                }
                                else if (P[i - 1, j] == 1)
                                {
                                    m_arr[c++] = x;
                                    m_arr[c++] = y;
                                    m_arr[c++] = r;
                                    m_arr[c++] = d;
                                    m_arr[c++] = 1;
                                    m_arr[c++] = 180;
                                }
                            }
                            else if ((tc >= 3) && (c <= FP_TEMPLATE_MAX_SIZE - 6) && (x != 0) && (y != 0) && ((foundx == false) || (foundy == false)))
                            {
                                //3 surrounding 1s
                                m_arr[c++] = x;
                                m_arr[c++] = y;
                                m_arr[c++] = r;
                                m_arr[c++] = d;
                                m_arr[c++] = 3;
                                m_arr[c++] = 0;
                            }//if tc>=3 
                        }//end if first
                        previ = i;
                        prevj = j;

                        //306;269
                        if (((i - origin.X) >= (306 - 4)) && ((i - origin.Y) >= (269 - 4)))
                        {
                            if (((i - origin.X) <= (306 + 4)) && ((i - origin.Y) <= (269 + 4)))
                            {
                                //JOptionPane.showMessageDialog (null,Double.toString(c)+";"+Integer.toString(i)+";"+Integer.toString(j),"My Point",JOptionPane.PLAIN_MESSAGE);
                            }
                        }

                    }//end if that checks for p[x,y]=1
                }//end for
            }//end for
            //put total size of points collected at 0 in array
            m_arr[0] = c;
            return m_arr;
        }//end getFingerPrintTemplate()

        public String ConvertFingerPrintTemplateDoubleToString(double[] finger)
        {
            String temp = "";
            for (int i = 0; i <= finger.Length - 1; i++)
            {
                temp = temp + finger[i].ToString() + ";";
            }
            return temp;
        }

        public double[] ConvertFingerPrintTemplateStringToDouble(String finger)
        {
            double[] m_finger = new double[FP_TEMPLATE_MAX_SIZE];
            int c = -1;
            String m_double = "";
            String temp = "";
            for (int i = 0; i <= finger.Length - 1; i++)
            {
                char[] tempch = finger.ToCharArray();
                temp = temp[i].ToString();
                if (temp == ";")
                {
                    m_finger[c++] = Double.Parse(m_double);
                }
                else
                {
                    m_double = m_double + temp;
                }
            }
            return m_finger;
        }

        /// <summery>
        /// ################################
        /// #         Matching             #
        /// ################################
        
        //cross-corelation algorithm
        public int Match(double[] finger1, double[] finger2, int threshold, bool fastmatch)
        {
            //compare matrix with all shifted matrixes
            //must do later. must get the size of the array
            // JOptionPane.showMessageDialog (null,Double.toString(finger1[0])+";"+Double.toString(finger1[1])+";"+Double.toString(finger2[3]),"Match",JOptionPane.PLAIN_MESSAGE);
            double matchcount = 0;
            double matchcounttotal = (finger1[0] - 6) / 6;
            double bestmatch = 0;
            double radian = Math.PI / 180;
            bool foundpoint;

            for (int k = -1 * FP_MATCH_POINT_ROTATION_MOVEMENT; k <= FP_MATCH_POINT_ROTATION_MOVEMENT; k++)
            {
                for (int i = 7; i <= finger1[0] - 5; i = i + 6)
                {
                    foundpoint = false;
                    for (int j = 7; j <= finger2[0] - 5; j = j + 6)
                    {
                        if (foundpoint == false)
                        {
                            //compare two points account for rotational , verticle and horizontal shift
                            int resx = 0;
                            int resy = 0;
                            double x1 = 0;
                            double y1 = 0;
                            double x2 = 0;
                            double y2 = 0;
                            double r = 0;
                            double d = 0;
                            //find nessasary parameters

                            r = finger2[j + 2];
                            d = finger2[j + 3];
                            x2 = finger1[i];
                            y2 = finger1[i + 1];
                            //do angle shift for x
                            x1 = r * Math.Cos(d + (k * radian));
                            resx = Math.Abs((int)x2 + (int)(-1 * x1));
                            //do angle shift for y         
                            y1 = r * Math.Sin(d + (k * radian));
                            resy = Math.Abs((int)y2 + (int)(-1 * y1));

                            //cheak shift matchs count as match
                            if ((FP_MATCH_POINT_DISTANCE_MOVEMENT > resx) && (FP_MATCH_POINT_DISTANCE_MOVEMENT > resy))
                            {

                                //cheak if same kind of feature
                                if (finger1[i + 4] == finger2[j + 4])
                                {
                                    //cheak if feature in  same direction
                                    //  if(((finger1[i+5]-finger2[j+5])<=46)||((finger1[i+5]==0)&&(finger2[j+5]==315))||((finger1[i+5]==0)&&(finger2[j+5]==45)))
                                    //  {
                                    matchcount++;
                                    foundpoint = true;
                                    //break;
                                    //  }//cheak if feature in  same direction
                                } //cheak if same kind of feature

                            }//end if
                        }//if found
                    }//end for j
                }//end for i
                //see if we have a match

                if ((((matchcount / matchcounttotal) * 100) >= threshold) && (fastmatch == true))
                {
                    //found match
                    return (int)((matchcount / matchcounttotal) * 100);
                }
                else
                {
                    //not found match     
                    if (matchcount > bestmatch)
                    {
                        bestmatch = matchcount;
                    }
                    //reset match counter to 0
                    matchcount = 0;
                } //end if

            }//end for k
            return (int)((bestmatch / matchcounttotal) * 100);
        }//end Match



    }//end class
}//end namespace