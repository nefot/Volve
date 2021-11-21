using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public int number_scene = 2;
   public void PlayGame(int number_scene1)
    {
        number_scene1 = number_scene;
        SceneManager.LoadScene(number_scene1);
    }
}
