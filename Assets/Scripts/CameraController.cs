using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    Vector3 _offset;
    private Vector3 _velocity;
    public float Dampening;

    public Vector2 MinBound, MaxBound;

    public Vector2 DeadZone;

    private Camera _camera;
    
    void Start()
    {
        _offset = transform.position - Player.position;
        _camera = GetComponent<Camera>();
    }

    
    void LateUpdate()
    { 
        //if (OutOfDeadZone())
        //{
            SmoothFollow();
        //}

        ClampCameraPosition();
    }

    private bool OutOfDeadZone()
    {
        var viewportCoordenates = _camera.WorldToViewportPoint(Player.position);
        return (Mathf.Abs(viewportCoordenates.x - 0.5f) > DeadZone.x || Mathf.Abs(viewportCoordenates.y - 0.5f) > DeadZone.y);
    }

    private void ClampCameraPosition()
    {
        float x = Mathf.Clamp(transform.position.x, MinBound.x, MaxBound.x);
        float y = Mathf.Clamp(transform.position.y, MinBound.y, MaxBound.y);

        transform.position = new Vector3(x, y, transform.position.z);
    }



    void SmoothFollow()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.position + _offset, ref _velocity, Dampening);
    }
}
