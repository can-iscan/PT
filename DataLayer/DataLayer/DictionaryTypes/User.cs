using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer.Dictionary
{
	internal class User : IUser
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

	internal class UserDictionary : Dictionary<uint, User> {}

}
