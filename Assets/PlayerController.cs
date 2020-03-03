using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    CharacterController controller;
    Rigidbody rb;

    private Vector3 moveDir = Vector3.zero;

    public float speed = 7.0f;
    public float jumpVel = 8.0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    public float gravity = 0.5f;

    void Start()
    {
        //hook up variables
        player = GetComponent<GameObject>();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        moveDir *= speed;
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpVel;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        controller.Move(moveDir * Time.deltaTime);
    }
}
