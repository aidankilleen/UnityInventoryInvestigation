using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;  // Assign the Player in the Inspector
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);

        if (Vector3.Distance(transform.position, player.position) < 2f)
        {
            animator.SetBool("IsAttacking", true);
            agent.isStopped = true;
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }

    }
    public void Die()
    {
        animator.SetBool("IsDead", true);
        agent.isStopped = true;
        Destroy(gameObject, 3f); // Destroy after 3 seconds
    }
}
