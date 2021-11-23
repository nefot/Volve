using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[System.Serializable]
public struct Upgrades
{
    int engine { get; set; }
    int suspension { get; set; }
    int brake { get; set; }
    public override string ToString()
    {
        return engine.ToString() + " " + suspension.ToString() + " " + brake.ToString();
    }
}

[System.Serializable]
public class PlayerDB
{
    public static float maxScore { get; set; }
    public static int coins { get; set; }
    public static Upgrades upgrades;
}
public class SavePlayerData : MonoBehaviour
{
    public static PlayerDB playerDB;
    private static string path = Application.streamingAssetsPath + @"/playerDB.json";
    private void Awake()
    {
        string jsonString;

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        jsonString = File.ReadAllText(path);
        playerDB = JsonUtility.FromJson<PlayerDB>(jsonString);
    }
    public static void Save()
    {
        var jsonString = JsonUtility.ToJson(playerDB);
        Debug.Log(jsonString);
        Debug.Log(path);
        using (FileStream fs = File.OpenWrite(path))
        {
            Byte[] info = new UTF8Encoding(true).GetBytes(jsonString);
            fs.Write(info, 0, info.Length);
        }
    }
}