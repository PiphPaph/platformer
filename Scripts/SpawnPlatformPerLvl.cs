using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformPerLvl : MonoBehaviour
{
    public GameObject platformPrefab;
    public float minDistance = 1f;
    public  int maxCountPlatformPrefab = 10;
    public  float minimX = -5f;
    public  float maximX = 7f;
    public  float minimY = -1f;
    public  float maximY = 5f;
    private List<GameObject> platforms = new List<GameObject>();

    void Start()
    {
        GenerateChunk(minimX, maximX, minimY, maximY);
    }
    void GenerateChunk(float minX, float maxX, float minY, float maxY)
    {
        for (int i = 0; i < maxCountPlatformPrefab; i++)
        {
            Vector2 spawnPosition;
            bool validPosition;
            do
            {
                spawnPosition = new Vector2(Random.Range(minimX, maximX), Random.Range(minimY, maximY));
                validPosition = true;
                foreach (var platform in platforms)
                {
                    if (Vector2.Distance(spawnPosition, platform.transform.position) < minDistance)
                    {
                        validPosition = false;
                        break;
                    }
                }
            } while (!validPosition);
            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity) as GameObject;
            platforms.Add(newPlatform);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (var platform in platforms)
            {
                Destroy(platform);
            }
            platforms.Clear();
            GenerateChunk(minimX, maximX, minimY, maximY);
        }
    }

    void Update()
    {
        
    }
}
