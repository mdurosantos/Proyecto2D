using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAccess : MonoBehaviour
{
    private static Transform playerPos;
    

    private void Awake()
    {
        playerPos = FindObjectOfType<PlayerInput>().transform;
    }

    public static Transform GetPlayerPos()
    {
        return playerPos;
    }
}
