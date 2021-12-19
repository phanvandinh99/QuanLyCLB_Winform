using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCLB
{
    public partial class frm_BiThu_DoanTruong : Form
    {
        public frm_BiThu_DoanTruong()
        {
            InitializeComponent();
        }

        private void QuanLyTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyCLB_Click(object sender, EventArgs e)
        {
            frm_BiThu_QLChuNhiem clb = new frm_BiThu_QLChuNhiem();
            clb.ShowDialog();
        }

        private void QuanLyDiaDiem_Click(object sender, EventArgs e)
        {
            frm_DiaDiem dd = new frm_DiaDiem();
            dd.ShowDialog();
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BiThu_ChuNhiem btcn = new frm_BiThu_ChuNhiem();
            btcn.ShowDialog();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_BiThu_ThanhVien bttv = new frm_BiThu_ThanhVien();
            bttv.ShowDialog();

        }
    }
}
