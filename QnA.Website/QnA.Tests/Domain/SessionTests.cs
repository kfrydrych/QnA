using Moq;
using NUnit.Framework;
using QnA.Domain.Interfaces;
using QnA.Domain.Models;
using System;

namespace QnA.Tests.Domain
{
    public class SessionTests
    {
        private DateTime _creationDate;
        private DateTime _modificationDate;
        private IDateService _dateService;

        [SetUp]
        public void Before_Each_Test()
        {
            _creationDate = new DateTime(2020, 10, 10, 20, 15, 05);

            _modificationDate = new DateTime(2020, 10, 15, 18, 20, 00);

            var dateServiceSetup = new Mock<IDateService>();

            dateServiceSetup
                .Setup(x => x.Now)
                .Returns(_creationDate);

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
                Assert.AreEqual(_creationDate, session.Created);
                Assert.AreEqual("test_user", session.CreatedBy);
                Assert.AreEqual(_creationDate, session.LastModified);
                Assert.AreEqual("test_user", session.LastModifiedBy);
                Assert.AreEqual("Created", session.LastChangeEvent);
                Assert.AreEqual(0, session.Questions.Count);
            });
        }

        [Test]
        public void When_Session_Set_Offline_Updates_Session_State()
        {
            var session = new Session("Test Session", "TEST_1234", "test_user", _dateService);

            var dateServiceSetup = new Mock<IDateService>();
            dateServiceSetup.Setup(x => x.Now).Returns(_modificationDate);
            _dateService = dateServiceSetup.Object;

            session.SetOffline("test_user", _dateService);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Test Session", session.Title);
                Assert.AreEqual("TEST_1234", session.AccessCode);
                Assert.AreEqual(Status.Offline, session.Status);
                Assert.AreEqual(_creationDate, session.Created);
                Assert.AreEqual("test_user", session.CreatedBy);
                Assert.AreEqual(_modificationDate, session.LastModified);
                Assert.AreEqual("test_user", session.LastModifiedBy);
                Assert.AreEqual("Set Offline", session.LastChangeEvent);
                Assert.AreEqual(0, session.Questions.Count);
            });
        }
    }
}
