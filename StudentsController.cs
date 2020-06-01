using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace zad4
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : Controller
    {
        private const string connecionString = "Data Source=db-mssql.pjwstk.edu.pl;" + "Initial Catalog=s18727;" + "Integrated Security=True";
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();
            
            using (var connection = new SqlConnection(connecionString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Student";
                
                connection.Open();
                var sdr = command.ExecuteReader();   

                while (sdr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = sdr["IndexNumber"].ToString();
                    st.FirstName = sdr["FirstName"].ToString();
                    st.LastName = sdr["LastName"].ToString();
                    
                    list.Add(st);
                }
            }
            return Ok(list);
        }
        
        
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            using (var connection = new SqlConnection(connecionString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Enrollment WHERE IdEnrollment = " +
                                      "(SELECT IdEnrollment FROM Student " +
                                      "WHERE IndexNumber = @indexNumber)";
                command.Parameters.AddWithValue("indexNumber", indexNumber);

                connection.Open();
                var sdr = command.ExecuteReader();

                if (sdr.Read())
                {
                    var enr = new Enrollment();

                    enr.IdEnrollment = (int) sdr["IdEnrollment"];
                    enr.Semester = (int) sdr["Semester"];
                    enr.IdStudy = (int) sdr["IdStudy"];
                    enr.StartDate = (DateTime) sdr["StartDate"];

                    return Ok(enr.ToString());
                }
            }
            
            return NotFound();
        }
    }
}