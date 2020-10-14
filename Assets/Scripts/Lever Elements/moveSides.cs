using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSides : MonoBehaviour
{
    public float moveToRight;
    public float speed = 1;
    private float positionY;

    private void Awake()
    {
        positionY = transform.localPosition.y;
        speed = Random.Range(0.7f, 2.1f);
    }

    void Update()
    {
        transform.localPosition = new Vector3(Mathf.PingPong(Time.time * speed, moveToRight), positionY, 0);// * Time.deltaTime * speed;
    }
}
