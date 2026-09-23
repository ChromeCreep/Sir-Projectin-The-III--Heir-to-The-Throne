using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn();
            timer = 0f;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPos = GetSpawnOutsideCamera();
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    private Vector3 GetSpawnOutsideCamera()
    {
        // Analyze later.
        var cam = Camera.main;

        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        Vector3 camPos = cam.transform.position;

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: // Left
                return new Vector3(camPos.x - width - 1f, camPos.y + Random.Range(-height, height), 0);

            case 1: // Right
                return new Vector3(camPos.x + width + 1f, camPos.y + Random.Range(-height, height), 0);

            case 2: // Bottom
                return new Vector3(camPos.x + Random.Range(-width, width), camPos.y - height - 1f, 0);

            default: // Top
                return new Vector3(camPos.x + Random.Range(-width, width), camPos.y + height + 1f, 0);
        }
    }
}
