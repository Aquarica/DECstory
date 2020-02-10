using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Animator anim;

    public float walkSpeed = 5f;                                                                      // Sets walkSpeed variable to 5
    public float jumpForce = 250f;                                                                    // Sets jumpForce variable to 250
    public float originalXScale;                                                                      // Sets originialXScale variable
    public float playerDirection = 1;                                                                 // Sets the playerDirection variable to 1

    private Rigidbody2D playerBody;                                                                   // References the Rigidbody2D as playerBody
    private BoxCollider2D playerCollider;                                                             // References the BoxCollider2D as playerCollider

    [SerializeField] private LayerMask platformsLayerMask = 8;                                        // References the layermask of Platforms for the grounded boolean

    void Start()
    {
        anim.SetInteger("State", 0);
    }

    void Awake()
    {
        playerBody = transform.GetComponent<Rigidbody2D>();                                           // Sets the playerBody to the Rigidbody2D
        playerCollider = transform.GetComponent<BoxCollider2D>();                                     // Sets the playerCollider to the BoxCollider2D
        originalXScale = transform.localScale.x;                                                      // Sets current Player Direction to OriginalXScale

    }

    bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);         // Raycast to detect when the player is touching the ground
        return (raycastHit2D.collider != null);                                                                                                                     // Raycast returns if the bool is true or false
    }

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        float playerHorizontal = Input.GetAxisRaw("Horizontal");                                    // Setts the Player Horizontal to the current Player Horizontal
        playerBody.velocity = new Vector2(playerHorizontal * walkSpeed, playerBody.velocity.y);     // Setts the Player velocity based on the walkSpeed set 


        if (playerHorizontal * playerDirection < 0f)                                                // Detects if the Player has changed direction
        {
            FlipPlayerDirection();
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))                                            // Detects if the Player is touching the ground and the W key is pressed
        {
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);                   // Triggers the Player to jump based on the jumpForce
            return;
        }
        anim.SetInteger("State", 1);
    }

    void FlipPlayerDirection()                                                                      // Triggers when the if statement under walk occurs
    {
        playerDirection *= -1;                                                                      // Sets the Player direction variable to the opposite ( negative or positive )
        Vector3 scale = transform.localScale;                                                       // Sets the scale of the Player
        scale.x = originalXScale * playerDirection;                                                 // Sets the scale based on the direction
        transform.localScale = scale;                                                               // Updates the visual change of scale to the Player
    }
}
