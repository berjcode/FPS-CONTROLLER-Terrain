using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    Vector3 velocity;

    bool isGrounded;

    public Transform ground;

    //karakter hareket
    public bool canMove = true;
    public float distance = 0.3f;
    //joystick
    public FixedJoystick fixedJoyStick;
    public float speed;
    public float jumpHeight;
    public float gravity;
    public LayerMask mask;

    // Eðilik Kalkmak

    public float orginalHeight;
    public float crouchHeight;

    //Ses 
    float timer;
    public float timeBetweenSteps;
    AudioSource source;
    bool isMoving;
    public AudioClip[] stepSounds;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();

    }

    public void Update()
    {
        #region Movement

        float horizontal = fixedJoyStick.Horizontal;
        float vertical = fixedJoyStick.Vertical;

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        if(canMove)
            controller.Move(move*speed*Time.deltaTime);




        #endregion

        #region Footsteps
        if(horizontal !=0 ||  vertical !=0 )
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving )
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                timer = timeBetweenSteps;
                source.clip = stepSounds[Random.Range(0, stepSounds.Length)];
                source.pitch = Random.Range(0.85f, 1.15f);
                source.Play();
            }
        }
        else
        {
            timer = timeBetweenSteps;
        }

        #endregion
        #region Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        #endregion

        #region Gravity
        isGrounded = Physics.CheckSphere(ground.position,distance,mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        #endregion

        #region Basic Crouch

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height = crouchHeight;
            speed = 1f;
            jumpHeight = 0f;
            
        }

        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = orginalHeight;
            speed = 5f;
            jumpHeight = 1f;
            
        }
        #endregion

        #region Basic Running
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 5.0f;
            timeBetweenSteps = 0.2f;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2.0f;
            timeBetweenSteps = 0.4f;

        }
        #endregion




    }

    public void RunState()
    {

        speed = 5.0f;
        timeBetweenSteps = 0.2f;

    }

    public void WalkState()
    {
        speed = 2.0f;
        timeBetweenSteps = 0.4f;
    }

    public void Jump()
    {
        if (isGrounded )
        {

            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void CrouchState()
    {
        controller.height = crouchHeight;
        speed = 1f;
        jumpHeight = 0f;
    }

    public void StandingState()
    {
        controller.height = orginalHeight;
        speed = 5f;
        jumpHeight = 1f;
    }
}
