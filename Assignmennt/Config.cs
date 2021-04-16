using System.DirectoryServices;

namespace Assignmennt
{
    public static class Config
    { 

        // Establish the connection of the active directory domain.
        public static string createDirectoryEntry(){
            // create and return new LDAP connection with desired settings  

            DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");
            return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
        }

        // get all infoamtions of the users.
        public static string GetPropertyValue(this SearchResult sr, string propertyName)
        {
            string ret = string.Empty;

            if (sr.Properties[propertyName].Count > 0)
                ret = sr.Properties[propertyName][0].ToString();

            return ret;
        }


        // Build my search method to get all poperties of te user's infomation.

        public static DirectorySearcher BuildUserSearcher(DirectoryEntry de){
            DirectorySearcher ds = null;

            ds = new DirectorySearcher(de);

            // Full Name
            ds.PropertiesToLoad.Add("name");

            // Email Address
            ds.PropertiesToLoad.Add("mail");

            // First Name
            ds.PropertiesToLoad.Add("givenname");

            // Last Name (Surname)
            ds.PropertiesToLoad.Add("sn");

            return ds;
        }

    }
}
