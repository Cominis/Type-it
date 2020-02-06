using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProps : MonoBehaviour
{
    public static float Width { get; private set; }
    public static float Length { get; private set; }
    public static float ZPosition { get; private set; }

    private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
        SetBoundaries();
        SetZPosition();
    }

    private void SetBoundaries()
    {
        Width = _mainCamera.orthographicSize;
        Length = Width * _mainCamera.aspect;
    }

    private void SetZPosition()
    {
        ZPosition = _mainCamera.transform.position.z;
    }
}
