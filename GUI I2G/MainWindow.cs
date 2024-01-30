using Emgu.CV;
using Emgu.CV.Structure;
using GUI_I2G.Contures;
using GUI_I2G.GCodeclasses;
using GUI_I2G.Tests;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Net;
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

        private Pen Normal { get; set; } = new(Color.Black, 1); //Die dicke solltw vlt auch adjusted werden

        private Pen HighLight { get; set; } = new(Color.White, 1);

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
            AproxyToolTip.SetToolTip(tB_aproxy, "Veränderungen dieses Wertes verändern wie die Konturen Erfasst werden");
            HistoryDisplayBox.Columns.Add("Project Name", HistoryDisplayBox.Width * 3 / 5);
            HistoryDisplayBox.Columns.Add("Last Opened", (int)(HistoryDisplayBox.Width * 1.6 / 5));
            tB_advises.Visible = HistoryDisplayBox.Items.Count == 0;
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
                throw new FormatException($"bitte geben Sie in '{textBox.AccessibleName}' nur (positive) Zahlen ein");
            }
        }
        private void CheckInput(System.Windows.Forms.TextBox textBox, out double value, double max)
        {
            CheckInput(textBox, out value);
            if (value > max)
                throw new FormatException("Please choose an CuttingDepth, that is less or equal than the chosen Z/Height of the material");
        }
        private void CheckInput(double min, System.Windows.Forms.TextBox textBox, out double value)
        {
            CheckInput(textBox, out value);
            if (value < min)
                throw new FormatException($"Please choose a value for {textBox.AccessibleName}, that is higher than {min}");
        }

        // Downloads the GCode as .txt file to MyDocuments
        public void DownloadGcode()
        {
            try
            {
                if (string.IsNullOrEmpty(tB_showGCode.Text))
                    throw (new FormatException("Bitte Werte eingeben vor dem Downloaden"));
                if (string.IsNullOrEmpty(CurrentProjectName))
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
                CheckInput(50, tB_X, out double xkoo1);
                CheckInput(50, tB_Y, out double ykoo1);
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
                    //pB_DragDrop.Image = Image.FromFile(files);
                    imagepath = files;
                }
                p.SetScaleFactor(Image.FromFile(imagepath).Width, Image.FromFile(imagepath).Height);
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
                string name = Path.GetFileName(imagepath); //damit man die Bilder speichern kann unter den namen
                CurrentGCode.SetAllContours(Contour.ContourExtractor(Contour.Konturfinder(rgbimage), epsilon));
                DrawOnPicBox();
                FillContourListBox();
            }
        }
        private void FillContourListBox()
        {
            ContourListBox.Items.Clear();
            for (int i = 0; i < CurrentGCode.GetAllContours().Count - 1; i++)
            {
                ContourListBox.Items.Add($"Contour {i}");
            }
        }
        /// <summary>
        /// Takes the Contours from CurrentGCode.GetAllContours() and draws them onto the Big DragAndDropArea
        /// </summary>
        /// <param name="index"></param>
        /// <param name="clear"></param>
        public void DrawOnPicBox(int index = -1, bool clear = false)
        {
            // This Method is also used, to  clear the DragAndDropArea. Therefor this List<C...> is always used, but only
            // filled if the bool clear param isn't changed to true
            List<Contour[]> Arr = new();

            // This sets the resolution of the drawn Image, but also influences the scaling for the Drawn Contour
            int H = (int)((double.TryParse(tB_Y.Text, out double valueY) && valueY != 0? valueY : pB_DragDrop.Height));
            int W = (int)((double.TryParse(tB_X.Text, out double valueX) && valueX != 0 ? valueX : pB_DragDrop.Width));

            // Just to make sure, it won't draw comlete pixelart
            while (H < 1000 && W < 1000)
            {
                H *= 10;
                W *= 10;
            }
            // And to stop the Bitmap wasting your RAM
            while (H > 4000 && W > 4000)
            {
                H /= 2;
                W /= 2;
            }


            Bitmap Drawnimage = new(W, H); //Creating the new Bitmap with the seted Width - W and Height - H


            double ScaleY;
            double ScaleX;
            double Scalea = 0;

            if (!clear)
            {
                Arr = CurrentGCode.GetAllContours();
                ScaleY = H / Image.FromFile(imagepath).Height;
                ScaleX = W / Image.FromFile(imagepath).Width;
                Scalea = Math.Min(ScaleX, ScaleY); //better readablility //thanks
            }

            Normal.Width = (float)((H < W ? H :W )* 0.002);
            HighLight.Width = Normal.Width;
            //Erstellen eines Graphics - Objekts aus der erstellten Bitmap
            using (Graphics g = Graphics.FromImage(Drawnimage))
            {
                //Pen pen = new(Color.Red, 3);
                //DrawOnPicBox(CurrentGCode.GetAllContours(), g);

                pB_DragDrop.Image = Drawnimage;
                // graphics = pB_DragDrop.CreateGraphics();
                Point[][] pArrArr = new Point[Arr.Count][];
                for (int i = 0; i < Arr.Count; i++)
                {
                    Point[] pArr = new Point[Arr[i].Length + 1];
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
                        Pen currentPen = index == pArrInd ? HighLight : Normal; //This Highlights the contours?? //yes
                        for (int i = 0; i < pArr.Length - 1; i++)
                        {
                            g.DrawLine(currentPen, new((int)(pArr[i].X * Scalea), (int)(pArr[i].Y * Scalea)), new((int)(pArr[i + 1].X * Scalea), (int)(pArr[i + 1].Y * Scalea)));
                            //g.DrawLine(currentPen, pArr[i], pArr[i + 1]);
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
            HistoryDisplayBox.SelectedItems.Clear();
            ContourListBox.Items.Clear();
            DrawOnPicBox(-1, true);
            CurrentProjectName = null;
            //using (Graphics g = pB_DragDrop.CreateGraphics())
            //{

            //    g.Clear(Color.Gray);
            //}
            lbl_DragDrop.Visible = true;
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

        private void HistoryDisplayBox_Enter(object sender, EventArgs e)
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

                tB_aproxy.Text = $"{CurrentProject.parameter.AproxValue * 10}";

                tB_showGCode.Lines = CurrentProject.Gcode.GCodeLines;
                imagepath = CurrentProject.imagePath;
                //pB_DragDrop.Image = Image.FromFile(imagepath);
                ContourArrAndDraw();
                lbl_DragDrop.Visible = false;
            }
        }

        private void ProjectSaveButton_Click(object? sender, EventArgs? e)
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
                    CurrentProject.imagePath = imagepath;
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
                button2_Click(sender, e);
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
            btn_ContLösch.Visible = checkBox1.Checked;
            btnLogo.Visible = !checkBox1.Checked;
            if (checkBox1.Checked)
                Settings.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // URL der NC Viewer-API
                string apiUrl = "https://ncviewer.com";

                // Der G-Code, den du senden möchtest
                string gCode = CurrentGCode.GCodeLines.ToString();

                // Erstelle einen WebClient
                using (WebClient client = new WebClient())
                {
                    // Erstelle die Anfrage-Daten
                    var requestData = new System.Collections.Specialized.NameValueCollection();
                    requestData["code"] = gCode;

                    // Sende die POST-Anfrage an die API
                    byte[] responseBytes = client.UploadValues(apiUrl, "POST", requestData);

                    // Konvertiere die Antwort in einen String
                    string responseBody = System.Text.Encoding.UTF8.GetString(responseBytes);

                    // Gib die Antwort aus (z.B. die URL zur Anzeige des G-Codes)
                    //Console.WriteLine("Response from NC Viewer API:");
                    //Console.WriteLine(responseBody);
                }

            }
            catch (Exception)
            { }
        }

        private void btn_ContLösch_Click(object sender, EventArgs e)
        {
            try
            {
                List<Contour[]> a = CurrentGCode.GetAllContours();
                a.RemoveAt(ContourListBox.SelectedIndex);
                int i = ContourListBox.SelectedIndex;
                CurrentGCode.SetAllContours(a);
                DrawOnPicBox();
                FillContourListBox();
                ContourListBox.SelectedIndex = i;
            }
            catch (Exception) { }
        }
        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            btnLogo.Visible = true;
            //(btnLogo.Visible, Settings.Visible) = (Settings.Visible, btnLogo.Visible);
            Settings.Visible = !Settings.Visible;
            checkBox1.Checked = false;
        }

        private void ContourListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e.KeyCode == '\u007F')
            //    btn_ContLösch_Click(sender, e);
        }

        private void ContourListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (sender == HistoryDisplayBox)
                    DeleteButton_Click(this, EventArgs.Empty);
                else
                    btn_ContLösch_Click(sender, e);
            }
        }

        private void btn_ShowAdvises_Click(object sender, EventArgs e)
        {
            tB_advises.Visible = !tB_advises.Visible;
            lbl_DragDrop.Visible = !tB_advises.Visible;
            if (pB_DragDrop.Image != null) { lbl_DragDrop.Visible = false; }
        }

    }
}