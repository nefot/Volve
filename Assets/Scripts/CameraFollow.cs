using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    public Transform target;
    void Start()
    {
        offset = transform.position - target.position;
    }
    void Update()
    {
        transform.position = target.position + offset;
    }
}
