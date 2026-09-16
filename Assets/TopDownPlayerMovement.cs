using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{

    //Variables important to the player moving.
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    private float originalSpeed;
    [SerializeField] private float slowedSpeed;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalSpeed = moveSpeed;
    }

    // Update is called once per frame
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

 
}
