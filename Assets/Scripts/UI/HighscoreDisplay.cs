using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField] private Text highscoreName;
    [SerializeField] private Text highscoreScore;

    public void SetText()
    {
        highscoreName.text = "Unnamed";
        highscoreScore.text = "0";
    }

    public void SetText(string name, int score)
    {
        highscoreName.text = name;
        highscoreScore.text = score.ToString();
    }
}
