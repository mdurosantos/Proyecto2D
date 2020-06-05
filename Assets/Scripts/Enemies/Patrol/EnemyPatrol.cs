﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private EnemyType enemyType = EnemyType.ConstantRotation; //Sirve para elegir el comportamiento del enemigo
    public float startWaitTime; //Es el tiempo que transcurre entre movimiento y movimiento o rotación y rotación
    private float waitTime; //Tiempo de espera transcurrido
    public Transform[] moveSpots; //Waypoints a los que se moverá el enemigo durante Patrol
    [SerializeField] private int initialSpot = 0; //Index del primer Waypoint al que se moverá el enemigo
    private int randomSpot; //Index aleatorio del Waypoint o de la Rotación
    public bool playerDetected = false; //El enemigo ha detectado al ugador
    [SerializeField] private float[] directionAngles = null; //Ángulos a los que rotará el enemigo durante RandomRotation
    [SerializeField] private Transform enemySpot = null; //Waypoint al que "pertenece" el enemigo.
    private PlayerVisibility playerVisibility; 
    private AIPath path;
    private AIDestinationSetter destination;
    //[SerializeField] private bool randomRotation = false;
    private float randomAngle;
    private int nextSpot;
    private Transform playerLocation; //Localización del jugador
    [SerializeField] private float speed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<AIPath>();
        playerLocation = LevelAccess.GetPlayerPos();
        destination = GetComponent<AIDestinationSetter>();
        playerVisibility = playerLocation.GetComponent<PlayerVisibility>();
        waitTime = startWaitTime;
        if(moveSpots.Length>0)
            destination.target = moveSpots[initialSpot];
        nextSpot = 0;
        if (enemyType == EnemyType.Patrol)
        {
            randomSpot = initialSpot;
        }
        else
        {
            randomSpot = Random.Range(0, directionAngles.Length);
        }
     
        //NewRandomAngle();
    }



    // Update is called once per frame
    void Update()
    {
        if (PlayerIsHidden())
        {
            SetPlayerDetected(false);
            waitTime = startWaitTime;
            switch (enemyType)
            {
                case EnemyType.ConstantRotation:
                    destination.target = enemySpot;
                    nextSpot = 0;
                    break;
                case EnemyType.RandomRotation:
                    destination.target = enemySpot;
                    randomSpot = Random.Range(0, directionAngles.Length);
                    break;
                default:
                    randomSpot = Random.Range(0, moveSpots.Length);
                    destination.target = moveSpots[randomSpot];          
                    break;
            }

        }
        if (PlayerDetected())
        {
            destination.target = playerLocation;
        }
        else
        {
            switch (enemyType)
            {
                case EnemyType.ConstantRotation:
                    if(Vector2.Distance(transform.position, enemySpot.position) < 0.2f)
                        ConstantRotation();
                    break;
                case EnemyType.RandomRotation:
                    if(Vector2.Distance(transform.position, enemySpot.position) < 0.2f)
                        RandomRotation();
                    break;
                default:
                    Patrol();
                    break;
            }
        }
    }


    private void Patrol()
    {        
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                destination.target = moveSpots[randomSpot];
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    private void RandomRotation()
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

    private void ConstantRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, directionAngles[nextSpot]), speed * Time.deltaTime);
        //else transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, randomAngle), speed * Time.deltaTime);
        if (transform.rotation.z - directionAngles[nextSpot] < 0.2f)
        {
            if (waitTime <= 0)
            {
                
                if (nextSpot < directionAngles.Length - 1)
                {
                    nextSpot++;
                }
                else
                {
                    nextSpot = 0;
                }
                
                //else NewRandomAngle();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    /*private void NewRandomAngle()
    {
        randomAngle = Random.Range(0f, 359f);
    } */

    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;
        if (!detected)
        {
            waitTime = startWaitTime;
            switch (enemyType)
            {
                case EnemyType.ConstantRotation:
                    destination.target = enemySpot;
                    nextSpot = 0;
                    break;
                case EnemyType.RandomRotation:
                    destination.target = enemySpot;
                    randomSpot = Random.Range(0, directionAngles.Length);
                    break;
                default:
                    randomSpot = Random.Range(0, moveSpots.Length);
                    destination.target = moveSpots[randomSpot];
                    break;
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = enemySpot.position;
    }

    private bool PlayerDetected()
    {
        return playerDetected && playerVisibility.getPlayerVisible();
    }

    private bool PlayerIsHidden()
    {
        return !playerVisibility.getPlayerVisible() && playerDetected;
    }

    public enum EnemyType
    {
        Patrol,
        ConstantRotation,
        RandomRotation
    }
}
