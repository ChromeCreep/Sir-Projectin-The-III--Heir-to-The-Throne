using System.Threading;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float shootTimer;
    public float timeBetweenFiring;

    void Start()
    {
        // Grabs the Camera within the scene in order to use it for aiming.
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        // Uses the camera in order to find where the mouse position is.
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        //Rotates the player in the direction of the mouse position;
        Vector3 rotation = mousePos - transform.position;

        // Handles the rotation.
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //Shoot Timer
        if (!canFire)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > timeBetweenFiring)
            {
                canFire = true;
                shootTimer = 0;
            }
        }

        //Input to shoot.
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
