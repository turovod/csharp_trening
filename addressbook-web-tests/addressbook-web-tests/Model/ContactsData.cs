
using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactsData : AccountData, IEquatable<ContactsData>, IComparable<ContactsData>
    {
        public ContactsData() { }

        private string allPhones;
        private string allEmails;

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Delete { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

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
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Fax)).Trim();
                }
                
            }
            set 
            {
                allPhones = value;
            } 
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

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
                    string _allEmails = null;
                    if (Email.Length > 0)
                    {
                        _allEmails = Email + "\r\n";
                    }

                    if (Email2.Length > 0)
                    {
                        _allEmails += Email2 + "\r\n";
                    }
                    
                    if (Email3.Length > 0)
                    {
                        _allEmails += Email3;
                    }

                    return _allEmails;
                }

            }
            set
            {
                allEmails = value;
            }
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string BDay { get; set; }

        public string BMonth { get; set; }

        public string BYear { get; set; }

        public string ADay { get; set; }

        public string AMonth {get; set; }

        public string AYear { get; set; }

        public string SAddress { get; set; }

        public string SHome { get; set; }

        public string SNotes { get; set; }

        public string AllInfo { get; set; }

        public ContactsData(string firstName, string username, string password)
            : base(username, password)
        {
            FirstName = firstName;
        }


        public int CompareTo(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        public bool Equals(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            if (LastName == other.LastName)
            {
                return FirstName == other.FirstName;
            }

            return false;
        }


    }
}
