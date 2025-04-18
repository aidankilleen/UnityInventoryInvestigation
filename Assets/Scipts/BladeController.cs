using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BladeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 360f;
    public float moveSpeed = 2f;
    public Transform pointA;
    public Transform pointB;

    public Vector3 target;

    void Start()
    {
        target = pointB.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.25f)
        {
            // Swap the target
            target = target == pointA.position ? pointB.position : pointA.position;
        }

    }
}
