using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public GameObject player;

    protected NavMeshAgent agent;
    protected Animator animator;

    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("EnemyAIController Update() called");
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);

        
    }
}
