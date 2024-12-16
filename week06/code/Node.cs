public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (value > Data)
            {
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        if (value == Data)
        {
            return true;
            // Insert to the left
        }
        else
        {
            if (value > Data)
            {
                if (Right is null)
                    return false;
                else
                {
                    Data = Right.Data; // Replace this line with the correct return statement(s)
                    Contains(value);
                }
            }
            else
            {
                if (Left is null)
                    return false;
                else
                {
                    Data = Left.Data; // Replace this line with the correct return statement(s)
                    Contains(value);
                }
            }

        }
        return false;
    }

    public int GetHeight()
    {
        // Base Case: If the node is null (this is handled implicitly via recursion), height is 0
        if (this == null)
        {
            return 0;
        }

        // Recursive Case: Compute the height of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0; // Use null-coalescing to handle null cases
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return the height of the current node
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}