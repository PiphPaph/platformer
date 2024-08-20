using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Button restartGameButton;
    public void RestartGameButton()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
}
