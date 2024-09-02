using UnityEngine;

public class HealPotionSpawn : MonoBehaviour
{
    private SpawnPlatformPerLvl _spawnPlatform;
    public GameObject healPotionPrefab;
    public Vector2 spawnHealPotionPosition;
    private float _spawnHealPotionY = 2;
    private SpawnPlatformPerLvl _spawnPlatformPosition;
    public GameObject destroyHealPotion;
    
    void Start()
    {
        _spawnPlatformPosition = FindObjectOfType<SpawnPlatformPerLvl>();
    }

    public void SpawnHealPotion()
    {
            spawnHealPotionPosition = new Vector2(_spawnPlatformPosition.platformPosition.transform.position.x, _spawnPlatformPosition.platformPosition.transform.position.y + _spawnHealPotionY);
            destroyHealPotion = Instantiate(healPotionPrefab, spawnHealPotionPosition, Quaternion.identity);
    }
}
