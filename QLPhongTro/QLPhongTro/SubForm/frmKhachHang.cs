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
        private int maKhachHang = 0;
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
            loadDSKhachHang();
        }
        private void loadDSKhachHang ()
        {
            var db = new Database();
            dgvKhachHang.DataSource = db.SelectData("loadDSKhachHang");

            

            dgvKhachHang.Columns[0].Width = 50;
            //dgvKhachHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[0].HeaderText = "ID";

            dgvKhachHang.Columns[1].Width = 50;
            //dgvKhachHang.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[1].HeaderText = "Họ";

            dgvKhachHang.Columns[2].Width = 100;
            //dgvKhachHang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[2].HeaderText = "Tên Đệm";

            dgvKhachHang.Columns[3].Width = 50;
            //dgvKhachHang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[3].HeaderText = "Tên";

            dgvKhachHang.Columns[4].Width = 100;
            //dgvKhachHang.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[4].HeaderText = "CMND/CCCD";

            dgvKhachHang.Columns[5].Width = 100;
            //dgvKhachHang.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[5].HeaderText = "Điện Thoại";

            dgvKhachHang.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvKhachHang.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[6].HeaderText = "Quê Quán";

            dgvKhachHang.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvKhachHang.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvKhachHang.Columns[7].HeaderText = "Hộ Khẩu Thường Trú";
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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                MessageBox.Show("Thêm mới khách hàng thành công!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                loadDSKhachHang();
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
            var ho = txtHo.Text.Trim();
            var tenDem = txtTenDem.Text.Trim();
            var ten = txtTen.Text.Trim();
            var dienThoai = txtDienThoai.Text.Trim();
            var cmnd = txtCMND.Text.Trim();
            var qq = txtQueQuan.Text.Trim();
            var hktt = txtHKTT.Text.Trim();
            if (maKhachHang == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa thông tin!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(ho) || string.IsNullOrEmpty(tenDem) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(cmnd) || string.IsNullOrEmpty(qq) || string.IsNullOrEmpty(hktt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idKH",
                    value= maKhachHang.ToString()
                },
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
            var rs = db.ExeCute("khachHangSuaThongTin", lstPra);
            if (rs == 1)
            {
                MessageBox.Show("Thay đổi thông tin khách hàng thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maKhachHang = 0;
                loadDSKhachHang();
                txtHo.Text = null;
                txtTenDem.Text = null;
                txtTen.Text = null;
                txtDienThoai.Text = null;
                txtCMND.Text = null;
                txtQueQuan.Text = null;
                txtHKTT.Text = null;
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (maKhachHang == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa thông tin!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idKH",
                    value= maKhachHang.ToString()
                }
            };
            if (MessageBox.Show("Bạn có chắc chắn xóa khách hàng này không","WARNING",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var rs = db.ExeCute("khachHangDelete", lstPra);
                if (rs == 1)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    maKhachHang = 0;
                    loadDSKhachHang();
                    txtHo.Text = null;
                    txtTenDem.Text = null;
                    txtTen.Text = null;
                    txtDienThoai.Text = null;
                    txtCMND.Text = null;
                    txtQueQuan.Text = null;
                    txtHKTT.Text = null;
                }
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                maKhachHang = int.Parse(dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtHo.Text = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTenDem.Text = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTen.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCMND.Text = dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDienThoai.Text = dgvKhachHang.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtQueQuan.Text = dgvKhachHang.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtHKTT.Text = dgvKhachHang.Rows[e.RowIndex].Cells[7].Value.ToString();
                //txtDonGia.Text = string.Format("{0:#,##0}", int.Parse(txtDonGia.Text));
                // = string.Format("{0:#,##0}", txtDonGia.Text);                
            }
        }
    }
}
