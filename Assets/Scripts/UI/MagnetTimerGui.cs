using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetTimerGui : MonoBehaviour
{
    [SerializeField] private Magnet magnet;

    private Text timerText;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        if (GameManager.gameOver) return;

        timerText.text = Mathf.FloorToInt(magnet.timer).ToString();
    }
}
