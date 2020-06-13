using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerAnimations))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 3f;
    private Vector2 _currentSpeed;
    private bool canMove;

    private PlayerInput _input;
    private PlayerAnimations animations;

    private Rigidbody2D rb;

    private float moveThreshold;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        animations = GetComponentInChildren<PlayerAnimations>();
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        moveThreshold = 0.1f * _maxSpeed * Time.deltaTime;
    }
    
    void Update()
    {
        if (canMove) Move();
    }

    private void Move()
    {
        float target_x = _input.Horizontal * _maxSpeed * Time.deltaTime;
        float target_y = _input.Vertical * _maxSpeed * Time.deltaTime;

        _currentSpeed.x = Mathf.Lerp(_currentSpeed.x, target_x, 0.5f);
        _currentSpeed.y = Mathf.Lerp(_currentSpeed.y, target_y, 0.5f);

        if (_input.Horizontal != 0 || _input.Vertical != 0) animations.Walk(new Vector2(_input.Horizontal, _input.Vertical));
        else animations.Idle();
        
        transform.Translate(_currentSpeed, Space.World);
    }

    public void setCanMove(bool can) { canMove = can; }
}
