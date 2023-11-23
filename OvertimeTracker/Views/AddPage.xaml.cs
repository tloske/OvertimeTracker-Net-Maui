using OvertimeTracker.ViewModels;

namespace OvertimeTracker.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}