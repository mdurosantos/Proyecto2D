using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Door : Interactuable
{

    public override void Interact()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach(Collider2D col in colliders)
        {
            if (!col.isTrigger)
            {
                //col.enabled = !col.enabled;
                gameObject.SetActive(false);//temp
                break;
            }
        }
    }
}
