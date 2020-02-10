using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float projectileDirection = 1;


    void Update()
    {
        GameObject Player = GameObject.Find("Player walk 2_0");
        Player_Movement playerFace = Player.GetComponent<Player_Movement>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            projectileDirection = 1;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            projectileDirection = 2;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            projectileDirection = 3;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            projectileDirection = 4;
        }

        if (Input.GetKeyUp(KeyCode.W) && playerFace.playerDirection == -1)
        {
            projectileDirection = 3;
        }

        if (Input.GetKeyUp(KeyCode.W) && playerFace.playerDirection == 1)
        {
            projectileDirection = 1;
        }

        if (Input.GetKeyUp(KeyCode.S) && playerFace.playerDirection == -1)
        {
            projectileDirection = 3;
        }

        if (Input.GetKeyUp(KeyCode.S) && playerFace.playerDirection == 1)
        {
            projectileDirection = 1;
        }
    }
}
