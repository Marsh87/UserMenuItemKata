using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UserAccountPreferenceKata.Models;

namespace UserAccountPreferenceKata
{
    public class UserPreference
    {
        public string GetUsersWithPreference(string userFileReference, string menuOptionsReferences)
        {
            var menuItems = GetMenuItemsList(menuOptionsReferences);
            var users = GetUsers(userFileReference, menuItems);
            return JsonConvert.SerializeObject(users);
        }

        private static List<User> GetUsers(string userFileReference, List<MenuItems> menuItems)
        {
            var users = new List<User>();
            using (StreamReader userReader = new StreamReader(userFileReference))
            {
                int counter = 0;
                string ln;

                while ((ln = userReader.ReadLine()) != null)
                {
                    var splitstring = ln.Split(' ');
                    var user = new User();
                    user.UserName = splitstring[0];
                    var preference = GetMenuPreferences(splitstring);
                    var preferenceCounter = 0;
                    foreach (char p in preference)
                    {
                        preferenceCounter++;
                        if (IsPreferenceYes(p))
                        {
                            var counter1 = preferenceCounter;
                            var menuItemName = menuItems.FirstOrDefault(x => x.Position == counter1)?.Name;
                            user.MenuItems.Add(menuItemName);
                        }
                    }

                    users.Add(user);
                    counter++;
                }

                userReader.Close();
            }

            return users;
        }

        private static bool IsPreferenceYes(char p)
        {
            return p == 'Y';
        }

        private static string GetMenuPreferences(string[] splitstring)
        {
            var preference = splitstring[1];
            if (splitstring.Length > 2)
            {
                preference += splitstring[2];
            }
            return preference;
        }

        private static List<MenuItems> GetMenuItemsList(string menuOptionsReferences)
        {
            var menuItems = new List<MenuItems>();
            using (StreamReader menuReader = new StreamReader(menuOptionsReferences))
            {
                int counter = 0;
                string ln;
                while ((ln = menuReader.ReadLine()) != null)
                {
                    var menusplitstring = ln.Split(',');
                    var menu = new MenuItems();
                    menu.Position = Convert.ToInt32(menusplitstring[0]);
                    menu.Name = menusplitstring[1].Trim();
                    menuItems.Add(menu);
                    counter++;
                }

                menuReader.Close();
            }
            return menuItems;
        }
    }
}