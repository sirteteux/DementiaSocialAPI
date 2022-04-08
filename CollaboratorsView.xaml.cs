// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: Users can view the list of collaborators and their details
// It loads the Collaborators.xml file under /bin/Debug.

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace ICT365_A2_Andreas_Lau
{
    /// <summary>
    /// Interaction logic for CollaboratorsView.xaml
    /// </summary>
    public partial class CollaboratorsView : Window
    {
        public CollaboratorsView()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            contributorBox.Text = "";

            XElement con = XElement.Load("Collaborators.xml");
            IEnumerable<Collaborators> childElements = from rec in con.Elements()
                                                       select new Collaborators
                                                       {
                                                           FirstName = (string)rec.Element("FirstName"),
                                                           LastName = (string)rec.Element("LastName"),
                                                           Area = (string)rec.Element("Area"),
                                                           Phone = (string)rec.Element("Phone"),
                                                           Twitter = (string)rec.Element("Twitter"),
                                                           Facebook = (string)rec.Element("Facebook"),
                                                           Time = (string)rec.Element("Time"),
                                                           weekend = (string)rec.Element("Weekend"),
                                                           radius = (string)rec.Element("Radius")
                                                       };

            int i = 1;
            foreach (Collaborators c in childElements)
            {
                contributorBox.AppendText("Collaborator: " + i + "\r\n"
                + "First name: " + c.FirstName + "\r\n"
                + "Last name: " + c.LastName + "\r\n"
                + "Area: " + c.Area + "\r\n"
                + "Contact: " + c.Phone + "\r\n"
                + "Has Twiter: " + c.Twitter + "\r\n"
                + "Has Facebook: " + c.Facebook + "\r\n"
                + "Time available: " + c.Time + "\r\n"
                + c.weekend + "\r\n"
                + "Radius from area: " + c.radius + "\r\n");
                i++;
                contributorBox.AppendText("********************************************\n");
            }
        }
    }
}
