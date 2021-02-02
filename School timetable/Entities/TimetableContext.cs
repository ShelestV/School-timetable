using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace School_timetable
{
	class TimetableContext : DbContext
	{
		protected TimetableContext() : base("SchoolTimetable") { }

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
				.HasMany(e => e.Timetable)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<DayOfWeek>()
				.HasMany(e => e.Timetable)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Lesson>()
				.HasMany(e => e.Timetable)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<Teacher>()
				.HasMany(e => e.Timetable)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolClass>()
				.HasMany(e => e.Timetable)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolSubject>()
				.HasMany(e => e.Timetable)
				.WithRequired()
				.WillCascadeOnDelete(true);


			modelBuilder.Entity<Teacher>()
				.HasMany(e => e.Subjects)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolSubject>()
				.HasMany(e => e.Teachers)
				.WithRequired()
				.WillCascadeOnDelete(true);


			modelBuilder.Entity<SchoolSubject>()
				.HasMany(e => e.ClassYears)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolClassLoading>()
				.HasMany(e => e.Subjects)
				.WithRequired()
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<SchoolClassLoading>()
				.HasMany(e => e.Classes)
				.WithRequired()
				.WillCascadeOnDelete(true);
		}
	}
}
