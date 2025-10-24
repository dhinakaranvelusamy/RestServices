using Microsoft.AspNetCore.Mvc;
using StudentInFormation;
using System.Collections.Generic;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsRepository repo = new StudentsRepository();

        // GET: api/students
        [HttpGet]
        public ActionResult<List<StudentInfo>> GetAll()
        {
            return Ok(repo.GetStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<StudentInfo> GetById(int id)
        {
            var student = repo.GetStudentByID(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

      [HttpPost]
        public ActionResult Add([FromBody] StudentInfo student)
        {
            repo.AddStudent(student);
            return Ok();
        }

        
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] StudentInfo student)
        {
            student.id = id;
            var updated = repo.UpdateStudent(student);
            if (!updated) return NotFound();
            return Ok();
        }

       
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = repo.DeleteStudent(id);
            if (!deleted) return NotFound();
            return Ok();
        }

       
        [HttpGet("search")]
        public ActionResult<List<StudentInfo>> Search(string name)
        {
            var results = repo.SearchStudentsByName(name);
            if (results.Count == 0) return NotFound();
            return Ok(results);
        }
    }
}
