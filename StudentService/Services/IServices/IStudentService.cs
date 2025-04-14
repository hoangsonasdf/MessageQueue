using Core.DTOs.Request;
using Core.Model;

namespace StudentService.Services.IServices
{
    public interface IStudentService
    {
        Task<Student> AddStudent(AddStudentRequest request);
    }
}
