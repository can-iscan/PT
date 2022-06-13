using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	internal class User : IUser
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }


		public User(long id, string firstName, string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
		}

	}
}
