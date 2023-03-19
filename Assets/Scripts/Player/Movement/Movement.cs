using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody body;
    public Direction direction;
    public float speed = 2;

    public void Move()
    {
        Obstacle detectedObstacle = PathIdentifier.GetObstacle(transform.position, direction);
        if (detectedObstacle)
            HandleObstacle(detectedObstacle);
    
        Translate();
    }

    public void Translate()
    {
        body.MovePosition(body.position + (Vector3)DirectionHelper.TransformToVector2(direction) * (speed * Time.fixedDeltaTime));
    }
    
    public void HandleObstacle(Obstacle obstacle)
    {
        // do things when an obstacle appears
        switch (obstacle.Type)
        {
            case ObstacleType.BLOCK:
                direction = DirectionHelper.ReverseDirection(direction);
                break;
        }
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            direction = DirectionHelper.GetDirection(x, y);
        }
    }
}
