using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	class Teacher
	{
		private string _fio;

		public string FIO { get => _fio; }

		public Teacher(string fio)
		{
			_fio = fio;
		}
	}
}
