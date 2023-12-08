namespace Advent.Common;

public class BinaryTree<T> where T : IComparable<T>
{
    public Node<T> Root { get; private set; } = null!;

    public void Add(T value)
    {
        if (Root == null)
        {
            Root = new Node<T>(value);
        }
        else
        {
            Root.Add(value);
        }
    }
}

public class Node<T> where T : IComparable<T>
{
    public T Value { get; private set; }
    public Node<T> Left { get; private set; } = null!;
    public Node<T> Right { get; private set; } = null!;

    public Node(T value) => Value = value;

    public void Add(T newValue)
    {
        if (Left == null)
        {
            Left = new Node<T>(newValue);
        }
        else if (Right == null)
        {
            Right = new Node<T>(newValue);
        }
        else 
        {
            throw new Exception("can't add");
        }
    }       
    
}
