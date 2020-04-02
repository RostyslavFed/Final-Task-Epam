using Hospital.BLL.DTO;
using System.Collections.Generic;

namespace Hospital.BLL.Interfaces
{
	public interface ILogService
	{
        void CreateLog(LogDTO LogDto);
        void ClearAllLogs();
        IEnumerable<LogDTO> GetAllLogs();
    }
}
