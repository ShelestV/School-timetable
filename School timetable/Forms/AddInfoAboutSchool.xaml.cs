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
	/// Логика взаимодействия для AddInfoAboutSchool.xaml
	/// </summary>
	public partial class AddInfoAboutSchool : Window
	{
		private List<string> _lessonsBegin;

		public List<string> LessonBegin
		{ 
			get => _lessonsBegin; 
			set => _lessonsBegin = value; 
		}

		private Window _oldWindow;
		public AddInfoAboutSchool(Window old)
		{
			InitializeComponent();
			_oldWindow = old;
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			_oldWindow.Show();
			this.Close();
		}

		private void AddSpecializationButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteSpecializationButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteAllSpecializationsButton_Click(object sender, RoutedEventArgs e)
		{ 
		
		}

		private void AddClassButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteClassButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeletAllClassesButton_Click(object sender, RoutedEventArgs e)
		{

		}
		
		private void AddRoomButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteRoomButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeletAllRoomsButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
