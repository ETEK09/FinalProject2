using CSharp38.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp38
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();

        public Student GetStudent(int id);
        public void UpdateStudent(Student student);
        public void InsertStudent(Student studentToInsert);

        public void DeleteStudent(Student student);
    }
}
