using UnityEngine;

public class Spawner_CB : MonoBehaviour
{
    private float timeSinceLastSpawn;
    private float spawnRate;
    public GameObject crawlBug;
    public TimeLeft timeLeftScript;
    private Vector3 spawnPos;
    private float spawnX;
    void Start()
    {
        spawnRate = 10;
        spawnX = Random.Range(-6, 6);
        spawnPos = new Vector3(spawnX, 0.08f, -5.5f);
        Instantiate(crawlBug, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > spawnRate)
        {
            spawnX = Random.Range(-6, 6);
            timeSinceLastSpawn = 0;
        }
        if (timeSinceLastSpawn == 0)
        {
            Instantiate(crawlBug, spawnPos, Quaternion.identity);
        }

        if (timeLeftScript.timeLeft <= timeLeftScript.startTime / 2)
        {
            spawnRate = 5;
        }
    }
}
