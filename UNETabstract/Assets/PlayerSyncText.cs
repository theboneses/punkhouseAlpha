using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerSyncText : NetworkBehaviour {

	[SyncVar]//(hook="")]
	public string playerString;

	public Text playerText;
	public Text playerBubble;

	public string lastText;
	//private float threshold = 5f;

	void Update(){
		GetText (); 
	}

	void FixedUpdate () {
		TransmitText ();

	}
	void GetText(){
		if (!isLocalPlayer) {
			playerBubble.text = playerString;
		}
	}
	[Command]
	void CmdProvideTextToServer(string playerTxt){
		playerString = playerTxt;
	}
	[Client]
	void TransmitText(){
		if (isLocalPlayer) {
			if (playerText.text!=lastText||playerText.text!=""||playerText.text!=" "){
				CmdProvideTextToServer (playerText.text);
				lastText = playerText.text;
				playerBubble.text = lastText;
			}
		}
	}
}