using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject highscoreIndicator;

    [SerializeField] private string highscorePrefix = "Score: ";

    public void ShowEndScreen(bool isHighscore, int score)
    {
        scoreText.text = highscorePrefix + score.ToString();
        highscoreIndicator.SetActive(isHighscore);
        endScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
