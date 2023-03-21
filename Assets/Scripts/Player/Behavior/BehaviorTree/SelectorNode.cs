public class SelectorNode : CompositeNode
{
    public SelectorNode(Movement movement) : base(movement)
    {
    }

    public override bool Update()
    {
        foreach (Node child in Children)
        {
            if (child.Update())
            {
                return true;
            }
        }
        return false;
    }
}