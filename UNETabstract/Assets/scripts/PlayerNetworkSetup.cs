using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNetworkSetup : NetworkBehaviour {

	private GameObject CameraManager;
	private GameObject InputField;
	[SerializeField]GameObject self;
	[SerializeField]Camera myCamera;

	void Start(){
		if (isLocalPlayer) {
			myCamera.enabled = true;
			GetComponent<PnetController> ().enabled = true;
			GetComponentInChildren<movelook> ().enabled = true;

			GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);


			GetComponentInChildren<cameraFNet> ().enabled = true;



			GetComponentInChildren<houseCamera> ().enabled = false;

			InputField = GameObject.Find ("UserInputField");
			GetComponent<PlayerSyncText> ().playerText = InputField.GetComponentInChildren<Text> ();
		}
	}
	// Use this for initialization
	public override void OnStartLocalPlayer () {
		


	}

	public override void PreStartClient(){
			GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
	}
	

}
