using EmployeeManager.Azure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Azure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString;

        public EmployeeRepository(IConfiguration config)
        {
            this.connectionString = config.GetConnectionString("NorthwindDb");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectAll()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  EmployeeID, FirstName, LastName, Title, BirthDate, HireDate, Country, Notes " +
                    "FROM Employees ORDER BY EmployeeID ASC";

                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Employee> employees = new List<Employee>();

                while (reader.Read())
                {
                    Employee item = new Employee
                    {
                        EmployeeID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Title = reader.GetString(3),
                        BirthDate = reader.GetDateTime(4),
                        HireDate = reader.GetDateTime(5),
                        Country = reader.GetString(6),
                        Notes = reader.IsDBNull(7) ? "" : reader.GetString(7)
                    };
                    employees.Add(item);
                }
                reader.Close();
                cnn.Close();
                return employees;
            }
        }

        public Employee SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> SelectCountries()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
