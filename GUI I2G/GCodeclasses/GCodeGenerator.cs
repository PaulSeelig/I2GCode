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
using System.Diagnostics;

namespace GUI_I2G.GCodeclasses
{
    public static partial class GCodeGenerator
    {
        //private static Parameter? parameter { get; set; } //this might be stupid but hey not the hardest fix
        private static double CurrentMillDepth {  get; set; }
        /// <summary>
        /// Generates GCode.string[]  with a given List<Contour[]>
        /// </summary>
        /// <param name="ContourImage"></param>++
        /// <returns></returns>
        public  static GCode GenerateGCode(List<Contour[]> ListOfContArrays, Parameter p)
        {
            GCode gcode = new(ListOfContArrays); // If we find errors/not working GCode, we can analyse the origin of it and change specific parts of it; here;
            List<string> GLinesList = Start(); //List and not array, because ContourImage.Length != GLineslist so the resulting Array.Length is unknown till the process finished,... also the code is easier to handle with the List.
            DummyGenerateMaterial(ref GLinesList, p);
            foreach (Contour[] CGroup in gcode.GetAllContours()) // all ContourGroups are gone through
            {
                CurrentMillDepth = 0;
                GLinesList.AddRange(MoveTo(CGroup[0].StartPoint, $"Z{p.MaterialDepth}"));
                GeneratePerRound(ref GLinesList, CGroup, p, p.CutDepthPerRound);
            }
            GLinesList.Add(End());
            gcode.GCodeLines = GLinesList.ToArray();
            return gcode;
        } 
        
        public static void GeneratePerRound(ref List<string> GLinesList, Contour[] CGroup, Parameter parameter, double wantedDepth)
        {        
            for (int j = 0; j < CGroup.Length; j++)// jede einzelne zusammenhängende Contourgroup wird contour für Contour durchgegangen
            {
                if (CurrentMillDepth + CGroup[j].Length * parameter.DDFactor < wantedDepth)
                {
                    CurrentMillDepth += CGroup[j].Length * parameter.DDFactor;
                    CGroup[j].EndDepth =  - CurrentMillDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                }
                else if (CurrentMillDepth != wantedDepth)
                {
                    CurrentMillDepth = wantedDepth;
                    CGroup[j].EndDepth = CurrentMillDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                    if (!Contour.IsClosed(CGroup)) // if IsOpen() because !
                    {
                        for (int k = j; k >= 0; k--)
                        {
                            GLinesList.Add(CutPath(CGroup[k].Reversed()));
                        }
                        for (int k = 0; k <= j; k++)
                        {
                            GLinesList.AddRange(MoveTo(CGroup[k].Reversed().EndPoint, $"Z{CurrentMillDepth}"));
                        }
                    }
                }
                else
                {
                    CGroup[j].EndDepth = wantedDepth;
                    GLinesList.Add(CutPath(CGroup[j]));
                }
            }
            if (CurrentMillDepth < parameter.CuttingDepth) // the Function should just repeat, if the overall progress is unfinished
            {
                if (CurrentMillDepth == wantedDepth || Contour.IsClosed(CGroup)) // The currentMillDepth should not be increased, if a open ContourGroup Length is too short for the wantedDepth to be reached
                {
                    if (wantedDepth + parameter.CutDepthPerRound < parameter.CuttingDepth)
                    {
                        wantedDepth += parameter.CutDepthPerRound;
                    }
                    else
                        wantedDepth = parameter.CuttingDepth;
                }
                if (Contour.IsClosed(CGroup))
                {
                    GeneratePerRound(ref GLinesList, CGroup,parameter,wantedDepth);
                }
                else
                    GeneratePerRound(ref GLinesList, Contour.ArrayReversed(CGroup),parameter,wantedDepth);
            }


        }
        [Conditional("DEBUG")]
        private static void DummyGenerateMaterial(ref List<string> those, Parameter p)
        {
            those.Add("G1");
            List<Line> lines = new()
            {
                new Line(new Point(0, 0), new(0, ((int)p.Eckpunkt[0]))),
                new Line(new Point(0, (int)p.Eckpunkt[0]), new((int)p.Eckpunkt[1], (int)p.Eckpunkt[0])),
                new Line(new Point((int)p.Eckpunkt[1], (int)p.Eckpunkt[0]), new((int)p.Eckpunkt[1], 0)),
                new Line(new((int)p.Eckpunkt[1], 0), new(0, 0))
                            };

            while (p.MaterialDepth > CurrentMillDepth)
            {
                
                foreach (Line item in lines)
                {
                    //CurrentMillDepth = ((CurrentMillDepth + (p.CurrentTool.ToolDepth * 0.025)) < p.MaterialDepth)? (CurrentMillDepth + (p.CurrentTool.ToolDepth * 0.025) ): p.MaterialDepth;
                    CurrentMillDepth += 0.025;
                    item.EndDepth = CurrentMillDepth;
                    those.Add(CutPath(item));
                }
            }
            CurrentMillDepth = 0;
        }
    }

}
