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
    private int randomSpot;
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, directionAngles.Length);
        waitTime = startWaitTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0, directionAngles[randomSpot]), 5.0f * Time.deltaTime);
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

    void RotateEnemy()
    {
        randomSpot = Random.Range(0, directionAngles.Length);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(directionAngles[randomSpot], Vector3.forward), 5.0f * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(directionAngles[randomSpot], Vector3.forward);
    }
}
