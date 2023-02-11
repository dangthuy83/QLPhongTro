namespace QLPhongTro
{
    partial class frmMain
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
            this.grbContentMainForm = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ketNoiDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loaiPhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dichVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tácVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thuePhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traPhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phongDangThueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phongTrongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tienDienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tienNuocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KhachHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbContentMainForm
            // 
            this.grbContentMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbContentMainForm.Location = new System.Drawing.Point(0, 38);
            this.grbContentMainForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.grbContentMainForm.Name = "grbContentMainForm";
            this.grbContentMainForm.Padding = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.grbContentMainForm.Size = new System.Drawing.Size(875, 495);
            this.grbContentMainForm.TabIndex = 0;
            this.grbContentMainForm.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.tácVụToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(875, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ketNoiDBToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(111, 32);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // ketNoiDBToolStripMenuItem
            // 
            this.ketNoiDBToolStripMenuItem.Name = "ketNoiDBToolStripMenuItem";
            this.ketNoiDBToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.ketNoiDBToolStripMenuItem.Text = "Kết Nối DB";
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loaiPhongToolStripMenuItem,
            this.phongToolStripMenuItem,
            this.dichVuToolStripMenuItem,
            this.KhachHangToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(115, 32);
            this.danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // loaiPhongToolStripMenuItem
            // 
            this.loaiPhongToolStripMenuItem.Name = "loaiPhongToolStripMenuItem";
            this.loaiPhongToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.loaiPhongToolStripMenuItem.Text = "Loại Phòng";
            this.loaiPhongToolStripMenuItem.Click += new System.EventHandler(this.loaiPhongToolStripMenuItem_Click);
            // 
            // phongToolStripMenuItem
            // 
            this.phongToolStripMenuItem.Name = "phongToolStripMenuItem";
            this.phongToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.phongToolStripMenuItem.Text = "Phòng";
            this.phongToolStripMenuItem.Click += new System.EventHandler(this.phongToolStripMenuItem_Click);
            // 
            // dichVuToolStripMenuItem
            // 
            this.dichVuToolStripMenuItem.Name = "dichVuToolStripMenuItem";
            this.dichVuToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.dichVuToolStripMenuItem.Text = "Dịch Vụ";
            this.dichVuToolStripMenuItem.Click += new System.EventHandler(this.dichVuToolStripMenuItem_Click);
            // 
            // tácVụToolStripMenuItem
            // 
            this.tácVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thuePhongToolStripMenuItem,
            this.traPhongToolStripMenuItem});
            this.tácVụToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tácVụToolStripMenuItem.Name = "tácVụToolStripMenuItem";
            this.tácVụToolStripMenuItem.Size = new System.Drawing.Size(81, 32);
            this.tácVụToolStripMenuItem.Text = "Tác Vụ";
            // 
            // thuePhongToolStripMenuItem
            // 
            this.thuePhongToolStripMenuItem.Name = "thuePhongToolStripMenuItem";
            this.thuePhongToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.thuePhongToolStripMenuItem.Text = "Thuê Phòng";
            this.thuePhongToolStripMenuItem.Click += new System.EventHandler(this.thuePhongToolStripMenuItem_Click);
            // 
            // traPhongToolStripMenuItem
            // 
            this.traPhongToolStripMenuItem.Name = "traPhongToolStripMenuItem";
            this.traPhongToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.traPhongToolStripMenuItem.Text = "Trả Phòng";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phongDangThueToolStripMenuItem,
            this.phongTrongToolStripMenuItem,
            this.tienDienToolStripMenuItem,
            this.tienNuocToolStripMenuItem,
            this.doanhThuToolStripMenuItem});
            this.thốngKêToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(109, 32);
            this.thốngKêToolStripMenuItem.Text = "Thống Kê";
            // 
            // phongDangThueToolStripMenuItem
            // 
            this.phongDangThueToolStripMenuItem.Name = "phongDangThueToolStripMenuItem";
            this.phongDangThueToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.phongDangThueToolStripMenuItem.Text = "Phòng Đang Thuê";
            // 
            // phongTrongToolStripMenuItem
            // 
            this.phongTrongToolStripMenuItem.Name = "phongTrongToolStripMenuItem";
            this.phongTrongToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.phongTrongToolStripMenuItem.Text = "Phòng Trống";
            // 
            // tienDienToolStripMenuItem
            // 
            this.tienDienToolStripMenuItem.Name = "tienDienToolStripMenuItem";
            this.tienDienToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.tienDienToolStripMenuItem.Text = "Tiền Điện";
            // 
            // tienNuocToolStripMenuItem
            // 
            this.tienNuocToolStripMenuItem.Name = "tienNuocToolStripMenuItem";
            this.tienNuocToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.tienNuocToolStripMenuItem.Text = "Tiền Nước";
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.doanhThuToolStripMenuItem.Text = "Doanh Thu";
            // 
            // KhachHangToolStripMenuItem
            // 
            this.KhachHangToolStripMenuItem.Name = "KhachHangToolStripMenuItem";
            this.KhachHangToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.KhachHangToolStripMenuItem.Text = "Khách Hàng";
            this.KhachHangToolStripMenuItem.Click += new System.EventHandler(this.KhachHangToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 533);
            this.Controls.Add(this.grbContentMainForm);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhà Trọ D9";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbContentMainForm;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ketNoiDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loaiPhongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dichVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tácVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thuePhongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traPhongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phongDangThueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phongTrongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tienDienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tienNuocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KhachHangToolStripMenuItem;
    }
}

