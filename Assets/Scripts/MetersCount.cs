using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MetersCount : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Text text;
    public float offset { get; private set; }
    public float xPos { get; private set; }
    void Start()
    {
        text = GetComponent<Text>();
        MetersInit();
    }
    void Update()
    {
        if(xPos < target.position.x)
        {
            xPos = target.position.x;
            text.text = Math.Round(xPos - offset).ToString() + " m";
        }
    }
    public void MetersInit()
    {
        xPos = target.position.x;
        offset = target.position.x;
        text.text = Math.Round(xPos - offset).ToString() + " m";
    }
}
