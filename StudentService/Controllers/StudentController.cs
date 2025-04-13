using Core.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentService.Services.IServices;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid student data.");
            }
            await _studentService.AddStudent(request);
            return Ok("Student added successfully.");
        }
    }
}
