using AutoMapper;
using University.Api.Dtos;
using University.DataAccess.Models;

namespace University.Api.Mapper
{
    public class UniversityMappingProfile : Profile
    {
        public UniversityMappingProfile() 
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            
            CreateMap<Professor, ProfessorDto>();
            CreateMap<ProfessorDto, Professor>();

            CreateMap<OfficeStaff, OfficeStaffDto>();
            CreateMap<OfficeStaffDto, OfficeStaff>();

            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();

            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>();

            CreateMap<StudyPlan, StudyPlanDto>();
            CreateMap<StudyPlanDto, StudyPlan>();
        }
    }
}
