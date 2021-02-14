using System.Windows;

namespace School_timetable.Forms
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		public Registration()
		{
			InitializeComponent();
		}

		private void RegistrateButton_Click(object sender, RoutedEventArgs e)
		{
			bool loginInTheRange = 4 < LoginTextBox.Text.Length && LoginTextBox.Text.Length < 20;
			bool passwordInTheRange = 4 < PasswordTextBox.Password.Length && PasswordTextBox.Password.Length < 10;
			
			if (loginInTheRange &&
				passwordInTheRange &&
				PasswordTextBox.Password.Equals(RepeatPasswordTextBox.Password))
			{
				// Check if this user is existed in system
				foreach (var systemUser in Contextdb.Users)
				{
					if (systemUser.Login.Equals(LoginTextBox.Text))
					{
						MessageBox.Show("This user is registrated!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						return;
					}
				}

				var user = new User(LoginTextBox.Text, PasswordTextBox.Password, UserStatus.User);
				Contextdb.Users.Add(user);
				Contextdb.AddUserToDatabase(user);
			}
			// If user enter incorrect data
			else
			{
				MessageBox.Show(
						"Please, enter correct data!\n" +
						" - Login length must be between 4 and 20\n" +
						" - Password length must be between 4 and 10\n" +
						" - 'Password' and 'Repeat password' must be equal", 
						"Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
