using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

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
        //verifies is the current data is the same value and return to avoid inserting duplicate values
        if (value == Data)
        {
            return;
        }
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
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        //the current node contains the value
        if (value == Data)
        {
            Console.WriteLine("Found value");
            return true;
        }
        else if (value < Data)
        {
            // Verify the left node is not null
            if (Left == null)
                return false;
            return Left.Contains(value); // return the result of the recursive call
        }
        else if(value > Data)
        {
            Console.WriteLine("GOing right: " + value);
            // Verify the right node is not null
            if (Right == null)
                return false;
            return Right.Contains(value); // return the result of the recursive call
        }
        Console.WriteLine("not found: " + value);
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        if (this == null) // if the current node is null(empty bst) returns 0
        {
            return 0;
        }
        else
        {
            int leftHeight = Left?.GetHeight() ?? 0; //recursive call getheight, if left subtree is null returns 0
            int rightHeight = Right?.GetHeight() ?? 0; //recursive call getheight for right subtree, if right subtree is null return 0

            return 1 + Math.Max(leftHeight, rightHeight); //return 1 + deepest level value between left and right subtrees
        }
    }
}