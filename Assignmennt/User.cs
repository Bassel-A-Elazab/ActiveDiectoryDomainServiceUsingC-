using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace Assignmennt
{
    public static class User
    {

        /*
         Add new user 
        Inexes:
            0 --> first name
            1 --> lastname
            2 --> email
            3 --> passwod
         */
        public static void addNewUser(List<string> newUserInfo) {

            string domain = "bassel.assignment.com";
            DirectoryEntry myLdapConnection = new DirectoryEntry(Config.createDirectoryEntry());
            DirectoryEntry newUser = myLdapConnection.Children.Add("CN=" + newUserInfo[0] + " " + newUserInfo[1], "User");

            if (DirectoryEntry.Exists(newUser.Path))
            {
                Console.WriteLine("The user: " + newUserInfo[0] + " " + newUserInfo[1] + " exits");
                return;
            }

            // Surname  
            newUser.Properties["sn"].Add(newUserInfo[1]);
            // Forename  
            newUser.Properties["givenname"].Add(newUserInfo[0]);
            // Display name  
            newUser.Properties["displayname"].Add(newUserInfo[0] + " " + newUserInfo[1]);
            // E-mail  
            newUser.Properties["mail"].Add(newUserInfo[2] + "@" + domain);

            newUser.CommitChanges();
            newUser.Invoke("SetPassword", newUserInfo[3]);
            Console.WriteLine("User: " + newUserInfo[0] + " " + newUserInfo[1] + " Successfuly created!");
        }


        /*
         Update new user 
        Inexes:
            0 --> first name
            1 --> lastname
            2 --> email
            3 --> passwod
         */

        public static void upateNewUser(List<string> oldUerInfo, List<string> upateUserInfo)
        {

            string domain = "bassel.assignment.com";
            DirectoryEntry myLdapConnection = new DirectoryEntry(Config.createDirectoryEntry());
            DirectoryEntry oldUser = myLdapConnection.Children.Add("CN=" + oldUerInfo[0] + " " + oldUerInfo[1], "User");

            if (DirectoryEntry.Exists(oldUser.Path))
            {
                myLdapConnection.Children.Remove(new DirectoryEntry(oldUser.Path));
            }

            DirectoryEntry newUser = myLdapConnection.Children.Add("CN=" + upateUserInfo[0] + " " + upateUserInfo[1], "User");

            // Surname  
            newUser.Properties["sn"].Add(upateUserInfo[1]);
            // Forename  
            newUser.Properties["givenname"].Add(upateUserInfo[0]);
            // Display name  
            newUser.Properties["displayname"].Add(upateUserInfo[0] + " " + upateUserInfo[1]);
            // E-mail  
            newUser.Properties["mail"].Add(upateUserInfo[2] + "@" + domain);

            newUser.CommitChanges();
            newUser.Invoke("SetPassword", upateUserInfo[3]);
            Console.WriteLine("User: " + oldUerInfo[0] + " " + oldUerInfo[1] + " Successfuly updated!");
        }

        // Fo searching about users
        public static void searchForUser(string userName){
            SearchResultCollection results;
            DirectorySearcher ds = null;
            DirectoryEntry de = new DirectoryEntry(Config.createDirectoryEntry());

            // Build User Searcher
            ds = Config.BuildUserSearcher(de);

            ds.Filter = "(&(name=" + userName + "*))";

            results = ds.FindAll();
            if (results.Count == 0){
                Console.WriteLine("The userName = " + userName + "Dosn't exist...");
            }else{
                foreach (SearchResult sr in results)
                {
                    Console.WriteLine("--------------    User Informations    --------------");
                    Console.WriteLine("First Name: " + sr.GetPropertyValue("givenname"));
                    Console.WriteLine("Last Name: " + sr.GetPropertyValue("sn"));
                    Console.WriteLine("Display Name: " + sr.GetPropertyValue("name"));
                    Console.WriteLine("E-mail: " + sr.GetPropertyValue("mail"));
                    Console.WriteLine("--------------    End Informations    --------------");
                }
            }

        }
    }


}
