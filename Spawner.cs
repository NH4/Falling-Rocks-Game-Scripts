using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fallingBlockPrefab;
    public float timeBetweenSpawn = 1;
    float nextSpawnTime;
    public float randomScale;
    Vector2 screenHalfSize;
    FallingBlocks newBlock;
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawn;
            if (timeBetweenSpawn > 0.6f)
            {
                //timeBetweenSpawn -= 0.01f; //difficulty icnreases over time
            }
            randomScale = Random.Range(0.2f, 1.5f); // Used for scalign the block after it spawns in blocks.transform.localScale
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), (screenHalfSize.y + (randomScale)));
            GameObject newBlock = Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(0, 0, Random.Range(-15, 15)));
            newBlock.transform.localScale =  Vector3.one * randomScale; //Changes the block size to the previously generated randomScale
     
        }
    }
}
