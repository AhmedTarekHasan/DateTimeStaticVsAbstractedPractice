using System;
using Moq;
using NUnit.Framework;

namespace DateTimeAbstracted.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        private Mock<IDateTimeProvider> m_IDateTimeProviderMock;
        private Logger m_Sut;

        [SetUp]
        public void SetUp()
        {
            m_IDateTimeProviderMock = new Mock<IDateTimeProvider>();
            m_Sut = new Logger(m_IDateTimeProviderMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            m_Sut = null;
            m_IDateTimeProviderMock = null;
        }

        [Test]
        public void LogTest()
        {
            // Arrange
            var inputMessage = "This is a test message";
            var expectedStamp = DateTimeOffset.Now;
            var expectedMessage = $"{expectedStamp}: This is a test message";

            m_IDateTimeProviderMock
                .Setup
                (
                    m => m.Now
                )
                .Returns(expectedStamp)
                .Verifiable();

            // Act
            var actual = m_Sut.Log(inputMessage);

            // Assert
            m_IDateTimeProviderMock
                .Verify
                (
                    m => m.Now
                );

            Assert.AreEqual(expectedMessage, actual);
        }
    }
}