using UnityEngine;

public class BooleanGridRuntimeRenderer : MonoBehaviour
{

    public float speed;
    public bool[,] grid = new bool[3, 3]
    {
        { true, false, true },
        { false, true, false },
        { true, false, true }
    };

    public GameObject activePrefab;   // Prefab for active state
    public GameObject inactivePrefab; // Prefab for inactive state
    public float cellSize = 1.0f;

    // Added: scale factor to resize prefabs upon instantiation
    

    private GameObject[,] instantiatedObjects;

    void Start()
    {
        instantiatedObjects = new GameObject[3, 3];

        Vector3 origin = transform.position;

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                GameObject prefab = grid[x, y] ? activePrefab : inactivePrefab;
                Vector3 pos = origin + new Vector3(x * cellSize, y * cellSize, 0);

                instantiatedObjects[x, y] = Instantiate(prefab, pos, Quaternion.identity, transform);

                // Apply the desired 2D scale here:
                instantiatedObjects[x, y].transform.localScale = new Vector3(cellSize, cellSize, cellSize);
            }
        }
    }

    public void UpdateGridRendering()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                GameObject prefab = grid[x, y] ? activePrefab : inactivePrefab;

                if (instantiatedObjects[x, y])
                    Destroy(instantiatedObjects[x, y]);

                Vector3 pos = transform.position + new Vector3(x * cellSize, y * cellSize, 0);
                instantiatedObjects[x, y] = Instantiate(prefab, pos, Quaternion.identity, transform);

                // Apply scale again when updating grid:
                instantiatedObjects[x, y].transform.localScale = new Vector3(cellSize, cellSize, cellSize);
            }
        }
    }


    public void FillObject()
    {
        grid = new bool[3, 3]
        {
            { true, true, true },
            { true, true, true },
            { true, true, true },
        };
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("INFILL"))
        {
            FillObject();
            UpdateGridRendering();
        }
    }
    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
