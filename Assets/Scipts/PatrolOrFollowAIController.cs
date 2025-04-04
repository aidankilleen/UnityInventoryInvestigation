using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class PatrolOrFollowAIController : PathFollowingEnemyAIController
{
    public float enemyDistanceThreshold = 5f;

    public void Start()
    {
        base.Start();
    }

    public void Update()
    {
        var distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < enemyDistanceThreshold)
        {
            // follow the player
            agent.SetDestination(player.transform.position);
        }
        else
        {
            // follow the path
            base.Update();
        }
    }
}
