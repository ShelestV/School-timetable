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
		private static string connectionString = @"Data Source =.\SQLEXPRESS; Initial Catalog = School_Timetable; Integrated Security = True";

		public static List<Teacher> Teachers;
		public static List<User> Users;

		public static void FirstConnection()
		{
			Teachers = new List<Teacher>();
			Users = new List<User>();

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				var teacherAdapter = new SqlDataAdapter("SELECT * FROM Teachers;", connection);
				var teachersSet = new DataSet();
				teacherAdapter.Fill(teachersSet);
				foreach (DataTable table in teachersSet.Tables)
				{
					foreach (DataRow row in table.Rows)
					{
						Teachers.Add(new Teacher(row["FIO"].ToString()));
					}
				}

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

				connection.Close();
			}
		}
	}
}
