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
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        private Database db;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            db = new Database();
            loadDsLoaiPhong();
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
            var tenLoaiPhong = txtLoaiPhong.Text;
            var donGia = int.Parse(txtDonGia.Text);

            if (string.IsNullOrEmpty(tenLoaiPhong))
            {
                MessageBox.Show("Vui Lòng Nhập Tên Loại Phòng", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(donGia <= 0)
            {
                MessageBox.Show("Đơn Giá Phải > 0 (VND)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var prList = new List<CustomParameter>();
            prList.Add(new CustomParameter {
                key= "@tenLoaiPhong",
                value=tenLoaiPhong
            });
            prList.Add(new CustomParameter
            {
                key = "@donGia",
                value = donGia.ToString()
            });
            var rs = db.ExeCute("themLoaiPhong",prList);
            if (rs == 1)
            {
                MessageBox.Show("Thêm Loại Phòng Thành Công","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDsLoaiPhong();
                txtLoaiPhong.Text = null; 
                txtDonGia.Text = "0";
            }
        }
            

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

       
    }
}
