using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutManager : MonoBehaviour
{
    public GameObject agent;
    public GameObject breaker;
    public GameObject instantiatedContainer;
    public GameObject brickPrefab;
    public Color easyColor;
    public Color mediumColor;
    public Color hardColor;
    
    private void Start()
    {

    }

    public void SpawnBlocks()
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                if (i % 2 ==0)
                {
                    GameObject brick = (GameObject)Instantiate(brickPrefab);
                    brick.transform.SetParent(instantiatedContainer.transform, false);
                    brick.transform.localPosition = new Vector3(i, j, 0.0f);
                    Material brickMat = brick.GetComponent<MeshRenderer>().material;
                    if (j > 8)
                    {
                        brickMat.color = hardColor;
                    }
                    else if (j > 4)
                    {
                        brickMat.color = mediumColor;
                    }
                    else
                    {
                        brickMat.color = easyColor;
                    }
                }
            }
        }
    }

    public void StartBreakerAndAgent()
    {
        Vector3 newPosition = new Vector3(Random.Range(-10, 11), -8.0f, 0.0f);
        agent.transform.localPosition = newPosition;

        newPosition.y += 3.0f;

        breaker.GetComponent<Breaker>().brickCount = 0;
        breaker.transform.localPosition = newPosition;
        Rigidbody breakerRB = breaker.GetComponent<Rigidbody>();
        breakerRB.velocity = Vector3.zero;
        breakerRB.AddRelativeForce(new Vector3(0.0f, -2.0f, 0.0f), ForceMode.Impulse);
    }

    public void ClearScene()
    {
        for (int i = 0; i < instantiatedContainer.transform.childCount; i++)
        {
            Destroy(instantiatedContainer.transform.GetChild(0).gameObject);
        }
    }
}
