// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: Main menu for users.

using System.Windows;

namespace ICT365_A2_Andreas_Lau
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CollaboratorRegistration collaboratorRegistration = new CollaboratorRegistration();
            collaboratorRegistration.Show();
        }

        private void View_Contributors_Click(object sender, RoutedEventArgs e)
        {
            CollaboratorsView collaboratorsView = new CollaboratorsView();
            collaboratorsView.Show();
        }

        private void twitterbtnClick(object sender, RoutedEventArgs e)
        {
            TwitterUI form3 = new TwitterUI();
            form3.Show();
        }

        private void facebookbtnClick(object sender, RoutedEventArgs e)
        {
            FacebookUI form4 = new FacebookUI();
            form4.Show();
        }
    }
}
