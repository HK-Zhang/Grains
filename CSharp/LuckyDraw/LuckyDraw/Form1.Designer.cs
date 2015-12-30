namespace LuckyDraw
{
    partial class Form1
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
            this.lblLucky = new System.Windows.Forms.Label();
            this.btnControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLucky
            // 
            this.lblLucky.AutoSize = true;
            this.lblLucky.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLucky.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLucky.Location = new System.Drawing.Point(0, 0);
            this.lblLucky.Name = "lblLucky";
            this.lblLucky.Size = new System.Drawing.Size(0, 108);
            this.lblLucky.TabIndex = 0;
            // 
            // btnControl
            // 
            this.btnControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnControl.Location = new System.Drawing.Point(0, 239);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(284, 23);
            this.btnControl.TabIndex = 1;
            this.btnControl.Text = "START";
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.lblLucky);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lucky Draw";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLucky;
        private System.Windows.Forms.Button btnControl;
    }
}

