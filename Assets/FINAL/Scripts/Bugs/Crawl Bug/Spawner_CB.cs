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
        spawnRate = 8;
        spawnX = Random.Range(-6, 6);
        spawnPos = new Vector3(spawnX, 0.08f, -5.5f);
        Instantiate(crawlBug, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        if (timeLeftScript.timeLeft > 0)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
        if (timeSinceLastSpawn > spawnRate)
        {
            spawnX = Random.Range(-6, 6);
            spawnPos = new Vector3(spawnX, 0.08f, -5.5f);

            Instantiate(crawlBug, spawnPos, Quaternion.identity);

            timeSinceLastSpawn = 0;
        }

        if (timeLeftScript.timeLeft <= timeLeftScript.startTime / 2)
        {
            spawnRate = 3;
        }
    }
}
