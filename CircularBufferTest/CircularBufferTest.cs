using Buffer.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CircularBufferTest
{
    [TestClass]
    public class CircularBufferTest
    {
        private const string testValue = "Hello, World!";
        private const int bufferSize = 3;

        [TestMethod]
        public void WriteReadValidAmount()
        {
            // Arrange
            CircularBuffer<string> circularBuffer = new CircularBuffer<string>();

            // Act
            circularBuffer.Write(testValue);
            var readValue = circularBuffer.Read();

            // Assert
            Assert.IsTrue(readValue == testValue);
        }

        [TestMethod]
        public void WriteMoreThenBufferSize()
        {
            //Arrange
            var circularBuffer = new CircularBuffer<string>(bufferSize);

            // Act
            try
            {
                for (int i = 0; i <= bufferSize; i++)
                {
                    circularBuffer.Write(testValue);
                }
                // Assert
                Assert.Fail();
            }
            // Assert
            catch (Exception GoodException)
            {
                Assert.IsTrue("Buffer is full" == GoodException.Message);
            }
        }

        [TestMethod]
        public void ReadMoreThenAviableValues()
        {
            //Arrange
            var circularBuffer = new CircularBuffer<string>();

            // Act
            try
            {
                circularBuffer.Read();
                Assert.Fail();
            }
            // Assert
            catch (Exception GoodException)
            {
                Assert.IsTrue("Buffer is empty" == GoodException.Message);
            }
        }

        [TestMethod]
        public void WriteTwoFullRings()
        {
            //Arrange
            var circularBuffer = new CircularBuffer<string>(bufferSize);
            string lastReadValue = "";

            // Act
            try
            {
                for (int i = 0; i <= bufferSize; i++)
                {
                    circularBuffer.Write(testValue);
                    lastReadValue = circularBuffer.Read();
                }
                Assert.IsTrue(lastReadValue == testValue);
            }
            // Assert
            catch (Exception BadException)
            {
                Assert.Fail();
            }
        }
    }
}