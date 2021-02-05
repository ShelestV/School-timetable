using System.Windows;
using System.Windows.Controls;

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
						if (user.UserStatus == Status.USER)
						{
							return;
						}
						else
						{
							var menu = new AdminMenu();
							menu.Owner = this;
							menu.Show();
							this.Hide();
							return;
						}
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
