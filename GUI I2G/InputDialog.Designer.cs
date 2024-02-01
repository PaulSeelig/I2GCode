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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputDialog));
            InputTextBox = new TextBox();
            Confirm = new Button();
            Dialog_Label = new Label();
            SuspendLayout();
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(139, 63);
            InputTextBox.Margin = new Padding(3, 4, 3, 4);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(347, 27);
            InputTextBox.TabIndex = 0;
            // 
            // Confirm
            // 
            Confirm.BackColor = Color.DarkCyan;
            Confirm.FlatAppearance.BorderColor = Color.FromArgb(0, 64, 64);
            Confirm.FlatAppearance.MouseDownBackColor = Color.Teal;
            Confirm.FlatStyle = FlatStyle.Flat;
            Confirm.Location = new Point(266, 110);
            Confirm.Margin = new Padding(3, 4, 3, 4);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(111, 31);
            Confirm.TabIndex = 1;
            Confirm.Text = "Confirm";
            Confirm.UseVisualStyleBackColor = false;
            Confirm.Click += Confirm_Click;
            // 
            // Dialog_Label
            // 
            Dialog_Label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Dialog_Label.AutoSize = true;
            Dialog_Label.ForeColor = Color.White;
            Dialog_Label.Location = new Point(139, 28);
            Dialog_Label.Name = "Dialog_Label";
            Dialog_Label.Size = new Size(126, 20);
            Dialog_Label.TabIndex = 2;
            Dialog_Label.Text = "Name Thy Project";
            Dialog_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(618, 160);
            Controls.Add(Dialog_Label);
            Controls.Add(Confirm);
            Controls.Add(InputTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputDialog";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
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