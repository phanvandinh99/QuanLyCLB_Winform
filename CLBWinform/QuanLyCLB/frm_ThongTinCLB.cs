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
    public partial class frm_ThongTinCLB : Form
    {
        KetNoiCSDL db = new KetNoiCSDL();
        public frm_ThongTinCLB()
        {
            InitializeComponent();
        }
        private void loadThanhVien_CLB(string name)
        {
            DataTable dt = db.red("select T.MSSV, T.Ho, T.Ten, T.Khoa, T.NgaySinh, T.GioiTinh, T.SDT from CLB C join GiaNhap G ON C.MaCLB = G.MaCLB join ThanhVien T ON G.MSSV = T.MSSV where C.TenCLB like N'"+name+"'");
            if (dt != null)
            {
                dataGridView_ThanhVien.DataSource = dt;
            }
        }
        private void loadCLB()
        {
            DataTable dt = db.red("Select * from CLB order by TenCLB");
            if (dt != null)
            {
                dataGridView_CLB.DataSource = dt;
            }
        }
        public void HienThiCBXBiThu()
        {
            string sql = "Select * from CLB";
            cbxCLB.DataSource = db.red(sql);
            cbxCLB.DisplayMember = "TenCLB";
            cbxCLB.ValueMember = "MaCLB";

        }
        private void frm_ThongTinCLB_Load(object sender, EventArgs e)
        {
            HienThiCBXBiThu();
            loadCLB();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cbxCLB.Text=="")
            {
                MessageBox.Show("Mời chọn tên CLB để xem", "Thông Báo Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                loadThanhVien_CLB(cbxCLB.Text);
            }    
        }

        private void dataGridView_CLB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxCLB.Text = dataGridView_CLB.CurrentRow.Cells["TenCLB"].Value.ToString();
        }
    }
}
