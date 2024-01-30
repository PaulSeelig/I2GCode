﻿using System.Xml.Linq;

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
            components = new System.ComponentModel.Container();
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
            label1 = new Label();
            HistoryDisplayBox = new ListView();
            ProjectSaveButton = new Button();
            panelSideBar = new Panel();
            btn_ContLösch = new Button();
            checkBox1 = new CheckBox();
            ContourListBox = new ListBox();
            tB_aproxy = new NumericUpDown();
            label10 = new Label();
            Settings = new Panel();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBox3 = new TextBox();
            label9 = new Label();
            label2 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            panel1 = new Panel();
            Btn_Setting = new Button();
            btn_Clear = new Button();
            DeleteButton = new Button();
            btnLogo = new Button();
            AproxyToolTip = new ToolTip(components);
            tB_advises = new TextBox();
            panel2 = new Panel();
            btn_ShowAdvises = new Button();
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).BeginInit();
            panelSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tB_aproxy).BeginInit();
            Settings.SuspendLayout();
            panel2.SuspendLayout();
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
            btn_GenerateGCode.Location = new Point(11, 424);
            btn_GenerateGCode.Margin = new Padding(3, 2, 3, 2);
            btn_GenerateGCode.Name = "btn_GenerateGCode";
            btn_GenerateGCode.Size = new Size(148, 33);
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
            pB_DragDrop.BorderStyle = BorderStyle.FixedSingle;
            pB_DragDrop.Location = new Point(311, 2);
            pB_DragDrop.Margin = new Padding(3, 2, 3, 2);
            pB_DragDrop.MinimumSize = new Size(456, 150);
            pB_DragDrop.Name = "pB_DragDrop";
            pB_DragDrop.Size = new Size(581, 536);
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
            lbl_DragDrop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_DragDrop.AutoSize = true;
            lbl_DragDrop.BackColor = Color.Gray;
            lbl_DragDrop.Enabled = false;
            lbl_DragDrop.FlatStyle = FlatStyle.Flat;
            lbl_DragDrop.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_DragDrop.ForeColor = Color.White;
            lbl_DragDrop.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            lbl_DragDrop.Location = new Point(490, 259);
            lbl_DragDrop.Name = "lbl_DragDrop";
            lbl_DragDrop.Size = new Size(227, 19);
            lbl_DragDrop.TabIndex = 2;
            lbl_DragDrop.Text = "Bild hier via Drag n Drop hochladen";
            lbl_DragDrop.TextAlign = ContentAlignment.MiddleCenter;
            lbl_DragDrop.DragEnter += pB_DragDrop_DragEnter;
            // 
            // tB_Y
            // 
            tB_Y.AccessibleName = "Tiefe ihres Materials";
            tB_Y.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_Y.BackColor = SystemColors.InactiveCaptionText;
            tB_Y.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_Y.ForeColor = Color.White;
            tB_Y.Location = new Point(191, 302);
            tB_Y.Margin = new Padding(3, 2, 3, 2);
            tB_Y.MaximumSize = new Size(97, 27);
            tB_Y.Name = "tB_Y";
            tB_Y.RightToLeft = RightToLeft.No;
            tB_Y.Size = new Size(97, 25);
            tB_Y.TabIndex = 4;
            tB_Y.TextAlign = HorizontalAlignment.Center;
            // 
            // tB_Z
            // 
            tB_Z.AccessibleName = "Z/Höhe ihres Materials";
            tB_Z.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_Z.BackColor = SystemColors.InactiveCaptionText;
            tB_Z.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_Z.ForeColor = Color.White;
            tB_Z.Location = new Point(191, 326);
            tB_Z.Margin = new Padding(3, 2, 3, 2);
            tB_Z.MaximumSize = new Size(97, 27);
            tB_Z.Name = "tB_Z";
            tB_Z.RightToLeft = RightToLeft.No;
            tB_Z.Size = new Size(97, 25);
            tB_Z.TabIndex = 5;
            tB_Z.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_X
            // 
            lbl_X.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_X.AutoSize = true;
            lbl_X.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_X.ForeColor = Color.White;
            lbl_X.Location = new Point(11, 281);
            lbl_X.Name = "lbl_X";
            lbl_X.Size = new Size(107, 19);
            lbl_X.TabIndex = 6;
            lbl_X.Text = "Breite (X) in mm";
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
            btn_DownloadGCode.Location = new Point(178, 464);
            btn_DownloadGCode.Margin = new Padding(3, 2, 3, 2);
            btn_DownloadGCode.Name = "btn_DownloadGCode";
            btn_DownloadGCode.Size = new Size(84, 76);
            btn_DownloadGCode.TabIndex = 7;
            btn_DownloadGCode.TextAlign = ContentAlignment.BottomCenter;
            btn_DownloadGCode.UseVisualStyleBackColor = false;
            btn_DownloadGCode.Click += btn_DownloadGCode_Click;
            // 
            // tB_depth
            // 
            tB_depth.AccessibleName = "Graviertiefe";
            tB_depth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_depth.BackColor = SystemColors.InactiveCaptionText;
            tB_depth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_depth.ForeColor = Color.White;
            tB_depth.Location = new Point(191, 349);
            tB_depth.Margin = new Padding(3, 2, 3, 2);
            tB_depth.MaximumSize = new Size(97, 27);
            tB_depth.Name = "tB_depth";
            tB_depth.RightToLeft = RightToLeft.No;
            tB_depth.Size = new Size(97, 25);
            tB_depth.TabIndex = 8;
            tB_depth.TextAlign = HorizontalAlignment.Center;
            // 
            // tB_X
            // 
            tB_X.AccessibleName = "Breite (X) ihres Materials";
            tB_X.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_X.BackColor = SystemColors.InactiveCaptionText;
            tB_X.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_X.ForeColor = Color.White;
            tB_X.Location = new Point(191, 279);
            tB_X.Margin = new Padding(3, 2, 3, 2);
            tB_X.MaximumSize = new Size(97, 27);
            tB_X.Name = "tB_X";
            tB_X.RightToLeft = RightToLeft.No;
            tB_X.Size = new Size(97, 25);
            tB_X.TabIndex = 9;
            tB_X.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_Y
            // 
            lbl_Y.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_Y.AutoSize = true;
            lbl_Y.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Y.ForeColor = Color.White;
            lbl_Y.Location = new Point(11, 304);
            lbl_Y.Name = "lbl_Y";
            lbl_Y.Size = new Size(100, 19);
            lbl_Y.TabIndex = 10;
            lbl_Y.Text = "Tiefe (Y) in mm";
            // 
            // lbl_Z
            // 
            lbl_Z.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_Z.AutoSize = true;
            lbl_Z.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Z.ForeColor = Color.White;
            lbl_Z.Location = new Point(11, 328);
            lbl_Z.Name = "lbl_Z";
            lbl_Z.Size = new Size(105, 19);
            lbl_Z.TabIndex = 11;
            lbl_Z.Text = "Höhe (Z) in mm";
            // 
            // lbl_depth
            // 
            lbl_depth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_depth.AutoSize = true;
            lbl_depth.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_depth.ForeColor = Color.White;
            lbl_depth.Location = new Point(12, 350);
            lbl_depth.Name = "lbl_depth";
            lbl_depth.Size = new Size(122, 19);
            lbl_depth.TabIndex = 12;
            lbl_depth.Text = "Graviertiefe in mm";
            // 
            // tB_showGCode
            // 
            tB_showGCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tB_showGCode.BackColor = Color.Gray;
            tB_showGCode.Cursor = Cursors.Cross;
            tB_showGCode.ForeColor = Color.White;
            tB_showGCode.Location = new Point(9, 187);
            tB_showGCode.Margin = new Padding(3, 2, 3, 2);
            tB_showGCode.MaximumSize = new Size(274, 2078);
            tB_showGCode.Multiline = true;
            tB_showGCode.Name = "tB_showGCode";
            tB_showGCode.ReadOnly = true;
            tB_showGCode.RightToLeft = RightToLeft.No;
            tB_showGCode.ScrollBars = ScrollBars.Vertical;
            tB_showGCode.Size = new Size(274, 359);
            tB_showGCode.TabIndex = 13;
            // 
            // label1
            // 
            label1.AccessibleDescription = "Lalelu";
            label1.AccessibleName = "Aproxywert für Bilderkennung";
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 374);
            label1.Name = "label1";
            label1.Size = new Size(112, 19);
            label1.TabIndex = 16;
            label1.Text = "Aproxywert in px";
            // 
            // HistoryDisplayBox
            // 
            HistoryDisplayBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HistoryDisplayBox.BackColor = Color.FromArgb(64, 64, 64);
            HistoryDisplayBox.ForeColor = Color.White;
            HistoryDisplayBox.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            HistoryDisplayBox.Location = new Point(9, 7);
            HistoryDisplayBox.Margin = new Padding(0);
            HistoryDisplayBox.MultiSelect = false;
            HistoryDisplayBox.Name = "HistoryDisplayBox";
            HistoryDisplayBox.RightToLeft = RightToLeft.No;
            HistoryDisplayBox.Size = new Size(274, 175);
            HistoryDisplayBox.TabIndex = 17;
            HistoryDisplayBox.TileSize = new Size(150, 10);
            HistoryDisplayBox.UseCompatibleStateImageBehavior = false;
            HistoryDisplayBox.View = View.Details;
            HistoryDisplayBox.DoubleClick += HistoryDisplayBox_Enter;
            HistoryDisplayBox.Enter += HistoryDisplayBox_Enter;
            HistoryDisplayBox.KeyDown += ContourListBox_KeyDown;
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
            ProjectSaveButton.Location = new Point(11, 468);
            ProjectSaveButton.Margin = new Padding(3, 2, 3, 2);
            ProjectSaveButton.Name = "ProjectSaveButton";
            ProjectSaveButton.Size = new Size(148, 30);
            ProjectSaveButton.TabIndex = 18;
            ProjectSaveButton.Text = "Project Speichern";
            ProjectSaveButton.UseVisualStyleBackColor = false;
            ProjectSaveButton.Click += ProjectSaveButton_Click;
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.FromArgb(64, 64, 64);
            panelSideBar.Controls.Add(btn_ContLösch);
            panelSideBar.Controls.Add(checkBox1);
            panelSideBar.Controls.Add(ContourListBox);
            panelSideBar.Controls.Add(tB_aproxy);
            panelSideBar.Controls.Add(label10);
            panelSideBar.Controls.Add(Settings);
            panelSideBar.Controls.Add(panel1);
            panelSideBar.Controls.Add(Btn_Setting);
            panelSideBar.Controls.Add(btn_Clear);
            panelSideBar.Controls.Add(DeleteButton);
            panelSideBar.Controls.Add(ProjectSaveButton);
            panelSideBar.Controls.Add(tB_X);
            panelSideBar.Controls.Add(btn_GenerateGCode);
            panelSideBar.Controls.Add(label1);
            panelSideBar.Controls.Add(tB_Y);
            panelSideBar.Controls.Add(tB_Z);
            panelSideBar.Controls.Add(lbl_X);
            panelSideBar.Controls.Add(lbl_depth);
            panelSideBar.Controls.Add(btn_DownloadGCode);
            panelSideBar.Controls.Add(lbl_Z);
            panelSideBar.Controls.Add(tB_depth);
            panelSideBar.Controls.Add(lbl_Y);
            panelSideBar.Controls.Add(btnLogo);
            panelSideBar.Dock = DockStyle.Left;
            panelSideBar.Location = new Point(0, 0);
            panelSideBar.Margin = new Padding(9, 2, 3, 2);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(308, 547);
            panelSideBar.TabIndex = 19;
            // 
            // btn_ContLösch
            // 
            btn_ContLösch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_ContLösch.BackColor = Color.DarkCyan;
            btn_ContLösch.BackgroundImageLayout = ImageLayout.Center;
            btn_ContLösch.FlatAppearance.BorderSize = 0;
            btn_ContLösch.FlatStyle = FlatStyle.Flat;
            btn_ContLösch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ContLösch.ForeColor = SystemColors.ButtonHighlight;
            btn_ContLösch.Location = new Point(23, 46);
            btn_ContLösch.Margin = new Padding(3, 2, 3, 2);
            btn_ContLösch.Name = "btn_ContLösch";
            btn_ContLösch.Size = new Size(148, 23);
            btn_ContLösch.TabIndex = 25;
            btn_ContLösch.Text = "Contour Löschen";
            btn_ContLösch.UseVisualStyleBackColor = false;
            btn_ContLösch.Visible = false;
            btn_ContLösch.Click += btn_ContLösch_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatAppearance.BorderColor = Color.Silver;
            checkBox1.FlatAppearance.BorderSize = 10;
            checkBox1.FlatAppearance.CheckedBackColor = Color.FromArgb(64, 64, 64);
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(194, 7);
            checkBox1.Margin = new Padding(3, 2, 3, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(85, 19);
            checkBox1.TabIndex = 24;
            checkBox1.Text = "ContourList";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // ContourListBox
            // 
            ContourListBox.BackColor = Color.FromArgb(64, 64, 64);
            ContourListBox.ForeColor = Color.WhiteSmoke;
            ContourListBox.FormattingEnabled = true;
            ContourListBox.ItemHeight = 15;
            ContourListBox.Location = new Point(191, 29);
            ContourListBox.Margin = new Padding(3, 2, 3, 2);
            ContourListBox.Name = "ContourListBox";
            ContourListBox.RightToLeft = RightToLeft.No;
            ContourListBox.Size = new Size(97, 199);
            ContourListBox.TabIndex = 23;
            ContourListBox.Visible = false;
            ContourListBox.SelectedIndexChanged += listBox1_Click;
            ContourListBox.KeyDown += ContourListBox_KeyDown;
            ContourListBox.KeyPress += ContourListBox_KeyPress;
            // 
            // tB_aproxy
            // 
            tB_aproxy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tB_aproxy.BackColor = SystemColors.InactiveCaptionText;
            tB_aproxy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tB_aproxy.ForeColor = Color.White;
            tB_aproxy.ImeMode = ImeMode.On;
            tB_aproxy.Location = new Point(191, 376);
            tB_aproxy.Margin = new Padding(3, 2, 3, 2);
            tB_aproxy.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            tB_aproxy.MaximumSize = new Size(96, 0);
            tB_aproxy.Name = "tB_aproxy";
            tB_aproxy.RightToLeft = RightToLeft.No;
            tB_aproxy.Size = new Size(96, 25);
            tB_aproxy.TabIndex = 21;
            tB_aproxy.TextAlign = HorizontalAlignment.Center;
            tB_aproxy.UpDownAlign = LeftRightAlignment.Left;
            tB_aproxy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            tB_aproxy.ValueChanged += tB_aproxy_TextChanged;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(10, 260);
            label10.Name = "label10";
            label10.Size = new Size(161, 19);
            label10.TabIndex = 43;
            label10.Text = "Materialeigenschaften:";
            // 
            // Settings
            // 
            Settings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Settings.Controls.Add(label3);
            Settings.Controls.Add(textBox1);
            Settings.Controls.Add(textBox2);
            Settings.Controls.Add(label7);
            Settings.Controls.Add(label8);
            Settings.Controls.Add(textBox3);
            Settings.Controls.Add(label9);
            Settings.Controls.Add(label2);
            Settings.Controls.Add(textBox4);
            Settings.Controls.Add(textBox5);
            Settings.Controls.Add(label4);
            Settings.Controls.Add(label5);
            Settings.Controls.Add(textBox6);
            Settings.Controls.Add(label6);
            Settings.Location = new Point(12, 48);
            Settings.Margin = new Padding(3, 2, 3, 2);
            Settings.Name = "Settings";
            Settings.Size = new Size(279, 195);
            Settings.TabIndex = 23;
            Settings.Visible = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(5, 76);
            label3.Name = "label3";
            label3.Size = new Size(151, 19);
            label3.TabIndex = 53;
            label3.Text = "Höhe (Schneide) in mm";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.InactiveCaptionText;
            textBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(178, 74);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.MaximumSize = new Size(97, 27);
            textBox1.Name = "textBox1";
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.Size = new Size(97, 25);
            textBox1.TabIndex = 52;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox2.BackColor = SystemColors.InactiveCaptionText;
            textBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(178, 28);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.MaximumSize = new Size(97, 27);
            textBox2.Name = "textBox2";
            textBox2.RightToLeft = RightToLeft.No;
            textBox2.Size = new Size(97, 25);
            textBox2.TabIndex = 47;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(5, 53);
            label7.Name = "label7";
            label7.Size = new Size(132, 19);
            label7.TabIndex = 51;
            label7.Text = "Durchmesser in mm";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(4, 30);
            label8.Name = "label8";
            label8.Size = new Size(45, 19);
            label8.TabIndex = 50;
            label8.Text = "Name";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox3.BackColor = SystemColors.InactiveCaptionText;
            textBox3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(178, 51);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.MaximumSize = new Size(97, 27);
            textBox3.Name = "textBox3";
            textBox3.RightToLeft = RightToLeft.No;
            textBox3.Size = new Size(97, 25);
            textBox3.TabIndex = 48;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(4, 7);
            label9.Name = "label9";
            label9.Size = new Size(119, 19);
            label9.TabIndex = 49;
            label9.Text = "Fräß-/Bohrkopf:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(5, 169);
            label2.Name = "label2";
            label2.Size = new Size(105, 19);
            label2.TabIndex = 46;
            label2.Text = "Z (Höhe) in mm";
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox4.BackColor = SystemColors.InactiveCaptionText;
            textBox4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.ForeColor = Color.White;
            textBox4.Location = new Point(178, 166);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.MaximumSize = new Size(97, 27);
            textBox4.Name = "textBox4";
            textBox4.RightToLeft = RightToLeft.No;
            textBox4.Size = new Size(97, 25);
            textBox4.TabIndex = 45;
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox5.BackColor = SystemColors.InactiveCaptionText;
            textBox5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.ForeColor = Color.White;
            textBox5.Location = new Point(178, 120);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.MaximumSize = new Size(97, 27);
            textBox5.Name = "textBox5";
            textBox5.RightToLeft = RightToLeft.No;
            textBox5.Size = new Size(97, 25);
            textBox5.TabIndex = 40;
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(5, 146);
            label4.Name = "label4";
            label4.Size = new Size(100, 19);
            label4.TabIndex = 44;
            label4.Text = "Y (Tiefe) in mm";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(4, 122);
            label5.Name = "label5";
            label5.Size = new Size(107, 19);
            label5.TabIndex = 43;
            label5.Text = "X (Breite) in mm";
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox6.BackColor = SystemColors.InactiveCaptionText;
            textBox6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox6.ForeColor = Color.White;
            textBox6.Location = new Point(178, 143);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.MaximumSize = new Size(97, 27);
            textBox6.Name = "textBox6";
            textBox6.RightToLeft = RightToLeft.No;
            textBox6.Size = new Size(97, 25);
            textBox6.TabIndex = 41;
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(4, 99);
            label6.Name = "label6";
            label6.Size = new Size(101, 19);
            label6.TabIndex = 42;
            label6.Text = "Arbeitsfläche:";
            // 
            // panel1
            // 
            panel1.Location = new Point(449, 217);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 94);
            panel1.TabIndex = 0;
            // 
            // Btn_Setting
            // 
            Btn_Setting.BackColor = Color.Transparent;
            Btn_Setting.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
            Btn_Setting.FlatAppearance.BorderSize = 0;
            Btn_Setting.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Btn_Setting.FlatAppearance.MouseOverBackColor = Color.FromArgb(74, 74, 74);
            Btn_Setting.FlatStyle = FlatStyle.Flat;
            Btn_Setting.Image = (Image)resources.GetObject("Btn_Setting.Image");
            Btn_Setting.Location = new Point(10, 9);
            Btn_Setting.Margin = new Padding(3, 2, 3, 2);
            Btn_Setting.Name = "Btn_Setting";
            Btn_Setting.Size = new Size(26, 22);
            Btn_Setting.TabIndex = 22;
            Btn_Setting.UseVisualStyleBackColor = false;
            Btn_Setting.Click += Btn_Setting_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Clear.BackColor = Color.Black;
            btn_Clear.BackgroundImageLayout = ImageLayout.Center;
            btn_Clear.FlatAppearance.BorderSize = 0;
            btn_Clear.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 24, 24);
            btn_Clear.FlatStyle = FlatStyle.Flat;
            btn_Clear.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Clear.ForeColor = SystemColors.ButtonHighlight;
            btn_Clear.Location = new Point(186, 424);
            btn_Clear.Margin = new Padding(3, 2, 3, 2);
            btn_Clear.Name = "btn_Clear";
            btn_Clear.Size = new Size(96, 33);
            btn_Clear.TabIndex = 21;
            btn_Clear.Text = "Clear";
            btn_Clear.UseVisualStyleBackColor = false;
            btn_Clear.Click += btnLogo_Click;
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
            DeleteButton.Location = new Point(11, 508);
            DeleteButton.Margin = new Padding(3, 2, 3, 2);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(148, 30);
            DeleteButton.TabIndex = 20;
            DeleteButton.Text = "Project Entfernen";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // btnLogo
            // 
            btnLogo.BackgroundImage = (Image)resources.GetObject("btnLogo.BackgroundImage");
            btnLogo.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogo.Enabled = false;
            btnLogo.FlatAppearance.BorderSize = 0;
            btnLogo.FlatStyle = FlatStyle.Flat;
            btnLogo.ForeColor = Color.Transparent;
            btnLogo.Location = new Point(0, 38);
            btnLogo.Margin = new Padding(3, 2, 3, 2);
            btnLogo.Name = "btnLogo";
            btnLogo.Size = new Size(305, 125);
            btnLogo.TabIndex = 19;
            btnLogo.UseVisualStyleBackColor = true;
            // 
            // tB_advises
            // 
            tB_advises.BackColor = Color.Gray;
            tB_advises.BorderStyle = BorderStyle.None;
            tB_advises.Cursor = Cursors.Hand;
            tB_advises.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            tB_advises.ForeColor = Color.Black;
            tB_advises.HideSelection = false;
            tB_advises.Location = new Point(321, 10);
            tB_advises.Margin = new Padding(3, 2, 3, 2);
            tB_advises.Multiline = true;
            tB_advises.Name = "tB_advises";
            tB_advises.RightToLeft = RightToLeft.No;
            tB_advises.Size = new Size(558, 513);
            tB_advises.TabIndex = 20;
            tB_advises.Text = resources.GetString("tB_advises.Text");
            tB_advises.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(HistoryDisplayBox);
            panel2.Controls.Add(tB_showGCode);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(902, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(290, 547);
            panel2.TabIndex = 20;
            // 
            // btn_ShowAdvises
            // 
            btn_ShowAdvises.BackColor = Color.Gray;
            btn_ShowAdvises.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
            btn_ShowAdvises.FlatAppearance.BorderSize = 0;
            btn_ShowAdvises.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_ShowAdvises.FlatAppearance.MouseOverBackColor = Color.Gray;
            btn_ShowAdvises.FlatStyle = FlatStyle.Flat;
            btn_ShowAdvises.Image = (Image)resources.GetObject("btn_ShowAdvises.Image");
            btn_ShowAdvises.Location = new Point(859, 6);
            btn_ShowAdvises.Margin = new Padding(3, 2, 3, 2);
            btn_ShowAdvises.Name = "btn_ShowAdvises";
            btn_ShowAdvises.Size = new Size(26, 22);
            btn_ShowAdvises.TabIndex = 23;
            btn_ShowAdvises.UseVisualStyleBackColor = false;
            btn_ShowAdvises.Click += btn_ShowAdvises_Click;
            // 
            // I2Gcode
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1192, 547);
            Controls.Add(btn_ShowAdvises);
            Controls.Add(panel2);
            Controls.Add(lbl_DragDrop);
            Controls.Add(panelSideBar);
            Controls.Add(tB_advises);
            Controls.Add(pB_DragDrop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(6129, 2830);
            Name = "I2Gcode";
            Opacity = 0.995D;
            Text = "I2G-Code";
            FormClosing += LastForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).EndInit();
            panelSideBar.ResumeLayout(false);
            panelSideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tB_aproxy).EndInit();
            Settings.ResumeLayout(false);
            Settings.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label label1;
        private ListView HistoryDisplayBox;
        private Button Btn_Setting;
        private Button ProjectSaveButton;
        private Panel panelSideBar;
        private Button btnLogo;
        private Button DeleteButton;
        private Button btn_Clear;
        private Panel Settings;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label7;
        private Label label8;
        private TextBox textBox3;
        private Label label9;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label4;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private Panel panel1;
        private Label label10;
        private Panel panel2;
        private NumericUpDown tB_aproxy;
        private ListBox ContourListBox;
        private CheckBox checkBox1;
        private Button btn_ContLösch;
        private ToolTip AproxyToolTip;
        private TextBox tB_advises;
        private Button btn_ShowAdvises;
    }
}