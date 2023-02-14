using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLPhongTro.Database;

namespace QLPhongTro.SubForm
{
    public partial class frmThue : Form
    {
        private Database db,dt;
        public frmThue()
        {
            InitializeComponent();
        }
        private void frmThue_Load(object sender, EventArgs e)
        {
            db = new Database();         
            var rs = db.SelectData("LoadAllDsPhong");

            cbbPhong.DataSource= rs;
            cbbPhong.ValueMember = "ID";
            cbbPhong.DisplayMember = "TenPhong";
            cbbPhong.SelectedIndex = -1;

            //load ds KH
            dt = new Database();
            var dts = dt.SelectData("loadDSKhachHangGhepHoTen");

            cbbKhachHang.DataSource= dts;
            cbbKhachHang.ValueMember= "ID";
            cbbKhachHang.DisplayMember= "HoTen";
            cbbKhachHang.SelectedIndex = -1;

            mtbNgayThue.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            mtbNgayTra.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnThoatThuePhong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var idPhong = cbbPhong.SelectedValue.ToString();
            var idKH = cbbKhachHang.SelectedValue.ToString();
            DateTime ngayThue, ngayTra;
            try
            {
                ngayThue = DateTime.ParseExact(mtbNgayThue.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ngayTra = DateTime.ParseExact(mtbNgayTra.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if(ngayTra <= ngayThue)
                {
                    MessageBox.Show("Ngày thuê không được bé hơn hoặc bằng ngày trả!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Ngày thuê hoặc ngày trả không hợp lệ!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng thuê!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
            if (cbbKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách thuê!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int datcoc;
            try
            {
                datcoc = int.Parse(txtTienCoc.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập tiền đặt cọc!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@idphong",
                    value = idPhong
                },
                new CustomParameter()
                {
                    key = "@idKH",
                    value = idKH
                },
                new CustomParameter()
                {
                    key = "@datCoc",
                    value = datcoc.ToString()
                },
                new CustomParameter()
                {
                    key = "@ngayThue",
                    value = ngayThue.ToString()
                },
                new CustomParameter()
                {
                    key = "@ngayTra",
                    value = ngayTra.ToString()
                }
            };
            var rs = db.ExeCute("ThuePhong", lstPra);
            if(rs == 1)
            {
                MessageBox.Show("Thuê phòng thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var updateTrangThai = new List<CustomParameter>()
                {
                    new CustomParameter()
                    {
                        key = "@idphong",
                        value = idPhong
                    },
                    new CustomParameter()
                    {
                        key = "@trangThai",
                        value = "1"
                    }
                };
                db.ExeCute("sqlUpdateTrangThaiPhong", updateTrangThai);
                this.Dispose();
            }
                
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            var f = new frmKhachHang();
            f.ShowDialog();
        }

        private void txtTienCoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
