using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        PlayerDB.maxScore = MathF.Round(Meters.xPos - Meters.offset);
        var Coins = Convert.ToInt32(GameObject.FindWithTag("Coins").GetComponent<Text>().text);
        PlayerDB.coins = Coins;
        SavePlayerData.Save();
        
    }
}
