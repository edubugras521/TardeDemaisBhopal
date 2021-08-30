using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalNoteManager : MonoBehaviour
{
    public Image background;
    public float fadeSpeed;
    public Text noteText;
    private bool isReading = false;
    public GameObject player;

    private float fadeValue;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            isReading = NoteManager.isReading;

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
                    NoteManager.isReading = false;
                    player.GetComponent<GasControl>().WinGame();
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
        NoteManager.isReading = true;
        fadeValue = 0;
        MovementControl.control.enabled = false;
        gameObject.SetActive(true);
    }
}
