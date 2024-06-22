namespace prove_09;

public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        } else {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        if (value == Data) {
            return true;
        } else if (value < Data) {
            // Search in the left subtree
            return Left != null && Left.Contains(value);
        } else {
            // Search in the right subtree
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight() {
    // Base case: height of an empty subtree is 0
    if (Left == null && Right == null)
        return 1;

    // Recursive case: calculate height of left and right subtrees
    int leftHeight = Left?.GetHeight() ?? 0;
    int rightHeight = Right?.GetHeight() ?? 0;

    // Height of current node is 1 + maximum height of left or right subtree
    return 1 + Math.Max(leftHeight, rightHeight);
}
}
