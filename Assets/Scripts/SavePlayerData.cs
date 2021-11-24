using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[Serializable]
public struct Upgrades
{
    int engine;
    int suspension;
    int brake;
    public override string ToString()
    {
        return engine.ToString() + " " + suspension.ToString() + " " + brake.ToString();
    }
}

[Serializable]
public class PlayerDB
{
    public float maxScore;
    public int coins;
    public Upgrades upgrades = new Upgrades();
}
public class SavePlayerData : MonoBehaviour
{
    public static PlayerDB playerDB;
    private static string path;
    private void Awake()
    {
        path = Application.streamingAssetsPath + @"/playerDB.json";

        if (!File.Exists(path))
        {
            File.Create(path);
        }
        var jsonString = File.ReadAllText(path);
        playerDB = JsonUtility.FromJson<PlayerDB>(jsonString) ?? new PlayerDB();
    }
    public static void Save()
    {
        string jsonString = JsonUtility.ToJson(playerDB);
        Debug.Log(JsonUtility.ToJson(playerDB));
        Debug.Log(path);
        using (FileStream fs = File.OpenWrite(path))
        {
            Byte[] info = new UTF8Encoding(true).GetBytes(jsonString);
            fs.Write(info, 0, info.Length);
        }
    }
}