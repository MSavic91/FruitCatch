using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    public float height;
    public float speed = 1;
    private float positionX;

    private void Awake()
    {
        positionX = transform.localPosition.x;
        speed = Random.Range(0.7f, 2.1f);
    }

    void Update()
    {
        transform.localPosition = new Vector3(positionX,Mathf.PingPong(Time.time * speed, height), 0);// * Time.deltaTime * speed;
    }
}
