using GUI_I2G.Tests;

namespace GUI_I2G
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //GCodeTest.GCUnittest(); Testing Unit
            ApplicationConfiguration.Initialize();
            Application.Run(new I2Gcode());
        }
    }
}