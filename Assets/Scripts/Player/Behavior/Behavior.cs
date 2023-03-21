using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Behavior : MonoBehaviour
{
    private Movement Movement;
    private Node rootNode;

    private void Awake()
    {
        Movement = GetComponent<Movement>();
        BuildBehaviorTree();
    }
    private void BuildBehaviorTree()
    {
        SelectorNode mainSelector = new SelectorNode(Movement);

        ThinkOnDirectionChangeNode thinkOnDirectionChangeNode = new ThinkOnDirectionChangeNode(Movement);
        ChangeDirectionNode changeDirectionNode = new ChangeDirectionNode(Movement);
        ObstacleDetectionNode obstacleDetectionNode = new ObstacleDetectionNode(Movement);
        WalkNode walkNode = new WalkNode(Movement);

        mainSelector.AddChild(thinkOnDirectionChangeNode);
        mainSelector.AddChild(changeDirectionNode);
        mainSelector.AddChild(obstacleDetectionNode);
        mainSelector.AddChild(walkNode);

        rootNode = mainSelector;
    }


    private void Update()
    {
        if (Movement.enabled)
        {
            rootNode.Update();
        }
    }
}