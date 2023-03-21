using UnityEngine;

public class ObstacleDetectionNode : Node
{
    public ObstacleDetectionNode(Movement movement) : base(movement)
    {
    }

    public override bool Update()
    {
        Obstacle detectedObstacle = PathIdentifier.GetObstacle(Movement.transform.position, Movement.direction);

        if (detectedObstacle)
        {
            Movement.HandleObstacle(detectedObstacle);
            return true;
        }

        return false;
    }
}