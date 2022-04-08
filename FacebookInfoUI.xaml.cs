// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: Users can view their Facebook profile information in this window.

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
    /// Interaction logic for FacebookInfoUI.xaml
    /// </summary>
    /// 
    public partial class FacebookInfoUI : Window
    {
        private FacebookClient facebookClient;
        public FacebookInfoUI(FacebookClient FBClient)
        {
            InitializeComponent();
            facebookClient = FBClient;
            dynamic me = FBClient.Get("Me");
            TBInfo.Text = "Name: " + me.Name.ToString() + "\n\r" +
                          "Gender: " + me.gender.ToString() + "\n\r" +
                          "Link: " + me.link.ToString() + "\n\r" +
                          "Quote: " + me.quotes.ToString() + "\n\r";

            ProfilePicture.Source = new BitmapImage(new Uri("https://www.graph.facebook.com/" + me.id.ToString() + "/picture/"));

        }
    }
}
