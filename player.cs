using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    bool jumpKeyPressed = false;
    float horizontalInput = 0;
    float verticalInput = 0;
    Rigidbody rigidBodyComponent;
    Renderer rendererComponent;

    Color RandomGroundColour()
    {
        Color ground;
        ground = new Color(Random.value, Random.value, Random.value, 1);

        return ground;
    }

    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        rendererComponent = GetComponent<Renderer>();
        rendererComponent.material.SetColor("_Color", Color.green);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
            rendererComponent.material.SetColor("_Color", RandomGroundColour());
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput * 2, rigidBodyComponent.velocity.y, verticalInput * 6);

        if (jumpKeyPressed)
        {
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }

    }
}
