using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNoteObject : MonoBehaviour
{
    public GameObject noteReader;
    public string noteContent;

    // Update is called once per frame
    public void ActivateNote()
    {
        noteReader.GetComponent<FinalNoteManager>().ReadNote(noteContent);
    }
}
