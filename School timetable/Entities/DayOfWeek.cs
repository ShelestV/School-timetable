using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	public enum Days
	{ 
		Monday = 1,
		Tuesday = 2,
		Wednesday = 3,
		Thursday = 4,
		Friday = 5
	}

	public class DayOfWeek
	{
		private Days _day;

		[Key]
		public Days Day
		{
			get => _day;
			set => _day = value;
		}

		public virtual ICollection<Timetable> Timetable { get; set; }

		public DayOfWeek()
		{
			Timetable = new List<Timetable>();
		}

		public DayOfWeek(Days day)
		{
			_day = day;
			Timetable = new List<Timetable>();
		}
	}
}
