using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls how the player camera looks around
/// </summary>
public class PlayerLook : MonoBehaviour
{

    public float MouseSensitivity = 100f;
    private Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponentInParent<CharacterController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
