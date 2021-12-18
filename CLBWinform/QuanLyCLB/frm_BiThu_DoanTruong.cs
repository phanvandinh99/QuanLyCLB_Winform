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
            frm_CauLacBo clb = new frm_CauLacBo();
            clb.ShowDialog();
        }

        private void QuanLyDiaDiem_Click(object sender, EventArgs e)
        {
            frm_DiaDiem dd = new frm_DiaDiem();
            dd.ShowDialog();
        }
    }
}
