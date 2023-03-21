using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody body;
    public Direction direction;
    public float speed = 2;

    private bool isBlocked = false;

    public void Move()
    {
        if (isBlocked)
        {
            return;
        }

        Obstacle detectedObstacle = PathIdentifier.GetObstacle(transform.position, direction);
        if (detectedObstacle)
        {
            HandleObstacle(detectedObstacle);
        }
        else
        {
            Translate();
        }
    }

    public void Translate()
    {
        body.MovePosition(body.position + (Vector3)DirectionHelper.TransformToVector2(direction) * (speed * Time.fixedDeltaTime));
    }

    public void HandleObstacle(Obstacle obstacle)
    {
        isBlocked = true;
        direction = DirectionHelper.ReverseDirection(direction);
        StartCoroutine(UnblockAndMoveAwayFromObstacle(0.5f));
    }

    private IEnumerator UnblockAndMoveAwayFromObstacle(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 offset = DirectionHelper.TransformToVector2(direction) * 0.1f;
        body.MovePosition(body.position + offset);
        isBlocked = false;
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