using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLPhongTro.Database;

namespace QLPhongTro.SubForm
{
    public partial class frmXuLyPhong : Form
    {
        private bool themmoi;
        private Database db;
        public frmXuLyPhong(bool themMoi)
        {    
            this.themmoi = themMoi;
            InitializeComponent();
        }  
        private void frmXuLyPhong_Load(object sender, EventArgs e)
        {
            db = new Database();
            loadLoaiPhong();
            if (themmoi)
            {
                lblTitle.Text = "Thêm Phòng Mới";
            }
            else
            {
                lblTitle.Text = "Cập Nhật Thông Tin Phòng";
            }
        }
        private void loadLoaiPhong()
        {
            var dt = db.SelectData("loadDSLoaiPhong");
            cbbLoaiPhong.DataSource = dt;
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbbLoaiPhong.ValueMember = "ID";
        }
        private void btnThoatXuLyPhong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(cbbLoaiPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            var idLoaiPhong = cbbLoaiPhong.SelectedValue.ToString();
            var tenPhong = txtTenPhong.Text.Trim();
            var trangthai = ckbTrangThai.Checked?1:0; //vì checkbox chỉ có true hoặc false,
                                                      //nên phải dùng toán tử 3 ngôi convert sang dạng bit 1,0 của dạng dữ liệu tinyint (SQL)

            if (string.IsNullOrEmpty(tenPhong))
            {
                MessageBox.Show("Vui lòng nhập tên phòng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }
            if(themmoi) //trường hợp thêm mới phòng
            {
                var lstPra = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "@idLoaiPhong",
                        value= idLoaiPhong
                    },
                    new CustomParameter()
                    {
                        key = "@tenPhong",
                        value= tenPhong
                    },
                     new CustomParameter()
                    {
                        key = "@trangThai",
                        value= trangthai.ToString()
                    }
                };
                var rs = db.ExeCute("themMoiPhong",lstPra);
                if(rs == 1)
                {
                    MessageBox.Show("Thêm mới phòng thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else //trường hợp cập nhật phòng
            {

            }
        }
    }
}
