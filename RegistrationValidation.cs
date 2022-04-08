// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: Runs validation in CollaboratorRegistration for user inputs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT365_A2_Andreas_Lau
{
     // Used in CollaboratorSignUp.xaml.cs
     // Validate user input in user sign up
    public class RegistrationValidation
    {
        // Validate user input first and last name
        public bool CollaboratorName(string firstname, string lastname)
        {
            string BadUserName = "";
            string BadLastName = "";


            if (firstname == BadUserName || lastname == BadLastName)
            {
                return true;
            }
            else
                return false;
        }

        // Validate user input contact details
        public bool CollaboratorContact(string Contact)
        {
            string BadContact = "";
            // Singapore should be auto pre-fixed to 65
            int ValidContactLength = 8;
            bool InvalidContactCheckDigits = false;

            if (Contact == BadContact || Contact.Length != ValidContactLength || CheckDigits(Contact) == InvalidContactCheckDigits)
            {
                return true;
            }
            else
                return false;

        }

        // Validate user input city
        public bool CollaboratorArea(int Arealist)
        {
            int InvalidArea = -1;

            if (Arealist == InvalidArea)
            {
                return true;
            }
            else
                return false;
        }

        // Validate user input Availibity
        public bool CollaboratorAvailability(bool radio100km, bool radio50km, bool radio25km, bool radio10km)
        {
            bool Empty = false;

            if (radio100km == Empty && radio50km == Empty && radio25km == Empty && radio10km == Empty)
            {
                return true;
            }
            else
                return false;
        }

        // Validate user input Radious
        public bool CollaboratorHelpRadius(bool radio6pm, bool radio6am, bool radioaft6pm, bool radioaft12am, bool radio24hour)
        {
            bool Empty = false;

            if (radio6pm == Empty && radio6am == Empty && radioaft6pm == Empty && radioaft12am == Empty && radio24hour == Empty)
            {
                return true;
            }
            else
                return false;
        }

        // Checks for digits used in collaborator contact function
        bool CheckDigits(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
