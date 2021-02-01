using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	class StudyPlan
	{
		private int _numberOfHours;
		private int _subjectID;
		private int _classStudyYearID;

		public int NumberOfHours
		{
			get
			{
				return _numberOfHours;
			}
			set
			{
				if (value >= 0)
					_numberOfHours = value;
			}
		}
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SubjectID
		{
			get => _subjectID;
			set => _subjectID = value;
		}

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ClassStudyYearID
		{
			get => _classStudyYearID;
			set => _classStudyYearID = value;
		}

		public virtual SchoolSubject Subject { get; set; }
		public virtual SchoolClassLoading StudyYear { get; set; }
	}
}
