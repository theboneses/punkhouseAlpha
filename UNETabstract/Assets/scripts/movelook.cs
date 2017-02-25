using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movelook : MonoBehaviour {

	public InputField userInput;
	public Vector3 lastRot;

	// Use this for initialization
	void Start () {
		userInput = FindObjectOfType<InputField> ();
		lastRot = new Vector3 (0f,0f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (userInput.isFocused == false) {
			if (Input.anyKey) {
				transform.forward = -Vector3.Normalize (new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")));
			}
		}
	}

}
