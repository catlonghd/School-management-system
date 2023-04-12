namespace BMCSDL_Lab3.Source
{
    partial class Form_Main
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
            this.btn_studentlist = new System.Windows.Forms.Button();
            this.btn_nhapdiem = new System.Windows.Forms.Button();
            this.panel_childform = new System.Windows.Forms.Panel();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.label_uname = new System.Windows.Forms.Label();
            this.panel_uname = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_menu.SuspendLayout();
            this.panel_uname.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_studentlist
            // 
            this.btn_studentlist.AutoSize = true;
            this.btn_studentlist.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_studentlist.Location = new System.Drawing.Point(0, 21);
            this.btn_studentlist.Name = "btn_studentlist";
            this.btn_studentlist.Size = new System.Drawing.Size(238, 50);
            this.btn_studentlist.TabIndex = 2;
            this.btn_studentlist.Text = "Danh sách sinh viên";
            this.btn_studentlist.UseVisualStyleBackColor = false;
            this.btn_studentlist.Click += new System.EventHandler(this.btn_StudentList_Click);
            // 
            // btn_nhapdiem
            // 
            this.btn_nhapdiem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_nhapdiem.Location = new System.Drawing.Point(0, 104);
            this.btn_nhapdiem.Name = "btn_nhapdiem";
            this.btn_nhapdiem.Size = new System.Drawing.Size(162, 50);
            this.btn_nhapdiem.TabIndex = 3;
            this.btn_nhapdiem.Text = "Nhập điểm";
            this.btn_nhapdiem.UseVisualStyleBackColor = false;
            // 
            // panel_childform
            // 
            this.panel_childform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_childform.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panel_childform.Location = new System.Drawing.Point(0, 160);
            this.panel_childform.Name = "panel_childform";
            this.panel_childform.Size = new System.Drawing.Size(1082, 740);
            this.panel_childform.TabIndex = 4;
            // 
            // panel_menu
            // 
            this.panel_menu.Controls.Add(this.btn_nhapdiem);
            this.panel_menu.Controls.Add(this.btn_studentlist);
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_menu.Location = new System.Drawing.Point(0, 160);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(180, 740);
            this.panel_menu.TabIndex = 5;
            // 
            // btn_logout
            // 
            this.btn_logout.AutoSize = true;
            this.btn_logout.Location = new System.Drawing.Point(47, 65);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(99, 42);
            this.btn_logout.TabIndex = 0;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // label_uname
            // 
            this.label_uname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_uname.AutoSize = true;
            this.label_uname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_uname.Location = new System.Drawing.Point(913, 112);
            this.label_uname.Name = "label_uname";
            this.label_uname.Size = new System.Drawing.Size(117, 32);
            this.label_uname.TabIndex = 1;
            this.label_uname.Text = "NO USER";
            this.label_uname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_uname
            // 
            this.panel_uname.Controls.Add(this.panel1);
            this.panel_uname.Controls.Add(this.label_uname);
            this.panel_uname.Controls.Add(this.btn_logout);
            this.panel_uname.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_uname.Location = new System.Drawing.Point(0, 0);
            this.panel_uname.Name = "panel_uname";
            this.panel_uname.Size = new System.Drawing.Size(1082, 160);
            this.panel_uname.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 116);
            this.panel1.TabIndex = 5;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 900);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.panel_childform);
            this.Controls.Add(this.panel_uname);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.panel_menu.ResumeLayout(false);
            this.panel_menu.PerformLayout();
            this.panel_uname.ResumeLayout(false);
            this.panel_uname.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_studentlist;
        private System.Windows.Forms.Button btn_nhapdiem;
        private System.Windows.Forms.Panel panel_childform;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label label_uname;
        private System.Windows.Forms.Panel panel_uname;
        private System.Windows.Forms.Panel panel1;
    }
}