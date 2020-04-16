using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
     public class GroupModificationTests : GroupTestBase
    {
        //[Test]
        //public void GroupModificationTest()
        //{
        //    GroupData newData = new GroupData("zzz");
        //    newData.Header = null;
        //    newData.Footer = null;

        //    app.Groups.GroupIsPresent();

        //    List<GroupData> oldGroups = app.Groups.GetGroupList();

        //    app.Groups.Modify(0, newData);

        //    Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

        //    List<GroupData> newGroups = app.Groups.GetGroupList();
        //    oldGroups[0].Name = newData.Name;
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);
        //}

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.GroupIsPresent();

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
