using UnityEngine;

public class Spawnerscript : MonoBehaviour
{
    public GameObject squarePrefab;
    public Transform spawnPoint;
    public float spawnInterval;
    private float nextSpawnTime;
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            Instantiate(squarePrefab, spawnPoint.position, spawnPoint.rotation);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}