using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	// Use this for initialization
	

	public float horizontalspeed= 1f;
	public float verticalspeed= 1f;
	private float xRotation=0.0f;
	private float yRotation = 0.0f;
	private Camera cam;
	CharacterController charactercontroller;
	private Vector3 playervelocityofjump;
	public float Movementspeed=1;
	public float gravity=9.8f;
	public float Velocity = 0;
	void Start()
	{
		charactercontroller = gameObject.GetComponent<CharacterController> ();
		
		cam = Camera.main;
	}
	void Update()
	{
		float mouseX = Input.GetAxis ("Mouse X") * horizontalspeed;
		float mouseY = Input.GetAxis ("Mouse Y") * verticalspeed;

		yRotation += mouseX;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp (xRotation, -90, 90);
		cam.transform.eulerAngles = new Vector3 (xRotation, yRotation, 0.0f);
		float Horizontal = Input.GetAxis ("Horizontal") * Movementspeed;
		float vertical = Input.GetAxis ("Vertical") * Movementspeed;
		charactercontroller.Move ((transform.right * Horizontal + transform.forward * vertical) * Time.deltaTime);
		if (charactercontroller.isGrounded) {
			Velocity = 0;
		} else {
			Velocity -= gravity * Time.deltaTime;
			charactercontroller.Move (new Vector3(0,Velocity,0));
		}
	}
}
