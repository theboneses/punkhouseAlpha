using UnityEngine;
using System.Collections;
//using UnityEngine.Networking;

public class cameraFollowNet : MonoBehaviour {

	//public Camera followCamera;
	public Vector3 lookDir;
	public Vector3 offset;
	public Transform followXform;
	public Vector3 distanceAway;
	public float distanceUp;
	public float smooth;
	//public Transform follow;
	//public Vector3 followForward;
	public Vector3 targetPosition;
	public Quaternion rotation;
	void Start(){
		//follow = GameObject.FindGameObjectWithTag ("Player").transform;
		//rotation = Quaternion.Euler (13, -90, 0);
	}
	// Update is called once per frame
	void Update(){
		//followXform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void LateUpdate () 
	{
		Vector3 characterOffset = followXform.position + offset;
		lookDir = characterOffset - this.transform.position;
		lookDir.y = 0;
		lookDir.Normalize();
		Debug.DrawRay (this.transform.position, lookDir, Color.green);

		//followForward = follow.forward;
		targetPosition = followXform.position + distanceAway;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);



		transform.LookAt(followXform);
	}

}