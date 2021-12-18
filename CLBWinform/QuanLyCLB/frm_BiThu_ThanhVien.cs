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
    public partial class frm_BiThu_ThanhVien : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public frm_BiThu_ThanhVien()
        {
            InitializeComponent();
        }
        public void Clears()
        {
            txtTaiKhoan.Clear();
            txtTaiKhoan.Focus();
            txtMatKhau.Clear();
            txtHo.Clear();
            txtTen.Clear();
        }
        private void load()
        {
            DataTable dt = db.red("select MSSV, MatKhau, Ho, Ten from ThanhVien where ChucVu = 'ThanhVien'");
            if (dt != null)
            {
                dataGridView_ThanhVien.DataSource = dt;
            }
        }
        private void frm_BiThu_ThanhVien_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView_ThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTaiKhoan.Text = dataGridView_ThanhVien.CurrentRow.Cells[0].Value.ToString();
            txtMatKhau.Text = dataGridView_ThanhVien.CurrentRow.Cells[1].Value.ToString();
            txtHo.Text = dataGridView_ThanhVien.CurrentRow.Cells[2].Value.ToString();
            txtTen.Text = dataGridView_ThanhVien.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnClears_Click(object sender, EventArgs e)
        {
            Clears();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Nhập MSSV để Cập nhật", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
                return;
            }
            if (txtHo.Text == "")
            {
                MessageBox.Show("Mời nhập Họ", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Mời nhập Tên", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return;
            }
            else
            {
                db.Exe("update ThanhVien set MatKhau = '" + txtMatKhau.Text + "', Ho = N'" + txtHo.Text + "', Ten = N'" + txtTen.Text + "' where MSSV = '" + txtTaiKhoan.Text + "'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Nhập Tài Khoản để Xóa", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
                return;
            }
            else
            {
                db.Exe("delete from ThanhVien where MSSV = '" + txtTaiKhoan.Text + "'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }

        private void btnClears_Click_1(object sender, EventArgs e)
        {
            Clears();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
