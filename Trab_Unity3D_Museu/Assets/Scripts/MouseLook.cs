using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        foreach (Camera c in Camera.allCameras)
        {
            if(c.gameObject.name == "Support Camera" && c.depth == -1f)
            {
                c.gameObject.GetComponent<MouseLook>().mouseSensitivity = 0f;
                Vector3 rayDirection = Vector3.ProjectOnPlane(c.transform.forward, Vector3.one * Screen.height);
                c.transform.Rotate(rayDirection.x, 0, 0);
                playerBody.Rotate((-Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime));
            }
        }
    }
}
