using Moq;
using NUnit.Framework;
using QnA.Domain.Interfaces;
using QnA.Domain.Models;
using System;

namespace QnA.Tests.Domain
{
    public class SessionTests
    {
        private readonly DateTime _testDate;
        private readonly IDateService _dateService;

        public SessionTests()
        {
            _testDate = new DateTime(2020, 10, 10, 20, 15, 05);

            var dateServiceSetup = new Mock<IDateService>();

            dateServiceSetup
                .Setup(x => x.Now)
                .Returns(_testDate);

            _dateService = dateServiceSetup.Object;
        }

        [Test]
        public void When_New_Session_Created_Sets_Valid_Default_Values()
        {
            var session = new Session("Test Session", "TEST_1234", "test_user", _dateService);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Test Session", session.Title);
                Assert.AreEqual("TEST_1234", session.AccessCode);
                Assert.AreEqual(Status.Online, session.Status);
                Assert.AreEqual(_testDate, session.Created);
                Assert.AreEqual("test_user", session.CreatedBy);
                Assert.AreEqual(_testDate, session.LastModified);
                Assert.AreEqual("test_user", session.LastModifiedBy);
                Assert.AreEqual("Created", session.LastChangeEvent);
                Assert.AreEqual(0, session.Questions.Count);
            });
        }
    }
}
