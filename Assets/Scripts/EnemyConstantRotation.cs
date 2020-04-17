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
    // Start is called before the first frame update
    void Start()
    {
        nextSpot = 0;
        waitTime = startWaitTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, directionAngles[nextSpot]), speed * Time.deltaTime);
        if (transform.rotation.z - directionAngles[nextSpot] < 0.2f) 
        {
            if (waitTime <= 0)
            {
                if (nextSpot < directionAngles.Length-1)
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

    void RotateEnemy()
    {
        nextSpot = Random.Range(0, directionAngles.Length);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(directionAngles[randomSpot], Vector3.forward), 5.0f * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(directionAngles[nextSpot], Vector3.forward);
    }
}
