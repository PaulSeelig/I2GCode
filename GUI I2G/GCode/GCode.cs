﻿using GUI_I2G.Contures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G.GCode
{
    internal class GCode
    {
        public string[]? GCodeLines { get; set; }

        public required Contour[] AllContours { get; set; } 
    }
}

