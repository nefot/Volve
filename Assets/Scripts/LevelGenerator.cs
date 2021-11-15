using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LevelGenerator : MonoBehaviour
{
    private Spline spline;
    public Vector3 NewPointPosition { get; private set; }
    public static int CurrentPointIndex { get; private set; }
    public Transform target;
    public int levelHeight;
    public float levelWidth;
    public float xRange;
    public float yRange;
    public float tangentRange;
    public SpriteShapeController spriteShapeController;
    void Awake()
    {
        spline = spriteShapeController.spline;
        NewPointPosition = spline.GetPosition(1);
        CurrentPointIndex = 2;
    }

    void Start()
    {
        
    }
    public void Generate()
    {
        NewPointPosition = new Vector3
            (
                Random.Range(NewPointPosition.x + xRange / 2, NewPointPosition.x + xRange),
                Mathf.Clamp(Random.Range(NewPointPosition.y - yRange, NewPointPosition.y + yRange), -levelHeight / 2, levelHeight / 2),
                NewPointPosition.z
            );

        spline.InsertPointAt(CurrentPointIndex, NewPointPosition);

        float tengentDeltaY = Random.Range(0, tangentRange);

        Vector3 leftTangent = new Vector3
            (
            Random.Range(-tangentRange, 0),
            tengentDeltaY,
            NewPointPosition.z
            );

        Vector3 rightTangent = new Vector3
            (
            Random.Range(0, tangentRange),
            -tengentDeltaY,
            NewPointPosition.z
            );

        spline.SetTangentMode(CurrentPointIndex, ShapeTangentMode.Continuous);
        spline.SetLeftTangent(CurrentPointIndex, leftTangent);
        spline.SetRightTangent(CurrentPointIndex, rightTangent);

        CurrentPointIndex++;

        int lastPointIndex = spline.GetPointCount() - 1;

        spline.SetPosition
            (
            lastPointIndex - 1, 
            new Vector3
            (
                NewPointPosition.x + levelWidth, 
                spline.GetPosition(lastPointIndex - 1).y,
                spline.GetPosition(lastPointIndex - 1).z
                )
            );

        spline.SetPosition
            (
            lastPointIndex, 
            new Vector3
            (
                NewPointPosition.x + levelWidth,
                spline.GetPosition(lastPointIndex).y,
                spline.GetPosition(lastPointIndex).z
                )
            );
    }
    void FixedUpdate()
    {
        if(target.position.x >= NewPointPosition.x - levelWidth)
        {
            Generate();
        }
    }
}
