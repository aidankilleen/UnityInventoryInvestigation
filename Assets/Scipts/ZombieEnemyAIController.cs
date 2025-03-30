using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemyAIController : EnemyAIController
{

    private void Update()
    {
        // zombie agent just follows the player
        Debug.Log("zombie Update() called");


        agent.SetDestination(player.transform.position);
        base.Update();
    }

}
