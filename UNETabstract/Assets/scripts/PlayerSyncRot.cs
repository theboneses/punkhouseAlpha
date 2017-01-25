using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncRot : NetworkBehaviour {

	[SyncVar]
	private Quaternion syncPlayerRotation;
	//[SyncVar]
	//private Quaternion syncCamRotation;
	[SerializeField]
	private Transform playerTransform;
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
		if (!isLocalPlayer) {
			playerTransform.rotation = Quaternion.Lerp (playerTransform.rotation,syncPlayerRotation,Time.deltaTime*lerpRate);
		}
	}
	[Command]
	void CmdProvideRotationToServer(Quaternion playerRot){
		syncPlayerRotation = playerRot;
	}
	[Client]
	void TransmitRotation(){
		if (isLocalPlayer) {
			if (Quaternion.Angle(playerTransform.rotation, lastRot) > threshold) {
				CmdProvideRotationToServer (playerTransform.rotation);
				lastRot = playerTransform.rotation;
			}
		}
	}
}
