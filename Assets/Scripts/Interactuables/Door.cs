using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactuable
{
    private bool open;
    private Animator anim;

    public override void Init()
    {
        open = false;
        anim = GetComponentInChildren<Animator>();

    }

    public override void Interact()
    {
        open = !open;
        anim.SetBool("open", open);
    }

}
