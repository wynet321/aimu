﻿namespace aimu
{
    partial class FormOrder
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
            this.labelNormal = new System.Windows.Forms.Label();
            this.labelCustom = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.labelOperation = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelSn = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.textBoxActualAmount = new System.Windows.Forms.TextBox();
            this.labelActualAmount = new System.Windows.Forms.Label();
            this.textBoxDeposit = new System.Windows.Forms.TextBox();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.labelMemo = new System.Windows.Forms.Label();
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCustomCategory = new System.Windows.Forms.Label();
            this.comboBoxCustomType = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonBrowseLeft = new System.Windows.Forms.Button();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.buttonBrowseRight = new System.Windows.Forms.Button();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.labelTel = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNormal
            // 
            this.labelNormal.AutoSize = true;
            this.labelNormal.Location = new System.Drawing.Point(12, 45);
            this.labelNormal.Name = "labelNormal";
            this.labelNormal.Size = new System.Drawing.Size(161, 12);
            this.labelNormal.TabIndex = 0;
            this.labelNormal.Text = "租赁、标准码、量身定制订单";
            // 
            // labelCustom
            // 
            this.labelCustom.AutoSize = true;
            this.labelCustom.Location = new System.Drawing.Point(501, 45);
            this.labelCustom.Name = "labelCustom";
            this.labelCustom.Size = new System.Drawing.Size(125, 12);
            this.labelCustom.TabIndex = 1;
            this.labelCustom.Text = "微定制、来图定制订单";
            // 
            // panelList
            // 
            this.panelList.AutoScroll = true;
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelList.Controls.Add(this.labelOperation);
            this.panelList.Controls.Add(this.labelPrice);
            this.panelList.Controls.Add(this.labelCategory);
            this.panelList.Controls.Add(this.labelColor);
            this.panelList.Controls.Add(this.labelSize);
            this.panelList.Controls.Add(this.labelSn);
            this.panelList.Location = new System.Drawing.Point(13, 61);
            this.panelList.Margin = new System.Windows.Forms.Padding(0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(475, 333);
            this.panelList.TabIndex = 2;
            // 
            // labelOperation
            // 
            this.labelOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOperation.Location = new System.Drawing.Point(364, 4);
            this.labelOperation.Margin = new System.Windows.Forms.Padding(0);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Padding = new System.Windows.Forms.Padding(5);
            this.labelOperation.Size = new System.Drawing.Size(80, 25);
            this.labelOperation.TabIndex = 5;
            this.labelOperation.Text = "操作";
            this.labelOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrice
            // 
            this.labelPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPrice.Location = new System.Drawing.Point(304, 4);
            this.labelPrice.Margin = new System.Windows.Forms.Padding(0);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Padding = new System.Windows.Forms.Padding(5);
            this.labelPrice.Size = new System.Drawing.Size(60, 25);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "价格";
            this.labelPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCategory
            // 
            this.labelCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCategory.Location = new System.Drawing.Point(224, 4);
            this.labelCategory.Margin = new System.Windows.Forms.Padding(0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Padding = new System.Windows.Forms.Padding(5);
            this.labelCategory.Size = new System.Drawing.Size(80, 25);
            this.labelCategory.TabIndex = 3;
            this.labelCategory.Text = "订单类型";
            this.labelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelColor
            // 
            this.labelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelColor.Location = new System.Drawing.Point(164, 4);
            this.labelColor.Margin = new System.Windows.Forms.Padding(0);
            this.labelColor.Name = "labelColor";
            this.labelColor.Padding = new System.Windows.Forms.Padding(5);
            this.labelColor.Size = new System.Drawing.Size(60, 25);
            this.labelColor.TabIndex = 2;
            this.labelColor.Text = "颜色";
            this.labelColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSize
            // 
            this.labelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSize.Location = new System.Drawing.Point(84, 4);
            this.labelSize.Margin = new System.Windows.Forms.Padding(0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(80, 25);
            this.labelSize.TabIndex = 1;
            this.labelSize.Text = "尺码";
            this.labelSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSn
            // 
            this.labelSn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSn.Location = new System.Drawing.Point(4, 4);
            this.labelSn.Margin = new System.Windows.Forms.Padding(0);
            this.labelSn.Name = "labelSn";
            this.labelSn.Padding = new System.Windows.Forms.Padding(5);
            this.labelSn.Size = new System.Drawing.Size(80, 25);
            this.labelSn.TabIndex = 0;
            this.labelSn.Text = "货号";
            this.labelSn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Location = new System.Drawing.Point(11, 411);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(53, 12);
            this.labelTotalAmount.TabIndex = 3;
            this.labelTotalAmount.Text = "订单金额";
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Location = new System.Drawing.Point(70, 408);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new System.Drawing.Size(60, 21);
            this.textBoxTotalAmount.TabIndex = 4;
            this.textBoxTotalAmount.Text = "0";
            // 
            // textBoxActualAmount
            // 
            this.textBoxActualAmount.Location = new System.Drawing.Point(197, 408);
            this.textBoxActualAmount.Name = "textBoxActualAmount";
            this.textBoxActualAmount.Size = new System.Drawing.Size(60, 21);
            this.textBoxActualAmount.TabIndex = 6;
            this.textBoxActualAmount.Text = "0";
            // 
            // labelActualAmount
            // 
            this.labelActualAmount.AutoSize = true;
            this.labelActualAmount.Location = new System.Drawing.Point(138, 411);
            this.labelActualAmount.Name = "labelActualAmount";
            this.labelActualAmount.Size = new System.Drawing.Size(53, 12);
            this.labelActualAmount.TabIndex = 5;
            this.labelActualAmount.Text = "实收金额";
            // 
            // textBoxDeposit
            // 
            this.textBoxDeposit.Location = new System.Drawing.Point(321, 408);
            this.textBoxDeposit.Name = "textBoxDeposit";
            this.textBoxDeposit.Size = new System.Drawing.Size(60, 21);
            this.textBoxDeposit.TabIndex = 8;
            this.textBoxDeposit.Text = "0";
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Location = new System.Drawing.Point(262, 411);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(53, 12);
            this.labelDeposit.TabIndex = 7;
            this.labelDeposit.Text = "租赁押金";
            // 
            // labelMemo
            // 
            this.labelMemo.AutoSize = true;
            this.labelMemo.Location = new System.Drawing.Point(11, 441);
            this.labelMemo.Name = "labelMemo";
            this.labelMemo.Size = new System.Drawing.Size(53, 12);
            this.labelMemo.TabIndex = 9;
            this.labelMemo.Text = "店内备注";
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(70, 441);
            this.textBoxMemo.Multiline = true;
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(392, 63);
            this.textBoxMemo.TabIndex = 10;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(377, 534);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "确定";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(579, 534);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCustomCategory
            // 
            this.labelCustomCategory.AutoSize = true;
            this.labelCustomCategory.Location = new System.Drawing.Point(632, 45);
            this.labelCustomCategory.Name = "labelCustomCategory";
            this.labelCustomCategory.Size = new System.Drawing.Size(53, 12);
            this.labelCustomCategory.TabIndex = 13;
            this.labelCustomCategory.Text = "定制类型";
            // 
            // comboBoxCustomType
            // 
            this.comboBoxCustomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomType.FormattingEnabled = true;
            this.comboBoxCustomType.Location = new System.Drawing.Point(688, 42);
            this.comboBoxCustomType.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxCustomType.Name = "comboBoxCustomType";
            this.comboBoxCustomType.Size = new System.Drawing.Size(102, 20);
            this.comboBoxCustomType.TabIndex = 14;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonBrowseLeft
            // 
            this.buttonBrowseLeft.Location = new System.Drawing.Point(579, 400);
            this.buttonBrowseLeft.Name = "buttonBrowseLeft";
            this.buttonBrowseLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseLeft.TabIndex = 17;
            this.buttonBrowseLeft.Text = "浏览";
            this.buttonBrowseLeft.UseVisualStyleBackColor = true;
            this.buttonBrowseLeft.Click += new System.EventHandler(this.buttonBrowseLeft_Click);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLeft.Location = new System.Drawing.Point(503, 65);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(243, 329);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 18;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRight.Location = new System.Drawing.Point(752, 65);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(243, 329);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 19;
            this.pictureBoxRight.TabStop = false;
            // 
            // buttonBrowseRight
            // 
            this.buttonBrowseRight.Location = new System.Drawing.Point(827, 400);
            this.buttonBrowseRight.Name = "buttonBrowseRight";
            this.buttonBrowseRight.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseRight.TabIndex = 20;
            this.buttonBrowseRight.Text = "浏览";
            this.buttonBrowseRight.UseVisualStyleBackColor = true;
            this.buttonBrowseRight.Click += new System.EventHandler(this.buttonBrowseRight_Click);
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(13, 13);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(29, 12);
            this.labelCustomerName.TabIndex = 21;
            this.labelCustomerName.Text = "姓名";
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Enabled = false;
            this.textBoxCustomerName.Location = new System.Drawing.Point(48, 10);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(125, 21);
            this.textBoxCustomerName.TabIndex = 22;
            // 
            // textBoxTel
            // 
            this.textBoxTel.Enabled = false;
            this.textBoxTel.Location = new System.Drawing.Point(214, 10);
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(125, 21);
            this.textBoxTel.TabIndex = 24;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Location = new System.Drawing.Point(179, 13);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(29, 12);
            this.labelTel.TabIndex = 23;
            this.labelTel.Text = "电话";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(345, 8);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 25;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Visible = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(803, 40);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 26;
            this.buttonReset.Text = "重置";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 573);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxTel);
            this.Controls.Add(this.labelTel);
            this.Controls.Add(this.textBoxCustomerName);
            this.Controls.Add(this.labelCustomerName);
            this.Controls.Add(this.buttonBrowseRight);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.buttonBrowseLeft);
            this.Controls.Add(this.comboBoxCustomType);
            this.Controls.Add(this.labelCustomCategory);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxMemo);
            this.Controls.Add(this.labelMemo);
            this.Controls.Add(this.textBoxDeposit);
            this.Controls.Add(this.labelDeposit);
            this.Controls.Add(this.textBoxActualAmount);
            this.Controls.Add(this.labelActualAmount);
            this.Controls.Add(this.textBoxTotalAmount);
            this.Controls.Add(this.labelTotalAmount);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.labelCustom);
            this.Controls.Add(this.labelNormal);
            this.Name = "FormOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单";
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNormal;
        private System.Windows.Forms.Label labelCustom;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Label labelOperation;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelSn;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.TextBox textBoxActualAmount;
        private System.Windows.Forms.Label labelActualAmount;
        private System.Windows.Forms.TextBox textBoxDeposit;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.Label labelMemo;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCustomCategory;
        private System.Windows.Forms.ComboBox comboBoxCustomType;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonBrowseLeft;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button buttonBrowseRight;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.Label labelTel;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonReset;
    }
}