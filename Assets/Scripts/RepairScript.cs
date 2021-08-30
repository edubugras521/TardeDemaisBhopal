using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairScript : MonoBehaviour
{

    public GameObject portalAbre;
    public GameObject portalFecha;
    public GameObject repairedPipe;

    public void Repaired()
    {
        portalAbre.SetActive(true);
        Destroy(portalFecha);
        repairedPipe.SetActive(true);
        Destroy(gameObject);
    }
}
