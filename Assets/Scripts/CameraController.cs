using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    Vector3 _offset;
    private float offsetScale;
    private Vector3 offsetOffset;
    private Vector3 targetAngles;
    private Vector3 _velocity = Vector3.zero;
    public float Dampening;

    public Vector2 MinBound, MaxBound;

    public Vector2 DeadZone;

    private Camera _camera;
    
    void Start()
    {
        _offset = transform.position - Player.position;
        offsetScale = 1f;
        offsetOffset = Vector3.zero;
        targetAngles = transform.localEulerAngles;
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

    public void ChangeTarget(Transform newTarget, float offsetScale)
    {
        //hardcoded angles for each possible direction to look at target, (if 0 is down)
        if (newTarget.localEulerAngles.z >= 180)
        {
            targetAngles = new Vector3(0f, 24f, -90f);
            offsetOffset = new Vector3(-1 / offsetScale, 0, 0);
        }
        else if (newTarget.localEulerAngles.z >= 90)
        {
            targetAngles = new Vector3(0f, -24f, 90f);
            offsetOffset = new Vector3(1 / offsetScale, 0, 0);
        }
        else
        {
            targetAngles = new Vector3(-24, 0, 0);
            if (offsetScale < 1f) offsetOffset = new Vector3(0, -1 / offsetScale, 0);
            else offsetOffset = Vector3.zero;
        }
        this.offsetScale = offsetScale;
        Player = newTarget;
    }

    void SmoothFollow()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.position + _offset * offsetScale + offsetOffset, ref _velocity, Dampening);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetAngles), 180f * Time.deltaTime);
    }
}
