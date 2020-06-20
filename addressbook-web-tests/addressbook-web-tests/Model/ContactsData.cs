
using System;

namespace WebAddressbookTests
{
    public class ContactsData : AccountData, IEquatable<ContactsData>, IComparable<ContactsData>
    {
        string firstName;
        string middleName;
        string lastName;
        string nickname;
        string delete;
        string company;
        string title;
        string address;
        string home;
        string mobile;
        string work;
        string fax;
        string email;
        string email2;
        string email3;
        string homepage;
        string bDay;
        string bMonth;
        string bYear;
        string aDay;
        string aMonth;
        string aYear;
        string sAddress;
        string sHome;
        string sNotes;

        public ContactsData(string firstName, string username, string password)
            : base(username, password)
        {
            this.firstName = firstName;
        }


        public int CompareTo(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;

            if (lastName.CompareTo(other.lastName) == 0)
            {
                return firstName.CompareTo(other.firstName);
            }
            return lastName.CompareTo(other.lastName);
        }

        public bool Equals(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            if (lastName == other.lastName)
            {
                return firstName == other.firstName;
            }

            return false;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Delete
        {
            get { return delete; }
            set { delete = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Home
        {
            get { return home; }
            set { home = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string Work
        {
            get { return work; }
            set { work = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        public string BDay
        {
            get { return bDay; }
            set { bDay = value; }
        }

        public string BMonth
        {
            get { return bMonth; }
            set { bMonth = value; }
        }

        public string BYear
        {
            get { return bYear; }
            set { bYear = value; }
        }

        public string ADay
        {
            get { return aDay; }
            set { aDay = value; }
        }

        public string AMonth
        {
            get { return aMonth; }
            set { aMonth = value; }
        }

        public string AYear
        {
            get { return aYear; }
            set { aYear = value; }
        }

        public string SAddress
        {
            get { return sAddress; }
            set { sAddress = value; }
        }

        public string SHome
        {
            get { return sHome; }
            set { sHome = value; }
        }

        public string SNotes
        {
            get { return sNotes; }
            set { sNotes = value; }
        }
    }
}
