using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	class Contextdb : Connectiondb
	{
		public static List<Subject> Subjects;
		public static List<Teacher> Teachers;
		public static List<User> Users;

		public static void GetInformationFromDatabase()
		{
			Subjects = new List<Subject>();
			Teachers = new List<Teacher>();
			Users = new List<User>();

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				GetUsersFromDatabase(connection);

				GetTeachersFromDatabase(connection);
				GetSubjectsFromDatabase(connection);
				GetSpecializationsForTeachersAndSubjects(connection);

				connection.Close();
			}
		}

		private static void GetUsersFromDatabase(SqlConnection connection)
		{
			var users = GetTableFromDatabase("SELECT * FROM Users;", connection);
			foreach (DataRow row in users.Rows)
			{
				string login = row["LoginUser"].ToString();
				string password = row["PasswordUser"].ToString();
				UserStatus status;
				if (row["UserStatus"].ToString().Equals("USER"))
					status = UserStatus.User;
				else
					status = UserStatus.Admin;
				Users.Add(new User(login, password, status));
			}
		}

		private static void GetTeachersFromDatabase(SqlConnection connection)
		{
			var teachers = GetTableFromDatabase("SELECT * FROM Teachers;", connection);
			foreach (DataRow row in teachers.Rows)
			{
				Teachers.Add(new Teacher(row["FIO"].ToString()));
			}
		}

		private static void GetSubjectsFromDatabase(SqlConnection connection)
		{
			var subjects = GetTableFromDatabase("SELECT * FROM Subjects;", connection);
			foreach (DataRow row in subjects.Rows)
			{
				Subjects.Add(new Subject(row["Name_subject"].ToString()));
			}
		}

		private static void GetSpecializationsForTeachersAndSubjects(SqlConnection connection)
		{
			DataTable specializations = GetTableFromDatabase("SELECT * FROM Specialization;", connection);

			foreach (DataRow row in specializations.Rows)
			{
				Teacher teacher = Teachers.FirstOrDefault(x => x.FIO.Equals(row["FIO"].ToString()));
				Subject subject = Subjects.FirstOrDefault(x => x.Name.Equals(row["Name_subject"].ToString()));

				teacher.Subjects.Add(subject);
				subject.Teachers.Add(teacher);
			}
		}

		public static void AddUserToDatabase(User user)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string status;
				if (user.Status == UserStatus.User)
					status = "USER";
				else
					status = "ADMIN";
				var queryInsert = new SqlCommand
					("INSERT INTO Users(LoginUser, PasswordUser, UserStatus) " +
					$"VALUES ('{user.Login}', '{user.Password}', '{status}')", connection);
				queryInsert.ExecuteNonQuery();

				connection.Close();
			}
		}
	}
}
