using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace School_timetable.Forms
{
	/// <summary>
	/// Логика взаимодействия для Enter.xaml
	/// </summary>
	public partial class Enter : Window
	{
		public Enter()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			using (var context = new Entities.TimetableContext())
			{
				foreach (User user in context.Users)
				{
					if (user.Login == LoginTextBox.Text &&
						user.Password == PasswordTextBox.Password)
					{
						MessageBox.Show("Successful entering!", "Congratilations");
						return;
					}
					MessageBox.Show("Uncorrect login or password!", "Error");
				}
			}
		}
	}
}
