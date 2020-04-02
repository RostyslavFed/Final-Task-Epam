using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.BLL.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProcedureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateProcedure(ProcedureDTO procedureDto)
        {
            var procedure = _mapper.Map<Procedure>(procedureDto);
            _unitOfWork.Procedures.Create(procedure);
            _unitOfWork.Save();
        }

        public void DeleteProcedure(int id)
        {
            _unitOfWork.Procedures.Delete(id);
            _unitOfWork.Save();
        }

        public ProcedureDTO GetProcedure(int id)
        {
            var procedure = _unitOfWork.Categories.Get(id);
            return _mapper.Map<ProcedureDTO>(procedure);
        }

        public IEnumerable<ProcedureDTO> GetProcedures()
        {
            var procedures = _unitOfWork.Procedures.GetAll().ToList();
            return _mapper.Map<IEnumerable<ProcedureDTO>>(procedures);
        }

        public void UpdateProcedure(ProcedureDTO procedureDto)
        {
            var procedure = _mapper.Map<Procedure>(procedureDto);
            _unitOfWork.Procedures.Update(procedure);
            _unitOfWork.Save();
        }
    }
}