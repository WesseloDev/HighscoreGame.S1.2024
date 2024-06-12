using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGui : MonoBehaviour
{
    private Text timerText;
    [SerializeField] private string timerPrefix = "Time Left:\n";

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        if (GameManager.gameOver) return;

        timerText.text = timerPrefix + Mathf.FloorToInt(GameManager.timer).ToString();
    }
}
