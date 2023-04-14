
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
            this.panel_menu = new System.Windows.Forms.Panel();
            this.btn_modifyStudent = new System.Windows.Forms.Button();
            this.btn_scoreInput = new System.Windows.Forms.Button();
            this.btn_studentList = new System.Windows.Forms.Button();
            this.panel_uname = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.label_uname = new System.Windows.Forms.Label();
            this.panel_childform = new System.Windows.Forms.Panel();
            this.panel_menu.SuspendLayout();
            this.panel_uname.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel_menu.Controls.Add(this.btn_modifyStudent);
            this.panel_menu.Controls.Add(this.btn_scoreInput);
            this.panel_menu.Controls.Add(this.btn_studentList);
            this.panel_menu.Location = new System.Drawing.Point(0, 122);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(173, 377);
            this.panel_menu.TabIndex = 0;
            // 
            // btn_modifyStudent
            // 
            this.btn_modifyStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btn_modifyStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_modifyStudent.FlatAppearance.BorderSize = 0;
            this.btn_modifyStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modifyStudent.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btn_modifyStudent.ForeColor = System.Drawing.Color.White;
            this.btn_modifyStudent.Location = new System.Drawing.Point(0, 131);
            this.btn_modifyStudent.Name = "btn_modifyStudent";
            this.btn_modifyStudent.Size = new System.Drawing.Size(173, 110);
            this.btn_modifyStudent.TabIndex = 2;
            this.btn_modifyStudent.Text = "Chỉnh sử thông tin sinh viên";
            this.btn_modifyStudent.UseVisualStyleBackColor = true;
            this.btn_modifyStudent.Click += new System.EventHandler(this.btn_modifyStudent_Click);
            // 
            // btn_scoreInput
            // 
            this.btn_scoreInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btn_scoreInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_scoreInput.FlatAppearance.BorderSize = 0;
            this.btn_scoreInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_scoreInput.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btn_scoreInput.ForeColor = System.Drawing.Color.White;
            this.btn_scoreInput.Location = new System.Drawing.Point(0, 72);
            this.btn_scoreInput.Name = "btn_scoreInput";
            this.btn_scoreInput.Size = new System.Drawing.Size(173, 59);
            this.btn_scoreInput.TabIndex = 1;
            this.btn_scoreInput.Text = "Nhập điểm";
            this.btn_scoreInput.UseVisualStyleBackColor = false;
            // 
            // btn_studentList
            // 
            this.btn_studentList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btn_studentList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_studentList.FlatAppearance.BorderSize = 0;
            this.btn_studentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_studentList.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btn_studentList.ForeColor = System.Drawing.Color.White;
            this.btn_studentList.Location = new System.Drawing.Point(0, 0);
            this.btn_studentList.Name = "btn_studentList";
            this.btn_studentList.Size = new System.Drawing.Size(173, 72);
            this.btn_studentList.TabIndex = 0;
            this.btn_studentList.Text = "Danh sách sinh viên";
            this.btn_studentList.UseVisualStyleBackColor = false;
            this.btn_studentList.Click += new System.EventHandler(this.btn_StudentList_Click);
            // 
            // panel_uname
            // 
            this.panel_uname.AllowDrop = true;
            this.panel_uname.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_uname.Controls.Add(this.btn_logout);
            this.panel_uname.Controls.Add(this.label_uname);
            this.panel_uname.Location = new System.Drawing.Point(0, 0);
            this.panel_uname.Name = "panel_uname";
            this.panel_uname.Size = new System.Drawing.Size(173, 122);
            this.panel_uname.TabIndex = 2;
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(187)))), ((int)(((byte)(241)))));
            this.btn_logout.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btn_logout.Location = new System.Drawing.Point(34, 57);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(99, 41);
            this.btn_logout.TabIndex = 1;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // label_uname
            // 
            this.label_uname.AutoSize = true;
            this.label_uname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label_uname.Location = new System.Drawing.Point(39, 12);
            this.label_uname.Name = "label_uname";
            this.label_uname.Size = new System.Drawing.Size(104, 32);
            this.label_uname.TabIndex = 2;
            this.label_uname.Text = "No user";
            this.label_uname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_childform
            // 
            this.panel_childform.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.panel_childform.Location = new System.Drawing.Point(173, 0);
            this.panel_childform.Name = "panel_childform";
            this.panel_childform.Size = new System.Drawing.Size(797, 499);
            this.panel_childform.TabIndex = 2;
            this.panel_childform.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_childform_paint);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 499);
            this.Controls.Add(this.panel_childform);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.panel_uname);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.panel_menu.ResumeLayout(false);
            this.panel_uname.ResumeLayout(false);
            this.panel_uname.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Panel panel_uname;
        private System.Windows.Forms.Label label_uname;
        private System.Windows.Forms.Button btn_studentList;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_scoreInput;
        private System.Windows.Forms.Panel panel_childform;
        private System.Windows.Forms.Button btn_modifyStudent;
    }
}