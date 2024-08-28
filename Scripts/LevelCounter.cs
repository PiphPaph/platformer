using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    public int lvlCounter = 1;
    public Text lvlCounterText;

    void Start()
    {
        lvlCounterText.text = "Level: " + lvlCounter.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lvlCounter++;
            lvlCounterText.text = "Level: " + lvlCounter.ToString();
        }
    }
}
