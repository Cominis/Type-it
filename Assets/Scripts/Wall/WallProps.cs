using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallProps : MonoBehaviour
{
    public static float MinX { get; private set; }
    public static float MaxX { get; private set; }
    public static float MinY { get; private set; }
    public static float MaxY { get; private set; }

    private PolygonCollider2D _wallCollider;
    private void Awake()
    {
        _wallCollider = GetComponent<PolygonCollider2D>();
        SetBoundaries();
    }

    private void SetBoundaries()
    {
        MinX = _wallCollider.bounds.min.x;
        MaxX = _wallCollider.bounds.max.x;
        MinY = _wallCollider.bounds.min.y;
        MaxY = _wallCollider.bounds.max.y;
    }
}
