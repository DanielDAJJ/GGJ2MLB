using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    private float speed = 5f;
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
