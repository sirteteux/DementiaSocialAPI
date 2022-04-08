// Author: Andreas Lau, 34095187
// Date: 20/03/2022
// Purpose: To run test on my collaborator registration.

using NUnit.Framework;
using ICT365_A2_Andreas_Lau;

namespace Assignment2Test
{
    // Testing both bad and good user input for Collaborator sign up
    // Test returns false if user input is valid
    // Test returns true if user input is invalid
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Test user input first and last name
        [Test]
        public void TestGoodUserUserSignUp()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(false, user.CollaboratorName("Andreas", "Lau"), "User input: Valid username and lastname input for sign-up");
        }

        [Test]
        public void TestBadUserSignUp()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(true, user.CollaboratorName("", ""), "User input: Invalid username and lastname input for sign-up");
        }

        // Test user input contact details
        [Test]
        public void TestGoodContactDetail()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(false, user.CollaboratorContact("34095187"), "User input: Valid contact input for sign - up");
        }

        [Test]
        public void TestBadContactDetail()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(true, user.CollaboratorContact("123"), "User input: Invalid contact input for sign - up");
        }

        // Test user input area
        [Test]
        public void TestGoodAreaListDetail()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(false, user.CollaboratorArea(1), "User input: Valid contact input for sign - up");
        }

        [Test]
        public void TestBadAreaDetail()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(true, user.CollaboratorArea(-1), "User input: Invalid contact input for sign - up");
        }

        // Test user input availability
        [Test]
        public void TestGoodAvailability()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(false, user.CollaboratorAvailability(true,false,false,true), "User input: Valid Availability input for sign - up");
        }

        [Test]
        public void TestBadAvailability()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(true, user.CollaboratorAvailability(false,false,false,false), "User input: Invalid Availability input for sign - up");
        }

        // Validate user input radius
        [Test]
        public void TestGoodHelpRadius()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(false, user.CollaboratorHelpRadius(true, false, true, false, true), "User input: Valid Availability input for sign - up");
        }

        [Test]
        public void TestBadHelpRadius()
        {
            RegistrationValidation user = new RegistrationValidation();
            Assert.AreEqual(true, user.CollaboratorHelpRadius(false, false, false, false, false), "User input: Invalid Availability input for sign - up");
        }
    }
}