using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public GameObject targetDoor;
    public GameObject hiddenWall;
    public Transform localPlayerStart;
    public Transform targetPlayerStart;
    public Transform playerEnd;
    public GameObject gameManager;
    public int nextRenderMode;
    public bool hideDoor = true;
    public bool playerLock = false;

    private bool playerReadyToWalk = false;
    private Vector3 currentPos;
    private Quaternion currentRot;
    private MeshRenderer doorMesh;

    void Start()
    {
        doorMesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (playerLock && !playerReadyToWalk)
        {
            MovePlayerToStart();
        }

        if (playerLock && playerReadyToWalk)
        {
            MovePlayerToEnd();
        }
    }

    public void Teleport()
    {
        playerReadyToWalk = false;
        LookControl.lockCamera = true;
        MovementControl.control.enabled = false;
        playerLock = true;
    }

    void MovePlayerToStart()
    {
        currentPos = player.position;
        currentRot = player.rotation;

        currentPos = Vector3.MoveTowards(currentPos, localPlayerStart.position, Time.deltaTime);
        currentRot = Quaternion.RotateTowards(currentRot, localPlayerStart.rotation, 60 * Time.deltaTime);

        player.position = currentPos;
        player.rotation = currentRot;
        playerCam.rotation = currentRot;

        if (player.position == localPlayerStart.position && playerCam.rotation == localPlayerStart.rotation)
        {
            gameManager.GetComponent<RenderManager>().ChangeRenderMode(nextRenderMode);
            targetDoor.GetComponent<DoorControl>().ToggleDoor();

            if (hideDoor)
            {
                doorMesh.enabled = false;
            }

            hiddenWall.SetActive(false);
            player.position = targetPlayerStart.position;
            player.rotation = targetPlayerStart.rotation;
            playerReadyToWalk = true;
        }
    }

    private void MovePlayerToEnd()
    {
        currentPos = player.position;
        currentPos = Vector3.MoveTowards(currentPos, playerEnd.position, 2 * Time.deltaTime);
        player.position = currentPos;

        if (player.position == playerEnd.position)
        {
            playerLock = false;
            if (hideDoor)
            {
                doorMesh.enabled = true;
            }
            hiddenWall.SetActive(true);
            MovementControl.control.enabled = true;
            LookControl.lockCamera = false;
        }
    }

    public bool isPlayerLocked()
    {
        return playerLock;
    }
}
