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
    public partial class frm_BiThu_QLChuNhiem : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public frm_BiThu_QLChuNhiem()
        {
            InitializeComponent();
        }
        private void HienThiGioiTinh()
        {
            cbxGioiTinh.Items.Add("Nam");
            cbxGioiTinh.Items.Add("Nữ");
            cbxGioiTinh.SelectedIndex = 0;

        }
        public void HienThiCBXBiThu()
        {
            string sql = "Select * from BiThu order by Ten";
            cbxMSBT.DataSource = db.red(sql);
            cbxMSBT.DisplayMember = "MSBT";
            cbxMSBT.ValueMember = "MSBT";

        }
        public void HienThiCBXCLB_ChuaChuNhiem()
        {
            string sql = "Select * from CLB";
            //cbxCLB.DataSource = db.red(sql);
            //cbxCLB.DisplayMember = "TenCLB";
            //cbxCLB.ValueMember = "MaCLB";

        }
        private void Clears()
        {
            txtMaSCN.Clear();
            txtMaSCN.Focus();
            txtHo.Clear();
            txtTen.Clear();
            txtMatKhau.Clear();
            txtKhoa.Clear();
            txtSDT.Clear();
            txtMaCLB.Clear();
            txtTenCLB.Clear();
            txtFB.Clear();
        }
        private void load()
        {
            DataTable dt = db.red("select * from ChuNhiem CN join CLB C ON C.MaSCN = CN.MaSCN order by CN.Ten");
            if (dt != null)
            {
                dataGridView_ChuNhiem.DataSource = dt;
            }
        }
        private void frm_BiThu_QLChuNhiem_Load(object sender, EventArgs e)
        {
            load();
            HienThiGioiTinh();
            HienThiCBXBiThu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSCN.Text == "")
                {
                    MessageBox.Show("Mã số chủ nhiệm quan trọng, Không được bỏ trống", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaSCN.Focus();
                    return;
                }
                if (txtMaCLB.Text == "")
                {
                    MessageBox.Show("Mã CLB quan trọng, Không được bỏ trống", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaCLB.Focus();
                    return;
                }
                if (txtTenCLB.Text == "")
                {
                    MessageBox.Show("Không được bỏ trống tên CLB", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenCLB.Focus();
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

                db.Exe("insert into ChuNhiem(MaSCN, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT) values ('" + txtMaSCN.Text + "', '" + txtMatKhau.Text + "', N'" + txtHo.Text + "', N'" + txtTen.Text + "', N'" + txtKhoa.Text + "', '" + ns + "', N'" + cbxGioiTinh.Text + "', '" + txtSDT.Text + "')");
                db.Exe("insert into CLB(MaCLB, MSBT, MaSCN, TenCLB, LienKetFB) values ('" + txtMaCLB.Text + "', '" + cbxMSBT.SelectedValue.ToString() + "', '" + txtMaSCN.Text + "', N'" + txtTenCLB.Text + "', N'" + txtFB.Text + "')"); //add vào clb
                MessageBox.Show("Thêm mới thành công", "Thông Báo!", MessageBoxButtons.OK);
                load();
                Clears();
            }
            catch
            {
                MessageBox.Show("Thông Báo", "Thêm Không Thành Công!", MessageBoxButtons.OK);
            }
        }

        private void dataGridView_ChuNhiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSCN.Text = dataGridView_ChuNhiem.CurrentRow.Cells[0].Value.ToString();
            txtMatKhau.Text = dataGridView_ChuNhiem.CurrentRow.Cells[1].Value.ToString();
            txtTen.Text = dataGridView_ChuNhiem.CurrentRow.Cells[2].Value.ToString();
            txtHo.Text = dataGridView_ChuNhiem.CurrentRow.Cells[3].Value.ToString();
            txtKhoa.Text = dataGridView_ChuNhiem.CurrentRow.Cells[4].Value.ToString();
            dateTime_NgaySinh.Value = DateTime.Parse(dataGridView_ChuNhiem.CurrentRow.Cells[5].Value.ToString());
            cbxGioiTinh.Text = dataGridView_ChuNhiem.CurrentRow.Cells[6].Value.ToString();
            txtSDT.Text = dataGridView_ChuNhiem.CurrentRow.Cells[7].Value.ToString();
            txtMaCLB.Text = dataGridView_ChuNhiem.CurrentRow.Cells[8].Value.ToString();
            cbxMSBT.Text = dataGridView_ChuNhiem.CurrentRow.Cells[9].Value.ToString();
            txtFB.Text = dataGridView_ChuNhiem.CurrentRow.Cells[12].Value.ToString();
            txtTenCLB.Text = dataGridView_ChuNhiem.CurrentRow.Cells[11].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSCN.Text == "")
            {
                MessageBox.Show("Nhập Mã Số Chủ Nhiệm để Xóa", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSCN.Focus();
                return;
            }
            else
            {
                db.Exe("delete from CLB where MaSCN = '" + txtMaSCN.Text + "'");
                db.Exe("delete from ChuNhiem where MaSCN = '" + txtMaSCN.Text + "'");
                Clears();
                load();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaSCN.Text == "")
            {
                MessageBox.Show("Nhập MaSCN để Cập nhật", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSCN.Focus();
                return;
            }
            else
            {
                string ns = string.Format("{0:dd/MMM/yyyy}", dateTime_NgaySinh.Value);
                db.Exe("update ChuNhiem set MatKhau = '"+txtMatKhau.Text+"', Ho=N'"+txtHo.Text+"', Ten =N'"+txtTen.Text+"', Khoa = N'"+txtKhoa.Text+"', NgaySinh = '"+ns+"', GioiTinh = N'"+cbxGioiTinh.Text+"', SDT = '"+txtSDT.Text+"' where MaSCN ='"+txtMaSCN.Text+"' ");
                db.Exe("update CLB set  MSBT = '" + cbxMSBT.SelectedValue.ToString() + "', TenCLB = N'" + txtTenCLB.Text + "', LienKetFB = N'" + txtFB.Text + "' where MaSCN = '" + txtMaSCN.Text + "'");
                MessageBox.Show("Thành Công", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clears();
                load();
            }
        }
    }
}
