using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 3f;
    private Vector2 _currentSpeed;
    private bool canMove;

    [SerializeField] private AudioClip[] walkingSoundEffects = null;
    [SerializeField] [Range(0f,12f)] private float stepFrequency = 4f; //base steps per second
    private float stepCounter;

    private PlayerInput _input;

    private Animator anim;

    private Rigidbody2D rb;

    private float moveThreshold;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        canMove = true;
        stepCounter = 0f;
        anim = GetComponentInChildren<Animator>();
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

        //_currentSpeed.x = Mathf.Lerp(_currentSpeed.x, target_x, 0.5f);
        //_currentSpeed.y = Mathf.Lerp(_currentSpeed.y, target_y, 0.5f);

        _currentSpeed.x = target_x;
        _currentSpeed.y = target_y;

        if (_input.Horizontal != 0 || _input.Vertical != 0)
        {
            if (stepCounter >= 1f/stepFrequency)
            {
                //SoundManager.PlayRandomAudio(walkingSoundEffects, transform.position);
                stepCounter = 0f;
            }
            else stepCounter += Time.deltaTime * (0.5f + Mathf.Abs(_input.Horizontal) / 2f + Mathf.Abs(_input.Vertical) / 2f);
        }

        if (_currentSpeed.magnitude <= moveThreshold)
        {
            anim.SetBool("stop", true);
            anim.SetInteger("direction", -1);
        }
        else
        {
            anim.SetBool("stop", false);
            if (Mathf.Abs(_currentSpeed.x) < Mathf.Abs(_currentSpeed.y))
            {
                if (_currentSpeed.y < moveThreshold) anim.SetInteger("direction", 0);
                else anim.SetInteger("direction", 2);
            }
            else
            {
                if (_currentSpeed.x < moveThreshold) anim.SetInteger("direction", 1);
                else anim.SetInteger("direction", 3);
            }
        }
        
        transform.Translate(_currentSpeed);
    }

    public void setCanMove(bool can) { canMove = can; }
}
