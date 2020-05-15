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

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        canMove = true;
        stepCounter = 0f;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
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

        if (_input.Horizontal != 0 || _input.Vertical != 0)
        {
            if (stepCounter >= 1f/stepFrequency)
            {
                //SoundManager.PlayRandomAudio(walkingSoundEffects, transform.position);
                stepCounter = 0f;
            }
            else stepCounter += Time.deltaTime * (0.5f + Mathf.Abs(_input.Horizontal) / 2f + Mathf.Abs(_input.Vertical) / 2f);
        }

        anim.SetFloat("direction_x", _input.Horizontal);
        anim.SetFloat("direction_y", _input.Vertical);
       
        if(_input.Vertical == 0 && _input.Horizontal == 0)
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", false);
            anim.SetBool("stop", true);
        }

        if(_input.Vertical < 0.1 && Mathf.Abs(_input.Horizontal) < Mathf.Abs(_input.Vertical))
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", true);
            anim.SetBool("walk_side", false);
            anim.SetBool("stop", false);
        }

        if (_input.Vertical > 0.1 && Mathf.Abs(_input.Horizontal) < Mathf.Abs(_input.Vertical))
        {
            anim.SetBool("walk_north", true);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", false);
            anim.SetBool("stop", false);
        }

        if (_input.Horizontal < 0.1 && Mathf.Abs(_input.Vertical) < Mathf.Abs(_input.Horizontal))
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", true);
            anim.SetBool("stop", false);
        }

        if (_input.Horizontal > 0.1 && Mathf.Abs(_input.Vertical) < Mathf.Abs(_input.Horizontal))
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", true);
            anim.SetBool("stop", false);
        }
        
        /////////////////////////////////////////
    /*
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", false);
            anim.SetBool("stop", true);
        }

        if (rb.velocity.y < 0.1 && Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", true);
            anim.SetBool("walk_side", false);
            anim.SetBool("stop", false);
        }

        if (rb.velocity.y > 0.1 && Mathf.Abs(rb.velocity.x) < Mathf.Abs(rb.velocity.y))
        {
            anim.SetBool("walk_north", true);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", false);
            anim.SetBool("stop", false);
        }

        if (rb.velocity.x < 0.1 && Mathf.Abs(rb.velocity.y) < Mathf.Abs(rb.velocity.x))
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", true);
            anim.SetBool("stop", false);
        }

        if (rb.velocity.x > 0.1 && Mathf.Abs(rb.velocity.y) < Mathf.Abs(rb.velocity.x))
        {
            anim.SetBool("walk_north", false);
            anim.SetBool("walk_south", false);
            anim.SetBool("walk_side", true);
            anim.SetBool("stop", false);
        }
        */
        transform.Translate(_currentSpeed);
    }

    public void setCanMove(bool can) { canMove = can; }
}
