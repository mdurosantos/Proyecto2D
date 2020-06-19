using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform daddy = null;
    private Vector3 previousPos;
    private float speed;
    private bool stopped;

    void Start()
    {
        anim = GetComponent<Animator>();
        previousPos = transform.position;
        speed = 0f;
    }
    
    void Update()
    {
        if(speed >= 0.01f)
        {
            if (stopped)
            {
                stopped = false;
                anim.SetBool("stop", false);
            }
        }
        else
        {
            if (!stopped)
            {
                stopped = true;
                anim.SetBool("stop", true);
            }
        }

        anim.SetInteger("direction", AngleToDir(daddy.localEulerAngles.z));
    }

    private void FixedUpdate()
    {
        transform.position = daddy.transform.position;
        speed = Vector3.Distance(transform.position, previousPos);
        previousPos = transform.position;
    }

    private int AngleToDir(float angle)
    {
        float ang = angle % 360f;
        if (ang < 45f) return 5;
        else if (ang < 90f) return 4;
        else if (ang < 135f) return 3;
        else if (ang < 180f) return 2;
        else if (ang < 225f) return 1;
        else if (ang < 270f) return 8;
        else if (ang < 315f) return 7;
        else return 6;
    }

    private void PlayStep()
    {
        //TODO maybe?
    }
}
