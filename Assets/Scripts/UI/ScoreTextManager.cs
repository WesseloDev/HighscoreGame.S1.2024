using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject scorePopupPrefab;
    [SerializeField] private GameObject scoreParent;
    [SerializeField] private string scorePrefix = "Score: ";
    [SerializeField] private string scorePopupPrefix = "          +";

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = scorePrefix + newScore.ToString();
    }

    public void SpawnScorePopup(int popupValue)
    {
        GameObject popup = Instantiate<GameObject>(scorePopupPrefab, scoreParent.transform);
        popup.transform.SetParent(scoreParent.transform);

        popup.GetComponent<Text>().text = scorePopupPrefix + popupValue.ToString();
        popup.GetComponent<ScorePopup>().enabled = true;
    }
}
