using System.Collections.Generic;
using Hospital.BLL.DTO;

namespace Hospital.BLL.Interfaces
{
    public interface IMedicineService
    {
        void CreateMedicine(MedicineDTO medicineDto);
        void UpdateMedicine(MedicineDTO medicineDto);
        void DeleteMedicine(int id);
        MedicineDTO GetMedicine(int id);
        IEnumerable<MedicineDTO> GetMedicines();
    }
}