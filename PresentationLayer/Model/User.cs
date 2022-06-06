using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Model
{

	public class User
	{
		public long Id;
		public string FirstName;
		public string LastName;

		public User() { }

		public User(long id, string fname, string lname)
		{
			this.Id = id;
			this.FirstName = fname;
			this.LastName = lname;
		}

		internal User(ServiceLayer.User user)
		{
			this.Id = user.Id;
			this.FirstName = user.FirstName;
			this.LastName = user.LastName;
		}

		internal ServiceLayer.User getServiceLayerUser()
		{
			ServiceLayer.User user = new ServiceLayer.User();
			user.Id = this.Id;
			user.FirstName = this.FirstName;
			user.LastName = this.LastName;
			return user;
		}

		internal static List<User> getUserListFromService(List<ServiceLayer.User> ser_users)
		{
			List<User> users = new List<User>();

			foreach (ServiceLayer.User user in ser_users)
			{
				users.Add(new User(user));
			}

			return users;
		}
	}
}
