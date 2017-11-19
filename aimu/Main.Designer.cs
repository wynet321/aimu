namespace aimu
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonDressManagement = new System.Windows.Forms.Button();
            this.buttonOrderManagement = new System.Windows.Forms.Button();
            this.buttonCustomerManagement = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonResizeImage = new System.Windows.Forms.Button();
            this.buttonRelogin = new System.Windows.Forms.Button();
            this.buttonStatistic = new System.Windows.Forms.Button();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.labelOrderStatistic = new System.Windows.Forms.Label();
            this.buttonTenantManager = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDressManagement
            // 
            this.buttonDressManagement.Location = new System.Drawing.Point(521, 570);
            this.buttonDressManagement.Name = "buttonDressManagement";
            this.buttonDressManagement.Size = new System.Drawing.Size(100, 30);
            this.buttonDressManagement.TabIndex = 2;
            this.buttonDressManagement.Text = "商品管理";
            this.buttonDressManagement.UseVisualStyleBackColor = true;
            this.buttonDressManagement.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonOrderManagement
            // 
            this.buttonOrderManagement.Location = new System.Drawing.Point(627, 570);
            this.buttonOrderManagement.Name = "buttonOrderManagement";
            this.buttonOrderManagement.Size = new System.Drawing.Size(100, 30);
            this.buttonOrderManagement.TabIndex = 3;
            this.buttonOrderManagement.Text = "订单管理";
            this.buttonOrderManagement.UseVisualStyleBackColor = true;
            this.buttonOrderManagement.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonCustomerManagement
            // 
            this.buttonCustomerManagement.Location = new System.Drawing.Point(415, 570);
            this.buttonCustomerManagement.Name = "buttonCustomerManagement";
            this.buttonCustomerManagement.Size = new System.Drawing.Size(100, 30);
            this.buttonCustomerManagement.TabIndex = 1;
            this.buttonCustomerManagement.Text = "客户管理";
            this.buttonCustomerManagement.UseVisualStyleBackColor = true;
            this.buttonCustomerManagement.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(838, 570);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 30);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(984, 662);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.buttonTenantManager);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.buttonResizeImage);
            this.panel1.Controls.Add(this.buttonRelogin);
            this.panel1.Controls.Add(this.buttonStatistic);
            this.panel1.Controls.Add(this.textBoxVersion);
            this.panel1.Controls.Add(this.labelOrderStatistic);
            this.panel1.Controls.Add(this.buttonCustomerManagement);
            this.panel1.Controls.Add(this.buttonOrderManagement);
            this.panel1.Controls.Add(this.buttonDressManagement);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 662);
            this.panel1.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(521, 456);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(262, 23);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // buttonResizeImage
            // 
            this.buttonResizeImage.Location = new System.Drawing.Point(838, 498);
            this.buttonResizeImage.Name = "buttonResizeImage";
            this.buttonResizeImage.Size = new System.Drawing.Size(100, 30);
            this.buttonResizeImage.TabIndex = 9;
            this.buttonResizeImage.Text = "整理图片";
            this.buttonResizeImage.UseVisualStyleBackColor = true;
            this.buttonResizeImage.Click += new System.EventHandler(this.buttonResizeImage_Click);
            // 
            // buttonRelogin
            // 
            this.buttonRelogin.Location = new System.Drawing.Point(838, 534);
            this.buttonRelogin.Name = "buttonRelogin";
            this.buttonRelogin.Size = new System.Drawing.Size(100, 30);
            this.buttonRelogin.TabIndex = 8;
            this.buttonRelogin.Text = "重新登录";
            this.buttonRelogin.UseVisualStyleBackColor = true;
            this.buttonRelogin.Click += new System.EventHandler(this.buttonRelogin_Click);
            // 
            // buttonStatistic
            // 
            this.buttonStatistic.Location = new System.Drawing.Point(733, 570);
            this.buttonStatistic.Name = "buttonStatistic";
            this.buttonStatistic.Size = new System.Drawing.Size(100, 30);
            this.buttonStatistic.TabIndex = 7;
            this.buttonStatistic.Text = "统计结果";
            this.buttonStatistic.UseVisualStyleBackColor = true;
            this.buttonStatistic.Click += new System.EventHandler(this.buttonStatistic_Click);
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxVersion.Location = new System.Drawing.Point(12, 636);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.ReadOnly = true;
            this.textBoxVersion.Size = new System.Drawing.Size(155, 21);
            this.textBoxVersion.TabIndex = 6;
            this.textBoxVersion.TabStop = false;
            this.textBoxVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelOrderStatistic
            // 
            this.labelOrderStatistic.AutoSize = true;
            this.labelOrderStatistic.Location = new System.Drawing.Point(730, 630);
            this.labelOrderStatistic.Name = "labelOrderStatistic";
            this.labelOrderStatistic.Size = new System.Drawing.Size(0, 12);
            this.labelOrderStatistic.TabIndex = 5;
            // 
            // buttonTenantManager
            // 
            this.buttonTenantManager.Location = new System.Drawing.Point(733, 534);
            this.buttonTenantManager.Name = "buttonTenantManager";
            this.buttonTenantManager.Size = new System.Drawing.Size(100, 30);
            this.buttonTenantManager.TabIndex = 11;
            this.buttonTenantManager.Text = "租户管理";
            this.buttonTenantManager.UseVisualStyleBackColor = true;
            this.buttonTenantManager.Click += new System.EventHandler(this.buttonTenantManager_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "艾慕婚纱管理系统v1.0";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOrderManagement;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonCustomerManagement;
        private System.Windows.Forms.Button buttonDressManagement;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelOrderStatistic;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.Button buttonStatistic;
        private System.Windows.Forms.Button buttonRelogin;
        private System.Windows.Forms.Button buttonResizeImage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonTenantManager;
    }
}

