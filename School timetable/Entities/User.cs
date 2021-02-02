using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	enum Status
	{ 
		USER = 0,
		ADMIN = 1
	}
	class User
	{
		private string _login;
		private string _password;
		private Status _status;

		[Key]
		public string Login
		{
			get
			{
				return _login;
			}
			set
			{
				if (4 < value.Length && value.Length < 20)
					_login = value;
			}
		}

		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				if (4 < value.Length && value.Length < 10)
					_password = value;
			}
		}

		public Status UserStatus
		{
			get => _status;
			set => _status = value;
		}
	}
}
