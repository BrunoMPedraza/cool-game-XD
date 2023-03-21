using UnityEngine;
using System.Collections;
public class ThinkOnDirectionChangeNode : Node
{
    private Direction lastDirection;

    public ThinkOnDirectionChangeNode(Movement movement) : base(movement)
    {
        lastDirection = Movement.direction;
    }

    public override bool Update()
    {
        if (Movement.direction != lastDirection)
        {
            lastDirection = Movement.direction;
            Movement.StartCoroutine(Think());
            return true;
        }
        return false;
    }

    private IEnumerator Think()
    {
        float thinkTime = Random.Range(1.5f, 2.85f);
        Movement.enabled = false;
        yield return new WaitForSeconds(thinkTime);
        Movement.enabled = true;
    }
}