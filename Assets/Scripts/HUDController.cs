using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private GameObject player1;
    public Transform arrow;
    public CarMoving scr;
   
    void Start()
    {   
       player1 = GameObject.FindGameObjectWithTag("Player");
       scr= player1.GetComponent<CarMoving>();
    }
    void Update()
    {
        arrow.rotation = Quaternion.Euler(arrow.rotation.x, arrow.rotation.y, ConvertRange(-255,((int)(scr.speed)),0,255,1));
        
        static int ConvertRange(int originalStart, int originalEnd, int newStart, int newEnd, int value) // value to convert
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (int)(newStart + ((value - originalStart) * scale));
        }
    }
}
