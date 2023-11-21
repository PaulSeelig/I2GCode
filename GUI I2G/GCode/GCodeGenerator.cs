using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_I2G.Contures;

namespace GUI_I2G.GCode
{
    internal class GCodeGenerator : IGCCommandlib
    {
        
        public  static GCode GenerateGCode(Contour[] ContourImage)
        {
            GCode gcode = new GCode { AllContours = Contour.ContourGroup(ContourImage) }; // If we find errors/not working GCode, we can analyse the origin of it and change specific parts of it; here;

            List<string> GLinesList = new List<string> { Start(ContourImage[0].StartPoint)}; //List and not array, because ContourImage.Length != GLineslist so the resulting Array.Length is unknown till the process finished,... also the code is easier to handle with the List.
            foreach (Contour[] CGroup in gcode.AllContours)
            {
                foreach (Contour contour in CGroup)
                {
                    if (contour != null && ContourImage.Length > 0)
                    {
                        if (contour is Curve)
                        {
                            GLinesList.Add(MoveInCurve(contour));
                        }
                        if (contour is Vector)
                        {
                            GLinesList.Add(MoveInLine(contour));
                        }
                    }
                }
                GLinesList.Add(MoveTo());
            }
            GLinesList.Add(End(ContourImage[ContourImage.Length-1].EndPoint));
            gcode.GCodeLines = GLinesList.ToArray();
            return gcode;

        }
    }
}
