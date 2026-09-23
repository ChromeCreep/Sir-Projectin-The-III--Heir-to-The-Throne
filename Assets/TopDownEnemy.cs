using UnityEngine;

public class TopDownEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed;

    private Transform enemyPosition;
    private Transform playerPosition;

    private float distance;
    

    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, playerPosition.position, moveSpeed * Time.deltaTime); 
    }

    private void OnDestroy()
    {
        if (KillCounter.instance != null)
        {
            KillCounter.instance.AddKill();
        }
    }
}
