using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ground2 : MonoBehaviour
{

    public float enemyspeed;
    public float enemyDirection = 1;

    void Start()
    {

    }

    void Update()
    {
        if (enemyDirection == 1)
        {
            transform.Translate(Vector2.right * enemyspeed * Time.deltaTime);
        }
        if (enemyDirection == 2)
        {
            transform.Translate(Vector2.right * enemyspeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "tombstone" && enemyDirection == 1)
        {
            transform.Rotate(0.0f, 180f, 0.0f);
            enemyDirection = 2;
        }

        if (col.gameObject.tag == "tombstone" && enemyDirection == 2)
        {
            transform.Rotate(0.0f, 0f, 0.0f);
            enemyDirection = 1;
        }
    }
}
