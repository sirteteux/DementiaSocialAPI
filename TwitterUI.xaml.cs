// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: Users can load Twitter profile, load Twitter profile's latest tweet
// and post tweets.

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using Tweetinvi;

namespace ICT365_A2_Andreas_Lau
{
    /// <summary>
    /// Interaction logic for TwitterUI.xaml
    /// </summary>
    public partial class TwitterUI : Window
    {
        private static string APIKey = "TG3kERrcEAyyV1NpMTdz7gpyO";
        private static string APISecret = "dCBGfOJbmoR8KFY5UlqkEoToxefrmXihKxFhsyqeOY4cPeS8wX";
        private static string APIToken = "302454793-RwPDHFBqHnkJe2LiqxyOJRqtIM9tUVs4vMxzodBH";
        private static string APITokenSecret = "eQDB8Lf8XV4mbzYgjprJUlkYfVv2dl87vS2kUUB7XnXVK";


        public TwitterUI()
        {
            InitializeComponent();
            Auth.SetUserCredentials(APIKey, APISecret, APIToken, APITokenSecret);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var time = DateTime.Now;
            TimeSpan now = DateTime.Now.TimeOfDay;
            
            if (TweetBox.Text == "") 
                MessageBox.Show("Please enter in text above!");
            else if(FullName.Text == "" || Handler.Text == "")
            {
                MessageBox.Show("Please Load the Twitter Account first!");
            }
            else
            {
                Tweet.PublishTweet(TweetBox.Text);
                MessageBox.Show("Tweet successfully published!");
                TweetBox.Text = "";
            }
        }
        
        private void GetTweet_Click(object sender, RoutedEventArgs e)
        {
            var user = Tweetinvi.User.GetAuthenticatedUser();
            var getTweets = Timeline.GetUserTimeline(user, 1).ToArray(); // Credit to the Tweetinvi documentation @ https://github.com/linvi/tweetinvi/wiki/Introduction
            GetTweet2.Text = "";
            if (FullName.Text == "" || Handler.Text == "")
            {
                MessageBox.Show("Please Load the Twitter Account first!");
            }
            else
            {
                foreach (var t in getTweets)
                {
                    GetTweet2.AppendText("-->" + t.FullText + " - " + t.TweetLocalCreationDate + Environment.NewLine + "--------END OF THE TWEET---------" + Environment.NewLine + Environment.NewLine);
                    
                }
                XmlDocument doc = new XmlDocument();
                doc.Load("TwitterFile.xml");
                for (int i = 0; i < getTweets.Length; i++)
                {
                    XmlNode Tweet = doc.CreateElement("Tweet");
                    XmlNode Text = doc.CreateElement("Text");
                    Text.InnerText = getTweets[i].FullText.ToString();
                    Tweet.AppendChild(Text);
                    doc.DocumentElement.AppendChild(Tweet);
                    XmlNode Time = doc.CreateElement("Time");
                    Time.InnerText = getTweets[i].TweetLocalCreationDate.ToString();
                    Tweet.AppendChild(Time);
                }
                doc.Save("TwitterFile.xml");
            }
        }
        private void LoadAccount_Click(object sender, RoutedEventArgs e)
        {
            var user = Tweetinvi.User.GetAuthenticatedUser();
            var getProfilePic = user.ProfileImageUrl;

            // Implemented from https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.imaging.bitmapimage.urisource?redirectedfrom=MSDN&view=netcore-3.1#System_Windows_Media_Imaging_BitmapImage_UriSource
            // This is used to convert the twitter profile picture into an appropriate format for twitterimage.Source.
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(getProfilePic);
            bitmap.EndInit();
            // Console.WriteLine(getProfilePic);

            FullName.Text = user.Name;
            Handler.Text = "@" + user.ScreenName;
            twitterimage.Source = bitmap;
        }
    }
}
    

