using Core.Model;
using StudentService.Data;
using StudentService.Repositories.IRepository;

namespace StudentService.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext _context;
        public StudentRepository(StudentDBContext context)
        {
            _context = context;
        }
        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}
