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
    public partial class frmThanhToan : Form
    {
        private string idThuePhong;
        private Database db;
        DataRow dr;
        public frmThanhToan(string idThuePhong)
        {
            this.idThuePhong = idThuePhong;
            db = new Database();
            InitializeComponent();
        }
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            loadHopDongThuePhong();
        }

        private void btnThoatThuePhong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void loadHopDongThuePhong()
        {
            List<CustomParameter> parameters = new List<CustomParameter>() 
            {
                new CustomParameter()
                {
                    key = "@id",
                    value= idThuePhong
                }
            };
            dr = db.SelectData("loadThongTinHopDongThuePhong", parameters).Rows[0];
            lblKhachHang.Text = dr["HoTen"].ToString();
            lblTenPhong.Text = dr["TenPhong"].ToString();
            lblGiaPhong.Text = string.Format("{0:N0} VND",int.Parse(dr["GiaPhong"].ToString()));

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtThanhToan_KeyUp(object sender, KeyEventArgs e)
        {
            lblConLai.Text = string.Format("{0:N0} VND", int.Parse(dr["GiaPhong"].ToString()) - int.Parse(txtThanhToan.Text));
        }

        private void txtThanhToan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            List<CustomParameter> lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@id",
                    value= idThuePhong
                },
                new CustomParameter()
                {
                    key = "@soTien",
                    value = txtThanhToan.Text.Trim()
                }
            };
            var kq = db.ExeCute("ThanhToan", lstPara);
            if(kq == 1)
            {
                MessageBox.Show("Thanh toán thành công!","",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
