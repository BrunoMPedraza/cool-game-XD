using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public static class DirectionHelper
{
    private static readonly Dictionary<Direction, Vector2> DirectionHasVector2 = new Dictionary<Direction, Vector2>
    {
        { Direction.RIGHT, Vector2.right },
        { Direction.LEFT, Vector2.left },
        { Direction.UP, Vector2.up },
        { Direction.DOWN, Vector2.down }
    };
    
    private static readonly Dictionary<Vector2, Direction> Vector2HasDirection = new Dictionary<Vector2, Direction>
    {
        { Vector2.right, Direction.RIGHT },
        { Vector2.left, Direction.LEFT },
        { Vector2.up, Direction.UP },
        { Vector2.down, Direction.DOWN }
    };

    private static readonly Dictionary<Direction, Direction> ReversedDirection = new Dictionary<Direction, Direction>
    {
        { Direction.RIGHT, Direction.LEFT },
        { Direction.LEFT, Direction.RIGHT },
        { Direction.UP, Direction.DOWN },
        { Direction.DOWN, Direction.UP }
    };
    
    public static Direction GetDirection(float x, float y)
    {
        return Vector2HasDirection.TryGetValue(new Vector2(x, y), out Direction result) ? result : Direction.RIGHT;
    }


    public static Vector2 TransformToVector2(Direction direction)
    {
        return DirectionHasVector2.TryGetValue(direction, out Vector2 result) ? result : Vector2.zero;
    }

    public static Direction ReverseDirection(Direction direction)
    {
        return ReversedDirection.TryGetValue(direction, out Direction result) ? result : direction;
    }
}
