namespace GUI_I2G
{
    partial class Form1
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
            BtngenrateGCode = new Button();
            PbBildDnD = new PictureBox();
            LbtBDnD = new Label();
            tBXKoo = new TextBox();
            tBYKoo = new TextBox();
            tBZKoo = new TextBox();
            LbXKoo = new Label();
            LbYKoo = new Label();
            LbZKoo = new Label();
            TbGCodeVorschau = new TextBox();
            LbGCodeVorschau = new Label();
            BtndownloadGCode = new Button();
            LbGraviertiefe = new Label();
            tBGraviertiefe = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PbBildDnD).BeginInit();
            SuspendLayout();
            // 
            // BtngenrateGCode
            // 
            BtngenrateGCode.BackColor = SystemColors.ButtonShadow;
            BtngenrateGCode.Location = new Point(87, 354);
            BtngenrateGCode.Name = "BtngenrateGCode";
            BtngenrateGCode.Size = new Size(193, 60);
            BtngenrateGCode.TabIndex = 0;
            BtngenrateGCode.Text = "G- Code generieren";
            BtngenrateGCode.UseVisualStyleBackColor = false;
            BtngenrateGCode.Click += button1_Click;
            // 
            // PbBildDnD
            // 
            PbBildDnD.BackColor = SystemColors.GradientInactiveCaption;
            PbBildDnD.Location = new Point(12, 12);
            PbBildDnD.Name = "PbBildDnD";
            PbBildDnD.Size = new Size(776, 154);
            PbBildDnD.TabIndex = 1;
            PbBildDnD.TabStop = false;
            // 
            // LbtBDnD
            // 
            LbtBDnD.AutoSize = true;
            LbtBDnD.Location = new Point(275, 130);
            LbtBDnD.Name = "LbtBDnD";
            LbtBDnD.Size = new Size(247, 20);
            LbtBDnD.TabIndex = 2;
            LbtBDnD.Text = "Bild hier via Drag n Drop hochladen";
            // 
            // tBXKoo
            // 
            tBXKoo.Location = new Point(187, 216);
            tBXKoo.Name = "tBXKoo";
            tBXKoo.Size = new Size(125, 27);
            tBXKoo.TabIndex = 3;
            // 
            // tBYKoo
            // 
            tBYKoo.Location = new Point(187, 249);
            tBYKoo.Name = "tBYKoo";
            tBYKoo.Size = new Size(125, 27);
            tBYKoo.TabIndex = 4;
            // 
            // tBZKoo
            // 
            tBZKoo.Location = new Point(187, 282);
            tBZKoo.Name = "tBZKoo";
            tBZKoo.Size = new Size(125, 27);
            tBZKoo.TabIndex = 5;
            // 
            // LbXKoo
            // 
            LbXKoo.AutoSize = true;
            LbXKoo.Location = new Point(73, 216);
            LbXKoo.Name = "LbXKoo";
            LbXKoo.Size = new Size(90, 20);
            LbXKoo.TabIndex = 6;
            LbXKoo.Text = "X- Eckpunkt:";
            LbXKoo.Click += lbXKoo_Click;
            // 
            // LbYKoo
            // 
            LbYKoo.AutoSize = true;
            LbYKoo.Location = new Point(74, 249);
            LbYKoo.Name = "LbYKoo";
            LbYKoo.Size = new Size(89, 20);
            LbYKoo.TabIndex = 7;
            LbYKoo.Text = "Y- Eckpunkt:";
            // 
            // LbZKoo
            // 
            LbZKoo.AutoSize = true;
            LbZKoo.Location = new Point(74, 282);
            LbZKoo.Name = "LbZKoo";
            LbZKoo.Size = new Size(90, 20);
            LbZKoo.TabIndex = 8;
            LbZKoo.Text = "Z- Eckpunkt:";
            // 
            // TbGCodeVorschau
            // 
            TbGCodeVorschau.Location = new Point(436, 213);
            TbGCodeVorschau.Multiline = true;
            TbGCodeVorschau.Name = "TbGCodeVorschau";
            TbGCodeVorschau.Size = new Size(352, 135);
            TbGCodeVorschau.TabIndex = 9;
            // 
            // LbGCodeVorschau
            // 
            LbGCodeVorschau.AutoSize = true;
            LbGCodeVorschau.Location = new Point(552, 190);
            LbGCodeVorschau.Name = "LbGCodeVorschau";
            LbGCodeVorschau.Size = new Size(130, 20);
            LbGCodeVorschau.TabIndex = 10;
            LbGCodeVorschau.Text = "G- Code Vorschau:";
            // 
            // BtndownloadGCode
            // 
            BtndownloadGCode.BackColor = SystemColors.ButtonShadow;
            BtndownloadGCode.Location = new Point(512, 354);
            BtndownloadGCode.Name = "BtndownloadGCode";
            BtndownloadGCode.Size = new Size(193, 60);
            BtndownloadGCode.TabIndex = 11;
            BtndownloadGCode.Text = "G- Code downloaden";
            BtndownloadGCode.UseVisualStyleBackColor = false;
            // 
            // LbGraviertiefe
            // 
            LbGraviertiefe.AutoSize = true;
            LbGraviertiefe.Location = new Point(73, 318);
            LbGraviertiefe.Name = "LbGraviertiefe";
            LbGraviertiefe.Size = new Size(89, 20);
            LbGraviertiefe.TabIndex = 13;
            LbGraviertiefe.Text = "Graviertiefe:";
            // 
            // tBGraviertiefe
            // 
            tBGraviertiefe.Location = new Point(186, 318);
            tBGraviertiefe.Name = "tBGraviertiefe";
            tBGraviertiefe.Size = new Size(125, 27);
            tBGraviertiefe.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LbGraviertiefe);
            Controls.Add(tBGraviertiefe);
            Controls.Add(BtndownloadGCode);
            Controls.Add(LbGCodeVorschau);
            Controls.Add(TbGCodeVorschau);
            Controls.Add(LbZKoo);
            Controls.Add(LbYKoo);
            Controls.Add(LbXKoo);
            Controls.Add(tBZKoo);
            Controls.Add(tBYKoo);
            Controls.Add(tBXKoo);
            Controls.Add(LbtBDnD);
            Controls.Add(PbBildDnD);
            Controls.Add(BtngenrateGCode);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PbBildDnD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtngenrateGCode;
        private PictureBox PbBildDnD;
        private Label LbtBDnD;
        private TextBox tBXKoo;
        private TextBox tBYKoo;
        private TextBox tBZKoo;
        private Label LbXKoo;
        private Label LbYKoo;
        private Label LbZKoo;
        private TextBox TbGCodeVorschau;
        private Label LbGCodeVorschau;
        private Button BtndownloadGCode;
        private Label LbGraviertiefe;
        private TextBox tBGraviertiefe;
    }
}