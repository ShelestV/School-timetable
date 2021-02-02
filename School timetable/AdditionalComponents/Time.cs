using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	class Time
	{
		private int _hour;
		private int _minute;

		public Time()
		{
			_hour = 0;
			_minute = 0;
		}

		public Time(int hour, int minute)
		{
			_hour = hour;
			_minute = minute;
		}

		public int Hour
		{
			get
			{
				return _hour;
			}
			set
			{
				if (0 <= value && value <= 24)
					_hour = value;
			}
		}

		public int Minute
		{
			get
			{
				return _minute;
			}
			set
			{
				if (0 <= value && value <= 60)
					_minute = value;
			}
		}
	}
}
