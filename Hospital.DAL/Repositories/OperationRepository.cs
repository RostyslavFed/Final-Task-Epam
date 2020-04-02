using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
    public class OperationRepository : IRepository<Operation>
    {
        private readonly HospitalContext _hospitalContext;
        private readonly IMapper _mapper;

        public OperationRepository(HospitalContext hospitalContext, IMapper mapper)
        {
            _hospitalContext = hospitalContext;
            _mapper = mapper;
        }

        public void Create(Operation item)
        {
            _hospitalContext.Operations.Add(item);
        }

        public void Delete(int id)
        {
            var operation = _hospitalContext.Operations.Find(id);
            if (operation != null)
            {
                _hospitalContext.Operations.Remove(operation);
            }
        }

        public IEnumerable<Operation> Find(Func<Operation, bool> predicate)
        {
            return _hospitalContext.Operations.Where(predicate).ToList();
        }

        public Operation Get(int id)
        {
            return _hospitalContext.Operations.Find(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _hospitalContext.Operations;
        }

        public void Update(Operation item)
        {
            Operation operation = Get(item.Id);
            _mapper.Map(item, operation);
        }
    }
}