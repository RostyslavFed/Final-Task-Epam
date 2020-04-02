using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.DAL.Entity;

namespace Hospital.BLL.Infrastructure
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Patient, PatientDTO>()
                        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                        .ForMember(d => d.Employee, opt => opt.MapFrom(s => s.Employee))
                        .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName))
                        .ForMember(d => d.Birthday, opt => opt.MapFrom(s => s.User.Birthday))
                        .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.User.Gender))
                        .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.User.PhoneNumber))
                        .ForMember(d => d.PhoneNumberConfirmed, opt => opt.MapFrom(s => s.User.PhoneNumberConfirmed))
                        .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
                        .ForMember(d => d.EmailConfirmed, opt => opt.MapFrom(s => s.User.EmailConfirmed))
                        .ForMember(d => d.Address, opt => opt.MapFrom(s => s.User.Address))
                        .ForMember(d => d.PasswordHash, opt => opt.MapFrom(s => s.User.PasswordHash))
                        .ReverseMap();

            CreateMap<Employee, EmployeeDTO>()
                        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                        .ForMember(d => d.Patients, opt => opt.MapFrom(s => s.Patients))
                        .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.UserName))
                        .ForMember(d => d.Birthday, opt => opt.MapFrom(s => s.User.Birthday))
                        .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.User.Gender))
                        .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.User.PhoneNumber))
                        .ForMember(d => d.PhoneNumberConfirmed, opt => opt.MapFrom(s => s.User.PhoneNumberConfirmed))
                        .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User.Email))
                        .ForMember(d => d.EmailConfirmed, opt => opt.MapFrom(s => s.User.EmailConfirmed))
                        .ForMember(d => d.Address, opt => opt.MapFrom(s => s.User.Address))
                        .ForMember(d => d.PasswordHash, opt => opt.MapFrom(s => s.User.PasswordHash))
                        .ReverseMap();

            CreateMap<User, UserDTO>()
                        .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                        .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                        .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                        .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                        .ForMember(d => d.Password, opt => opt.MapFrom(s => s.PasswordHash))
                        //.ForMember(d => d.Role, opt => opt.MapFrom(s => s.Roles.ToList()[0].RoleId))
                        .ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Examination, ExaminationDTO>().ReverseMap();
            CreateMap<Diagnose, DiagnoseDTO>().ReverseMap();
            CreateMap<Medicine, MedicineDTO>().ReverseMap();
            CreateMap<Procedure, ProcedureDTO>().ReverseMap();
            CreateMap<Operation, OperationDTO>().ReverseMap();
            CreateMap<Log, LogDTO>().ReverseMap();

            CreateMap<Patient, Patient>();
            CreateMap<Employee, Employee>();
            CreateMap<Category, Category>();
            CreateMap<Examination, Examination>();
            CreateMap<Diagnose, Diagnose>();
            CreateMap<Medicine, Medicine>();
            CreateMap<Procedure, Procedure>();
            CreateMap<Operation, Operation>();
            CreateMap<Log, Log>();
        }
    }
}