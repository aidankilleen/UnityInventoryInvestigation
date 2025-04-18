using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    public GameManagerWithInventory gameManager;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    private Animator animator;

    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Optional: Freeze rotation on X and Z so character doesn't fall over
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Get input from keyboard
        moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down
        turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        // Set Animator parameter
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void FixedUpdate()
    {
        // Handle rotation
        Quaternion turnRotation = Quaternion.Euler(0f, turnInput * rotationSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // Handle movement
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);
        if (other.CompareTag("Inventory"))
        {
            string itemName = other.gameObject.name;
            gameManager.AddItem(itemName);
            Destroy(other.gameObject); // Remove the item from the scene
        }

        if (other.CompareTag("portal"))
        {
            // check if we have apple and cake in inventory.

            if (gameManager.HasItem("apple") && gameManager.HasItem("cake"))
            {
                Destroy(other.gameObject);
                // load next scene
                Debug.Log("Loading next scene...");
                gameManager.ActivateTrigger("portal");
                // Load the next scene here
            }
            else
            {
                Debug.Log("You need an apple and a cake to enter the portal.");
            }
        }
        if (other.CompareTag("Finish"))
        {
            Destroy(other.gameObject);
            Debug.Log("Finished");
        }
    }


    private IEnumerator ReloadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sawblade"))
        {
            // Handle collision with obstacle
            Debug.Log("Collided with: " + collision.gameObject.name);
            // You can add more logic here, like playing a sound or animation

            //StartCoroutine(ReloadSceneAfterDelay());

            rb.AddExplosionForce(50f, collision.transform.position, 10f, 2f, ForceMode.Impulse);
           
        }


        if (collision.gameObject.CompareTag("portal"))
        {
            // Handle collision with obstacle
            Debug.Log("Collided with: " + collision.gameObject.name);
            // You can add more logic here, like playing a sound or animation
            if (gameManager.HasItem("apple") && gameManager.HasItem("cake"))
            {
                Destroy(collision.gameObject);
                // load next scene
                Debug.Log("Loading next scene...");
                gameManager.ActivateTrigger("portal");
                // Load the next scene here
            }
            else
            {
                Debug.Log("You need an apple and a cake to enter the portal.");
            }
        }

    }
}
