using Hospital.DAL.Entity;
using Hospital.DAL.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.DAL.Identity
{
	public class RoleManager : RoleManager<Role>
	{
		public RoleManager(HospitalContext hospitalContext)
			: base(new RoleStore<Role>(hospitalContext))
		{
		}
	}
}
