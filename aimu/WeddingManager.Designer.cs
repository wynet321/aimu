namespace aimu
{
    partial class WeddingManager
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
            this.buttonDressProperties = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_update_weddingdress = new System.Windows.Forms.Button();
            this.buttonDressList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDressProperties
            // 
            this.buttonDressProperties.Location = new System.Drawing.Point(60, 66);
            this.buttonDressProperties.Name = "buttonDressProperties";
            this.buttonDressProperties.Size = new System.Drawing.Size(119, 81);
            this.buttonDressProperties.TabIndex = 0;
            this.buttonDressProperties.Text = "礼服明细";
            this.buttonDressProperties.UseVisualStyleBackColor = true;
            this.buttonDressProperties.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 81);
            this.button2.TabIndex = 1;
            this.button2.Text = "新增礼服";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_update_weddingdress
            // 
            this.bt_update_weddingdress.Enabled = false;
            this.bt_update_weddingdress.Location = new System.Drawing.Point(230, 198);
            this.bt_update_weddingdress.Name = "bt_update_weddingdress";
            this.bt_update_weddingdress.Size = new System.Drawing.Size(119, 81);
            this.bt_update_weddingdress.TabIndex = 2;
            this.bt_update_weddingdress.Text = "删改礼服";
            this.bt_update_weddingdress.UseVisualStyleBackColor = true;
            this.bt_update_weddingdress.Click += new System.EventHandler(this.bt_update_weddingdress_Click);
            // 
            // buttonDressList
            // 
            this.buttonDressList.Location = new System.Drawing.Point(230, 66);
            this.buttonDressList.Name = "buttonDressList";
            this.buttonDressList.Size = new System.Drawing.Size(119, 81);
            this.buttonDressList.TabIndex = 4;
            this.buttonDressList.Text = "礼服列表";
            this.buttonDressList.UseVisualStyleBackColor = true;
            this.buttonDressList.Click += new System.EventHandler(this.buttonDressList_Click);
            // 
            // WeddingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 364);
            this.Controls.Add(this.buttonDressList);
            this.Controls.Add(this.bt_update_weddingdress);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonDressProperties);
            this.Name = "WeddingManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "礼服管理";
            this.Load += new System.EventHandler(this.WeddingManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDressProperties;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bt_update_weddingdress;
        private System.Windows.Forms.Button buttonDressList;
    }
}