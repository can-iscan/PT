using System;
using System.Collections.Generic;
using System.Text;

namespace PT.DataLayer
{
	public class User
	{
		public uint Id;
		public string FirstName;
		public string LastName;

		public User(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}
	}

	public class UserDictionary : Dictionary<uint, User>
	{

	}

	public class UserDictionary2
	{
		private uint counter = 0;
		private Dictionary<uint, User> UserDict = new Dictionary<uint, User>();

		public void Add(User user)
		{
			this.UserDict.Add(counter, user);
			this.counter++;
		}

		public bool Remove(uint id)
		{
			if(UserDict.ContainsKey(id))
			{
				UserDict.Remove(id);
				return true;
			}
			else
			{
				return false;
			}
		}

		public User Get(uint id)
		{
			if (UserDict.ContainsKey(id))
			{
				return UserDict[id];
			}
			else
			{
				throw new Exception("id doesnt exist!");
			}
		}

		public bool Set(uint id, User user)
		{
			if (UserDict.ContainsKey(id))
			{
				UserDict[id] = user;
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
