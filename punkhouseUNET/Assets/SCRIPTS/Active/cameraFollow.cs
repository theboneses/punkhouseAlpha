using UnityEngine;
using System.Collections;
//using UnityEngine.Networking;

public class cameraFollow : MonoBehaviour {

	//public Camera followCamera;
	public Vector3 lookDir;
	public Vector3 offset;
	[SerializeField] Transform followXform;
	[SerializeField] Transform follow;
	public float distanceAway;
	public float distanceUp;
	public float smooth;
	public Vector3 followForward;
	public Vector3 targetPosition;
	public Quaternion rotation;
	void Start(){
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 characterOffset = followXform.position + offset;
		lookDir = characterOffset - this.transform.position;
		lookDir.y = 0;
		lookDir.Normalize();
		Debug.DrawRay (this.transform.position, lookDir, Color.green);

		followForward = follow.forward;
		targetPosition = followXform.position + followXform.up * distanceUp + new Vector3(1,0,0)* distanceAway;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);



		transform.LookAt(followXform);
	}

}