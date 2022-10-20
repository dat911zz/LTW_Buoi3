using _2001202045_VuNgoDat_Buoi3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _2001202045_VuNgoDat_Buoi3.Core
{
    public class DAL
    {
        public string ConnStr = "Data Source=DESKTOP-GUE0JS7;Initial Catalog=QL_NhanSu;Integrated Security=True";
        public List<Employee> GetEmpList()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    string query = "select * from tbl_Employee";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(new Employee(
                            (int)row["Id"],
                            row["Name"].ToString(),
                            row["Gender"].ToString(),
                            row["City"].ToString()
                            ));
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }      
            return list;
        }
        public Employee GetEmp(string id)
        {
            return GetEmpList().Where(x => x.ID == int.Parse(id)).FirstOrDefault();
        }
        public int SL()
        {
            int sl = 0;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                string query = "select count(Id) from tbl_Employee";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                sl = (int)cmd.ExecuteScalar();
            }
            return sl;
        }
        public List<Department> GetDepList()
        {
            List<Department> list = new List<Department>();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                string query = "select * from tbl_Deparment";
                conn.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Department(
                        int.Parse(reader["DeptId"].ToString()),
                        reader["Name"].ToString()
                        ));
                }
            }

            return list;
        }
        public Department GetDep(string id)
        {
            return GetDepList().Where(x => x.Id == int.Parse(id)).FirstOrDefault();
        }
        public int CountEplInDep(string id)
        {
            int sl = 0;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                string query = "exec CountEmpInDep @id";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                sl = (int)cmd.ExecuteScalar();
            }
            return sl;
        }
        public List<Employee> GetEmplListInDept(string id)
        {
            List<Employee> list = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                string query = "exec ListEmplInDep @id";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Employee(
                        int.Parse(reader["Id"].ToString()),
                        reader["Name"].ToString(),
                        reader["Gender"].ToString(),
                        reader["City"].ToString()
                        ));
                }
            }
            return list;
        }
    }
}