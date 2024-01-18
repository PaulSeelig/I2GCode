﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using GUI_I2G.Contures;

namespace GUI_I2G
{
    public class Tool
    {
        public Tool(string name, double tooldepth, double diameter = 10) { Name = name; ToolDepth = tooldepth; Diameter = diameter;}
        public double ToolDepth { get; set; } = 25;// how far can the tool dive (I do mean cut) into the material
        public double Diameter {  get; set; }
        public string Name { get; set; }
    }
    public class Parameter
    {
        public static string Pfad { get => Directory.CreateDirectory(Environment.CurrentDirectory.ToString() + "\\Projects").FullName; }

        public Tool Tool1{ get; set; } 
        public Tool? Tool2 { get; set; } 
        public Tool? Tool3 { get; set; }

        // public Tool CurrentTool { get => SaveCurrentTool; set => SaveCurrentTool = value ?? Tool1; }

        public Tool? CurrentTool { get; set; } = new Tool("T1", 10);

        public double AddPosX { get; set; }
        public double AddPosY { get; set; }

        public double ScaleFactor {  get; set; }


        //public double ToolDepth => CurrentTool.ToolDepth;
        //public double ToolDiameter => CurrentTool.Diameter;

        /// <summary>
        /// Customising how deep the cuts will be in mm
        /// </summary>
        public double SaveCuttingDepth { get; set; }//less or equal? or do we leave room?

        public double CuttingDepth { get => SaveCuttingDepth; set => SaveCuttingDepth = value < MaterialDepth ? value : Allert(); }

        public double Allert() 
        {
            //MessageBox message 
            return MaterialDepth;
        }
        //public double SaveCutDepthPerRound { get; set; }
        /// <summary>
        /// is actually unnecessary if (toolDepth >= CuttingDepth), how ever if not, it is set by the function SetCutDepthPerRound(), 
        /// so it distributes the workload equally to each neccessary round
        /// </summary>
        public double CutDepthPerRound {  get
            {
                if (CuttingDepth <= CurrentTool.ToolDepth)
                    return CuttingDepth;
                else
                {
                    Rounds = (int)Math.Ceiling(CuttingDepth / CurrentTool.ToolDepth); // a == rounds the Tool needs anyway, e.g: tool == 30mm & cutdepth == 100mm,.. would need 4 rounds, if not distributed, it would make the first 3 round with 30mm and the last with 10mm
                    return (CuttingDepth / Rounds);    // but if we distribute the Cutperdepth equally each round it'll make 25mm in depth, .. now that I'm ready,.. I'm lagging if this is even better for the tool? I was really sure at the beginning
                }                                           // I guess it is better for the whole maschine, but worse for the tool
            }
        }

        public int Rounds {  get; set; } // honestly not sure yet, if I'll use this       

        public double MaterialDepth => Eckpunkt[2];
        public double[] Eckpunkt { get; set; } = new double[3];

        public double TableWidth { get; set; }
       
        //public static double TableHeight { get; set;}

        public double TableLength { get; set; }

        /// <summary>
        /// x mill-down mm per 1 Distance mm.
        /// e.g the tool can go 6mm on the z achsis down, on a distance of 10mm on the xy-plane
        /// It is mandatory to know, which angle is supported, while the milling tool dives into the material!
        /// </summary>
        public double DDFactor {  get; set; } = 0.05; //idk the correct value, so for now I imamgine it to be 6 mm down per 10 mm in Distance

        public static void SetScaleFactor(Contour[] pArrArray, ref Parameter p)
        {
            double pArrayXLength = pArrArray[1].EndPoint.X - pArrArray[0].StartPoint.X;
            double pArrayYLength = pArrArray[1].EndPoint.Y - pArrArray[0].StartPoint.Y;
            double scaleFactorX = p.Eckpunkt[0] / pArrayXLength;
            double scaleFactorY = p.Eckpunkt[1] / pArrayYLength;
            p.ScaleFactor = scaleFactorX <= scaleFactorY ? scaleFactorX : scaleFactorY;
            p.AddPosX = ((p.Eckpunkt[0] - p.ScaleFactor * pArrayXLength) * 0.5) - pArrArray[0].StartPoint.X;
            p.AddPosY = ((p.Eckpunkt[1] - p.ScaleFactor * pArrayYLength) * 0.5) - pArrArray[0].StartPoint.Y;
        }
        /// <summary>
        /// sets the required values for the GCode, any additional values either have a default or can be set individually
        /// </summary>
        public Parameter(double tWidth, double tLength, double[] WorkpieceCorners, double cutDepth = 20, double toolDepth = 4) 
        {
            TableWidth = tWidth;
            TableLength = tLength;
            Eckpunkt = WorkpieceCorners; //if failed maybe i need .ToArray<Point>()
            Tool1 = new("Tool1",toolDepth, 5);
            CuttingDepth = cutDepth;
            CurrentTool = Tool1;
        }
        public Parameter()
        {
            //TableWidth = 300;
            //TableLength = 400;
            //Eckpunkt = new[] { new(200), new(200), new(-200), new(200, -200) };
            //Tool1 = new("Tool1", 30, 20);
            //CuttingDepth = 50;
            //CurrentTool = Tool1;
        }
    }
}
