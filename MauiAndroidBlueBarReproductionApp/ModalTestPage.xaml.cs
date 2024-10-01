namespace MauiAndroidBlueBarReproductionApp;

public partial class ModalTestPage : ContentPage
{
	public ModalTestPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}