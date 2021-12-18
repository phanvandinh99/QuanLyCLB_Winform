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
    public partial class frm_DiaDiem : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public frm_DiaDiem()
        {
            InitializeComponent();
        }
        private void load()
        {
            DataTable dt = db.red("Select * from DiaDiem order by TenDD");
            if (dt != null)
            {
                dataGridView_DiaDiem.DataSource = dt;
            }
        }
        public void Clears()
        {
            txtMaDD.Clear();
            txtMaDD.Focus();
            txtTenDD.Clear();
            txtGhiChu.Clear();
        }
        private void frm_DiaDiem_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDD.Text == "")
                {
                    MessageBox.Show("Mã địa điểm quan trọng, Không được bỏ trống", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaDD.Focus();
                    return;
                }
                if (txtTenDD.Text == "")
                {
                    MessageBox.Show("Không bỏ trống Tên Địa Điểm", "Thông báo!", MessageBoxButtons.OK);
                    txtTenDD.Focus();
                    return;
                }
                db.Exe("insert into DiaDiem(MaDD, TenDD, GhiChu) values ('" + txtMaDD.Text + "', N'" + txtTenDD.Text + "', N'" + txtGhiChu.Text + "')");
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
                if (txtMaDD.Text == "")
                {
                    MessageBox.Show("Nhập mã địa điểm để Cập Nhật", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaDD.Focus();
                    return;
                }
                if (txtTenDD.Text == "")
                {
                    MessageBox.Show("Không bỏ trống Tên Địa Điểm", "Thông báo!", MessageBoxButtons.OK);
                    txtTenDD.Focus();
                    return;
                }
                db.Exe("update DiaDiem set TenDD = N'"+txtTenDD.Text+"', GhiChu= N'"+txtGhiChu.Text+"' where MaDD = '"+txtMaDD.Text+"'");
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
            if (txtMaDD.Text == "")
            {
                MessageBox.Show("Nhập mã địa điểm để Xóa", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDD.Focus();
                return;
            }
            db.Exe("delete from DiaDiem where MaDD = '"+txtMaDD.Text+"'");
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

        private void dataGridView_DiaDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDD.Text = dataGridView_DiaDiem.CurrentRow.Cells[0].Value.ToString();
            txtTenDD.Text = dataGridView_DiaDiem.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = dataGridView_DiaDiem.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
