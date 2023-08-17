using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CSharp38.Model;

namespace CSharp38
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _conn;

        public StudentRepository(IDbConnection conn)
        {
            _conn = conn;

        }


        public Student GetStudent(int id)
        {
            return _conn.QuerySingle<Student>("SELECT * FROM STUDENT WHERE ID = @id", new { id = id });
        }

        public void UpdateStudent(Student student)
        {
            _conn.Execute("UPDATE students SET Name = @stdntID, " +
                "Student = @stdntfirstname " +
                "WHERE ID = @id",
                new { StdntFirstName = student.StdntFirstName, StdntLastName = student.StdntLastName, StdntID = student.StdntID });
        }

        public void InsertStudent(Student studentToInsert)
        {
            _conn.Execute("INSERT INTO students (StdntID, StdntFirstName, StdntLastName, StdntGitHudID, StdntAge, StdntGrade) " +
                "VALUES (@stdntID, StdntFirstName, StdntLastName, StdntGitHudID, StdntAge, StdntGrade);",
                new { stdntID = studentToInsert.StdntID,
                    stdntFirstNameame = studentToInsert.StdntFirstName, 
                    stdntLastName = studentToInsert.StdntLastName,
                    
                });
        }
       


        public void DeleteStudent(Student student)
        {            
            _conn.Execute("DELETE FROM Student WHERE ID = @id;", new { id = student.ID });
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _conn.Query<Student>("Select * FROM STUDENT; ");
        }

       
    }
}
