namespace BMCSDL_Lab3
{
    partial class Form_Login
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
            this.button_login = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_uname = new System.Windows.Forms.Label();
            this.label_passwd = new System.Windows.Forms.Label();
            this.textBox_uname = new System.Windows.Forms.TextBox();
            this.textBox_passwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.AutoSize = true;
            this.button_login.Location = new System.Drawing.Point(444, 238);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(100, 40);
            this.button_login.TabIndex = 1;
            this.button_login.Text = "Đăng nhập";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(580, 238);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 40);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Thoát";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label_uname
            // 
            this.label_uname.AutoSize = true;
            this.label_uname.BackColor = System.Drawing.Color.Transparent;
            this.label_uname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_uname.Location = new System.Drawing.Point(178, 78);
            this.label_uname.Name = "label_uname";
            this.label_uname.Size = new System.Drawing.Size(156, 26);
            this.label_uname.TabIndex = 3;
            this.label_uname.Text = "Tên đăng nhập";
            // 
            // label_passwd
            // 
            this.label_passwd.AutoSize = true;
            this.label_passwd.BackColor = System.Drawing.Color.Transparent;
            this.label_passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_passwd.Location = new System.Drawing.Point(178, 156);
            this.label_passwd.Name = "label_passwd";
            this.label_passwd.Size = new System.Drawing.Size(93, 25);
            this.label_passwd.TabIndex = 4;
            this.label_passwd.Text = "Mật khẩu";
            // 
            // textBox_uname
            // 
            this.textBox_uname.Location = new System.Drawing.Point(444, 78);
            this.textBox_uname.Name = "textBox_uname";
            this.textBox_uname.Size = new System.Drawing.Size(250, 26);
            this.textBox_uname.TabIndex = 5;
            // 
            // textBox_passwd
            // 
            this.textBox_passwd.Location = new System.Drawing.Point(444, 155);
            this.textBox_passwd.Name = "textBox_passwd";
            this.textBox_passwd.PasswordChar = '*';
            this.textBox_passwd.Size = new System.Drawing.Size(250, 26);
            this.textBox_passwd.TabIndex = 6;
            this.textBox_passwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.textBox_passwd);
            this.Controls.Add(this.textBox_uname);
            this.Controls.Add(this.label_passwd);
            this.Controls.Add(this.label_uname);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_login);
            this.IsMdiContainer = true;
            this.Name = "Form_Login";
            this.Text = "Màn hình đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_uname;
        private System.Windows.Forms.Label label_passwd;
        private System.Windows.Forms.TextBox textBox_uname;
        private System.Windows.Forms.TextBox textBox_passwd;
    }
}

