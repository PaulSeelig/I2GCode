using Emgu.CV.ML.MlEnum;
using GUI_I2G.Contures;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GUI_I2G.GCodeclasses
{
    public class GCode
    {
        public List<string> GCodeLines { get; set; } = new();

        public List<Tuple<int, Contour>> AllLines { get; set; } = new();
        public void SetConcreteLists()
        {
            int d = 0;
            foreach (Contour[] cg in AllContours)
            {
                foreach (Contour c in cg)
                {
                    if (c.GetType() == typeof(Line) && c != null)
                    {
                        AllLines.Add(new((d), (Line)c));
                    }
                    else if(c.GetType() == typeof(Curve) && c != null)
                    {
                        AllCurves.Add(new(d, (Curve)c)); 
                    }
                    d++;
                }
            }
        }
        private readonly Predicate<Contour[]> AreSmaller = delegate (Contour[] cArr) { return Contour.GetArrLength(cArr) < MinLength; };
        private static double MinLength { get; set; }
        /// <summary>
        /// Removes all Contour[] from AllContours that cummulated Length, is shorter than the given double min
        /// </summary>
        /// <param name="min"></param>
        public void RemoveAllCArr(double min = 1) 
        {
            MinLength = min;
            AllContours.RemoveAll(AreSmaller);
        }
        public void SetAllContoursFromConcreteLists() 
        {
            List<Tuple<int, Contour>> AllContsToMerge = new();
            AllContsToMerge.AddRange(AllLines);
            AllContsToMerge.AddRange(AllCurves);
            AllContsToMerge.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            AllContours = Contour.ContourGroup(AllContsToMerge.Select(x => x.Item2).ToList());
        }
        public List<Tuple<int, Contour>> AllCurves { get; set; } = new();
        public void SetAllContours(List<Contour[]> conts) => AllContours = conts;
        public List<Contour[]> GetAllContours()
        {
            if (AllContours == null || AllContours.Count == 0)
                SetAllContoursFromConcreteLists();
            if (AllContours == null)
                throw NoContoursAtAll;
            return AllContours;
        }
        private List<Contour[]> AllContours { get; set; } = new();
        private readonly NullReferenceException NoContoursAtAll = new();

        public GCode(List<Contour[]> l) 
        {
            SetAllContours(l);
           
            
        }
        [JsonConstructor]
        public GCode() 
        {
            SetAllContoursFromConcreteLists();

        }

    }

 
}

