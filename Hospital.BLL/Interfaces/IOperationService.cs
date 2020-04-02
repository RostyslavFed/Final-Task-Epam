using System.Collections.Generic;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface IOperationService
    {
        void CreateOperation(OperationDTO operationDto);
        void UpdateOperation(OperationDTO operationDto);
        void DeleteOperation(int id);
        OperationDTO GetOperation(int id);
        IEnumerable<OperationDTO> GetOperations();
    }
}