using Microsoft.AspNet.Identity.EntityFramework;

namespace Hospital.DAL.Entity
{
	public class Role : IdentityRole
	{
		public Role()
		{
		}

		public Role(string roleName)
			: base(roleName)
		{
		}
	}
}
