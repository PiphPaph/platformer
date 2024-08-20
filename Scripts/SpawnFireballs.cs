using UnityEngine;

public class spawnNormalPlatform : MonoBehaviour
{
    public GameObject RedFireball;
    public int maxFireballCount = 1;
    public double timeSpawn;
    private double timer;
    public  float minY = -4f;
    public  float maxY = 4f;
    public float minDistance = 1f;

    void Start()
    {
        timer = timeSpawn;
        GenerateChunk(minY, maxY);
    }
    void GenerateChunk(float minY, float maxY)
    {
        
        for (int i = 0; i < maxFireballCount; i++)
        {
            Vector2 spawnPosition;
            bool validPosition;
            do
            {
                spawnPosition = new Vector2(12f, Random.Range(minY, maxY));
                validPosition = true;
                    if (Vector2.Distance(spawnPosition, RedFireball.transform.position) < minDistance)
                    {
                        validPosition = false;
                        break;
                    }
            } while (!validPosition);
            GameObject destroyFireball = Instantiate(RedFireball, spawnPosition, Quaternion.identity);
            Destroy(destroyFireball, 7f);
        }
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            GenerateChunk(minY, maxY);
        }
    }
}