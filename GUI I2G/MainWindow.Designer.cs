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
            lbl_showGCode = new Label();
            tB_aproxy = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).BeginInit();
            SuspendLayout();
            // 
            // btn_GenerateGCode
            // 
            btn_GenerateGCode.BackColor = SystemColors.ButtonHighlight;
            btn_GenerateGCode.FlatAppearance.BorderSize = 0;
            btn_GenerateGCode.FlatStyle = FlatStyle.Flat;
            btn_GenerateGCode.Image = (Image)resources.GetObject("btn_GenerateGCode.Image");
            btn_GenerateGCode.Location = new Point(29, 509);
            btn_GenerateGCode.Margin = new Padding(3, 2, 3, 2);
            btn_GenerateGCode.Name = "btn_GenerateGCode";
            btn_GenerateGCode.Size = new Size(239, 83);
            btn_GenerateGCode.TabIndex = 0;
            btn_GenerateGCode.Text = "G-Code generieren";
            btn_GenerateGCode.TextAlign = ContentAlignment.BottomCenter;
            btn_GenerateGCode.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_GenerateGCode.UseVisualStyleBackColor = false;
            btn_GenerateGCode.Click += button1_Click;
            // 
            // pB_DragDrop
            // 
            pB_DragDrop.BackColor = SystemColors.GradientInactiveCaption;
            pB_DragDrop.BackgroundImageLayout = ImageLayout.None;
            pB_DragDrop.Dock = DockStyle.Top;
            pB_DragDrop.Location = new Point(0, 0);
            pB_DragDrop.Margin = new Padding(3, 2, 3, 2);
            pB_DragDrop.Name = "pB_DragDrop";
            pB_DragDrop.Size = new Size(827, 148);
            pB_DragDrop.SizeMode = PictureBoxSizeMode.Zoom;
            pB_DragDrop.TabIndex = 1;
            pB_DragDrop.TabStop = false;
            pB_DragDrop.SizeChanged += pB_DragDrop_SizeChanged;
            pB_DragDrop.Click += pB_DragDrop_Click;
            pB_DragDrop.DragDrop += pB_DragDrop_DragDrop;
            pB_DragDrop.DragEnter += pB_DragDrop_DragEnter;
            // 
            // lbl_DragDrop
            // 
            lbl_DragDrop.AutoSize = true;
            lbl_DragDrop.Location = new Point(241, 98);
            lbl_DragDrop.Name = "lbl_DragDrop";
            lbl_DragDrop.Size = new Size(247, 20);
            lbl_DragDrop.TabIndex = 2;
            lbl_DragDrop.Text = "Bild hier via Drag n Drop hochladen";
            lbl_DragDrop.DragDrop += pB_DragDrop_DragDrop;
            lbl_DragDrop.DragEnter += pB_DragDrop_DragEnter;
            // 
            // tB_Y
            // 
            tB_Y.Location = new Point(158, 385);
            tB_Y.Margin = new Padding(3, 2, 3, 2);
            tB_Y.Name = "tB_Y";
            tB_Y.Size = new Size(110, 27);
            tB_Y.TabIndex = 4;
            // 
            // tB_Z
            // 
            tB_Z.Location = new Point(158, 416);
            tB_Z.Margin = new Padding(3, 2, 3, 2);
            tB_Z.Name = "tB_Z";
            tB_Z.Size = new Size(110, 27);
            tB_Z.TabIndex = 5;
            // 
            // lbl_X
            // 
            lbl_X.AutoSize = true;
            lbl_X.Location = new Point(12, 357);
            lbl_X.Name = "lbl_X";
            lbl_X.Size = new Size(133, 20);
            lbl_X.TabIndex = 6;
            lbl_X.Text = "X- Eckpunkt in mm";
            // 
            // btn_DownloadGCode
            // 
            btn_DownloadGCode.BackColor = SystemColors.ButtonHighlight;
            btn_DownloadGCode.BackgroundImageLayout = ImageLayout.Center;
            btn_DownloadGCode.FlatAppearance.BorderSize = 0;
            btn_DownloadGCode.FlatStyle = FlatStyle.Flat;
            btn_DownloadGCode.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn_DownloadGCode.Image = (Image)resources.GetObject("btn_DownloadGCode.Image");
            btn_DownloadGCode.Location = new Point(459, 509);
            btn_DownloadGCode.Name = "btn_DownloadGCode";
            btn_DownloadGCode.Size = new Size(239, 83);
            btn_DownloadGCode.TabIndex = 7;
            btn_DownloadGCode.Text = "G-Code downloaden";
            btn_DownloadGCode.TextAlign = ContentAlignment.BottomCenter;
            btn_DownloadGCode.TextImageRelation = TextImageRelation.ImageAboveText;
            btn_DownloadGCode.UseVisualStyleBackColor = false;
            btn_DownloadGCode.Click += btn_DownloadGCode_Click;
            // 
            // tB_depth
            // 
            tB_depth.Location = new Point(158, 447);
            tB_depth.Margin = new Padding(3, 2, 3, 2);
            tB_depth.Name = "tB_depth";
            tB_depth.Size = new Size(110, 27);
            tB_depth.TabIndex = 8;
            // 
            // tB_X
            // 
            tB_X.Location = new Point(158, 354);
            tB_X.Margin = new Padding(3, 2, 3, 2);
            tB_X.Name = "tB_X";
            tB_X.Size = new Size(110, 27);
            tB_X.TabIndex = 9;
            // 
            // lbl_Y
            // 
            lbl_Y.AutoSize = true;
            lbl_Y.Location = new Point(12, 388);
            lbl_Y.Name = "lbl_Y";
            lbl_Y.Size = new Size(132, 20);
            lbl_Y.TabIndex = 10;
            lbl_Y.Text = "Y- Eckpunkt in mm";
            // 
            // lbl_Z
            // 
            lbl_Z.AutoSize = true;
            lbl_Z.Location = new Point(12, 419);
            lbl_Z.Name = "lbl_Z";
            lbl_Z.Size = new Size(133, 20);
            lbl_Z.TabIndex = 11;
            lbl_Z.Text = "Z- Eckpunkt in mm";
            // 
            // lbl_depth
            // 
            lbl_depth.AutoSize = true;
            lbl_depth.Location = new Point(13, 450);
            lbl_depth.Name = "lbl_depth";
            lbl_depth.Size = new Size(132, 20);
            lbl_depth.TabIndex = 12;
            lbl_depth.Text = "Graviertiefe in mm";
            // 
            // tB_showGCode
            // 
            tB_showGCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tB_showGCode.BackColor = SystemColors.Window;
            tB_showGCode.Location = new Point(345, 177);
            tB_showGCode.Multiline = true;
            tB_showGCode.Name = "tB_showGCode";
            tB_showGCode.ReadOnly = true;
            tB_showGCode.ScrollBars = ScrollBars.Both;
            tB_showGCode.Size = new Size(455, 317);
            tB_showGCode.TabIndex = 13;
            // 
            // lbl_showGCode
            // 
            lbl_showGCode.AutoSize = true;
            lbl_showGCode.Location = new Point(484, 177);
            lbl_showGCode.Name = "lbl_showGCode";
            lbl_showGCode.Size = new Size(126, 20);
            lbl_showGCode.TabIndex = 14;
            lbl_showGCode.Text = "G-Code Vorschau:";
            lbl_showGCode.Click += lbl_showGCode_Click;
            // 
            // tB_aproxy
            // 
            tB_aproxy.Location = new Point(158, 478);
            tB_aproxy.Margin = new Padding(3, 2, 3, 2);
            tB_aproxy.Name = "tB_aproxy";
            tB_aproxy.Size = new Size(110, 27);
            tB_aproxy.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 481);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 16;
            label1.Text = "Aproxwert in px";
            // 
            // I2Gcode
            // 
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(827, 603);
            Controls.Add(label1);
            Controls.Add(tB_aproxy);
            Controls.Add(lbl_showGCode);
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
            Text = "I2G-Code";
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
        private Label lbl_showGCode;
        private TextBox textBox1;
        private Label label1;
        private TextBox tb_aproxy;
        private TextBox tB_aproxy;
    }
}