using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class InputBubNet : NetworkBehaviour 
{
	[SerializeField]
	public Text myBubble;

	[SyncVar]
	public string myBubbleNet;
	public InputField chatInput;

	void Update () 
	{
		myBubble = GameObject.Find ("MyBub").GetComponent<Text>();
		chatInput = GameObject.Find ("ChatInput").GetComponent<InputField> ();

		//if (!isLocalPlayer)
		//	return;
		if (chatInput.text != "" && Input.GetKeyDown("return"))
		{
			CmdUpdateMyBubble();
			RpcUpdateOtherBubbles ();
			chatInput.text = "";
		
		}
	}

	[Command]
	public void CmdUpdateMyBubble()
	{
		string message = chatInput.text;
		myBubbleNet = message;
	}
	[ClientRpc]
	public void RpcUpdateOtherBubbles()
	{
		string message = myBubbleNet;
		myBubble.text = message;
	}
}
