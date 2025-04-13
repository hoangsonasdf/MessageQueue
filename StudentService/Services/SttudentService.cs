using AutoMapper;
using Core.DTOs.Request;
using Core.Model;
using StudentService.Repositories.IRepository;
using StudentService.Services.IServices;

namespace StudentService.Services
{
    public class SttudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public SttudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task AddStudent(AddStudentRequest request)
        {
            var student = _mapper.Map<Student>(request);
            await _studentRepository.AddStudent(student);
        }
    }
}
