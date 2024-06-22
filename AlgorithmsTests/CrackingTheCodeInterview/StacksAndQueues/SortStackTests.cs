using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrackingTheCodeInterview.StacksAndQueues.SortStack
{
    [TestClass]
    public class SortStackTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 1)]
        [DataRow(new int[] { 3, 2, 1 }, 1)]
        [DataRow(new int[] { 2, 1, 3 }, 1)]
        public void Peek_EnqueueThenPeek_PerformsCorrectly(int[] inputs, int expected)
        {
            // Arrange
            SortStack sortStack = new();
            foreach (int n in inputs)
            {
                sortStack.Enqueue(n);
            }

            // Act
            int actual = sortStack.Peek();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 5, 2, 3, 1, 6, 4 }, 1, 1)]
        [DataRow(new int[] { 5, 6, 4, 3, 1, 2 }, 2, 2)]
        [DataRow(new int[] { 3, 1, 2, 6, 4, 5 }, 3, 3)]
        [DataRow(new int[] { 6, 5, 4, 3, 2, 1 }, 4, 4)]
        [DataRow(new int[] { 1, 6, 5, 2, 4, 3 }, 5, 5)]
        [DataRow(new int[] { 6, 4, 2, 1, 3, 5 }, 6, 6)]
        [DataRow(new int[] { 2, 1, 4, 3, 5, 6 }, 7, Int32.MinValue)]
        public void Dequeue_EnqueueThenDequeueSeveralTimes_PerformsCorrectly(int[] inputs, int nbDequeues, int expected)
        {
            // Arrange
            SortStack sortStack = new();
            foreach (int n in inputs)
            {
                sortStack.Enqueue(n);
            }

            // Act
            int actual = Int32.MinValue;
            for (int i = 0; i < nbDequeues; i++)
            {
                actual = sortStack.Dequeue();
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 5, 2, 4, 3, 2, 2, 1, 6, 4 }, 1, 1)]
        [DataRow(new int[] { 5, 6, 4, 3, 1, 1, 2 }, 2, 1)]
        [DataRow(new int[] { 3, 1, 2, 1, 1, 6, 4, 5 }, 3, 1)]
        [DataRow(new int[] { 6, 2, 5, 4, 3, 2, 1 }, 4, 3)]
        [DataRow(new int[] { 1, 2, 1, 6, 5, 2, 4, 3, 2 }, 5, 2)]
        [DataRow(new int[] { 4, 6, 4, 3, 2, 1, 3, 5 }, 6, 4)]
        public void Dequeue_EnqueueWithDuplicatesThenDequeueSeveralTimes_PerformsCorrectly(int[] inputs, int nbDequeues, int expected)
        {
            // Arrange
            SortStack sortStack = new();
            foreach (int n in inputs)
            {
                sortStack.Enqueue(n);
            }

            // Act
            int actual = Int32.MinValue;
            for (int i = 0; i < nbDequeues; i++)
            {
                actual = sortStack.Dequeue();
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
