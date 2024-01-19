using System.Xml.Linq;

namespace GUI_I2G
{
    partial class I2Gcode
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I2Gcode));
            btn_GenerateGCode = new Button();
            pB_DragDrop = new PictureBox();
            lbl_DragDrop = new Label();
            tB_Y = new TextBox();
            tB_Z = new TextBox();
            lbl_X = new Label();
            btn_DownloadGCode = new Button();
            tB_depth = new TextBox();
            tB_X = new TextBox();
            lbl_Y = new Label();
            lbl_Z = new Label();
            lbl_depth = new Label();
            tB_showGCode = new TextBox();
            tB_aproxy = new TextBox();
            label1 = new Label();
            HistoryDisplayBox = new ListView();
            ProjectSaveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).BeginInit();
            SuspendLayout();
            // 
            // btn_GenerateGCode
            // 
            btn_GenerateGCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_GenerateGCode.BackColor = Color.LightSeaGreen;
            btn_GenerateGCode.BackgroundImageLayout = ImageLayout.Center;
            btn_GenerateGCode.FlatAppearance.BorderSize = 0;
            btn_GenerateGCode.FlatStyle = FlatStyle.Flat;
            btn_GenerateGCode.ForeColor = SystemColors.ButtonHighlight;
            btn_GenerateGCode.Location = new Point(735, 628);
            btn_GenerateGCode.Margin = new Padding(3, 2, 3, 2);
            btn_GenerateGCode.Name = "btn_GenerateGCode";
            btn_GenerateGCode.Size = new Size(169, 34);
            btn_GenerateGCode.TabIndex = 0;
            btn_GenerateGCode.Text = "G-Code generieren";
            btn_GenerateGCode.UseVisualStyleBackColor = false;
            btn_GenerateGCode.Click += GCodeGenBtn_Click;
            // 
            // pB_DragDrop
            // 
            pB_DragDrop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pB_DragDrop.BackColor = Color.Gainsboro;
            pB_DragDrop.BackgroundImageLayout = ImageLayout.None;
            pB_DragDrop.BorderStyle = BorderStyle.Fixed3D;
            pB_DragDrop.Location = new Point(6, 5);
            pB_DragDrop.Margin = new Padding(3, 2, 3, 2);
            pB_DragDrop.MinimumSize = new Size(521, 200);
            pB_DragDrop.Name = "pB_DragDrop";
            pB_DragDrop.Size = new Size(685, 719);
            pB_DragDrop.SizeMode = PictureBoxSizeMode.Zoom;
            pB_DragDrop.TabIndex = 1;
            pB_DragDrop.TabStop = false;
            pB_DragDrop.Tag = "";
            pB_DragDrop.SizeChanged += pB_DragDrop_SizeChanged;
            pB_DragDrop.Click += pB_DragDrop_Click;
            pB_DragDrop.DragDrop += pB_DragDrop_DragDrop;
            pB_DragDrop.DragEnter += pB_DragDrop_DragEnter;
            pB_DragDrop.DragOver += pB_DragDrop_DragOver;
            pB_DragDrop.DragLeave += pB_DragDrop_DragLeave;
            // 
            // lbl_DragDrop
            // 
            lbl_DragDrop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_DragDrop.AutoSize = true;
            lbl_DragDrop.BackColor = Color.Transparent;
            lbl_DragDrop.Enabled = false;
            lbl_DragDrop.Location = new Point(207, 381);
            lbl_DragDrop.Name = "lbl_DragDrop";
            lbl_DragDrop.Size = new Size(194, 15);
            lbl_DragDrop.TabIndex = 2;
            lbl_DragDrop.Text = "Bild hier via Drag n Drop hochladen";
            lbl_DragDrop.TextAlign = ContentAlignment.MiddleCenter;
            lbl_DragDrop.Click += lbl_DragDrop_Click;
            lbl_DragDrop.DragDrop += pB_DragDrop_DragDrop;
            lbl_DragDrop.DragEnter += pB_DragDrop_DragEnter;
            // 
            // tB_Y
            // 
            tB_Y.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_Y.Location = new Point(877, 492);
            tB_Y.Margin = new Padding(3, 2, 3, 2);
            tB_Y.MaximumSize = new Size(110, 27);
            tB_Y.Name = "tB_Y";
            tB_Y.Size = new Size(110, 23);
            tB_Y.TabIndex = 4;
            // 
            // tB_Z
            // 
            tB_Z.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_Z.Location = new Point(877, 523);
            tB_Z.Margin = new Padding(3, 2, 3, 2);
            tB_Z.MaximumSize = new Size(110, 27);
            tB_Z.Name = "tB_Z";
            tB_Z.Size = new Size(110, 23);
            tB_Z.TabIndex = 5;
            // 
            // lbl_X
            // 
            lbl_X.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_X.AutoSize = true;
            lbl_X.Location = new Point(713, 464);
            lbl_X.Name = "lbl_X";
            lbl_X.Size = new Size(109, 15);
            lbl_X.TabIndex = 6;
            lbl_X.Text = "X- Eckpunkt in mm";
            // 
            // btn_DownloadGCode
            // 
            btn_DownloadGCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_DownloadGCode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_DownloadGCode.BackColor = Color.Transparent;
            btn_DownloadGCode.BackgroundImageLayout = ImageLayout.Center;
            btn_DownloadGCode.FlatAppearance.BorderSize = 0;
            btn_DownloadGCode.FlatStyle = FlatStyle.Flat;
            btn_DownloadGCode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_DownloadGCode.ForeColor = SystemColors.ActiveCaption;
            btn_DownloadGCode.Image = (Image)resources.GetObject("btn_DownloadGCode.Image");
            btn_DownloadGCode.Location = new Point(921, 628);
            btn_DownloadGCode.Name = "btn_DownloadGCode";
            btn_DownloadGCode.Size = new Size(108, 86);
            btn_DownloadGCode.TabIndex = 7;
            btn_DownloadGCode.TextAlign = ContentAlignment.BottomCenter;
            btn_DownloadGCode.UseVisualStyleBackColor = false;
            btn_DownloadGCode.UseWaitCursor = true;
            btn_DownloadGCode.Click += btn_DownloadGCode_Click;
            // 
            // tB_depth
            // 
            tB_depth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_depth.Location = new Point(877, 554);
            tB_depth.Margin = new Padding(3, 2, 3, 2);
            tB_depth.MaximumSize = new Size(110, 27);
            tB_depth.Name = "tB_depth";
            tB_depth.Size = new Size(110, 23);
            tB_depth.TabIndex = 8;
            // 
            // tB_X
            // 
            tB_X.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_X.Location = new Point(877, 461);
            tB_X.Margin = new Padding(3, 2, 3, 2);
            tB_X.MaximumSize = new Size(110, 27);
            tB_X.Name = "tB_X";
            tB_X.Size = new Size(110, 23);
            tB_X.TabIndex = 9;
            // 
            // lbl_Y
            // 
            lbl_Y.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_Y.AutoSize = true;
            lbl_Y.Location = new Point(713, 495);
            lbl_Y.Name = "lbl_Y";
            lbl_Y.Size = new Size(109, 15);
            lbl_Y.TabIndex = 10;
            lbl_Y.Text = "Y- Eckpunkt in mm";
            // 
            // lbl_Z
            // 
            lbl_Z.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_Z.AutoSize = true;
            lbl_Z.Location = new Point(713, 526);
            lbl_Z.Name = "lbl_Z";
            lbl_Z.Size = new Size(109, 15);
            lbl_Z.TabIndex = 11;
            lbl_Z.Text = "Z- Eckpunkt in mm";
            // 
            // lbl_depth
            // 
            lbl_depth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_depth.AutoSize = true;
            lbl_depth.Location = new Point(714, 557);
            lbl_depth.Name = "lbl_depth";
            lbl_depth.Size = new Size(105, 15);
            lbl_depth.TabIndex = 12;
            lbl_depth.Text = "Graviertiefe in mm";
            // 
            // tB_showGCode
            // 
            tB_showGCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tB_showGCode.BackColor = SystemColors.Window;
            tB_showGCode.Location = new Point(1044, 5);
            tB_showGCode.MaximumSize = new Size(312, 2770);
            tB_showGCode.Multiline = true;
            tB_showGCode.Name = "tB_showGCode";
            tB_showGCode.ReadOnly = true;
            tB_showGCode.RightToLeft = RightToLeft.No;
            tB_showGCode.ScrollBars = ScrollBars.Vertical;
            tB_showGCode.Size = new Size(312, 709);
            tB_showGCode.TabIndex = 13;
            tB_showGCode.TextChanged += tB_showGCode_TextChanged;
            // 
            // tB_aproxy
            // 
            tB_aproxy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_aproxy.Location = new Point(877, 585);
            tB_aproxy.Margin = new Padding(3, 2, 3, 2);
            tB_aproxy.MaximumSize = new Size(110, 27);
            tB_aproxy.Name = "tB_aproxy";
            tB_aproxy.Size = new Size(110, 23);
            tB_aproxy.TabIndex = 15;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(714, 588);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 16;
            label1.Text = "Aproxwert in px (2-15)";
            // 
            // HistoryDisplayBox
            // 
            HistoryDisplayBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            HistoryDisplayBox.BackColor = SystemColors.Info;
            HistoryDisplayBox.ForeColor = SystemColors.ControlText;
            HistoryDisplayBox.Location = new Point(697, 5);
            HistoryDisplayBox.Name = "HistoryDisplayBox";
            HistoryDisplayBox.Size = new Size(341, 451);
            HistoryDisplayBox.TabIndex = 17;
            HistoryDisplayBox.UseCompatibleStateImageBehavior = false;
            HistoryDisplayBox.View = View.Details;
            HistoryDisplayBox.DoubleClick += HistoryDisplayBox_Enter;
            HistoryDisplayBox.Enter += HistoryDisplayBox_Enter;
            // 
            // ProjectSaveButton
            // 
            ProjectSaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ProjectSaveButton.BackColor = Color.LightSeaGreen;
            ProjectSaveButton.BackgroundImageLayout = ImageLayout.Center;
            ProjectSaveButton.FlatAppearance.BorderSize = 0;
            ProjectSaveButton.FlatStyle = FlatStyle.Flat;
            ProjectSaveButton.ForeColor = SystemColors.ButtonHighlight;
            ProjectSaveButton.Location = new Point(735, 677);
            ProjectSaveButton.Margin = new Padding(3, 2, 3, 2);
            ProjectSaveButton.Name = "ProjectSaveButton";
            ProjectSaveButton.Size = new Size(169, 32);
            ProjectSaveButton.TabIndex = 18;
            ProjectSaveButton.Text = "Project Speichern";
            ProjectSaveButton.UseVisualStyleBackColor = false;
            ProjectSaveButton.Click += ProjectSaveButton_Click;
            // 
            // I2Gcode
            // 
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1362, 729);
            Controls.Add(ProjectSaveButton);
            Controls.Add(HistoryDisplayBox);
            Controls.Add(label1);
            Controls.Add(tB_aproxy);
            Controls.Add(tB_showGCode);
            Controls.Add(lbl_depth);
            Controls.Add(lbl_Z);
            Controls.Add(lbl_Y);
            Controls.Add(tB_X);
            Controls.Add(tB_depth);
            Controls.Add(btn_DownloadGCode);
            Controls.Add(lbl_X);
            Controls.Add(tB_Z);
            Controls.Add(tB_Y);
            Controls.Add(lbl_DragDrop);
            Controls.Add(pB_DragDrop);
            Controls.Add(btn_GenerateGCode);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(7002, 3760);
            Name = "I2Gcode";
            Padding = new Padding(3);
            RightToLeft = RightToLeft.Yes;
            Text = "I2G-Code";
            FormClosing += LastForm_FormClosing;
            Resize += I2Gcode_Resize;
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_GenerateGCode;
        private PictureBox pB_DragDrop;
        private Label lbl_DragDrop;
        private TextBox tB_Y;
        private TextBox tB_Z;
        private Label lbl_X;
        private Button btn_DownloadGCode;
        private TextBox tB_depth;
        private TextBox tB_X;
        private Label lbl_Y;
        private Label lbl_Z;
        private Label lbl_depth;
        private TextBox tB_showGCode;
        private TextBox textBox1;
        private Label label1;
        private TextBox tb_aproxy;
        private TextBox tB_aproxy;
        private ListView HistoryDisplayBox;
        private Button button1;
        private Button ProjectSaveButton;
    }
}