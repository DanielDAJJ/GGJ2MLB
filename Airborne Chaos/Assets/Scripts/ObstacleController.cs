using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float speed = 5f;
    public float destroyX = -10f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
        if (GameManager.Instance == null || GameManager.Instance.isGameOver) return;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
