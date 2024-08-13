using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformPerLvl : MonoBehaviour
{
    public GameObject platformPrefab;
    public int maxCountPlatformPrefab = 10;
    public double timeSpawn;
    private double timer;

    private float minimX = -2f;
    private float maximX = 4f;

    void Start()
    {
        //timer = timeSpawn;
        GenerateChunk(minimX, maximX);
    }
    void GenerateChunk(float minX, float maxX)
    {
        //var posY = GameObject.FindGameObjectWithTag("tiger").transform.position;
        Vector2 spawnPosition = new Vector2(0f, 0f);

        for (int i = 0; i < maxCountPlatformPrefab; i++)
        {
            spawnPosition.x = Random.Range(minimX, maximX);
            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity) as GameObject;
            
        }
    }
    // GameObject destroyPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity) as GameObject;
    // Destroy(destroyPlatform, 7f);

    void Update()
    {
        // timer -= Time.deltaTime;
        // if (timer <= 0) 
        // {
        //     timer = timeSpawn;
        //     GenerateChunk(minimX, maximX);
        // }
            
    }
}
