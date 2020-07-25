using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AdressBookDB : LinqToDB.Data.DataConnection
    {
        public AdressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Grouos { get { return GetTable<GroupData>(); } }
        public ITable<ContactsData> Contacts { get { return GetTable<ContactsData>(); } }
    }
}