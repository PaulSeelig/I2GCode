using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_I2G.Contures;
using GUI_I2G;
using Emgu.CV;
using System.Windows.Forms.Design;

namespace GUI_I2G.GCodeclasses
{
    public class GCodeGenerator : IGCCommandlib
    {

        /// <summary>
        /// Generates GCode.string[]  with a given List<Contour[]>
        /// </summary>
        /// <param name="ContourImage"></param>
        /// <returns></returns>
        public  static GCode GenerateGCode(Contour[] ContourImage)
        {
            GCode gcode = new() { AllContours = Contour.ContourGroup(ContourImage) }; // If we find errors/not working GCode, we can analyse the origin of it and change specific parts of it; here;
            List<string> GLinesList = Start(); //List and not array, because ContourImage.Length != GLineslist so the resulting Array.Length is unknown till the process finished,... also the code is easier to handle with the List.
           
            foreach (Contour[] CGroup in gcode.AllContours) // all ContourGroups are gone through
            {
                GLinesList.Add(MoveTo(CGroup[0].StartPoint));
                GeneratePerRound(in GLinesList, CGroup);
            }
            GLinesList.Add(End());
            gcode.GCodeLines = GLinesList.ToArray();
            return gcode;
        }





        public static void GeneratePerRound(in List<string> GLinesList, Contour[] CGroup, double currentMileDepth = 0.0 )
        {
            double startDepth = currentMileDepth;
            double wantedDepth = currentMileDepth + Parameter.CutDepthPerRound;

            for (int j = 0; j < CGroup.Length; j++)// jede einzelne zusammenhängende Contourgroup wird contour für Contour durchgegangen
            {

                if (currentMileDepth + CGroup[j].Length * Parameter.DDFactor < Parameter.CuttingDepth)
                {
                    currentMileDepth += CGroup[j].Length * Parameter.DDFactor;
                    CGroup[j].EndDepth = currentMileDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                }
                else if (currentMileDepth != Parameter.CutDepthPerRound)
                {
                    currentMileDepth = Parameter.CutDepthPerRound;
                    CGroup[j].EndDepth = currentMileDepth;
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
                    CGroup[j].EndDepth = currentMileDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                }
            }


            if (currentMileDepth <= Parameter.CuttingDepth + 1) // the Function should just repeat, if the overall progress is unfinished
            {
                if (currentMileDepth == wantedDepth || Contour.IsClosed(CGroup)) // The currentMileDepth should not be increased, if a open ContourGroup Length is too short for the wantedDepth to be reached
                {
                    if (currentMileDepth + Parameter.CutDepthPerRound <= Parameter.CuttingDepth + 1)
                    {
                        currentMileDepth += Parameter.CutDepthPerRound;
                    }
                    else
                        currentMileDepth = Parameter.CuttingDepth;
                }
                if (Contour.IsClosed(CGroup))
                {
                    GeneratePerRound(in GLinesList, CGroup, currentMileDepth);
                }
                else
                    GeneratePerRound(in GLinesList, Contour.Arreversed(CGroup), currentMileDepth);
            }

        }
    }
}
