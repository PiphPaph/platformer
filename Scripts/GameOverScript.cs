using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public float spacingTextChangeSpeed = 9f;
    public Button restartGameButton;
    public Button closeGame;
    public Character playerCharacter;
    
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartGameButton.gameObject.SetActive(false);
        closeGame.gameObject.SetActive(false);
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartGameButton.gameObject.SetActive(true);
        closeGame.gameObject.SetActive(true);
    }
    
    void Update()
    {
        if (playerCharacter.currentHp <= 0)
        {
            GameOver();
        }
        gameOverText.characterSpacing = Mathf.PingPong(Time.time * spacingTextChangeSpeed, 10f);
    }
}
