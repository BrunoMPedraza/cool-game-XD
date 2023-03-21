using UnityEngine;

public class WalkNode : Node
{
    public WalkNode(Movement movement) : base(movement)
    {
    }

    public override bool Update()
    {
        Movement.Move();
        return true;
    }
}