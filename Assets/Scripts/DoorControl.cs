using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Transform doorPivot;
    public Quaternion openAngle;
    private bool isOpen = false;
    public float doorCloseTimer;

    private Quaternion currentRotation;
    private float timer = 0;
    private float speed = 120;
    private Quaternion closed;

    void Start()
    {
        closed = doorPivot.localRotation;
    }

    void Update()
    {
        currentRotation = doorPivot.localRotation;

        if (isOpen)
        {
            currentRotation = Quaternion.RotateTowards(currentRotation, openAngle, speed * Time.deltaTime);

            if (speed > 10)
            {
                speed -= 40 * Time.deltaTime;
                speed = Mathf.Clamp(speed, 10, 120);
            }

            if (currentRotation == openAngle)
            {
                if (timer >= doorCloseTimer)
                {
                    isOpen = false;
                    timer = 0;
                    speed = 120;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        else
        {
            currentRotation = Quaternion.RotateTowards(currentRotation, closed, 240 * Time.deltaTime);
        }

        doorPivot.localRotation = currentRotation;
    }

    public void ToggleDoor()
    {
        isOpen = true;
    }
}
