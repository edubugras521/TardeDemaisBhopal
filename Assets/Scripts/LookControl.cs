using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LookControl : MonoBehaviour
{
    public float sensitivity = 1f;
    public Transform playerCharacter;
    public static bool lockCamera = false;

    float mouseX;
    float mouseY;
    float yRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GasControl.gameOver && !lockCamera && !NoteManager.isReading)
        {
            mouseX = Input.GetAxis("Mouse X") * ((Screen.width / Screen.height) * 10) * sensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * ((Screen.width / Screen.height) * 10) * sensitivity * Time.deltaTime;

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90, 90);
            transform.localRotation = Quaternion.Euler(yRotation, 0, 0);

            playerCharacter.Rotate(Vector3.up * mouseX);
        }

        if (lockCamera)
        {
            mouseY = 0;
            yRotation = 0;
        }

        if (GasControl.gameOver)
        {
            yRotation += (30f * Time.deltaTime);
            yRotation = Mathf.Clamp(yRotation, -90, 90);
            transform.localRotation = Quaternion.Euler(yRotation, 0, 0);
        }
    }
}
