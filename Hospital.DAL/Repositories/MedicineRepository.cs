using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class MedicineRepository : IRepository<Medicine>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public MedicineRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Medicine item)
        {
            _hospitalContext.Medicines.Add(item);
        }

        public void Delete(int id)
        {
            var medicine = _hospitalContext.Medicines.Find(id);
            if (medicine != null)
            {
                _hospitalContext.Medicines.Remove(medicine);
            }
        }

        public IEnumerable<Medicine> Find(Func<Medicine, bool> predicate)
        {
            return _hospitalContext.Medicines.Where(predicate).ToList();
        }

        public Medicine Get(int id)
        {
            return _hospitalContext.Medicines.Find(id);
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _hospitalContext.Medicines;
        }

        public void Update(Medicine item)
        {
            Medicine medicine = Get(item.Id);
            _mapper.Map(item, medicine);
        }
    }
}