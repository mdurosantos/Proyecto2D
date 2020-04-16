using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed;
    private Vector2 _currentSpeed;

    private PlayerInput _input;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float target_x = _input.Horizontal * _maxSpeed * Time.deltaTime;
        float target_y = _input.Vertical * _maxSpeed * Time.deltaTime;

        _currentSpeed.x = Mathf.Lerp(_currentSpeed.x, target_x, 0.5f);
        _currentSpeed.y = Mathf.Lerp(_currentSpeed.y, target_y, 0.5f);

        transform.Translate(_currentSpeed);
    }
}
