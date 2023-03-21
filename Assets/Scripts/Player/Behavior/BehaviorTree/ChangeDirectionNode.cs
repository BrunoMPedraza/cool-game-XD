using UnityEngine;

public class ChangeDirectionNode : Node
{
    public ChangeDirectionNode(Movement movement) : base(movement)
    {
    }

    public override bool Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            Movement.direction = DirectionHelper.GetDirection(x, y);
            return true;
        }
        return false;
    }
}
