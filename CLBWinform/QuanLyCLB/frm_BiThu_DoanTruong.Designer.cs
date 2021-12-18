
namespace QuanLyCLB
{
    partial class frm_BiThu_DoanTruong
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.QuanLyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyCLB = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyDiaDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 20);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuanLyTaiKhoan,
            this.QuanLyCLB,
            this.QuanLyDiaDiem,
            this.DangXuat});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // QuanLyTaiKhoan
            // 
            this.QuanLyTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênToolStripMenuItem,
            this.nhânViênToolStripMenuItem1});
            this.QuanLyTaiKhoan.Name = "QuanLyTaiKhoan";
            this.QuanLyTaiKhoan.Size = new System.Drawing.Size(141, 24);
            this.QuanLyTaiKhoan.Text = "Quản lý Tài Khoản";
            this.QuanLyTaiKhoan.Click += new System.EventHandler(this.QuanLyTaiKhoan_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhânViênToolStripMenuItem.Text = "Chủ Nhiệm";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem1
            // 
            this.nhânViênToolStripMenuItem1.Name = "nhânViênToolStripMenuItem1";
            this.nhânViênToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.nhânViênToolStripMenuItem1.Text = "Thành Viên";
            this.nhânViênToolStripMenuItem1.Click += new System.EventHandler(this.nhânViênToolStripMenuItem1_Click);
            // 
            // QuanLyCLB
            // 
            this.QuanLyCLB.Name = "QuanLyCLB";
            this.QuanLyCLB.Size = new System.Drawing.Size(102, 24);
            this.QuanLyCLB.Text = "Quản lý CLB";
            this.QuanLyCLB.Click += new System.EventHandler(this.QuanLyCLB_Click);
            // 
            // QuanLyDiaDiem
            // 
            this.QuanLyDiaDiem.Name = "QuanLyDiaDiem";
            this.QuanLyDiaDiem.Size = new System.Drawing.Size(140, 24);
            this.QuanLyDiaDiem.Text = "Quản lý Địa Điểm";
            this.QuanLyDiaDiem.Click += new System.EventHandler(this.QuanLyDiaDiem_Click);
            // 
            // DangXuat
            // 
            this.DangXuat.Name = "DangXuat";
            this.DangXuat.Size = new System.Drawing.Size(91, 24);
            this.DangXuat.Text = "Đăng xuất";
            this.DangXuat.Click += new System.EventHandler(this.DangXuat_Click);
            // 
            // frm_BiThu_DoanTruong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_BiThu_DoanTruong";
            this.Text = "Bí thư Đoàn Trường";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem QuanLyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem QuanLyCLB;
        private System.Windows.Forms.ToolStripMenuItem QuanLyDiaDiem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DangXuat;
    }
}