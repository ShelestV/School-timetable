using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace School_timetable.Entities
{
	class TimetableContext : DbContext
	{
		public TimetableContext() : base("SchoolTimetable") { }

		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<SchoolSubject> Subjects { get; set; }
		public DbSet<StudyPlan> Plans { get; set; }
		public DbSet<SchoolClassLoading> ClassLoadings { get; set; }
		public DbSet<SchoolClass> Classes { get; set; }
		public DbSet<DayOfWeek> Days { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Room>()
				.HasMany(c => c.Timetable)
				.WithRequired(p => p.Room)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<DayOfWeek>()
				.HasMany(c => c.Timetable)
				.WithRequired(p => p.Day)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Lesson>()
				.HasMany(c => c.Timetable)
				.WithRequired(p => p.Lesson)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Teacher>()
				.HasMany(c => c.Timetable)
				.WithRequired(p => p.Teacher)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolClass>()
				.HasMany(c => c.Timetable)
				.WithRequired(p => p.Class)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolSubject>()
				.HasMany(c => c.Timetable)
				.WithRequired(p => p.Subject)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolSubject>()
				.HasMany(c => c.ClassYears)
				.WithRequired(p => p.Subject)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolClassLoading>()
				.HasMany(c => c.Subjects)
				.WithRequired(p => p.Class)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolClassLoading>()
				.HasMany(c => c.Classes)
				.WithRequired(p => p.Year)
				.WillCascadeOnDelete(true);
		}
	}
}
