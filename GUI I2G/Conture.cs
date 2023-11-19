using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_I2G
{
    internal abstract class Conture
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public static Conture[] ContourExtractor()
        {
            //bloss beispielhaft
            Conture[] result = new Conture[3];
            result[0] = new Vector(new Point(3, 5) , new Point(2, -4));
            result[1] = new Curve(new Point(3, 5), new Point(3, 6), 5);
            result[2] = new Vector(new Point(4, 5), new Point(7, 4));

            return result;
        }
        public static void WriteOutContures(Conture[] contures)
        {
            foreach (Conture conture in contures) 
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
