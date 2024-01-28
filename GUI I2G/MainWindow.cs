using Emgu.CV;
using Emgu.CV.Structure;
using GUI_I2G.Contures;
using GUI_I2G.GCodeclasses;
using GUI_I2G.Tests;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_I2G
{
    public partial class I2Gcode : Form
    {
        // zoom level is needed for the SetZoomLevel Method, defines the speed of zooming
        private int zoomLevel = 100;

        // this imagepath is the path of the image that gets dropped intp the PictureBox, its used to draw the contours in button1_Click
        private string imagepath;

        private Graphics graphics;

        private Image<Rgb, System.Byte> rgbimage;

        private double depth;

        private History history = new History();

        private string historyfilePath = @".\History.json";

        private string ImageLocationhold { get; set; }

        private double epsilon = 3.4;

        private Parameter p = new();

        private Pen Normal { get; set; } = new(Color.Black);

        private Pen HighLight { get; set; } = new(Color.White);

        private GCode CurrentGCode = new();

        private string CurrentProjectName;

        private HistoryEntry CurrentProject = new HistoryEntry("", new(0, 0, new double[] { 0, 0, 0 }), new(), "");

        public I2Gcode()
        {
            InitializeComponent();
            if (File.Exists(historyfilePath))
            {
                history.OpenHistoryFromFile(historyfilePath);
                UpdateHistory();
            }

            //Adds Colums to HistoryDisplayBox

            HistoryDisplayBox.Columns.Add("Project Name", HistoryDisplayBox.Width * 3 / 5);
            HistoryDisplayBox.Columns.Add("Last Opened", (int)(HistoryDisplayBox.Width * 1.6 / 5));

            // allows to drop pictures into the PictureBox 
            pB_DragDrop.AllowDrop = true;
            // this Eventhandler is used if one hovers over the PictureBox
            //pB_DragDrop.DragEnter += new DragEventHandler(pB_DragDrop_DragEnter);
            // this Eventhandler is used after a Drag and drop process is complete
            //pB_DragDrop.DragDrop += new DragEventHandler(pB_DragDrop_DragDrop);
            // this is needed bcs in VS2022 this event does not exist until its manually added
            pB_DragDrop.MouseWheel += PB_DragDrop_MouseWheel;
        }
        // Checks if the input from the Coordinate TextBox gets parsed into double
        private void CheckInput(System.Windows.Forms.TextBox textBox, out double value)
        {
            if ((!double.TryParse(textBox.Text, out value)) || value <= 0)
            {
                throw new FormatException($"bitte geben Sie in '{textBox.AccessibleName}' nur Zahlen größer als Null ein");
            }
        }
        private void CheckInput(System.Windows.Forms.TextBox textBox, out double value, double max)
        {
            CheckInput(textBox, out value);
            if (value > max)
                throw new FormatException("Please choose an CuttingDepth, that is less or equal than the chosen Z/Height of the material");
        }

        // Downloads the GCode as .txt file to MyDocuments
        public void DownloadGcode()
        {
            try
            {
                if (string.IsNullOrEmpty(tB_showGCode.Text) || tB_showGCode.Text.Any(Char.IsWhiteSpace))
                    throw (new FormatException("Bitte Werte eingeben vor dem Speichern"));
                ProjectSaveButton_Click(null, null);
                // takes the GCode from the TextBox
                string GCodeVorschau = tB_showGCode.Text;
                // takes the folder path to MyDocuments
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // puts a file named "GCode .txt" at the destinaetd folderpath
                string filePath = Path.Combine(folderPath, CurrentProjectName);
                // writes the GCode into the file
                File.WriteAllText(filePath, GCodeVorschau);
                // opens the explorer and selects the saved file
                Process.Start("explorer.exe", "/select," + filePath);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Ungültige Eingabe, {ex.Message}");
            }
        }
        private void PB_DragDrop_MouseWheel(object? sender, MouseEventArgs e)
        {
            //if (e.Delta > 0 && zoomLevel < 200) // Zoom in
            //{
            //    zoomLevel += 10;
            //    pB_DragDrop.BringToFront();
            //}
            //else if (e.Delta < 0 && zoomLevel > 10) // Zoom out
            //{
            //    zoomLevel -= 10;
            //    pB_DragDrop.SendToBack();
            //}
            //SetZoomLevel();
        }

        public void GCodeGenBtn_Click(object sender, EventArgs e)       //Button zum GCode generieren 
        {
            try
            {
                CheckInput(tB_X, out double xkoo1);
                CheckInput(tB_Y, out double ykoo1);
                CheckInput(tB_Z, out double zkoo1);
                CheckInput(tB_depth, out depth, zkoo1);
                if (pB_DragDrop.Image == null)
                    throw new FormatException("Sie müssen ein Bild per drag and drop in das mittlere Feld eingeben");

                p.Eckpunkt[0] = xkoo1;
                p.Eckpunkt[1] = ykoo1;
                p.Eckpunkt[2] = zkoo1;
                p.CuttingDepth = depth;
                p.AproxValue = epsilon;


                //MessageBox.Show("Ihre Eingaben, waren korrekt, Ihr G-Code wird nun generiert, dies könnte einige Zeit in Anspruch nehmen!");



                //CvInvoke.DrawContours(rgbimage, Contour.Konturfinder(rgbimage), -1, new MCvScalar(200, 45, 45), 2);//hier werden die konturen auf ein rgb bild gemalt

                //CvInvoke.Imwrite("draw" + name, rgbimage);//um das Bild mit den Konturen zuspeichern + das konvertieren von emgu image zum draw image
                //Image save = Image.FromFile("draw" + name);//keine schöne methode (fürs konvertieren) habe aber nichts auf die schnelle gefunden werde das nachträglich machen                

                //pB_DragDrop.Image = save;
                CurrentGCode = GCodeGenerator.GenerateGCode(CurrentGCode.GetAllContours(), p);


                CurrentProject.parameter = p;
                tB_showGCode.Lines = CurrentGCode.GCodeLines;
                CurrentProject.Gcode = CurrentGCode;
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Ungültige Eingabe, {ex.Message}");
            }
        }
        private void pB_DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void pB_DragDrop_DragDrop(object sender, DragEventArgs e)
        {
            lbl_DragDrop.Visible = false;
            if (e.Data != null)
            {
                string files = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];
                if (files != null && files.Length > 0)
                {
                    pB_DragDrop.ImageLocation = files;
                    imagepath = files;
                }
                ImageLocationhold = pB_DragDrop.ImageLocation;
                ContourArrAndDraw();
                pB_DragDrop.ImageLocation = null;
            }
        }
        private void ContourArrAndDraw()
        {
            if (!string.IsNullOrEmpty(imagepath))
            {
                epsilon = double.TryParse(tB_aproxy.Text, out double value) && value > 0 ? value * 0.1 : 3;
                rgbimage = new(imagepath); //hier wird das rgbimage erstellt
                CurrentProject.imagePath = imagepath;
                string name = Path.GetFileName(imagepath); //damit man die Bilder speichern kann unter den namen
                CurrentGCode.SetAllContours(Contour.ContourExtractor(Contour.Konturfinder(rgbimage), epsilon));

                DrawOnPicBox();
                for (int i = 0; i < CurrentGCode.GetAllContours().Count - 1; i++)
                {
                    ListViewItem item = new($"Contour {i}");
                    ContourListBox.Items.Add(item);
                }
            }
        }
        public void DrawOnPicBox(int index = -1)
        {
            List<Contour[]> Arr = CurrentGCode.GetAllContours();
            int H = CurrentGCode.GetAllContours()[^1][0].EndPoint.Y;
            int W = CurrentGCode.GetAllContours()[^1][^1].StartPoint.X;
            Bitmap Drawnimage = new(W, H);

            // Erstellen eines Graphics-Objekts aus der erstellten Bitmap
            using (Graphics g = Graphics.FromImage(Drawnimage))
            {
                //Pen pen = new(Color.Red, 3);
                //DrawOnPicBox(CurrentGCode.GetAllContours(), g);

                pB_DragDrop.Image = Drawnimage;
                // graphics = pB_DragDrop.CreateGraphics();
                Point[][] pArrArr = new Point[Arr.Count][];
                for (int i = 0; i < Arr.Count; i++)
                {
                    Point[] pArr = new Point[Arr[i].Length];
                    for (int j = 0; j < Arr[i].Length; j++)
                    {
                        pArr[j] = Arr[i][j].StartPoint;
                    }
                    pArr[^1] = Arr[i][^1].EndPoint;
                    pArrArr[i] = pArr;
                }

                int pArrInd = 0;
                foreach (Point[] pArr in pArrArr.SkipLast(1))
                {
                    if (pArr.Length > 1)
                    {
                        Pen currentPen = index == pArrInd ? HighLight : Normal;
                        for (int i = 0; i < pArr.Length - 1; i++)
                        {
                            g.DrawLine(currentPen, pArr[i], pArr[i + 1]);
                            //g.DrawLines(new(Color.Black), pArr);
                        }
                    }
                    pArrInd++;
                }
            }
        }
        private void pB_DragDrop_Scale()
        {
            if (pB_DragDrop.Image != null)
            {
                pB_DragDrop.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void I2Gcode_Resize(object sender, EventArgs e)
        {
            pB_DragDrop_Scale();
        }
        private void btn_DownloadGCode_Click(object sender, EventArgs e)
        {
            DownloadGcode();
        }
        private void pB_DragDrop_SizeChanged(object sender, EventArgs e)
        {
            pB_DragDrop_Scale();
        }

        private void pB_DragDrop_DragOver(object sender, DragEventArgs e)
        {
            lbl_DragDrop.Visible = false;
        }

        private void pB_DragDrop_DragLeave(object sender, EventArgs e)
        {
            lbl_DragDrop.Visible = true;
        }
        private void btnLogo_Click(object sender, EventArgs e)
        {
            pB_DragDrop.Image = null;
            tB_showGCode.Text = null;
            tB_X.Text = null;
            tB_Y.Text = null;
            tB_Z.Text = null;
            tB_depth.Text = null;
            tB_aproxy.Text = "1";
        }
        private void UpdateHistory()
        {
            HistoryDisplayBox.BeginUpdate();
            HistoryDisplayBox.Items.Clear();

            HistoryEntry[] entries = history.GetLastOpened();

            foreach (HistoryEntry entry in entries)
            {
                ListViewItem item = new ListViewItem(entry.projectName);
                item.SubItems.Add(entry.lastOpened.ToString("dd-MM-yyyy HH:mm"));
                HistoryDisplayBox.Items.Add(item);
            }
            HistoryDisplayBox.EndUpdate();
            HistoryDisplayBox.Refresh();
        }

        private void HistoryDisplayBox_Enter(object? sender, EventArgs? e)
        {
            // Check if any item is selected
            if (HistoryDisplayBox.SelectedItems.Count > 0)
            {
                // Retrieve the selected item
                ListViewItem selectedItem = HistoryDisplayBox.SelectedItems[0];

                CurrentProject = history.GetEntryByName(selectedItem.SubItems[0].Text);

                CurrentProjectName = CurrentProject.projectName;

                //Displays values from Parameter
                tB_X.Text = CurrentProject.parameter.Eckpunkt[0].ToString();
                tB_Y.Text = CurrentProject.parameter.Eckpunkt[1].ToString();
                tB_Z.Text = CurrentProject.parameter.Eckpunkt[2].ToString();

                tB_depth.Text = CurrentProject.parameter.CuttingDepth.ToString();

                tB_aproxy.Text = CurrentProject.parameter.AproxValue.ToString();

                tB_showGCode.Lines = CurrentProject.Gcode.GCodeLines;
                imagepath = CurrentProject.imagePath;
                ContourArrAndDraw();
                lbl_DragDrop.Visible = false;
            }
        }

        private void ProjectSaveButton_Click(object sender, EventArgs e)
        {
            string Instruction;
            if (CurrentProjectName != null)
            {
                Instruction = "Momentanes Projekt speichern?";
            }
            else
            {
                Instruction = "Bitte Projectnamen eingeben";
            }
            using (InputDialog inputDialog = new InputDialog(Instruction, CurrentProjectName))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    CurrentProject.UpdateLastOpened();
                    if (CurrentProjectName == inputDialog.UserInput)
                    {
                        history.SaveGcodeProject(CurrentProject);
                    }
                    else
                    {
                        HistoryEntry ToSafe = new(CurrentProject);
                        ToSafe.projectName = inputDialog.UserInput;
                        CurrentProjectName = inputDialog.UserInput;
                        history.SaveGcodeProject(ToSafe);
                    }
                    UpdateHistory();
                }
            }
        }

        //Method that gets Called with the closing of the View
        private void LastForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            history.SaveHistoryToFile(@".\History.json");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (HistoryDisplayBox.FocusedItem != null)
            {
                history.DeleteGcodeProject(HistoryDisplayBox.FocusedItem.Index);
                UpdateHistory();
            }
        }

        private void tB_aproxy_TextChanged(object sender, EventArgs e)
        {
            if (ImageLocationhold != "" && ImageLocationhold != null)
            {
                CurrentProject.imagePath ??= ImageLocationhold;
            }
            if (CurrentProject.imagePath != null)
            {
                ContourArrAndDraw();
                pB_DragDrop.ImageLocation = null;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            DrawOnPicBox(ContourListBox.SelectedIndex);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ContourListBox.Visible = checkBox1.Checked;
            btnLogo.Visible = !checkBox1.Checked;
        }
    }
}