using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("322");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("123");
            lvlCounter++;
            lvlCounterText.text = "Level: " + lvlCounter.ToString();

        }
    }
}
