using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{

    //Variables important to the player moving.
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    private float originalSpeed;
    [SerializeField] private float slowedSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalSpeed = moveSpeed;
    }

    void Update()
    {
        //Basic Movement Logic
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(horizontalAxis * moveSpeed, verticalAxis * moveSpeed);
           
        if(horizontalAxis != 0 && verticalAxis != 0)
        {
            moveSpeed = slowedSpeed;
        }
        else
        {
            moveSpeed = originalSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
