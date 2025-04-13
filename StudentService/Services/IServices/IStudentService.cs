using Core.DTOs.Request;

namespace StudentService.Services.IServices
{
    public interface IStudentService
    {
        Task AddStudent(AddStudentRequest request);
    }
}
