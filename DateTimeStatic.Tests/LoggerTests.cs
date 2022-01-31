using System;
using NUnit.Framework;

namespace DateTimeStatic.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        private Logger m_Sut;

        [SetUp]
        public void SetUp()
        {
            m_Sut = new Logger();
        }

        [TearDown]
        public void TearDown()
        {
            m_Sut = null;
        }

        [Test]
        public void LogTest()
        {
            // Arrange
            var inputMessage = "This is a test message";
            var expectedMessage = ": This is a test message";

            // Act
            var actual = m_Sut.Log(inputMessage);

            // Assert
            Assert.IsTrue(actual.Contains(expectedMessage));
        }
    }
}