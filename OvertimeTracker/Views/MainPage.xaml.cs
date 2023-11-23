using OvertimeTracker.ViewModels;

namespace OvertimeTracker
{
	public partial class MainPage : ContentPage
	{

		public MainPage(MainViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}