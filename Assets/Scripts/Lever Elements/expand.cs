using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expand : MonoBehaviour
{
    private float localScaleY, localScaleZ;

    private void Awake()
    {
        localScaleY = transform.localScale.y;
        localScaleZ = transform.localScale.z;
    }
    void Update()
    {
        //Mathf.PingPong(Time.time * randomTimeRange, 180)
        transform.localScale = new Vector3(Mathf.Clamp(Mathf.PingPong(Time.time, 4),1,3), localScaleY, localScaleZ);
        
    }
}
