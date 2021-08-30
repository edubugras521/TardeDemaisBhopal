using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public Transform player;
    public static CharacterController control;
    public static bool portalActive = true;
    public float runMoveSpeed = 6f;
    public float crouchMoveSpeed = 3f;
    public float jumpHeight = 3f;
    public float gravity = -9.8f;
    public float crouchSpeed = 5f;
    public float groundDistance = 0.4f;
    public float StandingHeight;
    public float CrouchingHeight;
    public Transform grounded;
    public Transform overhead;
    public LayerMask groundMask;
    public LayerMask indoorMask;
    private AudioSource SourceFootsteps;
    public AudioSource SourceFootstepsInside;
    public AudioSource SourceFootstepsOutside;
    public AudioSource SourceCrouchstepsInside;
    public AudioSource SourceCrouchstepsOutside;

    Vector3 velocity;
    float speed;
    bool isGrounded;
    bool isCrouched;
    bool isIndoors;
    bool overheadBlocked;
    float currentHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        speed = runMoveSpeed;
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(grounded.position, groundDistance, groundMask);
        overheadBlocked = Physics.CheckSphere(overhead.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!GasControl.gameOver && control.enabled)
        {
            PlayerMove();
            FootstepManager();
        }
        else
        {
            SourceFootsteps.mute = true;
            SourceFootsteps.Stop();
        }

        velocity.y += gravity * Time.deltaTime;

    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        control.Move(move * speed * Time.deltaTime);

        //if(Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}

        if (Input.GetButtonDown("Crouch") && isGrounded)
        {
            if (!isCrouched)
            {
                isCrouched = true;
            }
            else
            {
                isCrouched = false;
            }
        }

        if (isCrouched)
        {
            if (currentHeight > CrouchingHeight)
            {
                currentHeight -= crouchSpeed * Time.deltaTime;
                currentHeight = Mathf.Clamp(currentHeight, CrouchingHeight, StandingHeight);
            }

            if (control.height != CrouchingHeight)
            {
                control.height = currentHeight;
                speed = crouchMoveSpeed;
            }

            player.localScale = new Vector3(1, (control.height / 3), 1);
        }

        if (!isCrouched)
        {
            if (currentHeight < StandingHeight && !overheadBlocked)
            {
                currentHeight += crouchSpeed * Time.deltaTime;
            }
            if (currentHeight > StandingHeight)
            {
                currentHeight = StandingHeight;
            }
            if (control.height != StandingHeight)
            {
                control.height = currentHeight;
            }
            player.localScale = new Vector3(1, (control.height / 3), 1);
            if (control.height == StandingHeight)
            {
                speed = runMoveSpeed;
            }
        }

        control.Move(velocity * Time.deltaTime);
    }
    
    void FootstepManager()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isIndoors = Physics.CheckSphere(grounded.position, groundDistance, indoorMask);

        if (isIndoors)
        {
            if (isCrouched)
            {
                SourceFootsteps = SourceCrouchstepsInside;
                SourceFootstepsInside.Stop();
                SourceCrouchstepsOutside.Stop();
                SourceFootstepsOutside.Stop();
            }
            else
            {
                SourceFootsteps = SourceFootstepsInside;
                SourceCrouchstepsInside.Stop();
                SourceCrouchstepsOutside.Stop();
                SourceFootstepsOutside.Stop();
            }
        }

        else if (!isIndoors)
        {
            if (isCrouched)
            {
                SourceFootsteps = SourceCrouchstepsOutside;
                SourceFootstepsOutside.Stop();
                SourceCrouchstepsInside.Stop();
                SourceFootstepsInside.Stop();
            }
            else
            {
                SourceFootsteps = SourceFootstepsOutside;
                SourceCrouchstepsOutside.Stop();
                SourceCrouchstepsInside.Stop();
                SourceFootstepsInside.Stop();
            }
        }


        if (x == 0 && z == 0)
        {
            SourceFootsteps.mute = true;
            SourceFootsteps.Stop();
        }

        else
        {
            SourceFootsteps.mute = false;
            if (!SourceFootsteps.isPlaying)
            {
                SourceFootsteps.Play();
            }
        }
    }
}
