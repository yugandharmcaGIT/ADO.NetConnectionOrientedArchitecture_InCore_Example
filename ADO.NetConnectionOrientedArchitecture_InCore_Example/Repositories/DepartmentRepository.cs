using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Contracts;
using ADO.NetConnectionOrientedArchitecture_InCore_Example.Models;
using System.Data;
using System.Runtime.InteropServices;

namespace ADO.NetConnectionOrientedArchitecture_InCore_Example.Repositories
{
    public class DepartmentRepository
    {
        string connectionString = "data source = Yugandhar;intigrated security = Yes;Encrypt = True; TrustServerCertificate = True; Initial catalag= Northwind_DB";

        public async Task<List<Department>> GetAllDepartment()
        {
            List<Department> lstdept = new List<Department>();
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        Department dept = new Department();
                        dept.DeptID = Convert.ToInt32(dr["deptid"]);
                        dept.DeptName = Convert.ToString(dr["deptname"]);
                        dept.DeptLocation = Convert.ToString(dr["deptlocation"]);

                        lstdept.Add(dept);
                    }
                    con.Close();
                }
                return lstdept;
            }
        }

        public async Task<Department> GetDepartmentByDeptid(int deptid)
        {
            Department dept = new Department();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_GetDepartmentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deptid", deptid);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (dr.Read()) 
                {
                    dept.DeptID = Convert.ToInt32(dr["deptid"]);
                    dept.DeptName = Convert.ToString(dr["deptname"]);
                    dept.DeptLocation = Convert.ToString(dr["deptlocation"]);
                }
                con.Close ();
            }
            return dept;
        }

        public async Task<bool> AddDepartment(Department deptdetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_AddDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deptname", deptdetail.DeptName);
                cmd.Parameters.AddWithValue("@deptlocation", deptdetail.DeptLocation);
                con.Open();
                await cmd.ExecuteNonQueryAsync(); 
                con.Close();
            }
            return true;
        }

        public async Task<bool> UpdateDepartment(Department deptdetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deptid",deptdetail.DeptID);
                cmd.Parameters.AddWithValue("@deptname", deptdetail.DeptName);
                cmd.Parameters.AddWithValue("@deptlocation", deptdetail.DeptLocation);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;
        }

        public async Task<bool> DeleteDepartmentByDeptid(int deptid)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_DeleteDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@deptid",deptid);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            return true;
        }

    }
}
