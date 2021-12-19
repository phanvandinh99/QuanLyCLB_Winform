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
            DataTable dt = db.red("select TV.MSSV, TV.MatKhau, TV.Ho, TV.Ten, TV.Khoa, TV.NgaySinh, TV.GioiTinh, TV.SDT, C.TenCLB from ThanhVien TV join GiaNhap G ON TV.MSSV = G.MSSV join CLB C ON C.MaCLB = G.MaCLB order by TV.Ten");
            if (dt != null)
            {
                dataGridView_CLB.DataSource = dt;
            }
        }
        private void HienThiGioiTinh()
        {
            cbxGioiTinh.Items.Add("Nam");
            cbxGioiTinh.Items.Add("Nữ");
            cbxGioiTinh.SelectedIndex = 0;

        }
        public void HienThiCBXBiThu()
        {
            string sql = "Select * from CLB order by TenCLB";
            cbxCLB.DataSource = db.red(sql);
            cbxCLB.DisplayMember = "TenCLB";
            cbxCLB.ValueMember = "MaCLB";

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
            HienThiCBXBiThu();
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
            cbxCLB.Text = dataGridView_CLB.CurrentRow.Cells[8].Value.ToString();
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
                string date = string.Format("{0:dd/MMM/yyyy}", DateTime.Now);

                db.Exe("insert into ThanhVien(MSSV, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT) values ('" + txtMSSV.Text + "', '" + txtMatKhau.Text + "', N'" + txtHo.Text + "', N'" + txtTen.Text + "', N'" + txtKhoa.Text + "', '" + ns + "', N'" + cbxGioiTinh.Text + "', '" + txtSDT.Text + "')");
                db.Exe("insert into GiaNhap(MSSV, MaCLB, NgayGiaNhap) values ('" + txtMSSV.Text + "', '" + cbxCLB.SelectedValue.ToString() + "', '" + date + "')"); //add vào clb
                MessageBox.Show("Thêm mới thành công", "Thông Báo!", MessageBoxButtons.OK);
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
                db.Exe("delete from GiaNhap where MSSV = '" + txtMSSV.Text + "'");
                db.Exe("delete from ThanhVien where MSSV = '" + txtMSSV.Text + "'");
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
                db.Exe("update ThanhVien set MatKhau = '" + txtMatKhau.Text + "', Ho = N'" + txtHo.Text + "', Ten = N'" + txtTen.Text + "', Khoa = '" + txtKhoa.Text + "', NgaySinh = '" + ns + "', GioiTinh = '" + cbxGioiTinh.Text + "', SDT = '" + txtSDT.Text + "' where MSSV = '" + txtMSSV.Text + "'");
                db.Exe("update GiaNhap set MaCLB = '" + cbxCLB.SelectedValue.ToString() + "' where MSSV = '" + txtMSSV.Text + "'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }
    }
}
