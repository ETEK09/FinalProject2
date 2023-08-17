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
            _conn.Execute("UPDATE students SET Name = @studentID, " +
                "Student = @firstname " +
                "WHERE ID = @id",
                new { FirstName = student.FirstName, LastName = student.LastName, StudentID = student.StudentID });
        }

        public void InsertStudent(Student studentToInsert)
        {
            _conn.Execute("INSERT INTO students (StudentID, FirstName, LastName, GitHudID, Age, Grade) " +
                "VALUES (@studentID, FirstName, LastName, GitHudID, Age, Grade);",
                new { studentID = studentToInsert.StudentID,
                    FirstName = studentToInsert.FirstName, 
                    LastName = studentToInsert.LastName,
                    
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
