using System.Collections;
using UnityEngine;

public class DuoWallSpawn : MonoBehaviour
{
    public GameObject wallPrefab1; // First wall prefab
    public GameObject wallPrefab2; // Second wall prefab
    public Transform spawnPoint; // Spawn location

    public float initialSpawnDelay = 2f; // Initial delay between spawns
    public float minSpawnDelay = 0.1f; // Minimum delay between spawns
    public float difficultyIncreaseRate = 0.9f; // Rate at which delay decreases
    [SerializeField]
    private float currentSpawnDelay;

    [SerializeField]
    private float spdIncreaseFreq = 1.0f;

    private bool gameStarted = false;
    private bool canSpace = true;

    public GameObject startText;

    public TimerUP timerUP;

    void Start()
    {
        timerUP = FindAnyObjectByType<TimerUP>();
    }

    private void Update()
    {
        if (canSpace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
                timerUP.isRunning = true;
            }
        }
        if (gameStarted)
        {
            currentSpawnDelay = initialSpawnDelay;
            SpawnWall();
            StartCoroutine(SpawnWalls());
            StartCoroutine(Quicker());
            gameStarted = false;
            canSpace = false;
            startText.SetActive(false);
        }

    }

    IEnumerator SpawnWalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnDelay);
            SpawnWall();

            // Gradually decrease the spawn delay
            
        }
    }

    IEnumerator Quicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(spdIncreaseFreq);
            if (currentSpawnDelay > minSpawnDelay)
            {
                currentSpawnDelay *= difficultyIncreaseRate;
            }
        }
        
    }

    void SpawnWall()
    {
        GameObject wallToSpawn = Random.value < 0.5f ? wallPrefab1 : wallPrefab2;
        Instantiate(wallToSpawn, spawnPoint.position, Quaternion.identity);
    }
}