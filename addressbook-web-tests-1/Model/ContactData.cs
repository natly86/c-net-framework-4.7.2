using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInfo;
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Id { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (HomePhone + MobilePhone + WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        //public string CleanUp(string phone)
        //{
        //    if (phone == null || phone == "")
        //    {
        //        return "";
        //    }
        //    return Regex.Replace(phone, "[ -()\r\n]", "") + "\r\n";
        //}

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email + Email2 + Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllInfo
        {
            get
            {
                return CleanUpInfo(allInfo).Trim();
            }
            set
            {
                allInfo = value;
            }
        }

        public string CleanUpInfo(string info)
        {
            if (info == null || info == "")
            {
                return "";
            }
            return Regex.Replace(info, "[ -()\r\n]", "") + "\r\n";
        }

        public string CleanUpText(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return Regex.Replace(text, "[ -()\r\n]", "") + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname == other.Lastname && Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() & Firstname.GetHashCode();
        }

       public override string ToString()
       {
            return  Lastname + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }
    }
}
