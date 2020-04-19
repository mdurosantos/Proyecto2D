using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstantRotation : MonoBehaviour
{
    [SerializeField]
    private float startWaitTime;
    private float waitTime;
    [SerializeField]
    private float[] directionAngles;
    private int nextSpot;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform playerLocation;
    private PlayerVisibility playerVisibility;
    private AIDestinationSetter destination;
    private bool playerDetected = false;
    [SerializeField]
    private Transform enemySpot;

    // Start is called before the first frame update
    void Start()
    {
        destination = GetComponent<AIDestinationSetter>();
        playerVisibility = playerLocation.GetComponent<PlayerVisibility>();
        nextSpot = 0;
        waitTime = startWaitTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerVisibility.getPlayerVisible() && playerDetected)
        {
            destination.target = enemySpot;
            nextSpot = 0;
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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, directionAngles[nextSpot]), speed * Time.deltaTime);
        if (transform.rotation.z - directionAngles[nextSpot] < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (nextSpot < directionAngles.Length - 1)
                {
                    nextSpot++;
                    Debug.Log("Sumado");
                }
                else
                {
                    nextSpot = 0;
                    Debug.Log("Reseteado");
                }
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
