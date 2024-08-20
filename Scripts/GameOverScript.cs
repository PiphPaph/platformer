using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public float spacingChangeSpeed = 9f;
    public Button restartGameButton;
    public Character playerCharacter;
    
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartGameButton.gameObject.SetActive(false);
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartGameButton.gameObject.SetActive(true);
    }
    
    void Update()
    {
        if (playerCharacter.currentHp <= 0)
        {
            GameOver();
        }
        gameOverText.characterSpacing = Mathf.PingPong(Time.time * spacingChangeSpeed, 10f);
    }
}
