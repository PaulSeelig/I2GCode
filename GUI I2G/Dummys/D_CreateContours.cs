using GUI_I2G.Contures;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GUI_I2G.Dummys
{
    public class D_CreateContours
    {
        public static List<Contour[]> CreateListOfContourArrays()
        {
            Contour a0 = new Curve(new(-47, 334), new(209, -274), new(165, 298));
            // closed Contourgroup
            Contour aC = new Curve(new Point(3, 4), new(45, 5), 25, Direction.Glockwise);
            Contour aV = new Line(new Point(45, 5), new(30, -50));
            Contour bC = new Curve(new Point(30, -50), new(3, 4), 80, Direction.CounterGlockwise);

            // open Contourgroup
            Contour cC = new Curve(new Point(300, -40), new(200, 52), 200, Direction.Glockwise);
            Contour dC = new Curve(new Point(200, 52), new(49, 5), 800, Direction.Glockwise);
            Contour bV = new Line(new Point(49, 5), new(-70, 65));
            Contour eC = new Curve(new Point(-70, 65), new(23, -93), 500, Direction.Glockwise);

            // single Contour
            Contour iV = new Line(new Point(3, 4), new(45, 5));

            // unused yet
            Contour cV = new Line(new Point(3, 4), new(45, 5));
            Contour dV = new Line(new Point(3, 4), new(45, 5));
            Contour eV = new Line(new Point(3, 4), new(45, 5));
            Contour fV = new Line(new Point(3, 4), new(45, 5));
            Contour gV = new Line(new Point(3, 4), new(45, 5));
            Contour hV = new Line(new Point(3, 4), new(45, 5));



            Contour[] aCArrClosed = new[] { aC, aV, bC };
            Contour[] bCArrOpen = new[] { cC, dC, bV, eC };
            Contour[] cCArrSingle = new[] { iV };
            //Contour[] dCArrClosed = new[] { aC, aV, bC };
            return new List<Contour[]>{aCArrClosed, bCArrOpen, cCArrSingle}; 
        }
    }
}
