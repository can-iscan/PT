using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class User
	{
		public uint Id = 0;
		public string FirstName;
		public string LastName;

		public User(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}
	}

	public class UserDictionary : Dictionary<uint, User> {}

}
