using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApp.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() {Username = "jason_admin", EmailAddress = "jason.admin@gmail.com", Password = "MyPass_w0rd", GivenName = "Jason", Surname = "Bryant", Role = "Administrator"},
            new UserModel() {Username = "rishabh_dora", EmailAddress = "rishabh.dora@gmail.com", Password = "MyPass_w0rd", GivenName = "Rishabh", Surname = "Dora", Role = "Seller"}

        };
    }
}
