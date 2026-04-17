using UnityEngine;

public class Spawner_CB : MonoBehaviour
{
    // Crawl Bug spawner

    // values for spawning
    private float timeSinceLastSpawn;
    private float spawnRate;
    private Vector3 spawnPos;
    private float spawnX;

    // crawl bug prefab
    public GameObject crawlBug;

    // only spawn if there is time left (player has not won or lost)
    public TimeLeft timeLeftScript;

    void Start()
    {
        // at game start, set all values and spawn a Crawl Bug
        // spawns a bug behind the player in a random range of X coords along the floor
        spawnRate = 8;
        spawnX = Random.Range(-6, 6);
        spawnPos = new Vector3(spawnX, 0.08f, -5.5f);
        Instantiate(crawlBug, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        // only increase time if there is time left
        if (timeLeftScript.timeLeft > 0)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
        // spawn a crawl bug at a random x coord every [spawnRate] seconds
        if (timeSinceLastSpawn > spawnRate)
        {
            spawnX = Random.Range(-6, 6);
            spawnPos = new Vector3(spawnX, 0.08f, -5.5f);

            Instantiate(crawlBug, spawnPos, Quaternion.identity);

            timeSinceLastSpawn = 0;
        }
        // half way through the game, speed up the spawnRate
        if (timeLeftScript.timeLeft <= timeLeftScript.startTime / 2)
        {
            spawnRate = 3;
        }
    }
}
