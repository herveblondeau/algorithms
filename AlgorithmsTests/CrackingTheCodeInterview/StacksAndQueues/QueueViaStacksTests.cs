using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrackingTheCodeInterview.StacksAndQueues.QueueViaStacks
{
    [TestClass]
    public class QueueViaStacksTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 1)]
        [DataRow(new int[] { 3, 2, 1 }, 3)]
        [DataRow(new int[] { 2, 1, 3 }, 2)]
        public void Peek_EnqueueThenPeek_PerformsCorrectly(int[] inputs, int expected)
        {
            // Arrange
            QueueViaStacks queueViaStacks = new QueueViaStacks();
            foreach (int n in inputs)
            {
                queueViaStacks.Enqueue(n);
            }

            // Act
            int actual = queueViaStacks.Peek();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 1)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 4, 4)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 5, 5)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 6, 6)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 7, Int32.MinValue)]
        public void Dequeue_EnqueueThenDequeueSeveralTimes_PerformsCorrectly(int[] inputs, int nbDequeues, int expected)
        {
            // Arrange
            QueueViaStacks queueViaStacks = new QueueViaStacks();
            foreach (int n in inputs)
            {
                queueViaStacks.Enqueue(n);
            }

            // Act
            int actual = Int32.MinValue;
            for (int i = 0; i < nbDequeues; i++)
            {
                actual = queueViaStacks.Dequeue();
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
