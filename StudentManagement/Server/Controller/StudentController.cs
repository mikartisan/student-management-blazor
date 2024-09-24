using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Server.Services;
using StudentManagement.Shared.Models;

namespace StudentManagement.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _student.GetStudents();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            try
            {
                var data = await _student.AddStudent(student);
                if(data.isSuccess)
                {
                    return Ok(data.Message);
                }

                return BadRequest(data.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _student.DeleteStudent(id);
                if (data.isSuccess)
                {
                    return Ok(data.Message);
                }

                return BadRequest(data.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            try
            {
                var data = await _student.UpdateStudent(student);
                if (data.isSuccess)
                {
                    return Ok(data.Message);
                }

                return BadRequest(data.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
