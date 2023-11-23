using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_I2G.Contures;

namespace GUI_I2G.GCodeclasses
{
    internal class GCodeGenerator : IGCCommandlib
    {
        public  static GCode GenerateGCode(Contour[] ContourImage)
        {
            GCode gcode = new() { AllContours = Contour.ContourGroup(ContourImage) }; // If we find errors/not working GCode, we can analyse the origin of it and change specific parts of it; here;
            List<string> GLinesList = new() { Start()}; //List and not array, because ContourImage.Length != GLineslist so the resulting Array.Length is unknown till the process finished,... also the code is easier to handle with the List.
           
            foreach (Contour[] CGroup in gcode.AllContours)
            {
                GLinesList.Add(MoveTo(CGroup[0].StartPoint));
                foreach (Contour contour in CGroup)
                {
                    if (contour != null && ContourImage.Length > 0)
                    {
                        GLinesList.Add(CutPath(contour));
                    }
                }
                if (CGroup[0].StartPoint == CGroup[^1].EndPoint)
                {
                    GLinesList.Add(CutPath(CGroup[0]));
                } 
                else
                {
                    GLinesList.Add(MoveTo(CGroup[0].EndPoint));
                    GLinesList.Add(CutPath(CGroup[0].Reversed()));
                }
            }
            GLinesList.Add(End());
            gcode.GCodeLines = GLinesList.ToArray();
            return gcode;

        }
    }
}
