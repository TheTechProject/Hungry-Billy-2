using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100.0f;

    private float xRot;
    private float yRot;

    float camYRotation;
    float camXRotation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        xRot = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        yRot = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        camYRotation -= yRot;
        camYRotation = Mathf.Clamp(camYRotation, -90.0f, 90.0f);
        camXRotation += xRot;

        transform.localRotation = Quaternion.Euler(camYRotation, camXRotation, 0.0f);
    }
}
