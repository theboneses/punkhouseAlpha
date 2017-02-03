using UnityEngine;
using System.Collections;

public class movelook : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = -Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));

	}
}
