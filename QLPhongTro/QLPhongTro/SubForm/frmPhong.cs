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
    public partial class frmPhong : Form
    {
        private Database db;
        private int rowIndex = -1; //lưu index của dgvdanhmucphong
        public frmPhong()
        {
            InitializeComponent();
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            loadDSPhong();
            #region Format column dgvDanhMucPhong
            dgvDanhMucPhong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDanhMucPhong.Columns[0].Width = 100;
            dgvDanhMucPhong.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhMucPhong.Columns[0].HeaderText = "ID Phòng";

            dgvDanhMucPhong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMucPhong.Columns[1].HeaderText = "Loại Phòng";

            dgvDanhMucPhong.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMucPhong.Columns[2].HeaderText = "Tên Phòng";

            dgvDanhMucPhong.Columns[3].Width = 200;
            dgvDanhMucPhong.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhMucPhong.Columns[3].DefaultCellStyle.Format = "N0"; //format số từ 200000 -> 200,000
            dgvDanhMucPhong.Columns[3].HeaderText = "Đơn Giá";
                        
            dgvDanhMucPhong.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMucPhong.Columns[4].HeaderText = "Trạng Thái";
            #endregion
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmXuLyPhong(null).ShowDialog(); //truyền tham số null để xác định trường hợp thêm mới phòng      
            loadDSPhong();
        }

        private void loadDSPhong()
        {
            db = new Database();
            var timkiem = txtTimKiem.Text.Trim();
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@timKiem",
                    value = timkiem
                }
            };
            var dt = db.SelectData("loadDsPhong", lstPra);
            dgvDanhMucPhong.DataSource = dt;
        }

        private void dgvDanhMucPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //lấy id phòng được chọn
            string idPhong = dgvDanhMucPhong.Rows[e.RowIndex].Cells[0].Value.ToString();
            new frmXuLyPhong(idPhong).ShowDialog(); //truyền tham số idphong chọn form frmxulyphong thành cập nhật
        }

        private void dgvDanhMucPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!","Chú Ý",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (MessageBox.Show("BẠN CÓ CHẮC MUỐN XÓA " + dgvDanhMucPhong.Rows[rowIndex].Cells[2].Value.ToString() +" KHÔNG?", "XÁC NHẬN XÓA PHÒNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var lstPra = new List<CustomParameter>()
                    {
                        new CustomParameter()
                        {
                            key = "@idPhong",
                            value = dgvDanhMucPhong.Rows[rowIndex].Cells[0].Value.ToString()
                        }
                    };
                    var kq = db.ExeCute("sqlDeletePhong", lstPra);
                    if(kq == 1)
                    {
                        MessageBox.Show("Xóa Phòng Thành Công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSPhong();
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loadDSPhong();
        }
    }
}
