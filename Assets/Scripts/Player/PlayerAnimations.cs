using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] [Range(0f,1f)] private float diagonalThreshold = 0.33f;
    private Animator anim;
    private bool stopped;
    private int direction;
    /* 4  5  6
     * 3  d  7
     * 2  1  8
     */
    private void Start()
    {
        anim = GetComponent<Animator>();
        stopped = true;
        direction = 1;
    }

    private void Update()
    {
        if (!stopped) anim.SetInteger("direction", direction);
    }

    public void Walk(Vector2 input)
    {
        if (stopped)
        {
            stopped = false;
            anim.SetBool("stop", false);
        }
        bool left = input.x <= 0f;
        bool down = input.y <= 0f;
        if (Mathf.Abs(input.x) <= diagonalThreshold) //vertical
        {
            if (down) anim.SetInteger("direction", 1);
            else anim.SetInteger("direction", 5);

        }
        else if (Mathf.Abs(input.y) <= diagonalThreshold) //horizontal
        {
            if (left) anim.SetInteger("direction", 3);
            else anim.SetInteger("direction", 7);
        }
        else //diagonal
        {
            if (left)
            {
                if (down) anim.SetInteger("direction", 2);
                else anim.SetInteger("direction", 4);
            }
            else
            {
                if (down) anim.SetInteger("direction", 8);
                else anim.SetInteger("direction", 6);
            }
        }
    }

    public void Idle()
    {
        if (!stopped)
        {
            stopped = true;
            anim.SetBool("stop", true);
        }
    }
}
