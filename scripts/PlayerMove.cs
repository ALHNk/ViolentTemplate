using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float Speed;
	public Transform orientation;
	float HorInput, VerInput;
	private Vector3 moveDirection;
	
	private Rigidbody rb;
	
	
	public float playerHeight;
	public LayerMask whatisGround;
	private bool grounded;
	public float groundDrag;
	
	
	public float jumpForce, JumpCoolDown;
	private bool readyToJump = true;


    // Start is called before the first frame update
    void Start()
    {
	    rb = GetComponent<Rigidbody>();
	    rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
	    grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatisGround);
		MyInput();
		SpeedControl();
		
	    if(grounded)
	    {
			rb.drag = groundDrag;
		}
		else rb.drag = 0;

    }
    
	void FixedUpdate()
	{
		Move();
	}
    
	private void MyInput()
	{
		HorInput = Input.GetAxisRaw("Horizontal");
		VerInput = Input.GetAxisRaw("Vertical");
		
		if(Input.GetKey(KeyCode.Space) && readyToJump && grounded){
			Jump();
			readyToJump = false;
			Invoke(nameof(ResetJump), JumpCoolDown);
		}
	}
	
	private void Move()
	{
		moveDirection = orientation.forward * VerInput + orientation.right * HorInput;
		rb.AddForce(moveDirection.normalized * Speed * 10f, ForceMode.Force);
		
	}
	
	private void SpeedControl()
	{
		Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		if(flatvel.magnitude > Speed){
			Vector3 limitVel = flatvel.normalized * Speed;
			rb.velocity = new Vector3(limitVel.x,rb.velocity.y, limitVel.z);
		}
	}
	
	private void Jump()
	{
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}
	
	private void ResetJump()
	{
		readyToJump = true;
	}

}
