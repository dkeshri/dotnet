using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Entities;

namespace Webapi.Repositories{
    public interface IStudentRepository
    {
        Student GetStudent(Guid id);
        IEnumerable<Student> GetStudents();
        void CreateStudent(Student Student);
        void UpdateStudent(Student Student);
        void DeleteStudent(Guid id);
        Task<Student> GetStudentAsync(int id);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task CreateStudentAsync(Student Student);
        Task UpdateStudentAsync(Student Student);
        Task DeleteStudentAsync(Guid id);
    }
}