﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.Contures
{
    internal class Vector : Contour
    {

        public Vector(Point start, Point end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        private double SaveLength {  get; set; }

        public override double Length { get => SaveLength; set => Math.Sqrt(Math.Pow(StartPoint.X - EndPoint.X, 2) + Math.Pow(StartPoint.Y - EndPoint.Y, 2));}
    }
}
