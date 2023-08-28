using CoreWebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace CoreWebApi.Services
{
    public class Methods : IMethods
    {
        
        private readonly SqlConnection cn;
            
        public Methods()
        { 
       
            cn = new SqlConnection("Data Source=LTPCHE102528704\\SQLEXPRESS;Initial Catalog=Loyalty;Integrated Security=True");
        }

       
        public void AddEmp(Employee employee)
        {
            try
            {
               
                var query = "Insert into EmpInfo (Id,Name,Email,Mobile) values (@Id,@Name,@Email,@Mobile)";
               
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("Id", employee.Id);
                    cmd.Parameters.AddWithValue("Name", employee.Name);
                    cmd.Parameters.AddWithValue("Email", employee.Email);
                    cmd.Parameters.AddWithValue("Mobile", employee.Mobile);
                    cmd.ExecuteNonQuery();
                }

                cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeleteEmp(int empid)
        {
            SqlCommand cmd = new SqlCommand($"Delete from EmpInfo where Id={empid}",cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
          
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> emplist = new List<Employee>();
            SqlCommand cmd = new SqlCommand("Select * from EmpInfo", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["Id"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Mobile = dr["Mobile"].ToString();

                    emplist.Add(emp);


                }
            }
            cn.Close();
            return emplist;
        }

        public Employee GetEmployeeByID(int employeeId)
        {
          
            SqlCommand cmd = new SqlCommand($"Select * from EmpInfo Where Id={employeeId}", cn);
            cn.Open();
            SqlDataReader dr= cmd.ExecuteReader();

            Employee emp = new Employee();
            if (dr.Read())
            {
                emp.Id = Convert.ToInt32(dr["Id"]);
                emp.Name = dr["Name"].ToString();
                emp.Email = dr["Email"].ToString();
                emp.Mobile = dr["Mobile"].ToString();
            }

            cn.Close();
            return emp;
        }

        public void UpdateEmployee(Employee employee)
        {
            string query= "Update EmpInfo set Name=@Name,Email=@Email,Mobile=@Mobile where Id= @Id ";
            SqlCommand cmd= new SqlCommand(query, cn);
            cn.Open();
            cmd.Parameters.AddWithValue("Id",employee.Id);
            cmd.Parameters.AddWithValue("Name",employee.Name);
            cmd.Parameters.AddWithValue("Email", employee.Email );
            cmd.Parameters.AddWithValue("Mobile", employee.Mobile);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}
