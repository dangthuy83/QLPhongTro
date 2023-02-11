using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLPhongTro.Database;

namespace QLPhongTro.SubForm
{
    public partial class frmKhachHang : Form
    {
        private Database db;
        public frmKhachHang()
        {
            db= new Database();
            InitializeComponent();
        }

        private void btnThoatXuLyPhong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState= FormWindowState.Maximized;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            var ho = txtHo.Text.Trim();
            var tenDem = txtTenDem.Text.Trim();
            var ten = txtTen.Text.Trim();
            var dienThoai = txtDienThoai.Text.Trim();
            var cmnd = txtCMND.Text.Trim();
            var qq = txtQueQuan.Text.Trim();
            var hktt = txtHKTT.Text.Trim();
            if (string.IsNullOrEmpty(ho) || string.IsNullOrEmpty(tenDem) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(cmnd) || string.IsNullOrEmpty(qq) || string.IsNullOrEmpty(hktt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            var lstPra = new List<CustomParameter>() 
            {
                new CustomParameter()
                {
                    key = "@ho",
                    value= ho
                },
                new CustomParameter()
                {
                    key = "@tenDem",
                    value= tenDem
                },
                new CustomParameter()
                {
                    key = "@ten",
                    value= ten
                },
                new CustomParameter()
                {
                    key = "@dienThoai",
                    value= dienThoai
                },
                new CustomParameter()
                {
                    key = "@cmnd",
                    value= cmnd
                },
                new CustomParameter()
                {
                    key = "@quequan",
                    value= qq
                },
                new CustomParameter()
                {
                    key = "@hktt",
                    value= hktt
                }
            };
            var rs = db.ExeCute("khachHangThemMoi", lstPra);
            if(rs == 1)
            {
                MessageBox.Show("Thêm mới khách hàng thành công","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtHo.Text = null;
                txtTenDem.Text = null;
                txtTen.Text= null;
                txtDienThoai.Text = null;
                txtCMND.Text = null;
                txtQueQuan.Text = null;
                txtHKTT.Text = null;
            }
            
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {

        }
    }
}
