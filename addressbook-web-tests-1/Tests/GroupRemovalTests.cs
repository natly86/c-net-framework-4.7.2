using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.GroupIsPresent();

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //GroupData toBeRemoved = oldGroups[0];
            //oldGroups.RemoveAt(0);
            //Assert.AreEqual(oldGroups, newGroups);

            //foreach (GroupData group in newGroups)
            //{
            //    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            //}
        }
     }
}
