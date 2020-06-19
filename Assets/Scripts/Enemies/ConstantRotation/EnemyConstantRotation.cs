using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstantRotation : Enemy
{
    private int nextSpot;
    [SerializeField] private bool randomRotation = false;
    private float randomAngle;
    
    public override void Init()
    {
        nextSpot = 0;
        NewRandomAngle();
    }
    
    public override void Act()
    {
        if (!playerVisibility.getPlayerVisible() && playerDetected)
        {
            destination.target = enemySpot;
            nextSpot = 0;
            SetPlayerDetected(false);
        }

        if (playerDetected && playerVisibility.getPlayerVisible()) destination.target = playerLocation;
        else Patrol();
    }

    void Patrol()
    {
        if(!randomRotation) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, directionAngles[nextSpot]), speed * Time.deltaTime);
        else transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, randomAngle), speed * Time.deltaTime);
        if (transform.rotation.z - directionAngles[nextSpot] < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (!randomRotation)
                {
                    if (nextSpot < directionAngles.Length - 1) nextSpot++;
                    else nextSpot = 0;
                }
                else NewRandomAngle();
                waitTime = startWaitTime;
            }
            else waitTime -= Time.deltaTime;
        }
    }

    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;
    }

    private void NewRandomAngle()
    {
        randomAngle = Random.Range(0f, 359f);
    }


}
