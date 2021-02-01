using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	class Room
	{
		private int _roomID;

		[Key]
		public int RoomID
		{
			get => _roomID;
			set => _roomID = value;
		}

		public virtual ICollection<Timetable> Timetable { get; set; }

		public Room()
		{
			Timetable = new List<Timetable>();
		}
	}
}
