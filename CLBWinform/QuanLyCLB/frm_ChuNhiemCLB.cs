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
    public partial class frm_ChuNhiemCLB : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public frm_ChuNhiemCLB()
        {
            InitializeComponent();

        }
        // Hiển thị lên datagridview
        private void load()
        {
            DataTable dt = db.red("Select * from ThanhVien order by Ten");
            if (dt != null)
            {
                dataGridView_CLB.DataSource = dt;
            }
        }
        private void HienThiGioiTinh()
        {
            cbxGioiTinh.Items.Add("Nam");
            cbxGioiTinh.Items.Add("Nu");
            cbxGioiTinh.SelectedIndex = 0;

        }
        private void HienThiThanhVien()
        {
            cbxChucvu.Items.Add("ThanhVien");
            cbxChucvu.Items.Add("ChuNhiem");
            cbxChucvu.SelectedIndex = 0;

        }
        private void Clears()
        {
            txtMSSV.Clear();
            txtMSSV.Focus();
            txtHo.Clear();
            txtTen.Clear();
            txtMatKhau.Clear();
            txtKhoa.Clear();
            txtSDT.Clear();
        }
        private void frm_ChuNhiemCLB_Load(object sender, EventArgs e)
        {
            load();
            HienThiThanhVien();
            HienThiGioiTinh();
        }

        private void dataGridView_CLB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMSSV.Text = dataGridView_CLB.CurrentRow.Cells[0].Value.ToString();
            txtMatKhau.Text = dataGridView_CLB.CurrentRow.Cells[1].Value.ToString();
            txtTen.Text = dataGridView_CLB.CurrentRow.Cells[2].Value.ToString();
            txtHo.Text = dataGridView_CLB.CurrentRow.Cells[3].Value.ToString();
            txtKhoa.Text = dataGridView_CLB.CurrentRow.Cells[4].Value.ToString();
            dateTime_NgaySinh.Value = DateTime.Parse(dataGridView_CLB.CurrentRow.Cells[5].Value.ToString());
            cbxGioiTinh.Text = dataGridView_CLB.CurrentRow.Cells[6].Value.ToString();
            txtSDT.Text = dataGridView_CLB.CurrentRow.Cells[7].Value.ToString();
            cbxChucvu.Text = dataGridView_CLB.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnClears_Click(object sender, EventArgs e)
        {
            Clears();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMSSV.Text == "")
                {
                    MessageBox.Show("Mã số sinh viên quan trọng, Không được bỏ trống", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMSSV.Focus();
                    return;
                }
                if (txtHo.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống Họ", "Thông Báo Lỗi!", MessageBoxButtons.OK);
                    txtHo.Focus();
                    return;
                }
                if (txtTen.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống Tên", "Thông Báo Lỗi!", MessageBoxButtons.OK);
                    txtTen.Focus();
                    return;
                }
                if (txtMatKhau.Text == "") // Mật khẩu k nhập sẽ là 'abc123'
                {
                    txtMatKhau.Text = "abc123";
                }
                if (txtKhoa.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống Khoa", "Thông Báo Lỗi!", MessageBoxButtons.OK);
                    txtKhoa.Focus();
                    return;
                }
                string ns = string.Format("{0:dd/MMM/yyyy}", dateTime_NgaySinh.Value);
                db.Exe("insert into ThanhVien(MSSV, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT, ChucVu) values ('" + txtMSSV.Text + "', '" + txtMatKhau.Text + "', N'" + txtHo.Text + "', N'" + txtTen.Text + "', N'" + txtKhoa.Text + "', '" + ns + "', N'" + cbxGioiTinh.Text + "', '" + txtSDT.Text + "', '" + cbxChucvu.Text + "')");
                load();
                Clears();
            }
            catch
            {
                MessageBox.Show("Thông Báo", "Thêm Không Thành Công!", MessageBoxButtons.OK);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Nhập MSSV để Xóa", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMSSV.Focus();
                return;
            }
            else
            {
                string ns = string.Format("{0:dd/MMM/yyyy}", dateTime_NgaySinh.Value);
                db.Exe("delete from ThanhVien where MSSV = '"+txtMSSV.Text+"'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Nhập MSSV để Cập nhật", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMSSV.Focus();
                return;
            }
            else
            {
                string ns = string.Format("{0:dd/MMM/yyyy}", dateTime_NgaySinh.Value);
                db.Exe("update ThanhVien set MatKhau = '" + txtMatKhau.Text + "', Ho = N'" + txtHo.Text + "', Ten = N'" + txtTen.Text + "', Khoa = '" + txtKhoa.Text + "', NgaySinh = '" + ns + "', GioiTinh = '" + cbxGioiTinh.Text + "', SDT = '" + txtSDT.Text + "', ChucVu = '" + cbxChucvu.Text + "' where MSSV = '" + txtMSSV.Text + "'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }
    }
}
