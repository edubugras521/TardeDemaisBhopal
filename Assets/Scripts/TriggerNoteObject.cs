using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNoteObject : MonoBehaviour
{
    public GameObject noteReader;
    public string noteContent;
    public GameObject portaAbre;
    public GameObject portaFecha;

    private bool triggered = false;


    // Update is called once per frame
    public void ActivateNote()
    {
        noteReader.GetComponent<NoteManager>().ReadNote(noteContent);
        if (!triggered)
        {
            portaAbre.SetActive(true);
            portaFecha.SetActive(false);
            triggered = true;
        }
    }
}
