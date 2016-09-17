using AppDemo.Core.Data;
using AppDemo.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Core.Tests
{
    [TestClass]
    public class InitializeEnvironment
    {
        public static AppDemoDbContext MockDb = null;

        public static Mock<AppDemoDbContext> MockContext = null;

        [AssemblyInitialize]
        public static void InitDb(TestContext context)
        {
            var mockContact = new Mock<DbSet<ContactRequest>>();

            var contacts = new List<ContactRequest>
            {
                new ContactRequest {
                    Comment = "test commenr 1",
                    Email = "anyon1e@test.com",
                    Name = "an1yone"
                }
            }.AsQueryable();
            
            mockContact.As<IQueryable<ContactRequest>>().Setup(m => m.Provider).Returns(contacts.Provider);
            mockContact.As<IQueryable<ContactRequest>>().Setup(m => m.Expression).Returns(contacts.Expression);
            mockContact.As<IQueryable<ContactRequest>>().Setup(m => m.ElementType).Returns(contacts.ElementType);
            mockContact.As<IQueryable<ContactRequest>>().Setup(m => m.GetEnumerator()).Returns(contacts.GetEnumerator());


            var mockContext = new Mock<AppDemoDbContext>();
            mockContext.Setup(c => c.ContactRequests).Returns(mockContact.Object);

            MockContext = mockContext;
            MockDb = mockContext.Object;
        }
    }
}
