using System;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject block;

    [SerializeField] public GameObject pickup;

    Vector3 currentPos;

    float size; // of single block

    void Start()
    {
        currentPos = block.transform.position;
        size = block.transform.localScale.x;
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnBlocks", 1.0f, .2f);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnBlocks");
    }

    void SpawnBlocks()
    {
        int rand = UnityEngine.Random.Range(0, 6);
        spawn(Convert.ToInt32(rand % 2 == 0));
    }

    void spawn(int val) // 0, 1
    {
        Vector3 nextPos = currentPos;

        nextPos.x += size * val;
        nextPos.z += size * (1 - val);

        currentPos = nextPos;

        Instantiate(block, nextPos, Quaternion.identity);

        // add a pickup as well
        if (UnityEngine.Random.Range(0, 10) % 3 == 0)
        {
            Vector3 newDiamondPos = nextPos + new Vector3(0, 1.2f, 0);
            Instantiate(pickup, newDiamondPos, pickup.transform.rotation);
        }
    }
}