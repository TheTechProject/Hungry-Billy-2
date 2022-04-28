using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100.0f;

    // Used to store the Mouse X and Y
    private float xRot;
    private float yRot;

    // Used to control camera values
    float camYRotation;
    float camXRotation;

    // Update is called once per frame
    void Update()
    {
        // Click to lock the cursor and escape to unlock the cursor.
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        xRot = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        yRot = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        camYRotation -= yRot; // Reverses the inversion cause by GetAxis.
        camYRotation = Mathf.Clamp(camYRotation, -90.0f, 90.0f); // To stop player from turning the camera upside down
        camXRotation += xRot;

        // Sets the rotation of the camera based on the Mouse positions.
        transform.localRotation = Quaternion.Euler(camYRotation, camXRotation, 0.0f);
    }
}
