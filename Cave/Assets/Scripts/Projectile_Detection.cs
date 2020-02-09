using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Detection : MonoBehaviour
{
    public float projectileSpeed = 30f;
    public Rigidbody2D projectile;

    void Start()
    {
        GameObject Player = GameObject.Find("Player walk 2_0");
        Player_Projectile playerProjectile = Player.GetComponent<Player_Projectile>();

        if (playerProjectile.projectileDirection == 1)
        {
            transform.Rotate(0.0f, 0.0f, 0.0f);
        }

        if (playerProjectile.projectileDirection == 2)
        {
            transform.Rotate(0.0f, 0.0f, 90f);
        }

        if (playerProjectile.projectileDirection == 3)
        {
            transform.Rotate(0.0f, 0.0f, 180f);
        }

        if (playerProjectile.projectileDirection == 4)
        {
            transform.Rotate(0.0f, 0.0f, 270f);
        }
    }

    void Update()
    {

        projectile.velocity = transform.right * projectileSpeed;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }

    }
}
