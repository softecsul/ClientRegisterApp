using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.Service
{
	interface IWebApi<T>
	{
		Task<IEnumerable<T>> GetAll ();

		Task<T> Get (int id);

		Task<bool> Insert (T t);

		bool Update (T t);

		Task<bool> Delete (int id);
	}
}
