using QLPhongTro.SubForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
       //hàm add form con lên groupbox có tên grbContentMainForm
        private void AddForm(Form f)
        {
            this.grbContentMainForm.Controls.Clear();//xóa các control trong groupbox main form
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None; //bỏ viền của form con
            f.Dock = DockStyle.Fill;
            this.Text= f.Text;
            this.grbContentMainForm.Controls.Add(f);
            f.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loaiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmLoaiPhong();
            AddForm(f);
        }
    }
}
