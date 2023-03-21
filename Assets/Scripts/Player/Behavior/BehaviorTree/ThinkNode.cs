using System.Collections;
using UnityEngine;

public class ThinkNode : Node
{
    private float minThinkTime;
    private float maxThinkTime;
    private float thinkTime;
    private float elapsedTime;

    public ThinkNode(Movement movement, float minThinkTime, float maxThinkTime) : base(movement)
    {
        this.minThinkTime = minThinkTime;
        this.maxThinkTime = maxThinkTime;
        thinkTime = Random.Range(minThinkTime, maxThinkTime);
    }

    public override bool Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= thinkTime)
        {
            elapsedTime = 0;
            thinkTime = Random.Range(minThinkTime, maxThinkTime);
            return true;
        }

        return false;
    }
}