using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class DiagnoseRepository : IRepository<Diagnose>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public DiagnoseRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Diagnose item)
        {
            _hospitalContext.Diagnosis.Add(item);
        }

        public void Delete(int id)
        {
            var diagnose = _hospitalContext.Diagnosis.Find(id);
            if (diagnose != null)
            {
                _hospitalContext.Diagnosis.Remove(diagnose);
            }
        }

        public IEnumerable<Diagnose> Find(Func<Diagnose, bool> predicate)
        {
            return _hospitalContext.Diagnosis.Where(predicate).ToList();
        }

        public Diagnose Get(int id)
        {
            return _hospitalContext.Diagnosis.Find(id);
        }

        public IEnumerable<Diagnose> GetAll()
        {
            return _hospitalContext.Diagnosis;
        }

        public void Update(Diagnose item)
        {
            Diagnose diagnose = Get(item.Id);
            _mapper.Map(item, diagnose);
        }
    }
}