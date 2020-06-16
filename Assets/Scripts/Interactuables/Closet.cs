using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : Interactuable
{
    private bool open;
    private Animator anim;

    public override void Init()
    {
        open = false;
        anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        open = !open;
        anim.SetBool("open", open);
        
        if (open) AudioManager.PlaySound("open_closet");

        if (rewards.Count > 0) AudioManager.PlaySound("key");
    }



}
