using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G
{
    public class Tool
    {
        public Tool(string name, double tooldepth, double diameter) { Name = name; ToolDepth = tooldepth; Diameter = diameter;}
        public double ToolDepth { get; set; }// how far can the tool dive (I do mean cut) into the material
        public double Diameter {  get; set; }
        public string Name { get; set; }
    }
    public class Parameter
    {
        public Tool Tool1{ get; set; } 
        public Tool? Tool2 { get; set; } 
        public Tool? Tool3 { get; set; }

        public Tool CurrentTool { get => SaveCurrentTool; set => SaveCurrentTool = value ?? Tool1; }

        private Tool? SaveCurrentTool { get; set; }


        //public double ToolDepth => CurrentTool.ToolDepth;
        //public double ToolDiameter => CurrentTool.Diameter;

        /// <summary>
        /// Customising how deep the cuts will be in mm
        /// </summary>
        private double SaveCuttingDepth { get; set; }//less or equal? or do we leave room?

        public double CuttingDepth { get => SaveCuttingDepth; set => SaveCuttingDepth = value < MaterialDepth ? value : Allert(); }

        public double Allert() 
        {
            //MessageBox message 
            return MaterialDepth;
        }
        public double SaveCutDepthPerRound { get; set; }
        /// <summary>
        /// is actually unnecessary if (toolDepth >= CuttingDepth), how ever if not, it is set by the function SetCutDepthPerRound(), 
        /// so it distributes the workload equally to each neccessary round
        /// </summary>
        public double CutDepthPerRound {  get => SaveCutDepthPerRound; private set
            {
                if (CuttingDepth <= CurrentTool.ToolDepth)
                    SaveCutDepthPerRound = CuttingDepth;
                else
                {
                    Rounds = (int)Math.Ceiling(CuttingDepth / CurrentTool.ToolDepth); // a == rounds the Tool needs anyway, e.g: tool == 30mm & cutdepth == 100mm,.. would need 4 rounds, if not distributed, it would make the first 3 round with 30mm and the last with 10mm
                    SaveCutDepthPerRound = CuttingDepth / Rounds;    // but if we distribute the Cutperdepth equally each round it'll make 25mm in depth, .. now that I'm ready,.. I'm lagging if this is even better for the tool? I was really sure at the beginning
                }                                           // I guess it is better for the whole maschine, but worse for the tool
            }
        }

        public int Rounds {  get; private set; } // honestly not sure yet, if I'll use this       

        public double MaterialDepth { get; set; } = 10;
        public Point[] Eckpunkte { get; private set; }

        public double TableWidth { get; set; }
       
        //public static double TableHeight { get; set;}

        public double TableLength { get; set; }

        /// <summary>
        /// x mill-down mm per 1 Distance mm.
        /// e.g the tool can go 6mm on the z achsis down, on a distance of 10mm on the xy-plane
        /// It is mandatory to know, which angle is supported, while the milling tool dives into the material!
        /// </summary>
        public double DDFactor {  get; set; } = 0.6; //idk the correct value, so for now I imamgine it to be 6 mm down per 10 mm in Distance

        /// <summary>
        /// sets the required values for the GCode, any additional values either have a default or can be set individually
        /// </summary>
        public Parameter(double tWidth, double tLength, Point[] WorkpieceCorners, double cutDepth, double toolDepth = 4) 
        {
            TableWidth = tWidth;
            TableLength = tLength;
            Eckpunkte = WorkpieceCorners;
            Tool1 = new("Tool1",toolDepth, 5);
            CuttingDepth = cutDepth;
            CurrentTool = Tool1;
        }
        public Parameter()
        {
            //TableWidth = 300;
            //TableLength = 400;
            //Eckpunkte = new[] { new Point(200, 200), new(-200, 200), new(-200, -200), new(200, -200) };
            //Tool1 = new("Tool1", 30, 20);
            //CuttingDepth = 50;
            //CurrentTool = Tool1;
        }
    }
}
