using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject normalCloudEnemy;

    [SerializeField]
    private GameObject bossCloudEnemy;

    [SerializeField]
    private Transform spawnPointMaximum;
    [SerializeField]
    private Transform spawnPointMinimum;

    [SerializeField]
    private float timeBetweenWaves;
    private float timeUntilNextWave;

    [SerializeField]
    private int numberOfEnemiesToSpawn;

    [SerializeField]
    private int wavesBetweenBoss;

    private int bossCountDown;


    public void FixedUpdate()
    {
        timeUntilNextWave -= Time.deltaTime;

        if (timeUntilNextWave <= 0f)
        {
        if (bossCountDown == wavesBetweenBoss)
        {
            bossCountDown = 0;
            timeUntilNextWave = timeBetweenWaves;
            
            Instantiate(bossCloudEnemy, new Vector3(Random.Range(spawnPointMinimum.position.x, spawnPointMaximum.position.x),Random.Range(spawnPointMinimum.position.y, spawnPointMaximum.position.y), 0), bossCloudEnemy.transform.rotation);
        }
        else
        {
        for (int iterator = 0; iterator <= numberOfEnemiesToSpawn; iterator++)
        {
        Instantiate(normalCloudEnemy, new Vector3(Random.Range(spawnPointMinimum.position.x, spawnPointMaximum.position.x),Random.Range(spawnPointMinimum.position.y, spawnPointMaximum.position.y), 0), normalCloudEnemy.transform.rotation);
        }
        bossCountDown++;
        timeUntilNextWave = timeBetweenWaves;
        }
        }
    }

}
