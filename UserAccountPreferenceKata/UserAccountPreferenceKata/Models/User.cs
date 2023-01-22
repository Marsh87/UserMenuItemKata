using System.Collections.Generic;

namespace UserAccountPreferenceKata.Models
{
    public class User
    {
        public User()
        {
            MenuItems = new List<string>();
        }
        public  string UserName { get; set; }
        public  List<string> MenuItems { get; set; }
    }
}