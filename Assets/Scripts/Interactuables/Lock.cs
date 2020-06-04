using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactuable
{
    public override void Init()
    {
        //nothing to see here :)
    }

    public override void Interact()
    {
        gameObject.SetActive(false);
    }
}
