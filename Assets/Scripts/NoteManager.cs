using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{
    public Image background;
    public float fadeSpeed;
    public Text noteText;
    public static bool isReading = false;

    private float fadeValue;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            if (isReading)
            {
                if (fadeValue < 0.85f)
                {
                    fadeValue += fadeSpeed * Time.deltaTime;
                    fadeValue = Mathf.Clamp(fadeValue, 0, 0.85f);
                    background.color = new Color(0, 0, 0, fadeValue);
                }

                if (Input.GetButtonDown("Interact"))
                {
                    isReading = false;
                }
            }

            else
            {
                fadeValue = 0;
                background.color = new Color(0, 0, 0, fadeValue);
                MovementControl.control.enabled = true;
                gameObject.SetActive(false);
            }
        }
    }

    public void ReadNote(string noteContent)
    {
        noteText.text = noteContent;
        isReading = true;
        fadeValue = 0;
        MovementControl.control.enabled = false;
        gameObject.SetActive(true);
    }
}
