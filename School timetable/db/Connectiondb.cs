using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_timetable
{
	class Connectiondb
	{
		protected const string connectionString = @"Data Source =.\SQLEXPRESS; Initial Catalog = School_Timetable; Integrated Security = True";

		protected static DataTable GetTableFromDatabase(string query, SqlConnection connection)
		{
			var adapter = new SqlDataAdapter(query, connection);
			var ds = new DataSet();
			adapter.Fill(ds);
			var table = ds.Tables[0];
			return table;
		}
	}
}
