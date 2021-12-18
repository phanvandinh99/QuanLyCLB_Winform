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
    public partial class frm_CauLacBo : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public frm_CauLacBo()
        {
            InitializeComponent();
        }
        private void load()
        {
            DataTable dt = db.red("Select * from CLB order by TenCLB");
            if (dt != null)
            {
                dataGridView_clb.DataSource = dt;
            }
        }
        public void HienThiCBXBiThu()
        {
            string sql = "Select * from BiThu order by Ten";
            cbxMSBT.DataSource = db.red(sql);
            cbxMSBT.DisplayMember = "MSBT";
            cbxMSBT.ValueMember = "MSBT";

        }
        public void Clears()
        {
            txtMaCLB.Clear();
            txtMaCLB.Focus();
            txtTenCLB.Clear();
            txtFB.Clear();
        }
        private void frm_CauLacBo_Load(object sender, EventArgs e)
        {
            load();
            HienThiCBXBiThu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCLB.Text == "")
                {
                    MessageBox.Show("Mã CLB quan trọng, Không được bỏ trống", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaCLB.Focus();
                    return;
                }
                if (txtTenCLB.Text == "")
                {
                    MessageBox.Show("Không bỏ trống Tên CLB", "Thông báo!", MessageBoxButtons.OK);
                    txtTenCLB.Focus();
                    return;
                }
                db.Exe("insert into CLB(MaCLB, MSBT, TenCLB, LienKetFB) values ('" + txtMaCLB.Text + "', '" + cbxMSBT.SelectedValue.ToString() + "', N'" + txtTenCLB.Text + "', N'" + txtFB.Text + "')");
                MessageBox.Show("Thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                Clears();
            }
            catch
            {
                MessageBox.Show("Thông Báo", "Thêm Không Thành Công!", MessageBoxButtons.OK);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCLB.Text == "")
                {
                    MessageBox.Show("Nhập mã CLB để Cập Nhật", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaCLB.Focus();
                    return;
                }
                if (txtTenCLB.Text == "")
                {
                    MessageBox.Show("Không bỏ trống Tên CLB", "Thông báo!", MessageBoxButtons.OK);
                    txtTenCLB.Focus();
                    return;
                }
                db.Exe("update CLB set  MSBT = '" + cbxMSBT.SelectedValue.ToString() + "', TenCLB = N'" + txtTenCLB.Text + "', LienKetFB = N'" + txtFB.Text + "' where MaCLB = '" + txtMaCLB.Text + "'");
                MessageBox.Show("Cập nhật thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                Clears();
            }
            catch
            {
                MessageBox.Show("Thông Báo", "Cập nhật Không Thành Công!", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCLB.Text == "")
            {
                MessageBox.Show("Nhập mã CLB để Xóa", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaCLB.Focus();
                return;
            }
            db.Exe("delete from CLB where MaCLB = '"+txtMaCLB.Text+"'");
            MessageBox.Show("Xóa thành Công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load();
            Clears();
        }

        private void btnClears_Click(object sender, EventArgs e)
        {
            Clears();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_clb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCLB.Text = dataGridView_clb.CurrentRow.Cells[0].Value.ToString();
            cbxMSBT.Text = dataGridView_clb.CurrentRow.Cells["MSBT"].Value.ToString();
            txtTenCLB.Text = dataGridView_clb.CurrentRow.Cells[2].Value.ToString();
            txtFB.Text = dataGridView_clb.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
