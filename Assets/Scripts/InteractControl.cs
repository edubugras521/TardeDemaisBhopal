using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractControl : MonoBehaviour
{

    private GameObject targetObject;
    private bool temFerramenta = false;
    private bool temChave = false;

    public int interactRange = 10;
    public Image crosshair;
    public GameObject Player;
    public LayerMask gasLayer;
    public Text InspectText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GasControl.gameOver && !LookControl.lockCamera)
        {
            InteractCheck();
        }

        else
        {
            CrosshairInactive();
            InspectText.text = "";
        }

    }

    void InteractCheck()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, interactRange, ~gasLayer))
        {
            if (hit.collider.CompareTag("Pickup Object"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();
                string objName = targetObject.name;
                InspectText.text = "[E]: Pegar " + objName;

                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log("PICKED UP");

                    if(objName == "Máscara de Gás")
                    {
                        GasControl.GasMaskEquipped = true;
                    }

                    if (objName == "Chave do Armazém")
                    {
                        temChave = true;
                    }

                    if (objName == "Ferramenta")
                    {
                        temFerramenta = true;
                        targetObject.GetComponent<FerramentaScript>().PickedUp();
                    }

                    Destroy(targetObject);
                }
            }

            if (hit.collider.CompareTag("Note"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();
                InspectText.text = "[E]: Ler Recado";

                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log("NOTE INSPECTED");
                    targetObject.GetComponent<NoteObject>().ActivateNote();
                }
            }

            if (hit.collider.CompareTag("TriggerNote"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();
                InspectText.text = "[E]: Ler Recado";

                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log("NOTE INSPECTED");
                    targetObject.GetComponent<TriggerNoteObject>().ActivateNote();
                }
            }

            if (hit.collider.CompareTag("FinalNote"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();
                InspectText.text = "[E]: Ler Recado";

                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log("NOTE INSPECTED");
                    targetObject.GetComponent<FinalNoteObject>().ActivateNote();
                }
            }

            if (hit.collider.CompareTag("Repair"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();
                string objName = targetObject.name;

                if (temFerramenta)
                {
                    InspectText.text = "[E]: Consertar " + objName;
                }
                else
                {
                    InspectText.text = "Requer Ferramenta";
                }

                if (Input.GetButtonDown("Interact"))
                {
                    if (objName == "Válvula de Gás")
                    {
                        if (temFerramenta)
                        {
                            targetObject.GetComponent<RepairScript>().Repaired();
                            temFerramenta = false;
                        }
                    }
                }
            }

            if (hit.collider.CompareTag("MaskLocker"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();

                if (GasControl.GasMaskEquipped)
                {
                    InspectText.text = "[E]: Guardar Máscara de Gás";

                    if (Input.GetButtonDown("Interact"))
                    {
                        targetObject.GetComponent<RepairScript>().Repaired();
                        GasControl.GasMaskEquipped = false;
                    }
                }

                else
                {
                    InspectText.text = "";
                }
            }

            if (hit.collider.CompareTag("Door"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();
                InspectText.text = "[E]: Abrir Porta";

                if (Input.GetButtonDown("Interact"))
                {
                    targetObject.GetComponent<DoorTeleporter>().Teleport();
                    Debug.Log("DOOR ACTIVATED");
                }
            }

            if (hit.collider.CompareTag("DoorLocked"))
            {
                targetObject = hit.collider.gameObject;
                CrosshairActive();

                if (!temChave)
                {
                    InspectText.text = "Porta Trancada";
                }

                if (temChave)
                {
                    InspectText.text = "[E]: Abrir Porta";

                    if (Input.GetButtonDown("Interact"))
                    {
                        targetObject.GetComponent<DoorTeleporter>().Teleport();
                        Debug.Log("DOOR ACTIVATED");
                    }
                }
            }

            if (hit.collider.CompareTag("Wall"))
            {
                CrosshairInactive();
                InspectText.text = "";
            }

            if (hit.collider.CompareTag("Gas"))
            {
                CrosshairInactive();
                InspectText.text = "";
            }
        }

        else
        {
            CrosshairInactive();
            InspectText.text = "";
        }
    }

    void CrosshairActive()
    {
        crosshair.color = new Color(0.5f, 1, 0.5f, 1);
        Debug.Log(crosshair.color);
    }

    void CrosshairInactive()
    {
        crosshair.color = Color.white;
        Debug.Log(crosshair.color);
    }
}
