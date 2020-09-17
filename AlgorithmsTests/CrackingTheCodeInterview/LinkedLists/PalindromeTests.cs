using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.LinkedLists.Palindrome
{
    [TestClass]
    public class PalindromeTests
    {
        [TestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 1 })]
        [DataRow(new int[] { 1, 2, 1 })]
        [DataRow(new int[] { 1, 2, 2, 3, 2, 2, 1 })]
        [DataRow(new int[] { 1, 2, 2, 3, 3, 3, 2, 2, 1 })]
        public void IsPalindrome_IsPalindrome_ReturnsTrue(int[] values)
        {
            // Arrange
            var list = _toList(values);

            // Act
            bool actual = Palindrome.IsPalindrome(list);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 2 })]
        [DataRow(new int[] { 1, 2, 2, 3, 3, 2, 1 })]
        [DataRow(new int[] { 1, 2, 2, 3, 3, 2, 2, 2, 1 })]
        public void IsPalindrome_IsNotPalindrome_ReturnsFalse(int[] values)
        {
            // Arrange
            var list = _toList(values);

            // Act
            bool actual = Palindrome.IsPalindrome(list);

            // Assert
            Assert.IsFalse(actual);
        }

        private static LinkedListNode _toList(int[] values)
        {
            if (values.Length == 0)
                return null;

            LinkedListNode start = new LinkedListNode(values[0]);
            LinkedListNode current = start;
            int i = 1;
            while (i + 1 <= values.Length)
            {
                current.Next = new LinkedListNode(values[i]);
                current = current.Next;
                i++;
            }

            return start;
        }
    }
}
