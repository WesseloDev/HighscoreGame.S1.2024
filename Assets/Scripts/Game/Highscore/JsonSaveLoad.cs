using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;

public static class JsonSaveLoad
{
    private static string path = Application.dataPath + "/highscores.json";

    public static void Save(HighscoreData data)
    {
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    public static HighscoreData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<HighscoreData>(json);
        }

        return null;
    }
}
