namespace aimu
{
    partial class UserProperties
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
            this.labelStoreName = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCellPhone = new System.Windows.Forms.TextBox();
            this.labelCellPhone = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.labelPasswordConfirmation = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.labelMemo = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCreateStore = new System.Windows.Forms.Button();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelStoreName
            // 
            this.labelStoreName.AutoSize = true;
            this.labelStoreName.Location = new System.Drawing.Point(176, 68);
            this.labelStoreName.Name = "labelStoreName";
            this.labelStoreName.Size = new System.Drawing.Size(29, 12);
            this.labelStoreName.TabIndex = 0;
            this.labelStoreName.Text = "店名";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(234, 95);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(100, 21);
            this.textBoxMail.TabIndex = 9;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(176, 9);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(29, 12);
            this.labelRole.TabIndex = 4;
            this.labelRole.Text = "类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "邮箱";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(236, 6);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(99, 20);
            this.comboBoxRole.TabIndex = 6;
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(235, 35);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(99, 20);
            this.comboBoxCity.TabIndex = 5;
            this.comboBoxCity.SelectedIndexChanged += new System.EventHandler(this.comboBoxCity_SelectedIndexChanged);
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(176, 38);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(29, 12);
            this.labelCity.TabIndex = 8;
            this.labelCity.Text = "城市";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(56, 165);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(149, 165);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxCellPhone
            // 
            this.textBoxCellPhone.Location = new System.Drawing.Point(70, 6);
            this.textBoxCellPhone.Name = "textBoxCellPhone";
            this.textBoxCellPhone.Size = new System.Drawing.Size(100, 21);
            this.textBoxCellPhone.TabIndex = 1;
            // 
            // labelCellPhone
            // 
            this.labelCellPhone.AutoSize = true;
            this.labelCellPhone.Location = new System.Drawing.Point(12, 9);
            this.labelCellPhone.Name = "labelCellPhone";
            this.labelCellPhone.Size = new System.Drawing.Size(53, 12);
            this.labelCellPhone.TabIndex = 14;
            this.labelCellPhone.Text = "手机号码";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(70, 95);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
            this.textBoxName.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 98);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 12);
            this.labelName.TabIndex = 16;
            this.labelName.Text = "姓名";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(70, 35);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 21);
            this.textBoxPassword.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 38);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(29, 12);
            this.labelPassword.TabIndex = 18;
            this.labelPassword.Text = "密码";
            // 
            // textBoxPasswordConfirmation
            // 
            this.textBoxPasswordConfirmation.Location = new System.Drawing.Point(70, 65);
            this.textBoxPasswordConfirmation.Name = "textBoxPasswordConfirmation";
            this.textBoxPasswordConfirmation.PasswordChar = '*';
            this.textBoxPasswordConfirmation.Size = new System.Drawing.Size(100, 21);
            this.textBoxPasswordConfirmation.TabIndex = 3;
            // 
            // labelPasswordConfirmation
            // 
            this.labelPasswordConfirmation.AutoSize = true;
            this.labelPasswordConfirmation.Location = new System.Drawing.Point(11, 68);
            this.labelPasswordConfirmation.Name = "labelPasswordConfirmation";
            this.labelPasswordConfirmation.Size = new System.Drawing.Size(53, 12);
            this.labelPasswordConfirmation.TabIndex = 20;
            this.labelPasswordConfirmation.Text = "密码确认";
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(176, 125);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(48, 16);
            this.checkBoxActive.TabIndex = 21;
            this.checkBoxActive.Text = "有效";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(70, 122);
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(100, 21);
            this.textBoxMemo.TabIndex = 22;
            // 
            // labelMemo
            // 
            this.labelMemo.AutoSize = true;
            this.labelMemo.Location = new System.Drawing.Point(11, 125);
            this.labelMemo.Name = "labelMemo";
            this.labelMemo.Size = new System.Drawing.Size(29, 12);
            this.labelMemo.TabIndex = 23;
            this.labelMemo.Text = "备注";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(243, 165);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 24;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCreateStore
            // 
            this.buttonCreateStore.Location = new System.Drawing.Point(341, 63);
            this.buttonCreateStore.Name = "buttonCreateStore";
            this.buttonCreateStore.Size = new System.Drawing.Size(41, 23);
            this.buttonCreateStore.TabIndex = 25;
            this.buttonCreateStore.Text = "新建";
            this.buttonCreateStore.UseVisualStyleBackColor = true;
            this.buttonCreateStore.Click += new System.EventHandler(this.buttonCreateStore_Click);
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Location = new System.Drawing.Point(236, 65);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(99, 20);
            this.comboBoxStore.TabIndex = 26;
            // 
            // UserProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 211);
            this.Controls.Add(this.comboBoxStore);
            this.Controls.Add(this.buttonCreateStore);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxMemo);
            this.Controls.Add(this.labelMemo);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.textBoxPasswordConfirmation);
            this.Controls.Add(this.labelPasswordConfirmation);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxCellPhone);
            this.Controls.Add(this.labelCellPhone);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.comboBoxCity);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelStoreName);
            this.Name = "UserProperties";
            this.Text = "属性";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStoreName;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCellPhone;
        private System.Windows.Forms.Label labelCellPhone;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPasswordConfirmation;
        private System.Windows.Forms.Label labelPasswordConfirmation;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.Label labelMemo;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCreateStore;
        private System.Windows.Forms.ComboBox comboBoxStore;
    }
}