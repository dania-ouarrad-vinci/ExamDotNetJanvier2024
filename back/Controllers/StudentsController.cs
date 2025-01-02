    using Microsoft.AspNetCore.Mvc;
    using back.Entities;
    using back.Repositories;
using back.DTO;

namespace back.Controllers
    {
        [ApiController]
        [Route("/api/[controller]")]
        public class StudentsController : ControllerBase
        {
            private readonly SchoolContext _dbcontext;
            private readonly IUnitOfWorkSchool _unitOfWorkSchool;

            public StudentsController()
            {
                _dbcontext = new SchoolContext();
            _unitOfWorkSchool = new UnitOfWorkSchoolSQL(_dbcontext);
            }


            // GET /api/Students

            [HttpGet]
            public async Task<IList<StudentDTO>> GetStudentsAsync()
            {
                IList<Student> lst = await _unitOfWorkSchool.StudentsRepository.GetAllAsync();
                return lst.Select(e => StudentToDTO(e)).ToList();
            }

            //POST /api/Employees 

            [HttpPost]
            public async Task InsertStudentsAsync(StudentDTO studentDTO)
            {
            // assure that id is not set to avoid error with autoincrement in database
                studentDTO.StudentId = 0;
                Student e = DTOToStudent(studentDTO);
                await _unitOfWorkSchool.StudentsRepository.InsertAsync(e);
            }

    

       
            private static StudentDTO StudentToDTO(Student emp) =>
                new StudentDTO
                {
                    StudentId = emp.StudentId,
                    Name = emp.Name,
                    Firstname = emp.Firstname,
                    YearResult = emp.YearResult,
                    SectionId = emp.SectionId
                };
               

            private static Student DTOToStudent(StudentDTO emp) =>
                new Student
                {
                    StudentId = emp.StudentId,
                    Name = emp.Name,
                    Firstname = emp.Firstname,
                    YearResult = emp.YearResult,
                    SectionId = emp.SectionId
                };
                
          
        }
    }