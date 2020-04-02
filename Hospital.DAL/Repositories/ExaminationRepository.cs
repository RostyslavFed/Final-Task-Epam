using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class ExaminationRepository : IRepository<Examination>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public ExaminationRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Examination item)
        {
            _hospitalContext.Examinations.Add(item);
        }

        public void Delete(int id)
        {
            var examination = _hospitalContext.Examinations.Find(id);
            if (examination != null)
            {
                _hospitalContext.Examinations.Remove(examination);
            }
        }

        public IEnumerable<Examination> Find(Func<Examination, bool> predicate)
        {
            return _hospitalContext.Examinations.Where(predicate).ToList();
        }

        public Examination Get(int id)
        {
            return _hospitalContext.Examinations.Find(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _hospitalContext.Examinations;
        }

        public void Update(Examination item)
        {
            Examination examination = Get(item.Id);
            _mapper.Map(item, examination);
        }
    }
}