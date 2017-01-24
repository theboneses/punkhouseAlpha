using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	[SerializeField]Camera FollowCamera;

	// Use this for initialization
	void Start () {

		if (isLocalPlayer) {
			GameObject.Find ("SceneCamera").SetActive (false);
			GetComponent<PlayerNetControllerScript> ().enabled = true;
			FollowCamera.enabled=true;
		}
		if (!isLocalPlayer) {
			FollowCamera.enabled = false;
		}
	}
	

}
