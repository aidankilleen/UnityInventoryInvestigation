using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowNearestGameObjectAIController : EnemyAIController
{
    public List<GameObject> gameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // call the base class Start()
        base.Start();
        // 
        gameObjects.Add(this.player);
    }

    // Update is called once per frame
    void Update()
    {
        // find the distance to each of the objects in the List
        GameObject closestGameObject = FindNearestGameObject();

        // find distance to player
        agent.SetDestination(closestGameObject.transform.position);

        // follow the nearest one


    }
    public GameObject FindNearestGameObject()
    {
        GameObject closest = null;

        float shortestDistance = Mathf.Infinity;

        foreach (GameObject obj in gameObjects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closest = obj;
            }
        }

        return closest;
    }
}
