using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject FollowObject;

    private Vector3 _velocity;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    void Start()
    {
        _velocity = Vector3.zero;
        CalculateCameraBoundaries();
    }

    private void CalculateCameraBoundaries()
    {
        _minX = WallProps.MinX + CameraProps.Length;
        _maxX = WallProps.MaxX - CameraProps.Length;
        _minY = WallProps.MinY + CameraProps.Width;
        _maxY = WallProps.MaxY - CameraProps.Width;
    }

    void Update()
    {
        
        Vector3 v3 = FollowObject.transform.position;

        float x = v3.x;
        float y = v3.y;

        if (x < _minX)
            x = _minX;
        else if (x > _maxX)
            x = _maxX;

        if (y < _minY)
            y = _minY;
        else if (y > _maxY)
            y = _maxY;

        transform.position = new Vector3(x, y, CameraProps.ZPosition);

        //todo: fix it for smooth cemera movement
        //target = new Vector3(x, y, _offsetZ);

        //transform.position = Vector3.SmoothDamp(
        //    transform.position,
        //    target,
        //    ref _velocity,
        //    0.01f,
        //    8f);
    }
}
