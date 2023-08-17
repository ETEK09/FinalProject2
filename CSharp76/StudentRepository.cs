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
            _conn.Execute("UPDATE student SET FirstName = @firstName, " +
                "LastName = @lastName, " +
                "StudentID = @studentID, " +
                "GitHubID = @gitHubID, " +
                "Age = @age, " +
                "Grade = @grade " +
                "WHERE ID = @id;",
                new { firstName = student.FirstName, lastName = student.LastName, age = student.Age, grade = student.Grade, gitHubID = student.GitHubID, studentID = student.StudentID, id = student.ID });
        }

        public void InsertStudent(Student studentToInsert)
        {
            _conn.Execute("INSERT INTO student (StudentID, FirstName, LastName, GitHubID, Age, Grade) " +
                "VALUES (@studentID, @firstName, @lastName, @gitHubID, @age, @grade);",
                new { studentID = studentToInsert.StudentID,
                    firstName = studentToInsert.FirstName,
                    lastName = studentToInsert.LastName,
                    gitHubID = studentToInsert.GitHubID,
                    age = studentToInsert.Age,
                    grade = studentToInsert.Grade,

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
