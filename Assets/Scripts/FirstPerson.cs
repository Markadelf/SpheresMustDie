using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour {

    public static FirstPerson PLAYER;

    public float MoveSpeed;
    public float Sensitivity;
    public float Gravity;
    public float JumpTime;
    public float JumpDist;
    public float TerminalVelocity = 100;
    public int JumpCount = 1;
    public float DeathHeight = -10;

    private Camera cam;
    private CharacterController control;
    private float camAngle;
    private float yVel;
    private float jumpSpeed;
    private int canJump;
    
    //Other
    public Gun blaster; 

	// Use this for initialization
	void Start () {
        cam = GetComponentInChildren<Camera>();
        control = GetComponent<CharacterController>();
        camAngle = 0;
        Cursor.lockState = CursorLockMode.Locked;
        yVel = 0;
        jumpSpeed = JumpDist / JumpTime - Gravity/2 * JumpTime;
        canJump = 0;
        PLAYER = this;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        Vector3 move = new Vector3();
        move += Input.GetAxis("Horizontal") * MoveSpeed * transform.right;
        move += Input.GetAxis("Vertical") * MoveSpeed * transform.forward;

        if(canJump > 0 && Input.GetButtonDown("Jump"))
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

        if (Input.GetButtonDown("Fire1"))
        {
            blaster.TryShoot();
        }

        if (transform.position.y < DeathHeight)
        {
            Destroy(gameObject);
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
        if(collision.collider.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13 || other.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }
    }
}
