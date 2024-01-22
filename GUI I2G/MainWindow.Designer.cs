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
            panelSideBar = new Panel();
            DeleteButton = new Button();
            btnLogo = new Button();
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).BeginInit();
            panelSideBar.SuspendLayout();
            SuspendLayout();
            // 
            // btn_GenerateGCode
            // 
            btn_GenerateGCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_GenerateGCode.BackColor = Color.DarkCyan;
            btn_GenerateGCode.BackgroundImageLayout = ImageLayout.Center;
            btn_GenerateGCode.FlatAppearance.BorderSize = 0;
            btn_GenerateGCode.FlatStyle = FlatStyle.Flat;
            btn_GenerateGCode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_GenerateGCode.ForeColor = SystemColors.ButtonHighlight;
            btn_GenerateGCode.Location = new Point(13, 506);
            btn_GenerateGCode.Margin = new Padding(3, 2, 3, 2);
            btn_GenerateGCode.Name = "btn_GenerateGCode";
            btn_GenerateGCode.Size = new Size(169, 44);
            btn_GenerateGCode.TabIndex = 0;
            btn_GenerateGCode.Text = "G-Code generieren";
            btn_GenerateGCode.UseVisualStyleBackColor = false;
            btn_GenerateGCode.Click += GCodeGenBtn_Click;
            // 
            // pB_DragDrop
            // 
            pB_DragDrop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pB_DragDrop.BackColor = Color.Gray;
            pB_DragDrop.BackgroundImageLayout = ImageLayout.None;
            pB_DragDrop.BorderStyle = BorderStyle.Fixed3D;
            pB_DragDrop.Location = new Point(373, 3);
            pB_DragDrop.Margin = new Padding(3, 2, 3, 2);
            pB_DragDrop.MinimumSize = new Size(521, 200);
            pB_DragDrop.Name = "pB_DragDrop";
            pB_DragDrop.Size = new Size(626, 715);
            pB_DragDrop.SizeMode = PictureBoxSizeMode.Zoom;
            pB_DragDrop.TabIndex = 1;
            pB_DragDrop.TabStop = false;
            pB_DragDrop.Tag = "";
            pB_DragDrop.SizeChanged += pB_DragDrop_SizeChanged;
            pB_DragDrop.DragDrop += pB_DragDrop_DragDrop;
            pB_DragDrop.DragEnter += pB_DragDrop_DragEnter;
            pB_DragDrop.DragOver += pB_DragDrop_DragOver;
            pB_DragDrop.DragLeave += pB_DragDrop_DragLeave;
            // 
            // lbl_DragDrop
            // 
            lbl_DragDrop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_DragDrop.AutoSize = true;
            lbl_DragDrop.BackColor = Color.Gray;
            lbl_DragDrop.Enabled = false;
            lbl_DragDrop.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_DragDrop.ForeColor = Color.White;
            lbl_DragDrop.Location = new Point(560, 345);
            lbl_DragDrop.Name = "lbl_DragDrop";
            lbl_DragDrop.Size = new Size(283, 23);
            lbl_DragDrop.TabIndex = 2;
            lbl_DragDrop.Text = "Bild hier via Drag n Drop hochladen";
            lbl_DragDrop.TextAlign = ContentAlignment.MiddleCenter;
            lbl_DragDrop.DragDrop += pB_DragDrop_DragDrop;
            lbl_DragDrop.DragEnter += pB_DragDrop_DragEnter;
            // 
            // tB_Y
            // 
            tB_Y.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_Y.BackColor = SystemColors.InactiveCaptionText;
            tB_Y.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_Y.ForeColor = Color.White;
            tB_Y.Location = new Point(201, 370);
            tB_Y.Margin = new Padding(3, 2, 3, 2);
            tB_Y.MaximumSize = new Size(110, 27);
            tB_Y.Name = "tB_Y";
            tB_Y.RightToLeft = RightToLeft.No;
            tB_Y.Size = new Size(110, 27);
            tB_Y.TabIndex = 4;
            tB_Y.TextAlign = HorizontalAlignment.Center;
            // 
            // tB_Z
            // 
            tB_Z.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_Z.BackColor = SystemColors.InactiveCaptionText;
            tB_Z.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_Z.ForeColor = Color.White;
            tB_Z.Location = new Point(201, 401);
            tB_Z.Margin = new Padding(3, 2, 3, 2);
            tB_Z.MaximumSize = new Size(110, 27);
            tB_Z.Name = "tB_Z";
            tB_Z.RightToLeft = RightToLeft.No;
            tB_Z.Size = new Size(110, 27);
            tB_Z.TabIndex = 5;
            tB_Z.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_X
            // 
            lbl_X.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_X.AutoSize = true;
            lbl_X.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_X.ForeColor = Color.White;
            lbl_X.Location = new Point(13, 342);
            lbl_X.Name = "lbl_X";
            lbl_X.Size = new Size(155, 23);
            lbl_X.TabIndex = 6;
            lbl_X.Text = "X- Eckpunkt in mm";
            // 
            // btn_DownloadGCode
            // 
            btn_DownloadGCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_DownloadGCode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_DownloadGCode.BackColor = Color.Transparent;
            btn_DownloadGCode.BackgroundImageLayout = ImageLayout.Center;
            btn_DownloadGCode.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btn_DownloadGCode.FlatAppearance.BorderSize = 0;
            btn_DownloadGCode.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_DownloadGCode.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btn_DownloadGCode.FlatStyle = FlatStyle.Flat;
            btn_DownloadGCode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_DownloadGCode.ForeColor = Color.FromArgb(64, 64, 64);
            btn_DownloadGCode.Image = (Image)resources.GetObject("btn_DownloadGCode.Image");
            btn_DownloadGCode.Location = new Point(215, 568);
            btn_DownloadGCode.Name = "btn_DownloadGCode";
            btn_DownloadGCode.Size = new Size(96, 102);
            btn_DownloadGCode.TabIndex = 7;
            btn_DownloadGCode.TextAlign = ContentAlignment.BottomCenter;
            btn_DownloadGCode.UseVisualStyleBackColor = false;
            btn_DownloadGCode.Click += btn_DownloadGCode_Click;
            // 
            // tB_depth
            // 
            tB_depth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_depth.BackColor = SystemColors.InactiveCaptionText;
            tB_depth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_depth.ForeColor = Color.White;
            tB_depth.Location = new Point(201, 432);
            tB_depth.Margin = new Padding(3, 2, 3, 2);
            tB_depth.MaximumSize = new Size(110, 27);
            tB_depth.Name = "tB_depth";
            tB_depth.RightToLeft = RightToLeft.No;
            tB_depth.Size = new Size(110, 27);
            tB_depth.TabIndex = 8;
            tB_depth.TextAlign = HorizontalAlignment.Center;
            // 
            // tB_X
            // 
            tB_X.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_X.BackColor = SystemColors.InactiveCaptionText;
            tB_X.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_X.ForeColor = Color.White;
            tB_X.Location = new Point(201, 339);
            tB_X.Margin = new Padding(3, 2, 3, 2);
            tB_X.MaximumSize = new Size(110, 27);
            tB_X.Name = "tB_X";
            tB_X.RightToLeft = RightToLeft.No;
            tB_X.Size = new Size(110, 27);
            tB_X.TabIndex = 9;
            tB_X.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_Y
            // 
            lbl_Y.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_Y.AutoSize = true;
            lbl_Y.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Y.ForeColor = Color.White;
            lbl_Y.Location = new Point(13, 373);
            lbl_Y.Name = "lbl_Y";
            lbl_Y.Size = new Size(154, 23);
            lbl_Y.TabIndex = 10;
            lbl_Y.Text = "Y- Eckpunkt in mm";
            // 
            // lbl_Z
            // 
            lbl_Z.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_Z.AutoSize = true;
            lbl_Z.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Z.ForeColor = Color.White;
            lbl_Z.Location = new Point(13, 404);
            lbl_Z.Name = "lbl_Z";
            lbl_Z.Size = new Size(155, 23);
            lbl_Z.TabIndex = 11;
            lbl_Z.Text = "Z- Eckpunkt in mm";
            // 
            // lbl_depth
            // 
            lbl_depth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_depth.AutoSize = true;
            lbl_depth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_depth.ForeColor = Color.White;
            lbl_depth.Location = new Point(14, 435);
            lbl_depth.Name = "lbl_depth";
            lbl_depth.Size = new Size(151, 23);
            lbl_depth.TabIndex = 12;
            lbl_depth.Text = "Graviertiefe in mm";
            // 
            // tB_showGCode
            // 
            tB_showGCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tB_showGCode.BackColor = Color.Gray;
            tB_showGCode.ForeColor = Color.White;
            tB_showGCode.Location = new Point(1025, 240);
            tB_showGCode.MaximumSize = new Size(312, 2770);
            tB_showGCode.Multiline = true;
            tB_showGCode.Name = "tB_showGCode";
            tB_showGCode.ReadOnly = true;
            tB_showGCode.RightToLeft = RightToLeft.No;
            tB_showGCode.ScrollBars = ScrollBars.Vertical;
            tB_showGCode.Size = new Size(312, 477);
            tB_showGCode.TabIndex = 13;
            // 
            // tB_aproxy
            // 
            tB_aproxy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_aproxy.BackColor = SystemColors.InactiveCaptionText;
            tB_aproxy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_aproxy.ForeColor = Color.White;
            tB_aproxy.Location = new Point(201, 463);
            tB_aproxy.Margin = new Padding(3, 2, 3, 2);
            tB_aproxy.MaximumSize = new Size(110, 27);
            tB_aproxy.Name = "tB_aproxy";
            tB_aproxy.RightToLeft = RightToLeft.No;
            tB_aproxy.Size = new Size(110, 27);
            tB_aproxy.TabIndex = 15;
            tB_aproxy.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 466);
            label1.Name = "label1";
            label1.Size = new Size(179, 23);
            label1.TabIndex = 16;
            label1.Text = "Aproxwert in px (2-15)";
            // 
            // HistoryDisplayBox
            // 
            HistoryDisplayBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HistoryDisplayBox.BackColor = Color.FromArgb(64, 64, 64);
            HistoryDisplayBox.ForeColor = Color.White;
            HistoryDisplayBox.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            HistoryDisplayBox.Location = new Point(1025, 2);
            HistoryDisplayBox.Margin = new Padding(0);
            HistoryDisplayBox.MultiSelect = false;
            HistoryDisplayBox.Name = "HistoryDisplayBox";
            HistoryDisplayBox.RightToLeft = RightToLeft.No;
            HistoryDisplayBox.Size = new Size(312, 232);
            HistoryDisplayBox.TabIndex = 17;
            HistoryDisplayBox.TileSize = new Size(150, 10);
            HistoryDisplayBox.UseCompatibleStateImageBehavior = false;
            HistoryDisplayBox.View = View.Details;
            HistoryDisplayBox.DoubleClick += HistoryDisplayBox_Enter;
            HistoryDisplayBox.Enter += HistoryDisplayBox_Enter;
            // 
            // ProjectSaveButton
            // 
            ProjectSaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ProjectSaveButton.BackColor = Color.DarkCyan;
            ProjectSaveButton.BackgroundImageLayout = ImageLayout.Center;
            ProjectSaveButton.FlatAppearance.BorderSize = 0;
            ProjectSaveButton.FlatStyle = FlatStyle.Flat;
            ProjectSaveButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectSaveButton.ForeColor = SystemColors.ButtonHighlight;
            ProjectSaveButton.Location = new Point(13, 568);
            ProjectSaveButton.Margin = new Padding(3, 2, 3, 2);
            ProjectSaveButton.Name = "ProjectSaveButton";
            ProjectSaveButton.Size = new Size(169, 40);
            ProjectSaveButton.TabIndex = 18;
            ProjectSaveButton.Text = "Project Speichern";
            ProjectSaveButton.UseVisualStyleBackColor = false;
            ProjectSaveButton.Click += ProjectSaveButton_Click;
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.FromArgb(64, 64, 64);
            panelSideBar.Controls.Add(DeleteButton);
            panelSideBar.Controls.Add(btnLogo);
            panelSideBar.Controls.Add(ProjectSaveButton);
            panelSideBar.Controls.Add(tB_X);
            panelSideBar.Controls.Add(btn_GenerateGCode);
            panelSideBar.Controls.Add(label1);
            panelSideBar.Controls.Add(tB_Y);
            panelSideBar.Controls.Add(tB_aproxy);
            panelSideBar.Controls.Add(tB_Z);
            panelSideBar.Controls.Add(lbl_X);
            panelSideBar.Controls.Add(lbl_depth);
            panelSideBar.Controls.Add(btn_DownloadGCode);
            panelSideBar.Controls.Add(lbl_Z);
            panelSideBar.Controls.Add(tB_depth);
            panelSideBar.Controls.Add(lbl_Y);
            panelSideBar.Dock = DockStyle.Left;
            panelSideBar.Location = new Point(0, 0);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(352, 729);
            panelSideBar.TabIndex = 19;
            panelSideBar.Paint += panelSideBar_Paint;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteButton.BackColor = Color.DarkCyan;
            DeleteButton.BackgroundImageLayout = ImageLayout.Center;
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.FlatStyle = FlatStyle.Flat;
            DeleteButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteButton.ForeColor = SystemColors.ButtonHighlight;
            DeleteButton.Location = new Point(13, 621);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(169, 40);
            DeleteButton.TabIndex = 20;
            DeleteButton.Text = "Project Entfernen";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // btnLogo
            // 
            btnLogo.BackgroundImage = (Image)resources.GetObject("btnLogo.BackgroundImage");
            btnLogo.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogo.FlatStyle = FlatStyle.Flat;
            btnLogo.ForeColor = Color.Transparent;
            btnLogo.Location = new Point(0, 24);
            btnLogo.Name = "btnLogo";
            btnLogo.Size = new Size(349, 167);
            btnLogo.TabIndex = 19;
            btnLogo.UseVisualStyleBackColor = true;
            btnLogo.Click += btnLogo_Click;
            // 
            // I2Gcode
            // 
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1362, 729);
            Controls.Add(HistoryDisplayBox);
            Controls.Add(tB_showGCode);
            Controls.Add(lbl_DragDrop);
            Controls.Add(pB_DragDrop);
            Controls.Add(panelSideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(7002, 3760);
            Name = "I2Gcode";
            RightToLeft = RightToLeft.Yes;
            Text = "I2G-Code";
            FormClosing += LastForm_FormClosing;
            Resize += I2Gcode_Resize;
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).EndInit();
            panelSideBar.ResumeLayout(false);
            panelSideBar.PerformLayout();
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
        private Panel panelSideBar;
        private Button btnLogo;
        private Button DeleteButton;
    }
}