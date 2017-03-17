using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
[NetworkSettings (channel=0,sendInterval=0.1f)]
public class PlayerSyncPos : NetworkBehaviour {

	[SyncVar (hook ="SyncPosValues")]
	private Vector3 syncPos;

	[SerializeField]
	Transform myTransform;
	[SerializeField]
	float lerpRate;
	private float normalLerpRate = 16f;
	private float fasterLerpRate = 27f;

	private Vector3 lastPos;

	private float threshold = 0.3f;

	private List<Vector3>syncPosList=new List<Vector3>();
	[SerializeField]private bool useHistoricalLerping = false;
	private float closeEnough = 0.1f;

	void Start(){
		lerpRate = normalLerpRate;
	}

	void Update(){
		LerpPosition ();
	}
	// Update is called once per frame
	void FixedUpdate () {
		TransmitPosition ();
	
	}
	void LerpPosition(){
		if (!isLocalPlayer) {
			if (useHistoricalLerping) {
				HistoricalLerping ();
			} else {
				OrdinaryLerping();
			}

		}
	}
	[Command]
	void CmdProvidePositionToServer(Vector3 pos){
		syncPos = pos;
	}
	[ClientCallback]
	void TransmitPosition(){
		if (isLocalPlayer && Vector3.Distance(myTransform.position,lastPos)>threshold) {
		CmdProvidePositionToServer (myTransform.position);
				lastPos = myTransform.position;
			}	
	}
	 
	[Client]
	void SyncPosValues(Vector3 latestPos){
		syncPos = latestPos;
		syncPosList.Add (syncPos);
	}

	void HistoricalLerping(){
		if(syncPosList.Count>0){
			myTransform.position = Vector3.Lerp (myTransform.position,syncPosList[0],Time.deltaTime*lerpRate);
			if (Vector3.Distance (myTransform.position, syncPosList [0]) < closeEnough) {
				syncPosList.RemoveAt (0);
			}
			if (syncPosList.Count > 10) {
				lerpRate = fasterLerpRate;
			} else {
				lerpRate = normalLerpRate;
			}
		}
	}

	void OrdinaryLerping(){
		myTransform.position = Vector3.Lerp (myTransform.position,syncPos,Time.deltaTime*lerpRate);
	}

}
