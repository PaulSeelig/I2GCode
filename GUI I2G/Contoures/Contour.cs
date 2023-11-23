﻿using GUI_I2G.GCodeclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    public abstract class Contour//wieso abstract (macht man doch nur wenn man auch abstract Methoden benutzt?(außerdem haben wir das damals schon abgequatscht?))
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Contour Reversed()
        {
            (EndPoint, StartPoint) = (StartPoint, EndPoint); //changes the start and end- point with each other; important for open Contours ContourGroup.Start != ContourGroup.End;
            return this;
        }
        public static Contour[] ContourExtractor(Image image)
        {
            return ContourExtractor();
        }
        public static Contour[] ContourExtractor() //DummyFunktion
        {
            //bloss beispielhaft
            Contour[] result = new Contour[3];
            result[0] = new Vector(new Point(3, 5), new Point(2, -4));
            result[1] = new Curve(new Point(3, 5), new Point(3, 6), 5);
            result[2] = new Vector(new Point(4, 5), new Point(7, 4));

            return result;
        }

        public static List <Contour[]> ContourGroup(Contour[] CList) // The GCodeGenerator has to know, which Contoures in the Array belong together
        {
            return new List <Contour[]>();
        }
        public static void WriteOutContures(Contour[] contures)
        {
            foreach (Contour conture in contures)
            {
                Console.WriteLine(conture.StartPoint.ToString() + " : " + conture.EndPoint.ToString());
                if (conture.GetType() == typeof(Curve))
                    Console.Write(" : " + (conture as Curve).Radius.ToString());
                if (conture is Vector)
                    Console.WriteLine((conture as Vector).Length.ToString());
            }
        }
    }




}
