using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	enum UserStatus
	{
		User = 0,
		Admin = 1
	}
	class User
	{
		private string _login;
		private string _password;
		private UserStatus _status;

		public string Login	{ get => _login; }
		public string Password { get => _password; }
		public UserStatus Status { get => _status; }

		public User(string login, string password, UserStatus status)
		{
			_login = login;
			_password = password;
			_status = status;
		}
	}
}
