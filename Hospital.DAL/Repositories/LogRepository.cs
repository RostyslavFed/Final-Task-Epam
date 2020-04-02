using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.DAL.EF;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.DAL.Repositories
{
	public class LogRepository : IRepository<Log>
	{
		private readonly HospitalContext _hospitalContext;
		private readonly IMapper _mapper;
		public LogRepository(HospitalContext hospitalContext, IMapper mapper)
		{
			_hospitalContext = hospitalContext;
			_mapper = mapper;
		}

		public void Create(Log item)
		{
			_hospitalContext.Logs.Add(item);
		}

		public IEnumerable<Log> GetAll()
		{
			return _hospitalContext.Logs;
		}

		public IEnumerable<Log> Find(Func<Log, bool> predicate)
		{
			return _hospitalContext.Logs.Where(predicate);
		}

		public Log Get(int id)
		{
			return _hospitalContext.Logs.Find(id);
		}

		public void Update(Log item)
		{
			var log = Get(item.Id);
			_mapper.Map(item, log);
		}

		public void Delete(int id)
		{
			var log = _hospitalContext.Logs.Find(id);
			if (log != null)
			{
				_hospitalContext.Logs.Remove(log);
			}
		}
	}
}
