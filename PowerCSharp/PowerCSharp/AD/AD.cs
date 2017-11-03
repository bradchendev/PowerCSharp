using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace PowerCSharp
{
    class AD
    {
    }

    public class AdUser
    {
        /// <summary>
        /// ex. bradchen
        /// </summary>
        /// <param name="userDomainName"></param>
        public void test(string userDomainName)
        {
            AdUser myAd = new AdUser();

            if (myAd.GetDomainNameFromAd(userDomainName) != "NotExist")
            {
                Console.WriteLine(myAd.GetDomainNameFromAd(userDomainName));
            }
            else
            {
                Console.WriteLine(myAd.GetDomainNameFromAd(userDomainName));
                Console.WriteLine("不存在");
            }

            Console.WriteLine(AdUser2.GetDomainName("test"));

            Console.WriteLine(AdUser2.GetDomainName("test2"));
        }
        public string GetDomainNameFromAd(string userName)
        {
            // try CONTOSO.com
            try
            {
                GetObjectDistinguishedName(ObjectClass.User, ReturnType.DistinguishedName, userName, "contoso.com");
                return "CONTOSO";
            }
            catch (Exception e)
            {
                if ((e.HResult == -2147467261) &&
                    e.Message.Contains("unable to locate the distinguishedName for the object "))
                {
                    // try PROSEWARE
                    try
                    {
                        GetObjectDistinguishedName(ObjectClass.User, ReturnType.DistinguishedName, userName, "proseware.com");
                        return "PROSEWARE";
                    }
                    catch (Exception ev)
                    {
                        //Console.WriteLine(ev);
                        return "NotExist";
                        //throw;
                    }

                }

                throw;
            }
        }

        public enum ObjectClass
        {
            User, Group, Computer
        }

        public enum ReturnType
        {
            DistinguishedName, ObjectGuid
        }

        // 傳入Domain User Account Name取得DN
        public static string GetObjectDistinguishedName(ObjectClass objectCls,
            ReturnType returnValue, string objectName, string ldapDomain)
        {
            string distinguishedName = string.Empty;
            string connectionPrefix = "LDAP://" + ldapDomain;
            DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);

            switch (objectCls)
            {
                case ObjectClass.User:
                    mySearcher.Filter = "(&(objectClass=user)(|(cn=" + objectName + ")(sAMAccountName=" + objectName + ")))";
                    break;
                case ObjectClass.Group:
                    mySearcher.Filter = "(&(objectClass=group)(|(cn=" + objectName + ")(dn=" + objectName + ")))";
                    break;
                case ObjectClass.Computer:
                    mySearcher.Filter = "(&(objectClass=computer)(|(cn=" + objectName + ")(dn=" + objectName + ")))";
                    break;
            }
            SearchResult result = mySearcher.FindOne();

            if (result == null)
            {
                throw new NullReferenceException
                ("unable to locate the distinguishedName for the object " +
                 objectName + " in the " + ldapDomain + " domain");
            }
            DirectoryEntry directoryObject = result.GetDirectoryEntry();
            if (returnValue.Equals(ReturnType.DistinguishedName))
            {
                distinguishedName = "LDAP://" + directoryObject.Properties
                                        ["distinguishedName"].Value;
            }
            if (returnValue.Equals(ReturnType.ObjectGuid))
            {
                distinguishedName = directoryObject.Guid.ToString();
            }
            entry.Close();
            entry.Dispose();
            mySearcher.Dispose();
            return distinguishedName;
        }
    }

    public static class AdUser2
    {
        public static string GetDomainName(string userName)
        {
            return userName;
        }
    }



}
