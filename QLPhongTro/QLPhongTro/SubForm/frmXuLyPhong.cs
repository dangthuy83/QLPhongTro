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
        private string idphong;
        private Database db;
        public frmXuLyPhong(string idPhong)
        {    
            this.idphong = idPhong;
            InitializeComponent();
        }  
        private void frmXuLyPhong_Load(object sender, EventArgs e)
        {
            db = new Database();
            loadLoaiPhong();
            if (string.IsNullOrEmpty(idphong))  //nếu idphong là null thì thì sẽ thêm mới phòng
            {
                lblTitle.Text = "Thêm Phòng Mới!";
            }
            else
            {
                lblTitle.Text = "Cập Nhật Thông Tin Phòng!";
                //vì phòng được xác định qua id nên chúng ta cần truyền tham số là giá trị id của phòng
                var lstPra = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "@idphong",
                        value = idphong
                    }
                };
                //sử dụng hàm SelectData trong class Database để lấy dữ liệu phòng
                var dtbPhong = db.SelectData("sqlSelectPhong", lstPra).Rows[0]; //kết quả trả về 1 datatable có 1 hàng là id đã chọn
                //set các dữ liệu lấy được cho các component trên frmXylyphong
                cbbLoaiPhong.SelectedValue = dtbPhong["IDLoaiPhong"].ToString();
                txtTenPhong.Text = dtbPhong["TenPhong"].ToString();
                if (dtbPhong["TrangThai"].ToString() == "1")
                {
                    ckbTrangThai.Checked = true;
                }
                else
                {
                    ckbTrangThai.Checked = false;
                }
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
                MessageBox.Show("Vui lòng chọn loại phòng!","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            var idLoaiPhong = cbbLoaiPhong.SelectedValue.ToString();
            var tenPhong = txtTenPhong.Text.Trim();
            var trangthai = ckbTrangThai.Checked?1:0; //vì checkbox chỉ có true hoặc false,
                                                      //nên phải dùng toán tử 3 ngôi convert sang dạng bit 1,0 của dạng dữ liệu tinyint (SQL)

            if (string.IsNullOrEmpty(tenPhong))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }
            if (string.IsNullOrEmpty(idphong)) //trường hợp thêm mới phòng có idphong <=> null
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
                    MessageBox.Show("Thêm mới phòng thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else //trường hợp cập nhật phòng đã tồn tại <=> id phòng có giá trị #null
            {
                var lstPra = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "@idPhong",
                        value= idphong
                    },
                    new CustomParameter()
                    {
                        key = "@tenPhong",
                        value= txtTenPhong.Text
                    },
                    new CustomParameter()
                    {
                        key = "@idLoaiPhong",
                        value= cbbLoaiPhong.SelectedValue.ToString()
                    },
                    new CustomParameter()
                    {
                        key = "@trangThai",
                        value= trangthai.ToString()
                    }
                };
                var kq = db.ExeCute("sqlUpdatePhong", lstPra);
                if(kq == 1)
                {
                    MessageBox.Show("Cập nhật thông tin phòng thành công!","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose(); //đóng form frmXylyphong
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin phòng không thành công!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
