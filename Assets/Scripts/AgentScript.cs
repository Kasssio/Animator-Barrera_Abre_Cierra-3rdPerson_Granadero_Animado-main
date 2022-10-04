using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform targetTransform;
    [SerializeField] Transform baseTransform;
    public bool chaseMode = false;
    // Start is called before the first frame update
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
            agent.destination = baseTransform.position;
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
