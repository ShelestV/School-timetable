using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable.Entities
{
	class Teacher
	{
		private int _teacherID;
		private string _fio;

		[Key]
		public int TeacherID 
		{ 
			get => _teacherID;
			set => _teacherID = value;
		}

		public string FIO 
		{
			get => _fio;
			set => _fio = value;
		}

		public virtual ICollection<SchoolSubject> Subjects { get; set; }
		public virtual ICollection<Timetable> Timetable { get; set; }

		public Teacher()
		{
			Subjects = new List<SchoolSubject>();
			Timetable = new List<Timetable>();
		}
	}
}
