using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Interactuable
{
    private bool open;
    private Animator anim;
    //private Text feedback;

    public override void Init()
    {
        open = false;
        anim = GetComponentInChildren<Animator>();
        //feedback = GameObject.FindGameObjectWithTag("Feedback").GetComponent<Text>();
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

    
    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //feedback.text = "Press Space";
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            //feedback.text = "";
        }
    }*/

}
