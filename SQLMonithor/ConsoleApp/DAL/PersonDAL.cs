using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models;

namespace ConsoleApp.DAL
{
    class PersonDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PersonDAL(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = this._configuration.GetConnectionString("Default");
        }

        public List<person> GetAllPerson()
        {
            var lstPerson = new List<person>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT TOP 5 BusinessEntityID \r\n ,LastName  \r\n,FirstName  FROM [Person].[Person]", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        lstPerson.Add(new person
                        {
                            BusinessEntityID = Convert.ToInt32(rdr[0]),
                            LastName = rdr[1].ToString(),
                            FirstName = rdr[2].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstPerson;
        }
    }
}
