using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactuable
{
    public override void Init()
    {
        //nothing to init
    }

    public override void Interact()
    {
        //maybe trigger open animation, or anything
        gameObject.SetActive(false);//temp
        AudioManager.PlaySound("key");
    }
}
