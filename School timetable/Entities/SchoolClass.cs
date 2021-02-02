using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable.Entities
{
	class SchoolClass
	{
		private int _studyYear;
		private string _letterClass;
		private int _numberOfPupils;

		[Key]
		[Column(Order = 0)]
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

		[Key]
		[Column(Order = 1)]
		[MaxLength(1)]
		public string LetterClass
		{
			get
			{
				return _letterClass;
			}
			set
			{
				if ('А' <= value[0] && value[0] <= 'Я' ||
					'а' <= value[0] && value[0] <= 'я')
					_letterClass = value;
			}
		}

		public int NumberOfPupils
		{
			get => _numberOfPupils;
			set => _numberOfPupils = value;
		}

		[ForeignKey("StudyYear")]
		public virtual SchoolClassLoading Year { get; set; }
		public virtual ICollection<Timetable> Timetable { get; set; }

		public SchoolClass()
		{
			Timetable = new List<Timetable>();
		}
	}
}
