using CommunityToolkit.Maui.Alerts;

namespace ColorMaker_MAUI;

public partial class MainPage : ContentPage
{
    bool isRandom;
    string setHexValue;

    public MainPage()
    {
        InitializeComponent();
    }

    private void slder_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        btnRandom.BackgroundColor = color;
        container.BackgroundColor = color;
        setHexValue = color.ToHex();
        lblHex.Text = setHexValue;
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        var random = new Random();

        var color = Color.FromRgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)
            );

        SetColor(color);

        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
        isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(setHexValue);
        var toast = Toast.Make("Color Copied!", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        await toast.Show();
    }
}
