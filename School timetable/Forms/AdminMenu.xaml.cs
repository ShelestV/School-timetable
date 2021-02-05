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
	/// Логика взаимодействия для AdminMenu.xaml
	/// </summary>
	public partial class AdminMenu : Window
	{
		public AdminMenu()
		{
			InitializeComponent();
		}

		private void AddInformationButton_Click(object sender, RoutedEventArgs e)
		{
			var newWindow = new AddInfoAboutSchool();
			newWindow.Show();
			this.Hide();
		}

		private void EditStudyPlanButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void EditTimetableButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
