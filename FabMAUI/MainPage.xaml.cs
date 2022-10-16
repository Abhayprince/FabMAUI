namespace FabMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private bool _rotated = false;

	private async void fabBtn_Clicked(object sender, EventArgs e)
	{
		((Button)sender).RotateTo(_rotated ? 0 : -90);
		
        //fabBtnsContainer.Margin = new Thickness(0, 0, _rotated ? 0 : -100, 50);

		fabBtnsContainer.Animate<Thickness>("fab_btns",
			value => // goes from 0 -> 1
			{	// 0.1
				// 0.01,... 0.05,... 0.6,... 0.9,... 1

				int factor = Convert.ToInt32(value * 10); // 1

				var rightMargin =
					!_rotated
					? (factor * 10) - 100  //10 - 100 => -90,    0.2 => 20-100 => -80 ..... 100 - 100 => 0
					: (factor * 10) * -1; // 10*-1 => -10		20 *-1 => -20, ....... 100 * -1 => -100

                return new Thickness(0, 0, rightMargin, 50);
			},
			newThickness => fabBtnsContainer.Margin = newThickness // The parameter come from the previous Func delegate parameter
			, length: 200
			, finished: (_, __) => _rotated = !_rotated);
    }
}

