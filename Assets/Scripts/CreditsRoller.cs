using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsRoller : MonoBehaviour
{

    public float startYPosition;
    public float endYPosition;
    public float speed = 1;
    private bool creditsRolling = false;

    private float currentYPosition;

    // Update is called once per frame
    void Update()
    {
        if(creditsRolling)
        {
            currentYPosition = transform.localPosition.y;

            if (currentYPosition < endYPosition)
            {
                currentYPosition += speed * Time.deltaTime;
            }

            else
            {
                currentYPosition = startYPosition;
            }

            transform.localPosition = new Vector3(0, currentYPosition, 0);
        }
    }

    public void RollCredits()
    {
        creditsRolling = !creditsRolling;
        transform.localPosition = new Vector3(0, startYPosition, 0);
    }
}
