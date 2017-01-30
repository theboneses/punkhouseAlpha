using UnityEngine;
using System.Collections;

public class punkController : MonoBehaviour {

	private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		myAnimator.SetFloat ("VSpeed", Input.GetAxis("vertical"));
	}
}
