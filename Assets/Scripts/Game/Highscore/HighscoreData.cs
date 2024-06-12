using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreData
{
    public int[] scores;
    public string[] names;
    
    public HighscoreData()
    {
        scores = new int[] {102000, 85900, 38400};
        names = new string[] { "Andrew", "Andy", "Aeon" };
    }

    public HighscoreData(int[] scores, string[] names)
    {
        this.scores = scores;
        this.names = names;
    }
}
