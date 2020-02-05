using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject FollowObject;
    private PolygonCollider2D _wallCollider;
    private Vector3 _velocity;
    private float _offsetZ;
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    void Awake()
    {
        _wallCollider = GameObject.FindGameObjectWithTag(Tags.WALL).GetComponent<PolygonCollider2D>();
        _offsetZ = transform.position.z;
        _velocity = Vector3.zero;

        var camera = Camera.main;
        var width = camera.orthographicSize;
        var length = width * camera.aspect;

        _minX = _wallCollider.bounds.min.x + length;
        _maxX = _wallCollider.bounds.max.x - length;
        _minY = _wallCollider.bounds.min.y + width;
        _maxY = _wallCollider.bounds.max.y - width;
    }

    void Update()
    {
        Vector3 v3 = FollowObject.transform.position;
        transform.position = new Vector3(v3.x, v3.y, -1);
        //float x = target.x;
        //float y = target.y;

        //if (x < _minX)
        //    x = _minX;
        //else if( x > _maxX)
        //    x = _maxX;

        //if (y < _minY)
        //    y = _minY;
        //else if (y > _maxY)
        //    y = _maxY;

        //target = new Vector3(x, y, _offsetZ);

        //transform.position = Vector3.SmoothDamp(
        //    transform.position,
        //    target,
        //    ref _velocity,
        //    0.01f,
        //    8f);
    }
}
