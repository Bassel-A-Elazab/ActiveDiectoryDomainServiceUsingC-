using System;
using System.Collections.Generic;
using System.DirectoryServices;


namespace Assignmennt
{
    public static class Program
    {

        static void Main(string[] args)
        {

            var oldUser = new List<string>();
            var updateUser = new List<string>();

            oldUser.Add("Tamer");
            oldUser.Add("Ali");
            oldUser.Add("tamer.ali");
            oldUser.Add("Ashraf#96");
            User.addNewUser(oldUser);

            updateUser.Add("TamerSelim");
            updateUser.Add("Ali");
            updateUser.Add("tamer.ali");
            updateUser.Add("Ashraf#96");
            User.upateNewUser(oldUser, updateUser);

            User.searchForUser("tamer");   // display and seach in once.


        }
    }
}
