public class SequenceNode : CompositeNode
{
    private int currentChildIndex = 0;

    public SequenceNode(Movement movement) : base(movement)
    {
    }

    public override bool Update()
    {
        if (Children.Count == 0)
        {
            return true;
        }

        bool childStatus = Children[currentChildIndex].Update();

        if (childStatus)
        {
            currentChildIndex++;
            if (currentChildIndex >= Children.Count)
            {
                currentChildIndex = 0;
            }
        }

        return childStatus;
    }
}