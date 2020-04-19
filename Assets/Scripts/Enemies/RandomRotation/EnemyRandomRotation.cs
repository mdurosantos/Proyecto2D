using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomRotation : MonoBehaviour
{
    [SerializeField]
    private float startWaitTime;
    private float waitTime;
    [SerializeField]
    private float[] directionAngles;
    private bool playerDetected = false;
    [SerializeField]
    private Transform playerLocation;
    private PlayerVisibility playerVisibility;
    private int randomSpot;
    private AIDestinationSetter destination;
    [SerializeField]
    private Transform enemySpot;

    // Start is called before the first frame update
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        playerVisibility = playerLocation.GetComponent<PlayerVisibility>();
        randomSpot = Random.Range(0, directionAngles.Length);
        waitTime = startWaitTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerVisibility.getPlayerVisible() && playerDetected)
        {
            destination.target = enemySpot;
            randomSpot = Random.Range(0, directionAngles.Length);
            SetPlayerDetected(false);
        }
        if (playerDetected && playerVisibility.getPlayerVisible())
        {
            destination.target = playerLocation;
        }
        else
        {
            Patrol();
        }
        
    }

    void Patrol()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, directionAngles[randomSpot]), 5.0f * Time.deltaTime);
        if (transform.rotation.z - directionAngles[randomSpot] < 0.2f) //Esperar
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, directionAngles.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;
    }


}
