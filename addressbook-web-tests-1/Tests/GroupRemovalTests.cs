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
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.GroupIsPresent();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

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
