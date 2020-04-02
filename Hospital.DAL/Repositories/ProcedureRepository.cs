using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class ProcedureRepository : IRepository<Procedure>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public ProcedureRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Procedure item)
        {
            _hospitalContext.Procedures.Add(item);
        }

        public void Delete(int id)
        {
            var procedure = _hospitalContext.Procedures.Find(id);
            if (procedure != null)
            {
                _hospitalContext.Procedures.Remove(procedure);
            }
        }

        public IEnumerable<Procedure> Find(Func<Procedure, bool> predicate)
        {
            return _hospitalContext.Procedures.Where(predicate).ToList();
        }

        public Procedure Get(int id)
        {
            return _hospitalContext.Procedures.Find(id);
        }

        public IEnumerable<Procedure> GetAll()
        {
            return _hospitalContext.Procedures;
        }

        public void Update(Procedure item)
        {
            Procedure procedure = Get(item.Id);
            _mapper.Map(item, procedure);
        }
    }
}