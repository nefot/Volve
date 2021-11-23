using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LevelGenerator : MonoBehaviour
{
    private Spline spline;
    public Vector3 NewPointPosition { get; set; }
    public static int CurrentPointIndex { get; set; }
    public Transform target;
    public int levelHeight;
    public float levelWidth;
    public float xRange;
    public float yRange;
    public float tangentRange;
    public SpriteShapeController spriteShapeController;
    private void Awake()
    {
        spline = spriteShapeController.spline;
        NewPointPosition = spline.GetPosition(1);
        CurrentPointIndex = 2;
    }
    private void Start()
    {
        LevelInit();
    }
    private void FixedUpdate()
    {
        if (target.position.x >= NewPointPosition.x - levelWidth)
        {
            Generate();
            Delete();
        }
    }
    public void LevelInit()
    {
        while (target.position.x >= NewPointPosition.x - levelWidth)
        {
            Generate();
        }
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Generate()
    {
        NewPointPosition = spline.GetPosition(spline.GetPointCount() - 3);
        NewPointPosition = new Vector3
        (
            Random.Range(NewPointPosition.x + xRange / 2, NewPointPosition.x + xRange),
            Mathf.Clamp(Random.Range(NewPointPosition.y - yRange, NewPointPosition.y + yRange), -levelHeight / 2, levelHeight / 2),
            NewPointPosition.z
        );

        InsertNewPoint(CurrentPointIndex);

        CurrentPointIndex++;

        int lastPointIndex = spline.GetPointCount() - 1;
        float NewCornerXPos = NewPointPosition.x + levelWidth;
        MoveCorner(lastPointIndex, NewCornerXPos);
        MoveCorner(lastPointIndex - 1, NewCornerXPos);
    }
    private void Delete()
    {
        float NewCornerX = spline.GetPosition(2).x;
        spline.RemovePointAt(2);
        MoveCorner(0, NewCornerX);
        MoveCorner(1, NewCornerX);
        CurrentPointIndex--;
    }
    private void InsertNewPoint(int PointIndex)
    {
        spline.InsertPointAt(PointIndex, NewPointPosition);

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

        spline.SetTangentMode(PointIndex, ShapeTangentMode.Continuous);
        spline.SetLeftTangent(PointIndex, leftTangent);
        spline.SetRightTangent(PointIndex, rightTangent);

        PointIndex++;
    }
    private void MoveCorner(int CornerIndex, float NewCornerXPos)
    {
        spline.SetPosition
        (
            CornerIndex,
            new Vector3
            (
                NewCornerXPos,
                spline.GetPosition(CornerIndex).y,
                spline.GetPosition(CornerIndex).z
            )
        );
    }
}
