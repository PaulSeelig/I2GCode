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
            genButton = new Button();
            displayBox = new PictureBox();
            Instructions = new Label();
            Xcordfield = new TextBox();
            TBDycord = new TextBox();
            TBDzcord = new TextBox();
            Xlabel = new Label();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            SuspendLayout();
            // 
            // genButton
            // 
            genButton.BackColor = SystemColors.MenuHighlight;
            genButton.Location = new Point(76, 251);
            genButton.Margin = new Padding(3, 2, 3, 2);
            genButton.Name = "genButton";
            genButton.Size = new Size(169, 45);
            genButton.TabIndex = 0;
            genButton.Text = "G- Code generieren";
            genButton.UseVisualStyleBackColor = false;
            genButton.Click += button1_Click;
            // 
            // displayBox
            // 
            displayBox.BackColor = SystemColors.GradientInactiveCaption;
            displayBox.Location = new Point(10, 9);
            displayBox.Margin = new Padding(3, 2, 3, 2);
            displayBox.Name = "displayBox";
            displayBox.Size = new Size(679, 116);
            displayBox.TabIndex = 1;
            displayBox.TabStop = false;
            // 
            // Instructions
            // 
            Instructions.AutoSize = true;
            Instructions.Location = new Point(241, 98);
            Instructions.Name = "Instructions";
            Instructions.Size = new Size(194, 15);
            Instructions.TabIndex = 2;
            Instructions.Text = "Bild hier via Drag n Drop hochladen";
            // 
            // Xcordfield
            // 
            Xcordfield.Location = new Point(136, 162);
            Xcordfield.Margin = new Padding(3, 2, 3, 2);
            Xcordfield.Name = "Xcordfield";
            Xcordfield.Size = new Size(110, 23);
            Xcordfield.TabIndex = 3;
            // 
            // TBDycord
            // 
            TBDycord.Location = new Point(136, 187);
            TBDycord.Margin = new Padding(3, 2, 3, 2);
            TBDycord.Name = "TBDycord";
            TBDycord.Size = new Size(110, 23);
            TBDycord.TabIndex = 4;
            // 
            // TBDzcord
            // 
            TBDzcord.Location = new Point(136, 212);
            TBDzcord.Margin = new Padding(3, 2, 3, 2);
            TBDzcord.Name = "TBDzcord";
            TBDzcord.Size = new Size(110, 23);
            TBDzcord.TabIndex = 5;
            // 
            // Xlabel
            // 
            Xlabel.AutoSize = true;
            Xlabel.Location = new Point(37, 162);
            Xlabel.Name = "Xlabel";
            Xlabel.Size = new Size(69, 15);
            Xlabel.TabIndex = 6;
            Xlabel.Text = "X- Startwert";
            // 
            // I2Gcode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(Xlabel);
            Controls.Add(TBDzcord);
            Controls.Add(TBDycord);
            Controls.Add(Xcordfield);
            Controls.Add(Instructions);
            Controls.Add(displayBox);
            Controls.Add(genButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "I2Gcode";
            Text = "I2G-code";
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button genButton;
        private PictureBox displayBox;
        private Label Instructions;
        private TextBox Xcordfield;
        private TextBox TBDycord;
        private TextBox TBDzcord;
        private Label Xlabel;
    }
}