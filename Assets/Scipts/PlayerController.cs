using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 0f;
    public float rotationSpeed = 25.0f;
    public float acceleration = 5.0f;
    public float deceleration = 5.0f;

    private Rigidbody _rb;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;//   (0, 0, speed);

    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);

        if (transform.position.y < -0.5)
        {
            // end the game
            Debug.Log("Game Over");
            //Application.Quit();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += acceleration * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= deceleration * Time.deltaTime;
        }
        else
        {
            speed = Mathf.MoveTowards(speed, 0, deceleration * Time.deltaTime);
        }

    }
    private void FixedUpdate()
    {
        Vector3 velocity = transform.forward * speed;
        _rb.velocity = velocity;

        _animator.SetFloat("Velocity", velocity.magnitude);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            Debug.Log("Triggered");
            other.gameObject.SetActive(false);

            var falseFloor = GameObject.Find("FalseFloor");
            falseFloor.SetActive(false);
        }
        
    }
}
