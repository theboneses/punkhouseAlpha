using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PnetController : MonoBehaviour {

	public float speed = 6.0F;
	public float gravity = 20.0F;
	public Vector3 animMag= Vector3.zero;	



	public Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public Animator anim;
	public bool moveEnabled;
	public InputField userInput;

	void Start(){
		// Store reference to attached component
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator> ();
		userInput = FindObjectOfType<InputField> ();

	}

	void Update()
	{
		
		// Character is on ground (built-in functionality of Character Controller)
		if (controller.isGrounded) {
			// Use input up and down for direction, multiplied by speed
			moveDirection = -(new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")));
			animMag = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

		}
		// Apply gravity manually.
		moveDirection.y -= gravity * Time.deltaTime;
		// Move Character Controller
		if (userInput.isFocused==false) {
			controller.Move (moveDirection * Time.deltaTime);
			float animSpeed = Vector3.Magnitude (animMag);
			anim.SetFloat ("speed", animSpeed);
		}
	}
	}
