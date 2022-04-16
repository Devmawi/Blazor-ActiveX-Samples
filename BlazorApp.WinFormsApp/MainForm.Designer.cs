namespace TestWindowsFormsApp
{
    partial class MainForm
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
            this.blazorAppUserControl1 = new BlazorApp.WinFormsControls.BlazorAppUserControl();
            this.SuspendLayout();
            // 
            // blazorAppUserControl1
            // 
            this.blazorAppUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blazorAppUserControl1.Location = new System.Drawing.Point(0, 0);
            this.blazorAppUserControl1.Name = "blazorAppUserControl1";
            this.blazorAppUserControl1.Size = new System.Drawing.Size(747, 353);
            this.blazorAppUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(747, 353);
            this.Controls.Add(this.blazorAppUserControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private BlazorApp.WinFormsControls.BlazorAppUserControl blazorAppUserControl1;
    }
}

