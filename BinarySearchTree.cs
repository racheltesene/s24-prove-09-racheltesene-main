using System.Collections;
using System.Collections.Generic;

namespace prove_09;

public class BinarySearchTree : IEnumerable<int> {
    private Node? _root;

    /// <summary>
    /// Insert a new node at the root of the tree.
    /// </summary>
    public void Insert(int value) {
        // Check if the value already exists in the tree
        if (Contains(value)) {
            return; // If it exists, do not insert it
        }
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point root to the new node.
        if (_root is null)
            _root = newNode;
        // If the list is not empty, then only root will be affected.
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Check to see if the tree contains a certain value
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value) {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers) {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values) {
        if (node is not null) {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse() {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers) {
            yield return number;
        }
    }

    private void TraverseBackward(Node? node, List<int> values) {
    if (node is not null) {
        TraverseBackward(node.Right, values); // Traverse right subtree
        values.Add(node.Data); // Add current node's data
        TraverseBackward(node.Left, values); // Traverse left subtree
    }
}


    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight() {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString() {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}
