namespace GUI_I2G
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InputTextBox = new TextBox();
            Confirm = new Button();
            Dialog_Label = new Label();
            SuspendLayout();
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(130, 47);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(304, 23);
            InputTextBox.TabIndex = 0;
            InputTextBox.TextChanged += textBox1_TextChanged;
            // 
            // Confirm
            // 
            Confirm.Location = new Point(232, 76);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(97, 23);
            Confirm.TabIndex = 1;
            Confirm.Text = "Confirm";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += Confirm_Click;
            // 
            // Dialog_Label
            // 
            Dialog_Label.AutoSize = true;
            Dialog_Label.Location = new Point(232, 20);
            Dialog_Label.Name = "Dialog_Label";
            Dialog_Label.Size = new Size(101, 15);
            Dialog_Label.TabIndex = 2;
            Dialog_Label.Text = "Name Thy Project";
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(541, 120);
            Controls.Add(Dialog_Label);
            Controls.Add(Confirm);
            Controls.Add(InputTextBox);
            Name = "InputDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Save";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputTextBox;
        private Button Confirm;
        private Label Dialog_Label;
    }
}