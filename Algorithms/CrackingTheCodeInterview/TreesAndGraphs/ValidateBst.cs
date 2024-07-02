namespace CrackingTheCodeInterview.TreesAndGraphs.ValidateBst;

// Source: "Cracking the coding interview" book (4.5 - Validate BST)
public class ValidateBst
{
    public static bool IsBst(BinaryTreeNode root)
    {
        return _IsBst(root, int.MinValue, int.MaxValue);
    }

    private static bool _IsBst(BinaryTreeNode node, int lowerLimit, int upperLimit)
    {
        if (node is null)
        {
            return true;
        }

        // These are the basic BST rules: a node value must be contained between its left and right child values
        if (node.LeftChild is not null && node.Value <= node.LeftChild.Value)
        {
            return false;
        }
        if (node.RightChild is not null && node.Value >= node.RightChild.Value)
        {
            return false;
        }

        // Because we use recursion, the above check is not enough. For instance, let's assume:
        // - we have a root node A
        // - A has a left child B
        // - B has a right child C
        // When we are checking B, the above rule ensures that C is greater than B. But we must also ensure that C is lesser than A!
        // Due to the BST nature, a node must be checked against all its ascendants, not just its immediate parents.
        // This is why we need to keep track and carry the lower and upper limits allowed for each node
        if (node.Value < lowerLimit || node.Value > upperLimit)
        {
            return false;
        }

        // Recursion
        return _IsBst(node.LeftChild, lowerLimit, node.Value) && _IsBst(node.RightChild, node.Value, upperLimit);
    }

}

// Basic binary tree implementation for the purpose of the problem
public class BinaryTreeNode
{
    public int Value { get; private set; }

    public BinaryTreeNode LeftChild { get; set; }

    public BinaryTreeNode RightChild { get; set; }

    public bool IsVisited { get; set; }

    public BinaryTreeNode(int value)
    {
        Value = value;
    }
}
