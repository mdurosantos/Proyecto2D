using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float chaseSpeed;
    public float startWaitTime;
    private float waitTime;

    public Transform[] moveSpots;
    [SerializeField]
    private int initialSpot;
    private int randomSpot;
    private bool playerDetected = false;
    [SerializeField]
    private Transform playerLocation;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        transform.position = moveSpots[initialSpot].position;
    }



    // Update is called once per frame
    void Update()
    {
        /*if (playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, chaseSpeed * Time.deltaTime);
            RotateToDirection(playerLocation);
        }
        else
        {*/
            JustPatrol();
        //}
    }

    void JustPatrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime); //Para desplazarse hacia el punto que toca.

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) //Esperar
        {
            if (waitTime <= 0)
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
            RotateToDirection(moveSpots[randomSpot]);
        }
    }

    void RotateToDirection(Transform target)
    {
        Vector3 dir = transform.position - target.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle-90f, Vector3.forward), 5.0f * Time.deltaTime);
    }

    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;
    }

}
