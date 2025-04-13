using Core.Model;

namespace StudentService.Repositories.IRepository
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
    }
}
