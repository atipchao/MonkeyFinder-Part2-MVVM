namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{
	public MainPage(MonkeysViewModel viewModel) // We pass in (use) MonkeyViewModel		
	{
		InitializeComponent();
		BindingContext = viewModel; // This is the Context for this Page
	}
}

