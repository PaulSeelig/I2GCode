using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_I2G.Contures;
using GUI_I2G;
using Emgu.CV;
using System.Windows.Forms.Design;
using GUI_I2G.Dummys;

namespace GUI_I2G.GCodeclasses
{
    public class GCodeGenerator : IGCCommandlib
    {
        //private static Parameter? parameter { get; set; } //this might be stupid but hey not the hardest fix

        /// <summary>
        /// Generates GCode.string[]  with a given List<Contour[]>
        /// </summary>
        /// <param name="ContourImage"></param>++
        /// <returns></returns>
        public  static GCode GenerateGCode(Image? ContourImage, Parameter p)
        {
            Contour[] contours = Contour.ContourExtractor(ContourImage);
            GCode gcode = new() { AllContours = D_CreateContours.CreateListOfContourArrays() }; //Contour.ContourGroup(contours) }; // If we find errors/not working GCode, we can analyse the origin of it and change specific parts of it; here;
            List<string> GLinesList = Start(); //List and not array, because ContourImage.Length != GLineslist so the resulting Array.Length is unknown till the process finished,... also the code is easier to handle with the List.
           
            foreach (Contour[] CGroup in gcode.AllContours) // all ContourGroups are gone through
            {
                GLinesList.Add(MoveTo(CGroup[0].StartPoint));
                GeneratePerRound(ref GLinesList, CGroup, p);
            }
            GLinesList.Add(End());
            gcode.GCodeLines = GLinesList.ToArray();
            return gcode;
        }
        




        public static void GeneratePerRound(ref List<string> GLinesList, Contour[] CGroup, Parameter parameter, double currentMillDepth = 0.0 )
        {
            double startDepth = currentMillDepth;
            double wantedDepth = currentMillDepth + parameter.CutDepthPerRound;

            for (int j = 0; j < CGroup.Length; j++)// jede einzelne zusammenhängende Contourgroup wird contour für Contour durchgegangen
            {

                if (currentMillDepth + CGroup[j].Length * parameter.DDFactor < parameter.CuttingDepth)
                {
                    currentMillDepth += CGroup[j].Length * parameter.DDFactor;
                    CGroup[j].EndDepth = currentMillDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                }
                else if (currentMillDepth != parameter.CutDepthPerRound)
                {
                    currentMillDepth = parameter.CutDepthPerRound;
                    CGroup[j].EndDepth = currentMillDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                    if (!Contour.IsClosed(CGroup)) // if IsOpen() because !
                    {
                        for (int k = j; k >= 0; k--)
                        {
                            GLinesList.Add(CutPath(CGroup[k].Reversed()));
                        }
                        for (int k = 0; k <= j; k++)
                        {
                            GLinesList.Add(MoveTo(CGroup[k].EndPoint));
                        }
                    }
                }
                else
                {
                    CGroup[j].EndDepth = currentMillDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                }
            }


            if (currentMillDepth <= parameter.CuttingDepth + 1) // the Function should just repeat, if the overall progress is unfinished
            {
                if (currentMillDepth == wantedDepth || Contour.IsClosed(CGroup)) // The currentMillDepth should not be increased, if a open ContourGroup Length is too short for the wantedDepth to be reached
                {
                    if (currentMillDepth + parameter.CutDepthPerRound <= parameter.CuttingDepth + 1)
                    {
                        currentMillDepth += parameter.CutDepthPerRound;
                    }
                    else
                        currentMillDepth = parameter.CuttingDepth;
                }
                if (Contour.IsClosed(CGroup))
                {
                    GeneratePerRound(ref GLinesList, CGroup,parameter, currentMillDepth);
                }
                else
                    GeneratePerRound(ref GLinesList, Contour.ArrayReversed(CGroup),parameter, currentMillDepth);
            }

        }
    }
}
