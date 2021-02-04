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
			TopPanel = new DockPanel();
		}

		private void EnterButton_Click(object sender, RoutedEventArgs e)
		{
			using (var database = new Entities.TimetableContext())
			{
				foreach (var user in database.Users)
				{
					if (user.Login.Equals(LoginTextBox.Text) &&
						user.Password.Equals(PasswordTextBox.Password))
					{
						MessageBox.Show("Successful entering!", "Congratilations");
						return;
					}
				}
				MessageBox.Show("Uncorrect login or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void RegistrationButton_Click(object sender, RoutedEventArgs e)
		{
			var registrationWindow = new Registration();
			registrationWindow.Show();
			registrationWindow.Owner = GetWindow(this);
		}
	}
}
