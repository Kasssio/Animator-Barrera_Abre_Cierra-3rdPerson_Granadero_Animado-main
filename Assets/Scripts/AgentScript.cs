using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform targetTransform;
    [SerializeField] Transform [] baseTransforms;
    public bool chaseMode = false;
    [SerializeField] float distanceToOrigin;

    int baseIndex;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chaseMode)
        {
            agent.destination = targetTransform.position;
        }

        else
        {
            if(agent.remainingDistance < distanceToOrigin && !agent.pathPending)
            {
                Debug.Log("Hola :)");
                baseIndex++;
                if(baseIndex >= baseTransforms.Length)
                {
                    baseIndex = 0;
                }
                agent.destination = baseTransforms[baseIndex].position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            chaseMode = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            chaseMode = false;
        }
    }
}
