using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro
{
    public class Database
    {
        private string connectionString = @"Data Source = Localhost\SQLSERVER; Initial Catalog = QLPHONGTRO; user ID = sa; password = 123";
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;
        public Database()
        {
            try 
            { 
                conn = new SqlConnection(connectionString);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("KHÔNG KẾT NỐI ĐƯỢC DATABASE" + ex.Message);
            }
        }
        public class CustomParameter
        {
            public string key { get; set; }
            public string value { get; set; }
        }
        public DataTable SelectData(string sql, List<CustomParameter> lstPara = null)
        {
            try 
            {
                conn.Open(); //mở kết nối
                cmd= new SqlCommand(sql, conn); //nộ dung câu lệnh sql được truyền vào
                cmd.CommandType = CommandType.StoredProcedure; //set command type là procedure
                dt = new DataTable();
                foreach(var para in lstPara)
                {
                    cmd.Parameters.AddWithValue(para.key, para.value); //gắn các tham số cho cmd
                }
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI LOAD DỮ LIỆU" + ex.Message);
                return null;
            }
            finally 
            { 
                conn.Close(); //đóng kết nối
            }
        }
        public int ExeCute(string sql, List<CustomParameter> lstPara = null)
        {
            try 
            { 
                conn.Open(); //mở kết nối
                cmd= new SqlCommand(sql, conn); //thực thi câu lệnh sql
                cmd.CommandType = CommandType.StoredProcedure; //set command type là procedure
                foreach (var para in lstPara)
                {
                    cmd.Parameters.AddWithValue(para.key, para.value); //gắn các tham số cho cmd
                }
                var rs = cmd.ExecuteNonQuery();//lấy kết quả thực thi truy vấn
                return (int)rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("KHÔNG THỰC HIỆN ĐƯỢC TRUY VẤN DỮ LIỆU" + ex.Message);
                return -1;
            }
            finally
            { 
                conn.Close(); //đóng kết nối
            }
        }
        public DataRow Select(string sql)
        {
            try
            {
                conn.Open(); //mở kết nối
                cmd = new SqlCommand(sql, conn); //thực thi câu lệnh sql
                cmd.CommandType = CommandType.StoredProcedure; //set command type là procedure
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader()); //thực thi câu lệnh
                return dt.Rows[0]; //trả về kết quả
            }
            catch (Exception ex)
            {
                MessageBox.Show("LỖI LOAD THÔNG TIN CHI TIẾT" + ex.Message);
                return null;
            }
            finally
            {
                conn.Close(); //đóng kết nối
            }
        }
    }
}
