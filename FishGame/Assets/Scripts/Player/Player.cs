using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains all player input functions
/// </summary>
public class Player : MonoBehaviour
{
    CharacterController controller;

    public float MoveSpeed = 10f;
    public float gravity = -9.81f;

    /// <summary>
    /// The player's y velocity used to determine the rate of falling
    /// </summary>
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * MoveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
