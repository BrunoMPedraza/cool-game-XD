public abstract class Node
{
    protected readonly Movement Movement;

    protected Node(Movement movement)
    {
        Movement = movement;
    }

    public abstract bool Update();
}
