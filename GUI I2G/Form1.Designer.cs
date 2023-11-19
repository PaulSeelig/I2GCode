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
            genButton = new Button();
            displayBox = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)displayBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            genButton.BackColor = SystemColors.MenuHighlight;
            genButton.Location = new Point(87, 335);
            genButton.Name = "button1";
            genButton.Size = new Size(193, 60);
            genButton.TabIndex = 0;
            genButton.Text = "G- Code generieren";
            genButton.UseVisualStyleBackColor = false;
            genButton.Click += button1_Click;
            // 
            // pictureBox1
            // 
            displayBox.BackColor = SystemColors.GradientInactiveCaption;
            displayBox.Location = new Point(12, 12);
            displayBox.Name = "pictureBox1";
            displayBox.Size = new Size(776, 154);
            displayBox.TabIndex = 1;
            displayBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(275, 130);
            label1.Name = "label1";
            label1.Size = new Size(247, 20);
            label1.TabIndex = 2;
            label1.Text = "Bild hier via Drag n Drop hochladen";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 216);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 249);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(155, 282);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 216);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 6;
            label2.Text = "X- Startwert";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(displayBox);
            Controls.Add(genButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)displayBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button genButton;
        private PictureBox displayBox;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label2;
    }
}