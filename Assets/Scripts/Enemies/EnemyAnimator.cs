using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator anim;
    private Transform daddy;

    void Start()
    {
        anim = GetComponent<Animator>();
        daddy = transform.parent;
    }
    
    void Update()
    {
        
    }
}
