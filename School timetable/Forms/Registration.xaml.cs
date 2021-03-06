﻿using System.Data.Entity.Infrastructure;
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
				using (var database = new Entities.TimetableContext())
				{
					var user = new User
					{
						Login = LoginTextBox.Text,
						Password = PasswordTextBox.Password,
						UserStatus = Status.USER
					};

					try
					{
						database.Users.Add(user);
						database.SaveChanges();
						MessageBox.Show("Registration completed successfuly", "Congratilations", MessageBoxButton.OK);
					}
					catch (DbUpdateException)
					{
						MessageBox.Show("This user is registrated!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						//throw new Exception("Problem with PK!", ex);
					}
					finally
					{
						database.Users.Remove(user);
					}
				}
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
