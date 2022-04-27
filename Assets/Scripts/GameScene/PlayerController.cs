using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;

    public float speed = 10.0f;    
    public float moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = Input.GetAxis("Horizontal");

    }

    void FixedUpdate()
    {

        rb.velocity = new Vector3(moveInput * speed, rb.velocity.y, speed);

    }

}
