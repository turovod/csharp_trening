
using LinqToDB.Mapping;
using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]

    public class ContactsData : AccountData, IEquatable<ContactsData>, IComparable<ContactsData>
    {
        public ContactsData() { }

        private string allPhones;
        private string allEmails;

        [Column(Name = ("firstname"))]
        public string FirstName { get; set; }

        [Column(Name = ("middlename"))]
        public string MiddleName { get; set; }

        [Column(Name = ("lastname"))]
        public string LastName { get; set; }

        [Column(Name = ("nickname"))]
        public string Nickname { get; set; }

        public string Delete { get; set; }

        [Column(Name = ("company"))]
        public string Company { get; set; }

        [Column(Name = ("title"))]
        public string Title { get; set; }

        [Column(Name = ("address"))]
        public string Address { get; set; }

        [Column(Name = ("home"))]
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

        [Column(Name = ("mobile"))]
        public string Mobile { get; set; }

        [Column(Name = ("work"))]
        public string Work { get; set; }

        [Column(Name = ("fax"))]
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

        [Column(Name = ("email"))]
        public string Email { get; set; }

        [Column(Name = ("email2"))]
        public string Email2 { get; set; }

        [Column(Name = ("email3"))]
        public string Email3 { get; set; }

        [Column(Name = ("homepage"))]
        public string Homepage { get; set; }

        [Column(Name = ("bday"))]
        public string BDay { get; set; }

        [Column(Name = ("bmonth"))]
        public string BMonth { get; set; }

        [Column(Name = ("byear"))]
        public string BYear { get; set; }

        [Column(Name = ("aday"))]
        public string ADay { get; set; }

        [Column(Name = ("amonth"))]
        public string AMonth {get; set; }

        [Column(Name = ("ayear"))]
        public string AYear { get; set; }

        [Column(Name = ("address2"))]
        public string SAddress { get; set; }

        [Column(Name = ("phone2"))]
        public string SHome { get; set; }

        [Column(Name = ("notes"))]
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
