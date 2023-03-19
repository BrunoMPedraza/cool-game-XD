using System.Linq;
using UnityEngine;

public static class PathIdentifier
{
    /// <summary>
    /// Returns an obstacle given a direction.
    /// Returns null if there's not obstacle in that direction.
    /// </summary>
    /// <param name="from">Point of view</param>
    /// <param name="direction">Direction from point of view</param>
    /// <param name="maxDistance">Maximum checking distance</param>
    /// <returns></returns>
    public static Obstacle GetObstacle(Vector3 from, Direction direction, float maxDistance = 2)
    {
        //  from + direction = direction from the point of view.
        Ray ray = new Ray(from, from + (Vector3)DirectionHelper.TransformToVector2(direction));
        
        // obtain and map all the obstacles from the hits array.
        Obstacle[] obstacles = Physics.RaycastAll(ray, maxDistance, ObstacleConstants.ObstacleMask)
            .Select((obstacle) => obstacle.collider.GetComponent<Obstacle>()).ToArray();

        Debug.DrawRay(ray.origin, ray.direction);
        
        if (obstacles.Length == 0)
        {
            return null;
        }
        
        Obstacle prioritizedObstacle = obstacles[0];
        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle.Priority > prioritizedObstacle.Priority)
            {
                prioritizedObstacle = obstacle;
            }
        }
        return prioritizedObstacle;
    }
}
