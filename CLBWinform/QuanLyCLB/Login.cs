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
    public partial class Login : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public Login()
        {
            InitializeComponent();
        }
        public void Clears()
        {
            txtTenDangNhap.Clear();
            txtTenDangNhap.Focus();
            txtMatKhau.Clear();
        }
        private void btnDanhNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Mời nhập tên đăng nhập", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mời nhập mật khẩu", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            try
            {
                string taiKhoan = txtTenDangNhap.Text.Trim();
                string matKau = txtMatKhau.Text.Trim();

                DataTable thanhVien = db.red("select * from ThanhVien where MSSV = '" + taiKhoan + "' AND MatKhau = '" + matKau + "' AND ChucVu = 'ThanhVien'"); // thành viên
                if (thanhVien.Rows.Count == 1)
                {
                    frm_ThongTinCLB ttclb = new frm_ThongTinCLB();
                    Clears();
                    ttclb.ShowDialog();
                }
                else
                {
                    DataTable chuNhiem = db.red("select * from ThanhVien where MSSV = '" + taiKhoan + "' AND MatKhau = '" + matKau + "' AND ChucVu = 'ChuNhiem'"); // Chủ nhiệm
                    if (chuNhiem.Rows.Count == 1)
                    {
                        frm_ChuNhiemCLB cnclb = new frm_ChuNhiemCLB();
                        Clears();
                        cnclb.ShowDialog();
                    }
                    else
                    {
                        DataTable biThu = db.red("select * from BiThu where MSBT = '" + taiKhoan + "' AND MatKhau = '" + matKau + "'"); // Bí thư
                        if (biThu.Rows.Count == 1)
                        {
                            frm_BiThu_DoanTruong btdt = new frm_BiThu_DoanTruong();
                            Clears();
                            btdt.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi đăng nhập", "Thông Báo!", MessageBoxButtons.OK);
                            Clears();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thất bại", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}