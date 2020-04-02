using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.BLL.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateMedicine(MedicineDTO medicineDto)
        {
            var medicine = _mapper.Map<Medicine>(medicineDto);
            _unitOfWork.Medicines.Create(medicine);
            _unitOfWork.Save();
        }

        public void UpdateMedicine(MedicineDTO medicineDto)
        {
            var medicine = _mapper.Map<Medicine>(medicineDto);
            _unitOfWork.Medicines.Update(medicine);
            _unitOfWork.Save();
        }

        public void DeleteMedicine(int id)
        {
            _unitOfWork.Medicines.Delete(id);
            _unitOfWork.Save();
        }

        public MedicineDTO GetMedicine(int id)
        {
            var medicine = _unitOfWork.Medicines.Get(id);
            return _mapper.Map<MedicineDTO>(medicine);
        }

        public IEnumerable<MedicineDTO> GetMedicines()
        {
            var medicines = _unitOfWork.Medicines.GetAll().ToList();
            return _mapper.Map<IEnumerable<MedicineDTO>>(medicines);
        }
    }
}