using Express_Report_Folders.WebView.Properties;
using System.Windows;

namespace Express_Report_Folders.WebView
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			if (Settings.Default.FirstTimeSetup)
			{
				var setup = new FirstTimeSetup() /*{ Owner = this }*/;
				var results = setup.ShowDialog();
				if (results.HasValue && results.Value)
				{
					Settings.Default.BaseUrl = setup.UrlAddress.Text;
					Settings.Default.FirstTimeSetup = false;
					Settings.Default.Save();
				}
			}
			ChromiumWebBrowser.Address = Settings.Default.BaseUrl;
			ChromiumWebBrowser.Load(Settings.Default.BaseUrl);
		}
	}
}
