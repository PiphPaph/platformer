using UnityEngine;

public class SpawnFireballs : MonoBehaviour
{
    public GameObject redFireball;
    public int maxFireballCount = 1;
    public double timeSpawn;
    private double _timer;
    public  float minY = -4f;
    public  float maxY = 4f;
    public float minDistance = 1f;
    public Vector2 spawnPosition;
    private float _spawnPositionX = 20f;
    public int destroyFireballTime = 7;
    private FireballWarning _fireballSpawned;
    public GameObject destroyFireball;

    private void Start()
    {
        _timer = timeSpawn;
        _fireballSpawned = GetComponent<FireballWarning>();
    }
    private void FireballSpawn(float minY, float maxY)
    {
        
        for (var i = 0; i < maxFireballCount; i++)
        {
            bool validPosition;
            do
            {
                spawnPosition = new Vector2(_spawnPositionX, Random.Range(minY, maxY));
                validPosition = true;
                    if (Vector2.Distance(spawnPosition, redFireball.transform.position) < minDistance)
                    {
                        validPosition = false;
                        break;
                    }
            } while (!validPosition);
            destroyFireball = Instantiate(redFireball, spawnPosition, Quaternion.identity);
            Destroy(destroyFireball, destroyFireballTime);
        }
        _fireballSpawned.SpawnWarning();
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = timeSpawn;
            FireballSpawn(minY, maxY);
        }
    }
}