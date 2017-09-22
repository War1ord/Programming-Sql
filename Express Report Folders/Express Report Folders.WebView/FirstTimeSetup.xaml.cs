using System.Windows;

namespace Express_Report_Folders.WebView
{
	/// <summary>
	/// Interaction logic for FirstTimeSetup.xaml
	/// </summary>
	public partial class FirstTimeSetup : Window
	{
		public FirstTimeSetup()
		{
			InitializeComponent();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}
