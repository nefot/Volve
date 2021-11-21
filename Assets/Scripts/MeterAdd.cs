using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MeterAdd : MonoBehaviour
{
    [SerializeField]
    private Text meters;
    public int current;
    float lastXVal;

    void Start()
    {
        lastXVal = transform.position.x;
    }

  
    void Update()
    { 
        if (transform.position.x > lastXVal)
        {
            meters.text = ((((int)Mathf.Abs(current + lastXVal)).ToString())+" m");
            lastXVal = transform.position.x;
        }
    }
}
