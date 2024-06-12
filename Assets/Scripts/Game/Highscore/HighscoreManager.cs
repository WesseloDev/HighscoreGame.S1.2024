using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    [SerializeField] private GameObject highscorePrefab;
    [SerializeField] private GameObject highscoreParent;

    private List<string> names = new List<string>();
    private List<int> scores = new List<int>();

    void Start()
    {
        LoadScores();
    }

    void OnDestroy()
    {
        SaveScores();
    }

    void SaveScores()
    {
        HighscoreData data = new HighscoreData(scores.ToArray(),names.ToArray());
        JsonSaveLoad.Save(data);
    }

    void LoadScores()
    {
        HighscoreData data = JsonSaveLoad.Load();
        if (data != null)
        {
            names = data.names.ToList();
            scores = data.scores.ToList();
        }
        else
        {
            names = new List<string>();
            scores = new List<int>();
        }

        UpdateHighscoreDisplay();
    }

    public bool AddScore(string name, int newScore)
    {
        for (int i = 0; i < scores.Count; i++)
        {
            int highscore = scores[i];

            if (newScore > highscore)
            {
                scores.Insert(i, newScore);
                names.Insert(i, name);

                UpdateHighscoreDisplay();
                if (i == 0) return true; else return false;
            }
        }

        scores.Add(newScore);
        names.Add(name);

        UpdateHighscoreDisplay();

        return false;
    }

    void UpdateHighscoreDisplay()
    {
        foreach(Transform child in highscoreParent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < scores.Count; i++)
        {
            GameObject prefab = Instantiate(highscorePrefab, highscoreParent.transform);

            HighscoreDisplay display = prefab.GetComponent<HighscoreDisplay>();

            if (display != null)
            {
                display.SetText(names[i], scores[i]);
            }
        }
    }
}
