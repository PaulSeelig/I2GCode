﻿namespace GUI_I2G
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
            ((System.ComponentModel.ISupportInitialize)pB_DragDrop).BeginInit();
            SuspendLayout();
            // 
            // btn_GenerateGCode
            // 
            btn_GenerateGCode.BackColor = SystemColors.ControlDark;
            btn_GenerateGCode.Location = new Point(77, 323);
            btn_GenerateGCode.Margin = new Padding(3, 2, 3, 2);
            btn_GenerateGCode.Name = "btn_GenerateGCode";
            btn_GenerateGCode.Size = new Size(169, 45);
            btn_GenerateGCode.TabIndex = 0;
            btn_GenerateGCode.Text = "G-Code generieren";
            btn_GenerateGCode.UseVisualStyleBackColor = false;
            btn_GenerateGCode.Click += button1_Click;
            // 
            // pB_DragDrop
            // 
            pB_DragDrop.BackColor = SystemColors.GradientInactiveCaption;
            pB_DragDrop.Location = new Point(10, 9);
            pB_DragDrop.Margin = new Padding(3, 2, 3, 2);
            pB_DragDrop.Name = "pB_DragDrop";
            pB_DragDrop.Size = new Size(679, 116);
            pB_DragDrop.TabIndex = 1;
            pB_DragDrop.TabStop = false;
            // 
            // lbl_DragDrop
            // 
            lbl_DragDrop.AutoSize = true;
            lbl_DragDrop.Location = new Point(241, 98);
            lbl_DragDrop.Name = "lbl_DragDrop";
            lbl_DragDrop.Size = new Size(194, 15);
            lbl_DragDrop.TabIndex = 2;
            lbl_DragDrop.Text = "Bild hier via Drag n Drop hochladen";
            // 
            // tB_Y
            // 
            tB_Y.Location = new Point(136, 225);
            tB_Y.Margin = new Padding(3, 2, 3, 2);
            tB_Y.Name = "tB_Y";
            tB_Y.Size = new Size(110, 23);
            tB_Y.TabIndex = 4;
            // 
            // tB_Z
            // 
            tB_Z.Location = new Point(136, 250);
            tB_Z.Margin = new Padding(3, 2, 3, 2);
            tB_Z.Name = "tB_Z";
            tB_Z.Size = new Size(110, 23);
            tB_Z.TabIndex = 5;
            // 
            // lbl_X
            // 
            lbl_X.AutoSize = true;
            lbl_X.Location = new Point(44, 206);
            lbl_X.Name = "lbl_X";
            lbl_X.Size = new Size(71, 15);
            lbl_X.TabIndex = 6;
            lbl_X.Text = "X- Eckpunkt";
            // 
            // btn_DownloadGCode
            // 
            btn_DownloadGCode.BackColor = SystemColors.ControlDark;
            btn_DownloadGCode.Location = new Point(408, 323);
            btn_DownloadGCode.Name = "btn_DownloadGCode";
            btn_DownloadGCode.Size = new Size(169, 45);
            btn_DownloadGCode.TabIndex = 7;
            btn_DownloadGCode.Text = "G-Code downloaden";
            btn_DownloadGCode.UseVisualStyleBackColor = false;
            // 
            // tB_depth
            // 
            tB_depth.Location = new Point(136, 277);
            tB_depth.Margin = new Padding(3, 2, 3, 2);
            tB_depth.Name = "tB_depth";
            tB_depth.Size = new Size(110, 23);
            tB_depth.TabIndex = 8;
            tB_depth.TextChanged += textBox1_TextChanged;
            // 
            // tB_X
            // 
            tB_X.Location = new Point(136, 198);
            tB_X.Margin = new Padding(3, 2, 3, 2);
            tB_X.Name = "tB_X";
            tB_X.Size = new Size(110, 23);
            tB_X.TabIndex = 9;
            // 
            // lbl_Y
            // 
            lbl_Y.AutoSize = true;
            lbl_Y.Location = new Point(44, 233);
            lbl_Y.Name = "lbl_Y";
            lbl_Y.Size = new Size(71, 15);
            lbl_Y.TabIndex = 10;
            lbl_Y.Text = "Y- Eckpunkt";
            // 
            // lbl_Z
            // 
            lbl_Z.AutoSize = true;
            lbl_Z.Location = new Point(44, 258);
            lbl_Z.Name = "lbl_Z";
            lbl_Z.Size = new Size(71, 15);
            lbl_Z.TabIndex = 11;
            lbl_Z.Text = "Z- Eckpunkt";
            // 
            // lbl_depth
            // 
            lbl_depth.AutoSize = true;
            lbl_depth.Location = new Point(44, 285);
            lbl_depth.Name = "lbl_depth";
            lbl_depth.Size = new Size(67, 15);
            lbl_depth.TabIndex = 12;
            lbl_depth.Text = "Graviertiefe";
            // 
            // tB_showGCode
            // 
            tB_showGCode.Location = new Point(339, 198);
            tB_showGCode.Multiline = true;
            tB_showGCode.Name = "tB_showGCode";
            tB_showGCode.Size = new Size(315, 119);
            tB_showGCode.TabIndex = 13;
            // 
            // lbl_showGCode
            // 
            lbl_showGCode.AutoSize = true;
            lbl_showGCode.Location = new Point(445, 180);
            lbl_showGCode.Name = "lbl_showGCode";
            lbl_showGCode.Size = new Size(102, 15);
            lbl_showGCode.TabIndex = 14;
            lbl_showGCode.Text = "G-Code Vorschau:";
            // 
            // I2Gcode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 406);
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
            Name = "I2Gcode";
            Text = "I2G-Code";
            Load += I2Gcode_Load;
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
    }
}