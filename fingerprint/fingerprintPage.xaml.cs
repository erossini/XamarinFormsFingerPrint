using Xamarin.Forms;
using Plugin.Fingerprint;

namespace fingerprint
{
    public partial class fingerprintPage : ContentPage
    {
        public fingerprintPage()
        {
            InitializeComponent();

            this.buttonFingerPrint.Clicked += ButtonFingerPrint_Clicked;
        }

        async void ButtonFingerPrint_Clicked(object sender, System.EventArgs e)
        {
            // check if the finger print functionality is available for the device
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);
            if (result) {
                // show a fingerprint request
                var auth = await CrossFingerprint.Current.AuthenticateAsync("Authenticate access to your example fingerprint");
                if (auth.Authenticated) {
                    await DisplayAlert("Whoooowhooo!", "Authentication is done!", "Ok");
                }
                else {
                    await DisplayAlert("Something wrong", "There is a problem with your finger", "Ok");
                }
            }
            else {
                await DisplayAlert("Finger print not available", "You can't use your finger for using this app", "Ok");
            }
        }
    }
}
