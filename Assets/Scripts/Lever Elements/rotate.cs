using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private float RandomDirection, randomTimeRange;
    private Vector3 RandomDirectionVector;

    private void Start()
    {
        RandomDirection = Random.Range(0, 2);
        if (RandomDirection == 0)
            RandomDirection = -1;
        //RandomDirectionVector = new Vector3( 0, 0, RandomDirection);
        randomTimeRange = Random.Range(10, 50);
    }

    void Update()
    {
        Quaternion target = Quaternion.Euler(0, 0, Mathf.PingPong(Time.time * randomTimeRange, 360) * RandomDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);

        //transform.RotateAround(transform.position, Vector3.forward, Mathf.PingPong(Time.time * 10, 70) * Time.deltaTime);
        //transform.RotateAround(transform.position, RandomDirectionVector, Mathf.PingPong(Time.time * 10, 70) * Time.deltaTime);
    }

}
