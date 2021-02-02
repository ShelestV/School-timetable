using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable.Entities
{
	class SchoolClassLoading
	{
		private int _studyYear;
		private int _classLoading;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int StudyYear 
		{
			get
			{ 
				return _studyYear; 
			}
			set 
			{
				// In Ukrainian study system there are 11 classes
				if (1 <= value && value <= 11)
					_studyYear = value;
			} 
		}

		public int ClassLoading
		{
			get
			{
				return _classLoading;
			}
			set
			{
				if (value >= 0)
					_classLoading = value;
			}
		}

		public virtual ICollection<SchoolClass> Classes { get; set; }
		public virtual ICollection<StudyPlan> Subjects { get; set; }

		public SchoolClassLoading()
		{
			Classes = new List<SchoolClass>();
			Subjects = new List<StudyPlan>();
		}
	}
}
