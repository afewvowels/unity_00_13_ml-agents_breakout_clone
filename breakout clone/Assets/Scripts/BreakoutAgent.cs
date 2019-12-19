using UnityEngine;
using MLAgents;

public class BreakoutAgent : Agent
{
    public BreakoutAcademy academy;
    public BreakoutManager sceneManager;

    private void Start()
    {
        academy = FindObjectOfType<BreakoutAcademy>();
    }

    public override void AgentAction(float[] vectorAction)
    {
        var moveAction = Mathf.FloorToInt(vectorAction[0]);

        switch(moveAction)
        {
            case 1:
                if (transform.localPosition.x + transform.right.x < 9.0f)
                {
                    transform.localPosition += transform.right;
                }
                break;
            case 2:
                if (transform.localPosition.x + (transform.right.x * 2.0f) < 9.0f)
                {
                    transform.localPosition += (transform.right * 2.0f);
                }
                break;
            case 3:
                if (transform.localPosition.x - transform.right.x > -9.0f)
                {
                    transform.localPosition -= transform.right;
                }
                break;
            case 4:
                if (transform.localPosition.x - (transform.right.x * 2.0f) > -9.0f)
                {
                    transform.localPosition -= (transform.right * 2.0f);
                }
                break;
        }
    }

    public override float[] Heuristic()
    {
        var action = new float[1];

        if (Input.GetKey(KeyCode.A))
        {
            action[0] = 3.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            action[0] = 1.0f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            action[0] = 4.0f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            action[0] = 2.0f;
        }

        return action;
    }

    public override void AgentReset()
    {
        sceneManager.ClearScene();
        sceneManager.SpawnBlocks();
        sceneManager.StartBreakerAndAgent();
    }
}