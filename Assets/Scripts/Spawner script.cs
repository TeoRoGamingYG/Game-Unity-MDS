using UnityEngine;

public class Spawnerscript : MonoBehaviour
{
    public GameObject squarePrefab;
    public Transform spawnPoint;
    public float spawnInterval;
    private float nextSpawnTime;
    public ConveyorBelt conveyorBelt;
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            GameObject spawnObject = Instantiate(squarePrefab, spawnPoint.position, spawnPoint.rotation);
            if(conveyorBelt != null)
            {
                conveyorBelt.AddItem(spawnObject.transform);
            }
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}