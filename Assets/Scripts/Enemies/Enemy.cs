using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float[] directionAngles = {0f,90f,180f,270f}; //Ángulos a los que rotará el enemigo durante RandomRotation
    [SerializeField] protected Transform enemySpot = null; //Waypoint al que "pertenece" el enemigo.
    [SerializeField] protected float startWaitTime = 0.1f; //Es el tiempo que transcurre entre movimiento y movimiento o rotación y rotación
    [SerializeField] protected float speed = 2f; //Velocidad de rotación
    protected float waitTime; //Tiempo de espera transcurrido
    protected bool playerDetected;
    protected int randomSpot; //Index aleatorio del Waypoint o de la Rotación
    protected Transform playerLocation; //Localización del jugador
    protected PlayerVisibility playerVisibility; //Control de la visibilidad del jugador
    protected AIDestinationSetter destination;

    void Start()
    {
        playerDetected = false;
        playerLocation = LevelAccess.GetPlayerPos();
        playerVisibility = playerLocation.GetComponent<PlayerVisibility>();
        destination = GetComponent<AIDestinationSetter>();
        waitTime = startWaitTime;
        Init();
    }
    
    void Update()
    {
        Act();
    }

    public abstract void Init();
    public abstract void Act();
}
