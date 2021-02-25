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
			Contextdb.GetInformationFromDatabase();
		}

		private void EnterButton_Click(object sender, RoutedEventArgs e)
		{
			foreach (var user in Contextdb.Users)
			{
				if (user.Login.Equals(LoginTextBox.Text) &&
					user.Password.Equals(PasswordTextBox.Password))
				{
					if (user.Status.Equals(UserStatus.User))
					{
					}
					else
					{
						var menu = new AdminMenu(this);
						menu.Owner = this;
						menu.Show();
						this.Hide();
					}
					LoginTextBox.Text = "";
					PasswordTextBox.Password = "";
					return;
				}
			}

			// if user is not existed in system
			MessageBox.Show("Uncorrect login or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		private void RegistrationButton_Click(object sender, RoutedEventArgs e)
		{
			var registrationWindow = new Registration(this);
			registrationWindow.Show();
			registrationWindow.Owner = GetWindow(this);
		}
	}
}
