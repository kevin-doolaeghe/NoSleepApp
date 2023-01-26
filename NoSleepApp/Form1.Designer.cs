
namespace NoSleepApp {

    partial class SleepForm {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.sleepButton = new System.Windows.Forms.Button();
            this.disableMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sleepButton
            // 
            this.sleepButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sleepButton.Location = new System.Drawing.Point(77, 12);
            this.sleepButton.Name = "sleepButton";
            this.sleepButton.Size = new System.Drawing.Size(75, 23);
            this.sleepButton.TabIndex = 0;
            this.sleepButton.Text = "Stop sleep";
            this.sleepButton.UseVisualStyleBackColor = true;
            this.sleepButton.Click += new System.EventHandler(this.OnSleepButtonClick);
            // 
            // disableMessageLabel
            // 
            this.disableMessageLabel.AutoSize = true;
            this.disableMessageLabel.Location = new System.Drawing.Point(29, 38);
            this.disableMessageLabel.Name = "disableMessageLabel";
            this.disableMessageLabel.Size = new System.Drawing.Size(168, 15);
            this.disableMessageLabel.TabIndex = 1;
            this.disableMessageLabel.Text = "Press Ctrl+C to disable service.";
            // 
            // SleepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 65);
            this.Controls.Add(this.disableMessageLabel);
            this.Controls.Add(this.sleepButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SleepForm";
            this.ShowInTaskbar = false;
            this.Text = "NoSleepApp";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sleepButton;
        private System.Windows.Forms.Label disableMessageLabel;
    }
}

