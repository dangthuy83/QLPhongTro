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
    public partial class frmDichVu : Form
    {
        private Database db;
        int id = -1;
        public frmDichVu()
        {
            db = new Database();
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            loadDSDichVu();
            dgvDichVu.Columns[0].Width = 150;
            dgvDichVu.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvDichVu.Columns[0].HeaderText = "ID Dịch Vụ";

            dgvDichVu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDichVu.Columns[1].HeaderText = "Tên Dịch Vụ";
        }
        private void loadDSDichVu()
        {
            
            var timkiem = txtTenDichVu.Text.Trim();
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@timKiem",
                    value = timkiem
                }
            };
            var dt = db.SelectData("loadDsDichVu", lstPra);
            dgvDichVu.DataSource = dt;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if(txtTenDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("vui lòng nhập tên dịch vụ!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tenDv",
                    value = txtTenDichVu.Text
                }
            };
            if (db.ExeCute("dichVuthem", lstPra) == 1)
            {
                MessageBox.Show("Thêm Mới dịch vụ thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDSDichVu();
                txtTenDichVu.Text = null;
                txtTenDichVu.Focus();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(id < 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần cập nhật!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenDichVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@id",
                    value = id.ToString()
                },
                new CustomParameter()
                {
                    key = "@tenDv",
                    value = txtTenDichVu.Text
                }                 
            };
            if (db.ExeCute("dichVuUpdate", lstPra) == 1)
            {
                MessageBox.Show("Cập nhật dịch vụ thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDSDichVu();
                txtTenDichVu.Text = null;
                txtTenDichVu.Focus();
                id = -1;
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (id < 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần cập nhật!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("BẠN CÓ CHẮC XÓA DỊCH VỤ " + txtTenDichVu.Text + " NÀY KHÔNG?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var lstPra = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@id",
                    value = id.ToString()
                }
            };
                if (db.ExeCute("dichVuXoa", lstPra) == 1)
                {
                    MessageBox.Show("Xóa dịch vụ thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDSDichVu();
                    txtTenDichVu.Text = null;
                    txtTenDichVu.Focus();
                    id = -1;
                }
            }

        }       
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>= 0)
            {
                id =int.Parse(dgvDichVu.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTenDichVu.Text = dgvDichVu.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
    }
}
