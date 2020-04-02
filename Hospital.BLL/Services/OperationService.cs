using System.Collections.Generic;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.BLL.Services
{
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OperationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateOperation(OperationDTO operationDto)
        {
            var operation = _mapper.Map<Operation>(operationDto);
            _unitOfWork.Operations.Create(operation);
            _unitOfWork.Save();
        }

        public void DeleteOperation(int id)
        {
            _unitOfWork.Operations.Delete(id);
            _unitOfWork.Save();
        }

        public OperationDTO GetOperation(int id)
        {
            var operation = _unitOfWork.Operations.Get(id);
            return _mapper.Map<OperationDTO>(operation);
        }

        public IEnumerable<OperationDTO> GetOperations()
        {
            var operations = _unitOfWork.Operations.GetAll();
            return _mapper.Map<IEnumerable<OperationDTO>>(operations);
        }

        public void UpdateOperation(OperationDTO operationDto)
        {
            var operation = _mapper.Map<Operation>(operationDto);
            _unitOfWork.Operations.Update(operation);
            _unitOfWork.Save();
        }
    }
}