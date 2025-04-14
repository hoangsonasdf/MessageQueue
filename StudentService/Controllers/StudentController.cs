using Core.DTOs.Request;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ;
using RabbitMQ.Events;
using StudentService.Services.IServices;

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly RabbitMQPublisher _rabbitMQPublisher;
        public StudentController(IStudentService studentService, RabbitMQPublisher rabbitMQPublisher)
        {
            _studentService = studentService;
            _rabbitMQPublisher = rabbitMQPublisher;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid student data.");
            }
            var student = await _studentService.AddStudent(request);
            var studentEvent = new StudentCreatedEvent
            {
                Id = student.Id,
                Name = student.Name,
            };

            await _rabbitMQPublisher.Publish(studentEvent);
            return Ok("Student added successfully.");
        }
    }
}
