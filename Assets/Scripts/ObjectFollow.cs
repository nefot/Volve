using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public enum FollowMode
    { 
        Offset,
        Wall,
        Hard
    }
    public FollowMode followMode;
    public Transform target;
    public Vector3 offset { get; private set; }
    private delegate void Follow();
    private Follow follow;
    void Start()
    {
        offset = target.position - transform.position;
        switch (followMode)
        {
            case FollowMode.Offset:
                follow = () => { transform.position = target.position - offset; };
                break;
            case FollowMode.Wall:
                follow = () =>
                {
                    if (transform.position.x < target.position.x - offset.x)
                    {
                        transform.position = target.position - offset;
                    }
                };
                break;
            case FollowMode.Hard:
                follow = () => { transform.position = target.position; };
                break;
            default:
                throw new System.Exception("Follow mode not specified");
        }
    }
    void LateUpdate()
    {
        follow();
    }
}
