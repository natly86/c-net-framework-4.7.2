using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests_1.Tests
{
    [TestFixture]
    class Class1
    {
        [Test]
        public void TestMethod1()
        {
            double total = 900;
            bool vipClient = true;

            if (total > 1000 || vipClient)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
        }
    }
}
