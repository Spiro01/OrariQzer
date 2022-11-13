namespace OrariQzer;

public partial class App : Application
{
	protected override Window CreateWindow(IActivationState activationState)
	{
		MainPage = new MainPage();
		return base.CreateWindow(activationState);
	}
}
