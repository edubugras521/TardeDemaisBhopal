using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerramentaScript : MonoBehaviour
{
    public GameObject portaAbre;
    public GameObject portaFecha;
    
    public void PickedUp()
    {
        portaAbre.SetActive(true);
        portaFecha.SetActive(false);
    }
}
