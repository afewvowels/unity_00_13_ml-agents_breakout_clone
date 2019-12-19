using UnityEngine;

public class Breaker : MonoBehaviour
{
    public int brickCount;
    public BreakoutAgent agent;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("brick"))
        {
            Destroy(c.gameObject);
            agent.AddReward(1.0f / 50.0f);
            brickCount++;
            if (brickCount == 90)
            {
                agent.AddReward(1.0f);
                agent.Done();
            }
        }

        if (c.gameObject.CompareTag("bounds"))
        {
            agent.AddReward(-0.5f);
            agent.Done();
        }
        else
        {
            Vector3 reflected = Vector3.Reflect(c.gameObject.transform.position - transform.position, Vector3.down);
            rb.AddForce(reflected.normalized * 2.0f, ForceMode.VelocityChange);
        }

        if (c.gameObject.CompareTag("agent"))
        {
            agent.AddReward(1.0f / 250.0f);
        }
    }
}