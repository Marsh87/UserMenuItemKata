using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using UserAccountPreferenceKata.Models;

namespace UserAccountPreferenceKata.Tests
{
    [TestFixture]
    public class UserPreferenceTests
    {
        [Test]
        public void GetUsersWithPreference_GivenInputFileWithOneUserAndYesSelection_ShouldReturnUserPreference()
        {
            // Arrange
            var userFileReference = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\TestFiles\\users1.txt";
            var menuOptionsReferences = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\menus.txt";
            var sut = new UserPreference();
            // Act
            var result = sut.GetUsersWithPreference(userFileReference, menuOptionsReferences);
            // Assert
            var users = new List<User>();
            var user = new User();
            user.UserName = "User1";
            user.MenuItems = new List<string>() {"Applications Menu"};
            users.Add(user);
            var expected = JsonConvert.SerializeObject(users);
            Assert.AreEqual(expected,result);

        }        
        
        [Test]
        public void GetUsersWithPreference_GivenInputFileWithOneUserAndYesAndNoSelection_ShouldReturnUserPreference()
        {
            // Arrange
            var userFileReference = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\TestFiles\\users2.txt";
            var menuOptionsReferences = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\menus.txt";
            var sut = new UserPreference();
            // Act
            var result = sut.GetUsersWithPreference(userFileReference, menuOptionsReferences);
            // Assert
            var users = new List<User>();
            var user = new User();
            user.UserName = "User1";
            user.MenuItems = new List<string>() {"Applications Menu"};
            users.Add(user);
            var expected = JsonConvert.SerializeObject(users);
            Assert.AreEqual(expected,result);
        }
        
        [Test]
        public void GetUsersWithPreference_GivenInputFileWithOneUserAndYesAndNoSelectionWithSpaceInFrontOfPreference_ShouldReturnUserPreference()
        {
            // Arrange
            var userFileReference = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\TestFiles\\users3.txt";
            var menuOptionsReferences = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\menus.txt";
            var sut = new UserPreference();
            // Act
            var result = sut.GetUsersWithPreference(userFileReference, menuOptionsReferences);
            // Assert
            var users = new List<User>();
            var user = new User();
            user.UserName = "User1";
            user.MenuItems = new List<string>() {"Security Permissions Menu","Accounts Menu","Help Menu"};
            users.Add(user);
            var expected = JsonConvert.SerializeObject(users);
            Assert.AreEqual(expected,result);
        }
        
        [Test]
        public void GetUsersWithPreference_GivenInputFileWithTwoUsersAndYesAndNoSelectionWithSpaceInFrontOfPreference_ShouldReturnUserPreference()
        {
            // Arrange
            var userFileReference = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\TestFiles\\users4.txt";
            var menuOptionsReferences = "C:\\Systems\\DeliberatePractice\\UserAccountPreferenceKata\\menus.txt";
            var sut = new UserPreference();
            // Act
            var result = sut.GetUsersWithPreference(userFileReference, menuOptionsReferences);
            // Assert
            var users = new List<User>();
            var user = new User();
            user.UserName = "User1";
            user.MenuItems = new List<string>() {"Applications Menu"};
            users.Add(user);
            var user1 = new User();
            user1.UserName = "UserBob";
            user1.MenuItems = new List<string>() {"Customers Menu","Profile Menu","Help Menu"};
            users.Add(user1);
            var expected = JsonConvert.SerializeObject(users);
            Assert.AreEqual(expected,result);
        }
    }
}