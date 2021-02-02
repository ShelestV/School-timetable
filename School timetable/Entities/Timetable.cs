using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable.Entities
{
	enum Weeks
	{ 
		FIRST = 1,
		SECOND = 2
	}

	class Timetable
	{
		private Weeks _indexWeek;
		private Days _dayOfWeek;
		private int _roomID;
		private int _lessonID;
		private int _teacherID;
		private int _studyYear;
		private string _letterClass;
		private int _subjectID;

		[Key]
		[Column(Order = 0)]
		public Weeks IndexWeek
		{
			get => _indexWeek;
			set => _indexWeek = value;
		}

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int RoomID
		{
			get => _roomID;
			set => _roomID = value;
		}

		[Key]
		[Column(Order = 2)]
		public Days DayOfWeek
		{
			get => _dayOfWeek;
			set => _dayOfWeek = value;
		}

		[Key]
		[Column(Order = 3)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int LessonID
		{
			get => _lessonID;
			set => _lessonID = value;
		}

		public int TeacherID
		{
			get => _teacherID;
			set => _teacherID = value;
		}

		public int SubjectID
		{
			get => _subjectID;
			set => _subjectID = value;
		}

		public int StudyYear
		{
			get => _studyYear;
			set => _studyYear = value;
		}

		public string LetterClass
		{
			get => _letterClass;
			set => _letterClass = value;
		}

		[ForeignKey("DayOfWeek")]
		public virtual DayOfWeek Day { get; set; }
		[ForeignKey("RoomID")]
		public virtual Room Room { get; set; }
		[ForeignKey("LessonID")]
		public virtual Lesson Lesson { get; set; }
		[ForeignKey("TeacherID")]
		public virtual Teacher Teacher { get; set; }
		[ForeignKey("SubjectID")]
		public virtual SchoolSubject Subject { get; set; }
		[ForeignKey("StudyYear,LetterClass")]
		public virtual SchoolClass Class { get; set; }
	}
}
