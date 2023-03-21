using System.Collections.Generic;

public abstract class CompositeNode : Node
{
    protected List<Node> Children = new List<Node>();

    protected CompositeNode(Movement movement) : base(movement)
    {
    }

    public void AddChild(Node node)
    {
        Children.Add(node);
    }
}