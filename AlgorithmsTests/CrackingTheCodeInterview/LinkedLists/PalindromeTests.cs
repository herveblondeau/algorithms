using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.LinkedLists.Palindrome;

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
        var list = _toList(values)!;
        var palindrome = new Palindrome();

        // Act
        bool actual = palindrome.IsPalindrome(list);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    [DataRow(new int[] { 1, 2 })]
    [DataRow(new int[] { 1, 2, 2 })]
    [DataRow(new int[] { 1, 2, 2, 3, 3, 2, 1 })]
    [DataRow(new int[] { 1, 2, 2, 3, 3, 2, 2, 2, 1 })]
    public void IsPalindrome_IsNotPalindrome_ReturnsFalse(int[] values)
    {
        // Arrange
        var list = _toList(values)!;
        var palindrome = new Palindrome();

        // Act
        bool actual = palindrome.IsPalindrome(list);

        // Assert
        actual.Should().BeFalse();
    }

    private static LinkedListNode? _toList(int[] values)
    {
        if (values.Length == 0)
            return null;

        LinkedListNode start = new(values[0]);
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
