using System;
using Cau1.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAO
{
    public class DepartmentDAO : DBConnection
    {
        public List<Department> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department_2119110238 ", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Department> lstDepart = new List<Department>();
            while (reader.Read())
            {
                Department depart = new Department();
                depart.IdDepartment = reader["IdDepartment"].ToString();
                depart.Name = reader["Name"].ToString();
                lstDepart.Add(depart);

            }
            conn.Close();
            return lstDepart;
        }
        public Department ReadArea(string IdDepartment)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department_2119110238  where IdDepartment= " + "'" + IdDepartment.ToString() + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Department depart = new Department();
            if (reader.HasRows && reader.Read())
            {
                depart.IdDepartment = reader["IdDepartment"].ToString();
                depart.Name = reader["Name"].ToString();
            }
            conn.Close();
            return depart;
        }
    }
}
