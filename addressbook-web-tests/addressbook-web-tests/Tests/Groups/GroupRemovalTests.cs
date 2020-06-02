using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBasse
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);
            
        }
     
    }
}
