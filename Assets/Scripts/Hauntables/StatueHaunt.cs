using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueHaunt : Hauntable
{
    [SerializeField] private GameObject bottomDoor = null;
    [SerializeField] private GameObject leftDoor = null;
    [SerializeField] private GameObject topDoor = null;
    [SerializeField] private GameObject rightDoor = null;
    [SerializeField] private Sprite bottomStatue = null;
    [SerializeField] private Sprite leftStatue = null;
    [SerializeField] private Sprite topStatue = null;
    [SerializeField] private Sprite rightStatue = null;
    private GameObject objectModel;
    private SpriteRenderer spriteRenderer;
    int state;
    private float horizontal;
    private float vertical;

    public override void Init()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<SpriteRenderer>() != null) spriteRenderer = child.GetComponent<SpriteRenderer>();
            else objectModel = child;
        }
        SetState(0);
    }

    public override void Interact()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (new Vector2(horizontal, vertical).magnitude >0.5f)
        {
            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                if (horizontal < 0f) SetState(1);
                else SetState(3);
            }
            else
            {
                if (vertical < 0f) SetState(0);
                else SetState(2);
            }
        }
    }

    private void SetState(int s) //TEMP bad way of doing it, but works for now
    {
        state = s;
        switch (state) {
            case 0:
                bottomDoor.SetActive(false);
                leftDoor.SetActive(true);
                topDoor.SetActive(true);
                rightDoor.SetActive(true);
                objectModel.transform.localEulerAngles = new Vector3(90, -90, 90);
                spriteRenderer.sprite = bottomStatue;
                break;
            case 1:
                bottomDoor.SetActive(true);
                leftDoor.SetActive(false);
                topDoor.SetActive(true);
                rightDoor.SetActive(true);
                objectModel.transform.localEulerAngles = new Vector3(0, -90, 90);
                spriteRenderer.sprite = leftStatue;
                break;
            case 2:
                bottomDoor.SetActive(true);
                leftDoor.SetActive(true);
                topDoor.SetActive(false);
                rightDoor.SetActive(true);
                objectModel.transform.localEulerAngles = new Vector3(-90, -90, 90);
                spriteRenderer.sprite = topStatue;
                break;
            case 3:
                bottomDoor.SetActive(true);
                leftDoor.SetActive(true);
                topDoor.SetActive(true);
                rightDoor.SetActive(false);
                objectModel.transform.localEulerAngles = new Vector3(180, -90, 90);
                spriteRenderer.sprite = rightStatue;
                break;
            default:break;
        }
    }
}
