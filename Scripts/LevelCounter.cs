using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    public int lvlCounter = 1;
    public Text lvlCounterText;
    private HealPotionSpawn _potionSpawn;
    public int lvlForSpawnPotion = 5;

    void Start()
    {
        lvlCounterText.text = "Level: " + lvlCounter.ToString();
        _potionSpawn = FindObjectOfType<HealPotionSpawn>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            lvlCounter++;
            lvlCounterText.text = "Level: " + lvlCounter.ToString();
        }
    }
}
