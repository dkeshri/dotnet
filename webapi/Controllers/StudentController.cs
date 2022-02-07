using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.Entities;
using Webapi.Repositories;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("Students")]
    public class StudentController:ControllerBase
    {
        private IStudentRepository repository;
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            
            var Students = repository.GetStudents();
            return Students;
        }
        // Get /Students/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(Guid id)
        {
            var Student = repository.GetStudent(id);
            if (Student is null)
            {
                return NotFound();
            }
            return Student;
        }
        // Post /Students
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student Student)
        {
            Student student = new()
            {
                StudentId = Guid.NewGuid(),
                FirstName = Student.FirstName,
                LastName = Student.LastName,
                Address = Student.Address,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateStudent(Student);
            return CreatedAtAction(nameof(GetStudent),new { id = student.StudentId },student);
        }

    }
}