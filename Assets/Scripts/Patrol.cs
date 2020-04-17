using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform[] moveSpots;
    [SerializeField]
    private int initialSpot;
    private int randomSpot; 
    

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        transform.position = moveSpots[initialSpot].position;
    }



    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime); //Para desplazarse hacia el punto que toca.

        
        
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) //Esperar
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            RotateToDirection();
        }
    }

    void RotateToDirection()
    {
        Vector3 dir = transform.position - moveSpots[randomSpot].position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle-90f, Vector3.forward), 5.0f * Time.deltaTime);
    }

}
