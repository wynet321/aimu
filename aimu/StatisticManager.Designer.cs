namespace aimu
{
    partial class StatisticManager
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
            this.buttonDressStatistic = new System.Windows.Forms.Button();
            this.buttonSellerStatistic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDressStatistic
            // 
            this.buttonDressStatistic.Location = new System.Drawing.Point(60, 66);
            this.buttonDressStatistic.Name = "buttonDressStatistic";
            this.buttonDressStatistic.Size = new System.Drawing.Size(119, 81);
            this.buttonDressStatistic.TabIndex = 0;
            this.buttonDressStatistic.Text = "礼服统计";
            this.buttonDressStatistic.UseVisualStyleBackColor = true;
            this.buttonDressStatistic.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSellerStatistic
            // 
            this.buttonSellerStatistic.Location = new System.Drawing.Point(230, 66);
            this.buttonSellerStatistic.Name = "buttonSellerStatistic";
            this.buttonSellerStatistic.Size = new System.Drawing.Size(119, 81);
            this.buttonSellerStatistic.TabIndex = 4;
            this.buttonSellerStatistic.Text = "销售业绩";
            this.buttonSellerStatistic.UseVisualStyleBackColor = true;
            this.buttonSellerStatistic.Click += new System.EventHandler(this.buttonDressList_Click);
            // 
            // StatisticManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 209);
            this.Controls.Add(this.buttonSellerStatistic);
            this.Controls.Add(this.buttonDressStatistic);
            this.Name = "StatisticManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "商品管理";
            this.Load += new System.EventHandler(this.WeddingManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDressStatistic;
        private System.Windows.Forms.Button buttonSellerStatistic;
    }
}