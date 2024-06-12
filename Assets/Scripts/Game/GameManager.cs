using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private GameObject interactableHolder;
    private static ScoreTextManager scoreTextManager;
    private HighscoreManager highscoreManager;
    private EndScreenManager endScreenManager;
    public Transform player;

    [SerializeField] private float initialTime;
    public static float timer;

    public static bool gameOver = false;

    void Start()
    {
        scoreTextManager = GetComponent<ScoreTextManager>();
        scoreTextManager.UpdateScoreText(score);
        highscoreManager = GetComponent<HighscoreManager>();
        endScreenManager = GetComponent<EndScreenManager>();

        StartGame();
    }

    void Update()
    {
        if (gameOver) return;

        timer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R) || player.position.y < -5f || timer <= 0f)
        {
            EndGame();
            return;
        }
    }

    void EndGame()
    {
        Debug.Log("Ending game");
        gameOver = true;
        CursorManager.UnlockCursor();
        bool newHighscore = highscoreManager.AddScore(System.Environment.MachineName, score);
        endScreenManager.ShowEndScreen(newHighscore, score);
    }

    public static void AddScore(int amount)
    {
        if (gameOver) return;
        score += amount;
        scoreTextManager.UpdateScoreText(score);
        scoreTextManager.SpawnScorePopup(amount);
        //Debug.Log(score);
    }

    public static void AddTime(float amount)
    {
        if (gameOver) return;
        timer += amount;
    }

    public void StartGame()
    {
        gameOver = false;
        timer = initialTime;
        score = 0;
        CursorManager.LockCursor();
    }
}
