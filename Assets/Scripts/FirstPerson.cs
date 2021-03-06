﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour {

    public static FirstPerson PLAYER;
    public static bool GUN_AQUIRED;
    public static bool EASY_MODO = false;

    public float MoveSpeed;
    public float Sensitivity;
    public float Gravity;
    public float JumpTime;
    public float JumpDist;
    public float TerminalVelocity = 100;
    public int JumpCount = 1;
    public float DeathHeight = -10;
    public bool CanHold = false;

    //Dash Ability parameters
    public bool shouldHaveDash;
    private bool isDashing;
    public KeyCode dashKey;
    public float dashSpeed, dashDecceleration;
    private Vector3 dashVelocity;
    
    private Camera cam;
    private CharacterController control;
    private float camAngle;
    private float yVel;
    private float jumpSpeed;
    private int canJump;
    
    //Other
    public Gun blaster;
    public GameObject gunMesh;

    // Use this for initialization
    void Start()
    {
        isDashing = false;
        cam = GetComponentInChildren<Camera>();
        control = GetComponent<CharacterController>();
        camAngle = 0;
        Cursor.lockState = CursorLockMode.Locked;
        yVel = 0;
        jumpSpeed = JumpDist / JumpTime - Gravity / (2 * JumpTime);
        canJump = 0;
        PLAYER = this;
        Cursor.visible = false;
        GUN_AQUIRED = false;
        if (gunMesh != null)
        {
            gunMesh.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 move = new Vector3();
        if (!isDashing)// restricting movement while dashing
        {
            move += Input.GetAxis("Horizontal") * MoveSpeed * transform.right;
            move += Input.GetAxis("Vertical") * MoveSpeed * transform.forward;
        }

        if (canJump > 0 && Input.GetButtonDown("Jump"))
        {
            yVel = jumpSpeed;
            canJump--;
        }

        yVel += Gravity * Time.deltaTime;
        yVel = yVel < -TerminalVelocity ? -TerminalVelocity : yVel;
        move.y = yVel;

        control.Move(move * Time.deltaTime);

        transform.Rotate(Vector3.up, (Input.GetAxis("Mouse X")) * Sensitivity);
        camAngle += -(Input.GetAxis("Mouse Y")) * Sensitivity;
        camAngle = camAngle < 90 ? camAngle : 90;
        camAngle = camAngle > -90 ? camAngle : -90;
        cam.transform.localRotation = Quaternion.Euler(camAngle, 0 , 0);

        if ((CanHold ? Input.GetButton("Fire1") : Input.GetButtonDown("Fire1")) && GUN_AQUIRED)
        {
            blaster.TryShoot();
        }

        if (transform.position.y < DeathHeight)
        {
            Destroy(gameObject);
        }

        // dash stuff below
        if (Input.GetKeyDown(dashKey) && !isDashing && yVel == 0)
        {
            InitiateDash(move);
        }

        if (isDashing)
        {
            if (dashVelocity.magnitude <= 1.0f)
            {
                dashVelocity = Vector3.zero;
                isDashing = false;
            }
            control.Move(dashVelocity * Time.deltaTime);
            dashVelocity -= Vector3.Normalize(dashVelocity) * dashDecceleration * Time.deltaTime;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        float upness = Vector3.Dot(collision.normal, Vector3.up);
        if (upness > .5)
        {
            canJump = JumpCount;
            yVel = 0;
        }
        else if (upness < -.5)
        {
            yVel = -1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 11 && !EASY_MODO)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 13 || other.gameObject.layer == 11) && !EASY_MODO)
        {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("WeaponPickup"))
        {
            GUN_AQUIRED = true;
            other.gameObject.SetActive(false);
            gunMesh.SetActive(true);
        }
    }

    private void InitiateDash(Vector3 moveVector)
    {
        Vector3 move1 = Vector3.Normalize(moveVector);

        if (moveVector.magnitude < 0.5f)
        {
            dashVelocity = transform.forward * dashSpeed;
            Debug.Log(transform.forward);
        }
        else
        {
            dashVelocity = move1 * dashSpeed;
        }
        isDashing = true;
    }
}
