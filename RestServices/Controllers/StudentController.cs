using Microsoft.AspNetCore.Mvc;
using StudentApi.Data;
using System.Collections.Generic;
using StudentInFormation;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsRepository _repo;

        public StudentsController()
        {
            _repo = new StudentsRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentInfo>> GetAll()
        {
            return Ok(_repo.GetStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<StudentInfo> GetById(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<StudentInfo> Create(StudentInfo student)
        {
            // Auto-generate ID
            var all = _repo.GetStudents();
            student.Id = all.Count > 0 ? all[^1].Id + 1 : 1;
            _repo.AddStudent(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentInfo updated)
        {
            var existing = _repo.GetStudentById(id);
            if (existing == null)
                return NotFound();

            updated.Id = id;
            _repo.UpdateStudent(updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _repo.DeleteStudent(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

        // 🔍 SEARCH ENDPOINTS

        [HttpGet("search/name/{name}")]
        public ActionResult<IEnumerable<StudentInfo>> SearchByName(string name)
        {
            var results = _repo.SearchByName(name);
            return Ok(results);
        }

        [HttpGet("search/rollno/{rollno}")]
        public ActionResult<StudentInfo> SearchByRollNo(int rollno)
        {
            var result = _repo.SearchByRollNo(rollno);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("search/mobile/{mobile}")]
        public ActionResult<StudentInfo> SearchByMobile(long mobile)
        {
            var result = _repo.SearchByMobile(mobile);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
