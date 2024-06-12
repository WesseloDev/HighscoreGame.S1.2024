using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreInWorld : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private int currentItemsInWorld = 0;

    private int currentScoreInWorld = 0;

    private List<IScoreable> scoreables = new List<IScoreable>();

    [SerializeField] private Text display;
    [SerializeField] private string textPrefix = "Total Score in World:\n";


    void Update()
    {
        if (currentItemsInWorld != parent.childCount)
        {
            GetTotalScore();
        }
    }

    void GetTotalScore()
    {
        currentItemsInWorld = 0;
        currentScoreInWorld = 0;
        scoreables.Clear();


        foreach (Transform child in parent)
        {
            currentItemsInWorld++;

            MonoBehaviour[] scripts = child.GetComponentsInChildren<MonoBehaviour>();

            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is IScoreable)
                {
                    scoreables.Add(scripts[i] as IScoreable);
                }
            }
        }

        foreach (IScoreable scoreable in scoreables)
        {
            currentScoreInWorld += scoreable.Value;
        }

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        display.text = textPrefix + currentScoreInWorld.ToString();
    }
}
