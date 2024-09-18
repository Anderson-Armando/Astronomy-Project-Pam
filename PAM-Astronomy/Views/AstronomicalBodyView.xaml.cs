namespace PAM_Astronomy.Views;

using PAM_Astronomy.Models;

[QueryProperty(nameof(AstroName), "astroName")]

public partial class AstronomicalBodyView : ContentPage
{
	public AstronomicalBodyView()
	{
		InitializeComponent();
	}

	string astroName;
	public string AstroName
	{
		get => astroName;
		set
		{
			astroName = value;
			UpdateAstroBodyUI(astroName);
		}
	}

	void UpdateAstroBodyUI(string astroName)
	{
		AstronomicalBodyView body = FindAstroData(astroName);

		Title = body.Name;

        lblIcon.Text = body.EmojiIcon;
		lblName.Text = body.Name;
		lblMass.Text = body.Mass;
		lblCircumference.Text = body.Circumference;
		lblAge.Text = body.Age;
	}

	AstronomicalBodyView FindAstroData(string astronomicalBodyName)
	{
		return astronomicalBodyName switch
		{
			"comet" => SolarSystemData.HalleysComet,
            "earth" => SolarSystemData.Earth,
			"moon" => SolarSystemData.Moon,
			"sun" => SolarSystemData.Sun, 
			_=> throw new ArgumentException()
		};
	}

}