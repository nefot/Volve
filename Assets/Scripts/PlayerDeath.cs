using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(SavePlayerData))]
public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }
    public void Death()
    {
        PlayerDataToDB();
        SceneManager.LoadScene(0);
    }
    public void PlayerDataToDB()
    {
        var Meters = GameObject.FindWithTag("Meters").GetComponent<MetersCount>();
        var maxScore = SavePlayerData.playerDB.maxScore;
        var score = Meters.xPos - Meters.offset;
        if (maxScore < score)
        {
            SavePlayerData.playerDB.maxScore = MathF.Round(Meters.xPos - Meters.offset);
        }
        
        var Coins = Convert.ToInt32(GameObject.FindWithTag("Coins").GetComponent<Text>().text);
        SavePlayerData.playerDB.coins += Coins;
        SavePlayerData.Save();
    }
}
