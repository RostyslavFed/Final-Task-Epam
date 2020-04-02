using System.Collections.Generic;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface IProcedureService
    {
        void CreateProcedure(ProcedureDTO procedureDto);
        void UpdateProcedure(ProcedureDTO procedureDto);
        void DeleteProcedure(int id);
        ProcedureDTO GetProcedure(int id);
        IEnumerable<ProcedureDTO> GetProcedures();
    }
}