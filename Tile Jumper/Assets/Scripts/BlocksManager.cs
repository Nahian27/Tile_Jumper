using UnityEngine;

public class BlocksManager : MonoBehaviour
{
    public GameObject[] BlockPrefabs;
    public Transform CubeTransform;
    private float BlockPrefabLenth = 10, ySpawn = 10;

    void Start()
    {

    }

    void Update()
    {
        if (CubeTransform.position.y > ySpawn - BlockPrefabLenth)
        {
            SpawnBlocks(Random.Range(0, BlockPrefabs.Length));
        }
    }

    public void SpawnBlocks(int BlockPrefabIndex)
    {
        Instantiate(BlockPrefabs[BlockPrefabIndex], transform.up * ySpawn, transform.rotation);
        ySpawn += BlockPrefabLenth;
    }
}
