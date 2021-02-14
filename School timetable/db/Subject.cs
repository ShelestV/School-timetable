using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	class Subject
	{
		private string _name;

		public string Name { get => _name; }

		public List<Teacher> Teachers;

		public Subject(string name)
		{
			_name = name;
			Teachers = new List<Teacher>();
		}
	}
}
