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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TransmitRotation ();
		LerpRotation (); 
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
			CmdProvideRotationToServer (playerTransform.rotation);
		}
	}
}
