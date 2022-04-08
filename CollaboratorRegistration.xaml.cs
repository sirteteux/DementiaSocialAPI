// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: Users can register as collaborators and this will add into Collaborators.xml.
// This window also validates inputs through RegistrationValidation.cs

using System;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace ICT365_A2_Andreas_Lau
{
    /// <summary>
    /// Interaction logic for CollaboratorRegistration.xaml
    /// </summary>
    public partial class CollaboratorRegistration : Window
    {
        public CollaboratorRegistration()
        {
            InitializeComponent();
        }
        private void submitbtn(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Collaborators.xml");
            XmlNode contributor = doc.CreateElement("Collaborators");

            // Creating each element for XML
            #region

            // Creates element FirstName
            XmlNode firstname = doc.CreateElement("FirstName");
            firstname.InnerText = firstnamebox.Text;
            contributor.AppendChild(firstname);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element LastName
            XmlNode lastname = doc.CreateElement("LastName");
            lastname.InnerText = lastnamebox.Text;
            contributor.AppendChild(lastname);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element area
            XmlNode area = doc.CreateElement("Area");
            area.InnerText = arealist.Text;
            contributor.AppendChild(area);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element Phone
            XmlNode phone = doc.CreateElement("Phone");
            phone.InnerText = mobilebox.Text;
            contributor.AppendChild(phone);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element Twitter
            XmlNode twitter = doc.CreateElement("Twitter");
            if (twitterbox.IsChecked == true)
            {
                twitter.InnerText = "Yes";
            }
            if (twitterbox.IsChecked == false)
            {
                twitter.InnerText = "No";
            }
            contributor.AppendChild(twitter);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element Facebook
            XmlNode facebook = doc.CreateElement("Facebook");
            if (facebookbox.IsChecked == true)
            {
                twitter.InnerText = "Yes";
            }
            if (facebookbox.IsChecked == false)
            {
                twitter.InnerText = "No";
            }
            contributor.AppendChild(twitter);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element Time
            XmlNode time = doc.CreateElement("Time");
            if (radio6am.IsChecked == true)
            {
                time.InnerText = "6am - 12pm";
            }
            if (radio6pm.IsChecked == true)
            {
                time.InnerText = "12pm - 6pm";
            }
            if (radioafter6pm.IsChecked == true)
            {
                time.InnerText = "6pm - 12am";
            }
            if (radioafter12am.IsChecked == true)
            {
                time.InnerText = "12am - 6am";
            }
            if (radio24hour.IsChecked == true)
            {
                time.InnerText = "24Hours";
            }

            contributor.AppendChild(time);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element Weekend
            XmlNode weekend = doc.CreateElement("Weekend");
            if (weekendcheck.IsChecked == true)
            {
                weekend.InnerText = "Available for weekends";
            }
            else
            {
                weekend.InnerText = "Not available for weekends";
            }
            contributor.AppendChild(weekend);
            doc.DocumentElement.AppendChild(contributor);

            // Creates element Radius
            XmlNode radius = doc.CreateElement("Radius");
            if (radio10km.IsChecked == true)
            {
                radius.InnerText = "10km";
            }
            if (radio25km.IsChecked == true)
            {
                radius.InnerText = "25km";
            }
            if (radio50km.IsChecked == true)
            {
                radius.InnerText = "50km";
            }
            if (radio100km.IsChecked == true)
            {
                radius.InnerText = "100km";
            }
            contributor.AppendChild(radius);
            doc.DocumentElement.AppendChild(contributor);
            #endregion

            // IF statements to check for invalid form
            // uses RegistrationValidation.cs
            #region 
            RegistrationValidation user = new RegistrationValidation();
            bool invalidName = user.CollaboratorName(firstnamebox.Text, lastnamebox.Text);
            bool invalidContact = user.CollaboratorContact(mobilebox.Text);
            bool invalidAreaList = user.CollaboratorArea(arealist.SelectedIndex);
            bool invalidAvailability = user.CollaboratorAvailability((bool)radio100km.IsChecked, (bool)radio50km.IsChecked, (bool)radio25km.IsChecked, (bool)radio10km.IsChecked);
            bool invalidradius = user.CollaboratorHelpRadius((bool)radio6pm.IsChecked, (bool)radio6am.IsChecked, (bool)radioafter6pm.IsChecked, (bool)radioafter12am.IsChecked, (bool)radio24hour.IsChecked);

            if (invalidName)
            {
                MessageBox.Show("Please enter a valid name");
            }

            else if (invalidContact)
            {
                MessageBox.Show("Please enter in a valid mobile number (8 digits)");
            }


            else if (invalidAreaList)
            {
                MessageBox.Show("Please select a area!");
            }

            else if (invalidAvailability)
            {
                MessageBox.Show("Please select a time!");
            }

            else if (invalidradius)
            {
                MessageBox.Show("Please select a radius!");
            }
            #endregion

            else
            {
                doc.Save("Collaborators.xml");
                MessageBox.Show("Submitted Successfully!");
                this.Close();
            }
        }

        private void clearbtn(object sender, RoutedEventArgs e)
        {
            // Resets all values on clear button
            #region
            firstnamebox.Text = "";
            lastnamebox.Text = "";
            mobilebox.Text = "";
            arealist.SelectedIndex = -1;
            radio100km.IsChecked = false;
            radio10km.IsChecked = false;
            radio25km.IsChecked = false;
            radio50km.IsChecked = false;
            radio6am.IsChecked = false;
            radio6pm.IsChecked = false;
            radioafter6pm.IsChecked = false;
            radioafter12am.IsChecked = false;
            radio24hour.IsChecked = false;
            weekendcheck.IsChecked = false;
            twitterbox.IsChecked = false;
            facebookbox.IsChecked = false;
            #endregion
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void twitterbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void weekendcheck_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void facebookbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radio6am_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radio6am_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
