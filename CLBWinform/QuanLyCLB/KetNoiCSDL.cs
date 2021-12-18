using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCLB
{
    class KetNoiCSDL
    {
        #region Kết nối csdl
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=DataCLB;Integrated Security=True");
        public void opencon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closecon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public Boolean Exe(string cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;

            }
            closecon();
            return check;
        }
        public DataTable red(string cmd)
        {
            opencon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            closecon();
            return dt;
        }
        #endregion
    }
}
