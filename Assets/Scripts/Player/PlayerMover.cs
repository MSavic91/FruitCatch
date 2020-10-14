using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 position;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
        
        if (Input.touchCount != 0) 
        {
            position = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
    }

}
