using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Chronos;

public class BlocksManager : MonoBehaviour
{
    public GameObject[] BlockPrefabs;
    public Light Cube;
    public Clock clock;
    private float BlockPrefabLenth = 10, ySpawn = 10;

    void Start()
    {

    }

    void Update()
    {
        if (Cube.GetComponent<Transform>().position.y > ySpawn - BlockPrefabLenth)
        {
            SpawnBlocks(Random.Range(0, BlockPrefabs.Length));
        }

        if (Input.GetKeyUp(KeyCode.R) || Input.touchCount > 2)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Rewind();
        }
    }

    public void SpawnBlocks(int BlockPrefabIndex)
    {
        Instantiate(BlockPrefabs[BlockPrefabIndex], transform.up * ySpawn, transform.rotation);
        ySpawn += BlockPrefabLenth;
    }

    public void Rewind()
    {
        StartCoroutine(RewindCR());
    }

    public IEnumerator RewindCR()
    {
        //Cube.enabled = false;
        clock.localTimeScale = -1;

        yield return new WaitForSeconds(3.5f);
        clock.localTimeScale = 1;
    }
}
