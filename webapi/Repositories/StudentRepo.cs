using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Data;
using Webapi.Entities;

namespace Webapi.Repositories{
    public class StudentRepo : IStudentRepository
    {
        private AppSQLDbContext context;
        public StudentRepo(AppSQLDbContext context)
        {
            this.context = context;
        }
        public void CreateStudent(Student Student)
        {
            context.Students.Add(Student);
            context.SaveChanges();
        }

        public Task CreateStudentAsync(Student Student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(Guid id)
        {
            Student student = context.Students.Find(id);
            return student;
        }

        public Task<Student> GetStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.Students.ToList<Student>();
        }

        public Task<IEnumerable<Student>> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student Student)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student Student)
        {
            throw new NotImplementedException();
        }
    }
}