using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AppDemo.Core.Abstract.Services;
using AppDemo.Core.Concrete.Services;
using AppDemo.Core.Data;
using AppDemo.Core.Abstract.Repositories;
using AppDemo.Core.Concrete.Repositories;
using AppDemo.Core.DataTransferObjects.Request;
using System.Threading.Tasks;

namespace AppDemo.Core.Tests
{
    [TestClass]
    public class ContactRequestServiceTests
    {
        [TestMethod]
        public async Task CreateAsync()
        {
            try
            {
                var dbContext = InitializeEnvironment.MockContext;

                IContactRequestRepository ctcRepo = new ContactRequestRepository(dbContext.Object);

                IContactRequestService ctcServ = new ContactRequestService(ctcRepo);

                await ctcServ.CreateAsync(new ContactRequestData
                {
                    Comment = "test commenr",
                    Email = "anyone@test.com",
                    Name = "anyone"
                });

                dbContext.Verify(m => m.SaveChangesAsync(), Times.Once);


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
