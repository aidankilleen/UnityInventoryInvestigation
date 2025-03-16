using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierLineRnderer : MonoBehaviour
{
    public Transform pointA, pointB, pointC, pointD; // Control points
    public int curveResolution = 20; // Number of points along the curve

    void OnDrawGizmos()
    {
        if (pointA == null || pointB == null || pointC == null || pointD == null) return;

        Vector3 prevPoint = pointA.position;
        for (int i = 1; i <= curveResolution; i++)
        {
            float t = i / (float)curveResolution;
            Vector3 nextPoint = BezierCurve(pointA.position, pointB.position, pointC.position, pointD.position, t);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(prevPoint, nextPoint);
            prevPoint = nextPoint;
        }
    }

    Vector3 BezierCurve(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        float u = 1 - t;
        float uu = u * u;
        float uuu = uu * u;
        float tt = t * t;
        float ttt = tt * t;

        return (uuu * a) + (3 * uu * t * b) + (3 * u * tt * c) + (ttt * d);
    }
}
