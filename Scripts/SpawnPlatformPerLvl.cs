using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatformPerLvl : MonoBehaviour
{
    public GameObject platformPrefab;
    public float minDistance = 4f;
    public int maxCountPlatformPrefab = 10;
    public float minimX = -5f;
    public float maximX = 7f;
    private float _minimY = -3f;
    private float _maximY = 2.5f;
    private SpawnFireballs _spawnFireballs;
    public List<GameObject> platforms;
    public Vector2 spawnPosition;
    private LevelCounter _levelCounter;
    private HealPotionSpawn _potionSpawn;
    public GameObject platformPosition;

    void Start()
    {
        SpawnPlatforms(minimX, maximX, _minimY, _maximY);
        _spawnFireballs = FindObjectOfType<SpawnFireballs>();
        _potionSpawn = FindObjectOfType<HealPotionSpawn>();
        _levelCounter = FindObjectOfType<LevelCounter>();
        platformPosition = GetRandomPlatform();
    }
    void SpawnPlatforms(float minX, float maxX, float minY, float maxY)
    {
        for (int i = 0; i < maxCountPlatformPrefab; i++)
        {
            bool validPosition;
            do
            {
                spawnPosition = new Vector2(Random.Range(minimX, maximX), Random.Range(_minimY, _maximY));
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
            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platforms.Add(newPlatform);
        }
    }
    GameObject GetRandomPlatform()
    {
        System.Random platform = new System.Random();
        var index = platform.Next(platforms.Count);
        return platforms[index];
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
            SpawnPlatforms(minimX, maximX, _minimY, _maximY);
            Destroy(_spawnFireballs.destroyFireball);
            //Destroy(_potionSpawn.destroyHealPotion);
            if (_levelCounter.lvlCounter >= _levelCounter.lvlForSpawnPotion)
            {
                platformPosition = GetRandomPlatform();
                GetRandomPlatform();
                _potionSpawn.SpawnHealPotion();
            }
        }
    }
}
