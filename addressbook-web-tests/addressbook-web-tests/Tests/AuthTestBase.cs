﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{

    public class AuthTestBase : TestBasse
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new ContactsData("a", "admin", "secret"));
        }
    }
}
