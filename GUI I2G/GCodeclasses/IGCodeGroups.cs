using Emgu.CV.Face;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GUI_I2G.GCodeclasses
{ 
    public static class IntExtension
    {
        public static string IsOrSet(this string newone, ref string current)
        {
            if (current == newone || newone == null) 
                return "";

            current = newone;
            return $"{current} ";
        } 
    }
    public static partial class GCodeGenerator
    {

        //modale Gruppe ist ->(ein einmal verwendeter Befehl wird aufrechterhalten, bis
        //zum Moment seines Widerrufs, durch den Aufruf eines anderen Befehl der Gruppe)

        /// <summary>
        /// G0 -> bewegung zum gewünschten Ort
        /// G1 -> Gerade Bewegung mit arbeitsvorschub zum gewünschten Ort
        /// G2 -> kreisbewegung im Uhrzeigersinn
        /// G3 -> Kreisbewegung gegen den Uhrzeigersinn
        /// </summary>
        private static string G0_3;

        /// <summary>
        /// Der Befehl G4 erlaubt die Anhaltung des ausgeführten Programms für bestimmte Zeit. Der die Zeit festlegende 
        //  Parameter „P” erlaubt die Eingabe des Zeitwerts in [ms]. Der Parameter „T” hingegen erlaubt die Eingabe der
        //  Zeit in [s] mit einer Genauigkeit von 3 Nachkommastellen.
        //  BEISPIEL BESCHREIBUNG
        //  G4 P100 Verweilzeit abwarten 100ms
        //  G4 T10.5 Verweilzeit abwarten 10s und 500ms
        /// </summary>
        private static int G4;

        /// <summary>
        /// 5. G17, G18, G19 – Auswahl der Ebene für die Kreisinterpolation
        /// G17-> XY plane
        /// Die Gruppe der G-Codes, die eine modale Grupe und für die Definition der Ebene für die Kreisinterpolation verantwortlich ist
        /// </summary>
        private static string G17_19;

        /// <summary>
        /// Die Befehle G90 und G91 sind Modale Befehle, welche bis zum Widerruf aktiv bleiben.
        //  G90 definiert die absolute Positionsangabe, welche dafür sorgt, dass jedes Maß in Bezug auf das aktuelle
        //  Koordinatensystem angefahren wird.Wird durch G91 abgewählt.
        //  G91 definiert die inkrementelle Fahrt. Jede angefahrene Position wird als Ursprung des Koordinatensystems
        //  gesehen.Wird durch G90 abgewählt.
        //  BEISPIEL BESCHREIBUNG
        //  G90 Wählt die absolute Weise der Positionierung.
        //  G91 Wählt die inkrementelle Weise der Positionierung.
        /// </summary>
        private static string G90_91;  

    }

}
