namespace SuperMetroidPaletteTool
{
    partial class FormAskToClose
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
            label1 = new System.Windows.Forms.Label();
            checkBoxDoNotAsk = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(386, 45);
            label1.TabIndex = 3;
            label1.Text = ("Are you sure you want to close the application?\r\n\r\nThis message box is here to pr" + "event accidentally closing the application.");
            // 
            // checkBoxDoNotAsk
            // 
            checkBoxDoNotAsk.AutoSize = true;
            checkBoxDoNotAsk.Location = new System.Drawing.Point(12, 82);
            checkBoxDoNotAsk.Name = "checkBoxDoNotAsk";
            checkBoxDoNotAsk.Size = new System.Drawing.Size(176, 19);
            checkBoxDoNotAsk.TabIndex = 2;
            checkBoxDoNotAsk.Text = "Do not ask to confirm again.";
            checkBoxDoNotAsk.UseVisualStyleBackColor = true;
            checkBoxDoNotAsk.CheckedChanged += checkBoxDoNotAsk_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(242, 106);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Yes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(323, 106);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 0;
            button2.Text = "No";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormAskToClose
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(415, 140);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBoxDoNotAsk);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = " ";
            TopMost = true;
            Load += FormAskToClose_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox checkBoxDoNotAsk;
        private Button button1;
        private Button button2;
    }
}