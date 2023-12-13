using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
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
        public Tool Tool2 { get; set; } 
        public Tool Tool3 { get; set; }

        public Tool CurrentTool { get; set; } 


        //public double ToolDepth => CurrentTool.ToolDepth;
        //public double ToolDiameter => CurrentTool.Diameter;

        /// <summary>
        /// Customising how deep the cuts will be in mm
        /// </summary>
        public double CuttingDepth { get => CuttingDepth; set => value = value < MaterialDepth ? value : 0;} //less or equal? or do we leave room?

        /// <summary>
        /// is actually unnecessary if (toolDepth >= CuttingDepth), how ever if not, it is set by the function SetCutDepthPerRound(), 
        /// so it distributes the workload equally to each neccessary round
        /// </summary>
        public double CutDepthPerRound {  get => CutDepthPerRound; private set=> SetCutDepthPerRoun(); }

        public int Rounds {  get; private set; } // honestly not sure yet, if I'll use this

        public void SetCutDepthPerRoun()
        {
            if(CuttingDepth <= CurrentTool.ToolDepth)
                CutDepthPerRound = CuttingDepth;
            else 
            {
                Rounds = (int) Math.Ceiling(CuttingDepth/CurrentTool.ToolDepth); // a == rounds the Tool needs anyway, e.g: tool == 30mm & cutdepth == 100mm,.. would need 4 rounds, if not distributed, it would make the first 3 round with 30mm and the last with 10mm
                CutDepthPerRound = CuttingDepth / Rounds;    // but if we distribute the Cutperdepth equally each round it'll make 25mm in depth, .. now that I'm ready,.. I'm lagging if this is even better for the tool? I was really sure at the beginning
            }                                           // I guess it is better for the whole maschine, but worse to the tool
        }

        public double MaterialDepth { get; set; } = 10;
        public double[]? Eckpunkte { get; private set; }

        public double TableWidth { get; set; }
       
        //public static double TableHeight { get; set;}

        public double TableLength { get; set; }

        /// <summary>
        /// x mile down mm per 1 Distance mm.
        /// It is mandatory to know, which angle is supported, while the miling tool deeps into the material!
        /// </summary>
        public double DDFactor {  get; set; } = 0.6; //idk the correct value, so for now I imamgine it to be 6 mm down per 10 mm in Distance

        /// <summary>
        /// sets the required values for the GCode, any additional values either have a default or can be set individually
        /// </summary>
        public Parameter(double tWidth, double tLength,ref double[] WorkpieceCorners, double cutDepth, double toolDepth1 =4 , double tooldiameter = 3, string toolName1 = "Tool1") 
        {
            TableWidth = tWidth;
            TableLength = tLength;
            Eckpunkte = WorkpieceCorners;
            Tool1 = new(toolName1,toolDepth1, tooldiameter);
            CuttingDepth = cutDepth;
        }
    }
}
