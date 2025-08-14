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
        if (value == Data)
        {
            Console.WriteLine("value already exists");
            return;
        }
        else if (value < Data)
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
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left == null)
            {
                return false;
            }
            else
            {
                return Left.Contains(value);
            }
        }
        else
        {
            if (Right == null)
            {
                return false;
            }
            else
            {
                return Right.Contains(value);
            }
        }
    }

    public int GetHeight()
    {
        int leftH = 0;
        int rightH = 0;

        if (Left != null)
        {
            leftH = Left.GetHeight();
        }

        if (Right != null)
        {
            rightH = Right.GetHeight();
        }

        return 1 + Math.Max(leftH, rightH);
    }
}