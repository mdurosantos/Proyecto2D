using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get { return _horizontal; } }
    public float Vertical { get { return _vertical; } }

    private float _horizontal;
    private float _vertical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        //Debug.Log(Horizontal + " / " +Vertical);
    }


    void GetInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
}
