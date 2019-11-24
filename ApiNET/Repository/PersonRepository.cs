using ApiNET.Services;
using ApiNET.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiNET.Repository
{
    ///<Summary>
    /// Person class
    ///</Summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DapperConnection"].ConnectionString;
        public IEnumerable<PersonViewModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<PersonViewModel>("SELECT * FROM Persons");
            }
        }

        public PersonViewModel GetByIin(string iin)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<PersonViewModel>("SELECT * FROM Persons WHERE Iin = @iin", new { iin }).FirstOrDefault();
            }
        }
        public void Create(PersonViewModel personViewModel)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Persons (iin, firstname, lastname, birthdate) VALUES(@Iin, @Firstname, @Lastname, @Birthdate);";
                db.Execute(sqlQuery, personViewModel);               
            }
        }
        public void Update(PersonViewModel personViewModel)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Persons SET Firstname = @Firstname, Lastname = @Lastname, Birthdate = @Birthdate WHERE Iin = @Iin";
                db.Execute(sqlQuery, personViewModel);
            }
        }
       
        public void Delete(string iin)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Persons WHERE Iin = @iin";
                db.Execute(sqlQuery, new { iin });
            }
        }
    }
}