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
    public partial class frmThuePhong : Form
    {
        private Database db;
        public frmThuePhong()
        {
            InitializeComponent();
        }

        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            db = new Database();
            loadDSThuePhong();
        }
        private void loadDSThuePhong()
        {
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tukhoa",
                    value = txtTimKiem.Text.Trim()
                }
            };
            dgvThuePhong.DataSource = db.SelectData("loadDSThuePhong", lstPra);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmThue().ShowDialog();
            loadDSThuePhong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loadDSThuePhong();
        }

        private void dgvThuePhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(e.ColumnIndex == dgvThuePhong.Columns["btnThanhToan"].Index)
                {
                    var idThuePhong = dgvThuePhong.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                    new frmThanhToan(idThuePhong).ShowDialog();
                }
            }
        }
    }
}
