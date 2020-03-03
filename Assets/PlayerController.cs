using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;

    private Vector3 moveDir = Vector3.zero;

    public float runSpeed = 7.0f;
    public float jumpVel = 5.0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    void Start()
    {
        //hook up variables
        player = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpVel;
            Debug.Log(rb.velocity);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        rb.velocity = new Vector3((Input.GetAxis("Horizontal") * runSpeed), rb.velocity.y, 0f);
        Debug.Log(rb.velocity);
    }
}
