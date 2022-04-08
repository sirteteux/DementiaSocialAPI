// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: Displays Facebook simple UI whereby users can retrieve their Facebook information
// and post many things such as image, video, and text posts etc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Facebook;

namespace ICT365_A2_Andreas_Lau
{
    /// <summary>
    /// Interaction logic for Facebook1.xaml
    /// </summary>

    // Learned from an expert in youtube
    // Source Code: https://www.youtube.com/watch?v=tSV28Tdscog
    public partial class FacebookUI : Window
    {
        private FacebookClient FBClient;
        public string AccessToken { get; set; }
        public FacebookUI()
        {
            InitializeComponent();
            wBrowser.Navigate(new Uri("https://www.facebook.com/andreas.laukuantze/", UriKind.Absolute));
        }

        private void wBrowser_OnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString().StartsWith("http://www.facebook.com/connect/login_success.html"))
            {
                AccessToken = e.Uri.Fragment.Split('&')[0].Replace("#access token=", "");
                FBClient = new FacebookClient(AccessToken);
                FacebookInfoUI fbInfo = new FacebookInfoUI(FBClient);
                fbInfo.Show();
                this.Hide();

            }
        }
    }
}
