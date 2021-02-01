using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	public class Lesson
	{
		private int _lessonID;
		private Time _timeBegin;
		private Time _timeEnd;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int LessonId 
		{
			get => _lessonID;
			set => _lessonID = value;
		}

		public Time TimeBegin
		{
			get => _timeBegin;
			set => _timeBegin = value;
		}

		public Time TimeEnd
		{
			get => _timeEnd;
			set => _timeEnd = value;
		}

		public virtual ICollection<Timetable> Timetable { get; set; }

		public Lesson()
		{
			Timetable = new List<Timetable>();
		}
	}
}
