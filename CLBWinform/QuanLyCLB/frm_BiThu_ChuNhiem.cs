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
    public partial class frm_BiThu_ChuNhiem : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public frm_BiThu_ChuNhiem()
        {
            InitializeComponent();
        }
        private void load()
        {
            DataTable dt = db.red("select MaSCN, MatKhau, Ho, Ten from ChuNhiem");
            if (dt != null)
            {
                dataGridView_ChuNhiem.DataSource = dt;
            }
        }
        private void frm_BiThu_ChuNhiem_Load(object sender, EventArgs e)
        {
            load();
        }
        public void Clears()
        {
            txtTaiKhoan.Clear();
            txtTaiKhoan.Focus();
            txtMatKhau.Clear();
            txtHo.Clear();
            txtTen.Clear();
        }    
        private void dataGridView_ChuNhiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTaiKhoan.Text = dataGridView_ChuNhiem.CurrentRow.Cells[0].Value.ToString();
            txtMatKhau.Text = dataGridView_ChuNhiem.CurrentRow.Cells[1].Value.ToString();
            txtHo.Text = dataGridView_ChuNhiem.CurrentRow.Cells[2].Value.ToString();
            txtTen.Text = dataGridView_ChuNhiem.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
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
                db.Exe("update ChuNhiem set MatKhau = '"+txtMatKhau.Text+"', Ho = N'"+txtHo.Text+"', Ten = N'"+txtTen.Text+"' where MaSCN = '"+txtTaiKhoan.Text+"'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Nhập Tài Khoản để Xóa", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
                return;
            }
            else
            {
                db.Exe("delete from ChuNhiem where MaSCN = '" + txtTaiKhoan.Text + "'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }

        private void btnClears_Click(object sender, EventArgs e)
        {
            Clears();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
