using System;
using Cau1.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAO
{
    public class ProjectDAO : DBConnection
    {
        public List<ProjectDTO> ReadCustomer()
        {

            {

                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee_2119110238", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                List<ProjectDTO> lstCus = new List<ProjectDTO>();
                DepartmentDAO dpm = new DepartmentDAO();
                while (reader.Read())
                {
                    ProjectDTO cus = new ProjectDTO();
                    cus.IdEmployee = reader["IdEmployee"].ToString();
                    cus.Name = reader["Name"].ToString();
                    cus.DateBirth = reader["DateBirth"].ToString();
                    cus.Gender = (bool.Parse(reader["Gender"].ToString()));
                    cus.PlaceBirth = reader["PlaceBirth"].ToString();
                    cus.Depart = dpm.ReadArea(reader["IdDepartment"].ToString());
                    lstCus.Add(cus);
                }
                conn.Close();
                return lstCus;

            }
        }
        public void NewCustomer(ProjectDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee_2119110238 values (@IdEmployee, @Name, @DateBirth ,@Gender, @PlaceBirth, @IdDepartment)", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", cus.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", cus.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cus.PlaceBirth));

            cmd.Parameters.Add(new SqlParameter("@IdDepartment", cus.Depart.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void DeleteCustomer(ProjectDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee_2119110238 where IdEmployee = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void EditCustomer(ProjectDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee_2119110238 set Name = @Name, DateBirth = @DateBirth, Gender = @Gender, PlaceBirth = @PlaceBirth, IdDepartment = @IdDepartment where IdEmployee = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", cus.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", cus.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", cus.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cus.PlaceBirth));

            cmd.Parameters.Add(new SqlParameter("@IdDepartment", cus.Depart.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
