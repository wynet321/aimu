namespace aimu
{
    partial class FormProcessing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessing));
            this.pictureBoxWait = new System.Windows.Forms.PictureBox();
            this.labelWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWait)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWait
            // 
            this.pictureBoxWait.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWait.Image")));
            this.pictureBoxWait.Location = new System.Drawing.Point(118, 12);
            this.pictureBoxWait.Name = "pictureBoxWait";
            this.pictureBoxWait.Size = new System.Drawing.Size(102, 92);
            this.pictureBoxWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWait.TabIndex = 0;
            this.pictureBoxWait.TabStop = false;
            // 
            // labelWait
            // 
            this.labelWait.AutoSize = true;
            this.labelWait.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWait.Location = new System.Drawing.Point(105, 107);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(144, 16);
            this.labelWait.TabIndex = 1;
            this.labelWait.Text = "加载中，请稍候...";
            // 
            // FormProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 140);
            this.Controls.Add(this.labelWait);
            this.Controls.Add(this.pictureBoxWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormProcessing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxWait;
        private System.Windows.Forms.Label labelWait;
    }
}