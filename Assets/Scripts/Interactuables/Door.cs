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
        
        if (open) AudioManager.PlaySound("open_door");
    }

    public void CollidersActive(bool active)
    {
        foreach(Collider2D c in GetComponentsInChildren<Collider2D>()) if (!c.isTrigger) c.enabled = active;
    }

}
