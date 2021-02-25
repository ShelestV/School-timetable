using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace School_timetable
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			// Close Application
			Environment.Exit(0);
		}

		private void MinimizeButton_Click(object sender, RoutedEventArgs e)
		{
			Window w = Window.GetWindow((Button)sender);
			w.WindowState = WindowState.Minimized;
		}
	}
}
