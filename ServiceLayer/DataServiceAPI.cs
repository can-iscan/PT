using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public abstract class DataServiceAPI
    {
		public abstract string addCatalog(Catalog catalog);
		public abstract bool removeCatalog(string title);
		public abstract Catalog getCatalog(string title);
		public abstract bool changeCatalog(Catalog catalog);
		public abstract List<Catalog> getAllCatalogs();

		public abstract long addUser(User user);
		public abstract bool removeUser(long id);
		public abstract User getUser(long id);
		public abstract bool changeUser(User user);
		public abstract List<User> getAllUsers();

		public abstract State getState(long id);
		public abstract List<State> getAllStates();

		public abstract Event getEvent(long id);
		public abstract List<Event> getAllEvents();

		public static DataServiceAPI CreateDataService()
		{
            return new DataService();
		}
    }
}
