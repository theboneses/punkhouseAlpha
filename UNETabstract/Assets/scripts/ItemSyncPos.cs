using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ItemSyncPos : NetworkBehaviour {

	[SyncVar]
	private Vector3 syncPos;

	[SerializeField]
	Transform myTransform;
	[SerializeField]
	float lerpRate = 15f;

	private Vector3 lastPos;

	private float threshold = 0.3f;

	void Update(){
		LerpPosition ();
	}
	// Update is called once per frame
	void FixedUpdate () {
		TransmitPosition ();
	
	}
	void LerpPosition(){
		
			myTransform.position = Vector3.Lerp (myTransform.position,syncPos,Time.deltaTime*lerpRate);

	}
	[Command]
	void CmdProvidePositionToServer(Vector3 pos){
		syncPos = pos;
	}
	[ClientCallback]
	void TransmitPosition(){
		if (Vector3.Distance(myTransform.position,lastPos)>threshold) {
		CmdProvidePositionToServer (myTransform.position);
				lastPos = myTransform.position;
			}
		
	}

}
