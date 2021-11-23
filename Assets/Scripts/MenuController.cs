using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuController : MonoBehaviour
{
    public int number_scene = 2;
    public void PlayGame()
    {
        SceneManager.LoadScene(number_scene);
    }
    public void SelectScene(int num)
    {
        number_scene = num;
    }
}
