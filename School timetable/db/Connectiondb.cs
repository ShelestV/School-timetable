using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	static class Connectiondb
	{
		private const string connectionString = @"Data Source =.\SQLEXPRESS; Initial Catalog = School_Timetable; Integrated Security = True";

		public static List<Subject> Subjects;
		public static List<Teacher> Teachers;
		public static List<User> Users;

		public static void FirstConnection()
		{
			Subjects = new List<Subject>();
			Teachers = new List<Teacher>();
			Users = new List<User>();

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var userAdapter = new SqlDataAdapter("SELECT * FROM Users;", connection);
				var usersSet = new DataSet();
				userAdapter.Fill(usersSet);
				foreach (DataTable table in usersSet.Tables)
				{
					foreach (DataRow row in table.Rows)
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

				var teacherAdapter = new SqlDataAdapter("SELECT * FROM Teachers;", connection);
				var teachersSet = new DataSet();
				teacherAdapter.Fill(teachersSet);
				var teacherTable = teachersSet.Tables[0];
				foreach (DataRow row in teacherTable.Rows)
				{
					Teachers.Add(new Teacher(row["FIO"].ToString()));
				}

				var subjectAdapter = new SqlDataAdapter("SELECT * FROM Subjects;", connection);
				var subjectsSet = new DataSet();
				subjectAdapter.Fill(subjectsSet);
				var subjectTable = subjectsSet.Tables[0];
				foreach (DataRow row in subjectTable.Rows)
				{
					Subjects.Add(new Subject(row["Name_subject"].ToString()));
				}

				var specializationAdapter = new SqlDataAdapter("SELECT * FROM Specialization;", connection);
				var specializationSet = new DataSet();
				specializationAdapter.Fill(specializationSet);
				var specializationTable = specializationSet.Tables[0];
				foreach (DataRow row in specializationTable.Rows)
				{
					Teacher teacher = Teachers.FirstOrDefault(x => x.FIO.Equals(row["FIO"].ToString()));
					Subject subject = Subjects.FirstOrDefault(x => x.Name.Equals(row["Name_subject"].ToString()));

					teacher.Subjects.Add(subject);
					subject.Teachers.Add(teacher);
				}

				connection.Close();
			}
		}
	}
}
