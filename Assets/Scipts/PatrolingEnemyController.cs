using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public class PatrolingEnemyController : MonoBehaviour
{
    public Transform player;
    public SplineContainer splineRoute;

    private List<Vector3> sampledPoints;
    public float sampleSpacing = 1f;
    public float pointReachedThreshold = 0.5f;

    private int currentPointIndex = 0;
    private int direction = 1;


    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        sampledPoints = new List<Vector3>();
        float splineLength = splineRoute.Spline.GetLength();

        for (float t = 0; t <= splineLength; t += sampleSpacing)
        {
            float percent = t / splineLength;   
            var localPosition = splineRoute.Spline.EvaluatePosition(percent);
            var worldPosition = splineRoute.transform.TransformPoint(localPosition);
            sampledPoints.Add(worldPosition);
        }
        if (sampledPoints.Count > 0)
        {
            agent.SetDestination(sampledPoints[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(player.position);
        // no points then do nothing
        if (sampledPoints == null || sampledPoints.Count == 0) 
        {
            return;
        }  

        // check if we reached the current point
        if (!agent.pathPending && agent.remainingDistance <= pointReachedThreshold)
        {
            // start moving to the next point
            currentPointIndex += direction;

            if (currentPointIndex < sampledPoints.Count)
            {
                agent.SetDestination(sampledPoints[currentPointIndex]);
            } else
            {
                agent.isStopped = true;
            }
        }
        
    }
}
