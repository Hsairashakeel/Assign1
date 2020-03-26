namespace Assignment2
{
    partial class newUserScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.loginTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.genderTxt = new System.Windows.Forms.ComboBox();
            this.adressTxt = new System.Windows.Forms.TextBox();
            this.ageTxt = new System.Windows.Forms.NumericUpDown();
            this.nic = new System.Windows.Forms.MaskedTextBox();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.profilePhoto = new System.Windows.Forms.PictureBox();
            this.update = new System.Windows.Forms.Button();
            this.DOBTxt = new System.Windows.Forms.DateTimePicker();
            this.hockey = new System.Windows.Forms.CheckBox();
            this.cricket = new System.Windows.Forms.CheckBox();
            this.chess = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ageTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username/Login";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gender";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Age";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "NIC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "DOB";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 449);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Hobby";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(149, 152);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(159, 20);
            this.emailTxt.TabIndex = 10;
            this.emailTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(149, 105);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(159, 20);
            this.passwordTxt.TabIndex = 11;
            // 
            // loginTxt
            // 
            this.loginTxt.Location = new System.Drawing.Point(149, 67);
            this.loginTxt.Name = "loginTxt";
            this.loginTxt.Size = new System.Drawing.Size(159, 20);
            this.loginTxt.TabIndex = 12;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(149, 25);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(159, 20);
            this.nameTxt.TabIndex = 13;
            // 
            // genderTxt
            // 
            this.genderTxt.AllowDrop = true;
            this.genderTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderTxt.FormattingEnabled = true;
            this.genderTxt.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.genderTxt.Location = new System.Drawing.Point(149, 196);
            this.genderTxt.Name = "genderTxt";
            this.genderTxt.Size = new System.Drawing.Size(159, 21);
            this.genderTxt.TabIndex = 14;
            this.genderTxt.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // adressTxt
            // 
            this.adressTxt.Location = new System.Drawing.Point(149, 246);
            this.adressTxt.Multiline = true;
            this.adressTxt.Name = "adressTxt";
            this.adressTxt.Size = new System.Drawing.Size(159, 20);
            this.adressTxt.TabIndex = 15;
            // 
            // ageTxt
            // 
            this.ageTxt.Location = new System.Drawing.Point(149, 301);
            this.ageTxt.Name = "ageTxt";
            this.ageTxt.Size = new System.Drawing.Size(120, 20);
            this.ageTxt.TabIndex = 16;
            // 
            // nic
            // 
            this.nic.Location = new System.Drawing.Point(149, 346);
            this.nic.Mask = "00000-0000000-0";
            this.nic.Name = "nic";
            this.nic.Size = new System.Drawing.Size(120, 20);
            this.nic.TabIndex = 17;
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
            this.FileDialog.Filter = "JPG file | *.jpg";
            // 
            // profilePhoto
            // 
            this.profilePhoto.Location = new System.Drawing.Point(445, 25);
            this.profilePhoto.Name = "profilePhoto";
            this.profilePhoto.Size = new System.Drawing.Size(177, 133);
            this.profilePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profilePhoto.TabIndex = 18;
            this.profilePhoto.TabStop = false;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(493, 185);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 19;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // DOBTxt
            // 
            this.DOBTxt.CustomFormat = "yy-MM-dd";
            this.DOBTxt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DOBTxt.Location = new System.Drawing.Point(149, 396);
            this.DOBTxt.Name = "DOBTxt";
            this.DOBTxt.Size = new System.Drawing.Size(200, 20);
            this.DOBTxt.TabIndex = 20;
            // 
            // hockey
            // 
            this.hockey.AutoSize = true;
            this.hockey.Location = new System.Drawing.Point(235, 449);
            this.hockey.Name = "hockey";
            this.hockey.Size = new System.Drawing.Size(63, 17);
            this.hockey.TabIndex = 23;
            this.hockey.Text = "Hockey";
            this.hockey.UseVisualStyleBackColor = true;
            this.hockey.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cricket
            // 
            this.cricket.AutoSize = true;
            this.cricket.Location = new System.Drawing.Point(149, 449);
            this.cricket.Name = "cricket";
            this.cricket.Size = new System.Drawing.Size(59, 17);
            this.cricket.TabIndex = 24;
            this.cricket.Text = "Cricket";
            this.cricket.UseVisualStyleBackColor = true;
            // 
            // chess
            // 
            this.chess.AutoSize = true;
            this.chess.Location = new System.Drawing.Point(321, 448);
            this.chess.Name = "chess";
            this.chess.Size = new System.Drawing.Size(55, 17);
            this.chess.TabIndex = 25;
            this.chess.Text = "Chess";
            this.chess.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(301, 488);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 26;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(160, 488);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 27;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // newUserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.create);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.chess);
            this.Controls.Add(this.cricket);
            this.Controls.Add(this.hockey);
            this.Controls.Add(this.DOBTxt);
            this.Controls.Add(this.update);
            this.Controls.Add(this.profilePhoto);
            this.Controls.Add(this.nic);
            this.Controls.Add(this.ageTxt);
            this.Controls.Add(this.adressTxt);
            this.Controls.Add(this.genderTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.loginTxt);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "newUserScreen";
            this.Text = "newUserScreen";
            this.Load += new System.EventHandler(this.newUserScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ageTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox loginTxt;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.ComboBox genderTxt;
        private System.Windows.Forms.TextBox adressTxt;
        private System.Windows.Forms.NumericUpDown ageTxt;
        private System.Windows.Forms.MaskedTextBox nic;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.PictureBox profilePhoto;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.DateTimePicker DOBTxt;
        private System.Windows.Forms.CheckBox hockey;
        private System.Windows.Forms.CheckBox cricket;
        private System.Windows.Forms.CheckBox chess;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button create;
    }
}