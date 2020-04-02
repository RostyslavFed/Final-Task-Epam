using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entity;
using Hospital.DAL.Interfaces;

namespace Hospital.BLL.Services
{
	public class LogService : ILogService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public LogService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void ClearAllLogs()
		{
			var logsId = _unitOfWork.Logs.GetAll().Select(l => l.Id).ToList();
			foreach(var id in logsId)
			{
				_unitOfWork.Logs.Delete(id);
			}
			_unitOfWork.Save();
		}

		public void CreateLog(LogDTO LogDto)
		{
			var log = _mapper.Map<Log>(LogDto);
			_unitOfWork.Logs.Create(log);
			_unitOfWork.Save();
		}

		public IEnumerable<LogDTO> GetAllLogs()
		{
			var logs = _unitOfWork.Logs.GetAll();
			return _mapper.Map<IEnumerable<LogDTO>>(logs);
		}
	}
}
