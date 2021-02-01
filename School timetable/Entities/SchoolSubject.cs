using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	public class SchoolSubject
	{
		private int _subjectID;
		private string _name;

		[Key]
		public int SubjectID
		{
			get => _subjectID;
			set => _subjectID = value;
		}
		public string Name
		{
			get => _name;
			set => _name = value;
		}

		public virtual ICollection<Teacher> Teachers { get; set; }
		public virtual ICollection<StudyPlan> ClassYears { get; set; }
		public virtual ICollection<Timetable> Timetable { get; set; }

		public SchoolSubject()
		{
			Teachers = new List<Teacher>();
			ClassYears = new List<StudyPlan>();
			Timetable = new List<Timetable>();
		}
	}
}
