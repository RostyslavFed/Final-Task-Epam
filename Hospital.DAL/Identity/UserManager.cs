using Hospital.DAL.Entity;
using Hospital.DAL.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.DAL.Identity
{
	public class UserManager : UserManager<User>
	{
		public UserManager(HospitalContext hospitalContext)
			: base(new UserStore<User>(hospitalContext))
		{
		}
	}
}
