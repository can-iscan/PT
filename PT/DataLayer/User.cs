using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class User : IUser
	{
		public uint Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }


		public User(string firstName, string lastName)
		{
			this.Id = 0;
			this.FirstName = firstName;
			this.LastName = lastName;
		}

	}

	public class UserDictionary : Dictionary<uint, User> {}

	public interface IUser
	{
		uint Id { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
	}
}
