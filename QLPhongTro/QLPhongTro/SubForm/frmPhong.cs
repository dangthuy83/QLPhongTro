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
        public frmPhong()
        {
            InitializeComponent();
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            loadDSPhong();
            dgvDanhMucPhong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDanhMucPhong.Columns[0].Width = 100;
            dgvDanhMucPhong.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhMucPhong.Columns[0].HeaderText = "ID Phòng";            

            dgvDanhMucPhong.Columns[3].Width = 200;
            dgvDanhMucPhong.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhMucPhong.Columns[3].DefaultCellStyle.Format = "N0";
            dgvDanhMucPhong.Columns[3].HeaderText = "Đơn Giá";

            dgvDanhMucPhong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMucPhong.Columns[1].HeaderText = "Loại Phòng";

            dgvDanhMucPhong.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMucPhong.Columns[2].HeaderText = "Tên Phòng";

            dgvDanhMucPhong.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhMucPhong.Columns[4].HeaderText = "Trạng Thái";
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmXuLyPhong(true).ShowDialog();            
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
    }
}
