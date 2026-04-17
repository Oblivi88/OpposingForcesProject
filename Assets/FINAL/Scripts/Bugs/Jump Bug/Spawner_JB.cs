using UnityEngine;

public class Spawner_JB : MonoBehaviour
{
    private float timeSinceLastSpawn;
    private float spawnRate;
    public GameObject jumpBug;
    public TimeLeft timeLeftScript;
    private Vector3 spawnPos;
    private float spawnZ;
    void Start()
    {
        spawnRate = 5;
        spawnZ = Random.Range(-6, 0);
        spawnPos = new Vector3(-4.61f, 20.18f, spawnZ);
        Instantiate(jumpBug, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        if (timeLeftScript.timeLeft > 0)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
        if (timeSinceLastSpawn > spawnRate)
        {
            spawnZ = Random.Range(-6, 0);
            spawnPos = new Vector3(-4.61f, 20.18f, spawnZ);

            Instantiate(jumpBug, spawnPos, Quaternion.identity);

            timeSinceLastSpawn = 0;
        }
    }
}
