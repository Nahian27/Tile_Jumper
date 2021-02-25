using UnityEngine;

public class BlocksManager : MonoBehaviour
{
    public GameObject[] BlockPrefabs;
    public Transform CubeTransform;
    private float BlockLenth = 10, ySpawn = 10;

    void Start()
    {

    }

    void Update()
    {
        if (CubeTransform.position.y > ySpawn - BlockLenth)
        {
            SpawnBlocks(Random.Range(0, BlockPrefabs.Length));
        }
    }

    public void SpawnBlocks(int blockIndex)
    {
        Instantiate(BlockPrefabs[blockIndex], transform.up * ySpawn, transform.rotation);
        ySpawn += BlockLenth;
    }
}
