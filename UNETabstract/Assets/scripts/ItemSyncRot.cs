using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ItemSyncRot : NetworkBehaviour {

	[SyncVar]
	private Quaternion syncItemRotation;
	//[SyncVar]
	//private Quaternion syncCamRotation;
	[SerializeField]
	private Transform itemTransform;
	[SerializeField]
	private float lerpRate = 15f;

	private Quaternion lastRot;
	private float threshold = 5f;

	void Update(){
		LerpRotation (); 
	}

	void FixedUpdate () {
		TransmitRotation ();

	}
	void LerpRotation(){
		
			itemTransform.rotation = Quaternion.Lerp (itemTransform.rotation,syncItemRotation,Time.deltaTime*lerpRate);

	}
	[Command]
	void CmdProvideRotationToServer(Quaternion itemRot){
		syncItemRotation = itemRot;
	}
	[Client]
	void TransmitRotation(){
		
			if (Quaternion.Angle(itemTransform.rotation, lastRot) > threshold) {
				CmdProvideRotationToServer (itemTransform.rotation);
				lastRot = itemTransform.rotation;
			}

	}
}
