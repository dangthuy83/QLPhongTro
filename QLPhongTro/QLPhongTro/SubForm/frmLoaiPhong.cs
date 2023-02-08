using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLPhongTro.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLPhongTro.SubForm
{
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        private Database db;
        private int maLoaiPhong = 0;
        private int xacNhan = 0;

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            db = new Database();
            loadDsLoaiPhong();

            lblTrangThai.Text = null;
            
            btnXacNhan.Enabled = false;
            btnCapNhat.Enabled = btnThem.Enabled = true;

            txtDonGia.ReadOnly = true;
            txtLoaiPhong.ReadOnly = true;

            dgvDanhMucLoaiPhog.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDanhMucLoaiPhog.Columns[0].Width= 100;
            dgvDanhMucLoaiPhog.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhMucLoaiPhog.Columns[0].HeaderText = "ID Phòng";

            dgvDanhMucLoaiPhog.Columns[2].Width = 200;
            dgvDanhMucLoaiPhog.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhMucLoaiPhog.Columns[2].DefaultCellStyle.Format = "N0";
            dgvDanhMucLoaiPhog.Columns[2].HeaderText = "Đơn Giá";

            dgvDanhMucLoaiPhog.Columns[1].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMucLoaiPhog.Columns[1].HeaderText = "Tên Loại Phòng";
        }
        private void loadDsLoaiPhong()
        {
            var db = new Database();            
            dgvDanhMucLoaiPhog.DataSource = db.SelectData("loadDSLoaiPhong");
        }
        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chỉ cho ô textbox đơn giá nhập số, không cho nhập chữ
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "ĐANG THÊM LOẠI PHÒNG MỚI...";
            xacNhan = 1;
            txtDonGia.ReadOnly = false;
            txtLoaiPhong.ReadOnly = false;
            txtDonGia.Text = "0";
            txtLoaiPhong.Text = null;

            btnXacNhan.Enabled = true;
            btnCapNhat.Enabled = btnThem.Enabled = false;
        }
            

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            lblTrangThai.Text = "ĐANG CẬP NHẬT THÔNG TIN LOẠI PHÒNG....";
            xacNhan = -1;
            txtDonGia.ReadOnly = false;
            txtLoaiPhong.ReadOnly = false;
            btnXacNhan.Enabled = true;
            btnCapNhat.Enabled = btnThem.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var tenLoaiPhong = txtLoaiPhong.Text;
            var donGia = int.Parse(txtDonGia.Text);

            if (string.IsNullOrEmpty(tenLoaiPhong))
            {
                MessageBox.Show("Vui Lòng Nhập Tên Loại Phòng", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (donGia <= 0)
            {
                MessageBox.Show("Đơn Giá Phải > 0 (VND)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (xacNhan == 1)
            {               
                var prList = new List<CustomParameter>();
                prList.Add(new CustomParameter
                {
                    key = "@tenLoaiPhong",
                    value = tenLoaiPhong
                });
                prList.Add(new CustomParameter
                {
                    key = "@donGia",
                    value = donGia.ToString()
                });
                var rs = db.ExeCute("themLoaiPhong", prList);
                if (rs == 1)
                {
                    MessageBox.Show("Thêm Loại Phòng Thành Công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
            }
            else if(xacNhan == -1)
            {  
                if (maLoaiPhong == 0)
                {
                    MessageBox.Show("Vui Lòng Chọn Phòng Cần Cập Nhật", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }             

                var prList = new List<CustomParameter>();
                prList.Add(new CustomParameter
                {
                    key = "@idLoaiPhong",
                    value = maLoaiPhong.ToString()
                });
                prList.Add(new CustomParameter
                {
                    key = "@tenLoaiPhong",
                    value = tenLoaiPhong
                });
                prList.Add(new CustomParameter
                {
                    key = "@donGia",
                    value = donGia.ToString()
                });
                var rs = db.ExeCute("capNhatLoaiPhong", prList);
                if (rs == 1)
                {
                    MessageBox.Show("Cập Nhật Loại Phòng Thành Công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
            }
            loadDsLoaiPhong();
            txtLoaiPhong.Text = null;
            txtDonGia.Text = "0";
            maLoaiPhong = 0;
            txtDonGia.ReadOnly= true;
            txtLoaiPhong.ReadOnly= true;

            btnXacNhan.Enabled = false;
            btnCapNhat.Enabled = btnThem.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {            
            if(maLoaiPhong == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Phòng Cần Xóa","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(MessageBox.Show("BẠN CÓ CHẮC CHẮN XÓA LOẠI PHÒNG " + '"' + txtLoaiPhong.Text.ToUpper() + '"' + " NÀY KHÔNG","XÁC NHẬN XÓA",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var lstpara = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "@idLoaiPhong",
                        value = maLoaiPhong.ToString()
                    }
                };

                var rs = db.ExeCute("xoaLoaiPhong", lstpara);
                if(rs  == 1)
                {
                    MessageBox.Show("XÓA " + '"' + txtLoaiPhong.Text.ToUpper() + '"' + " THÀNH CÔNG", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDsLoaiPhong();
                    maLoaiPhong= 0;
                }
                
            }    
        }
        private void dgvDanhMucLoaiPhog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                maLoaiPhong = int.Parse(dgvDanhMucLoaiPhog.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtLoaiPhong.Text = dgvDanhMucLoaiPhog.Rows[e.RowIndex].Cells[1].Value.ToString();                
                txtDonGia.Text = dgvDanhMucLoaiPhog.Rows[e.RowIndex].Cells[2].Value.ToString();
                //txtDonGia.Text = string.Format("{0:#,##0}", int.Parse(txtDonGia.Text));
                // = string.Format("{0:#,##0}", txtDonGia.Text);                
            }
        }

        
    }
}
