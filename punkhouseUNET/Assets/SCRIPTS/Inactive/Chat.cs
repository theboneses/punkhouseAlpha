using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Chat : NetworkBehaviour 
{
	//*********FIRST ATTEMPT BASED ON DEPRECATED RPC CODE********
	//public List<string> chatHistory = new List<string>();
	//private string currentMessage = string.Empty;
	//private void OnGUI(){
	//	GUILayout.BeginHorizontal (GUILayout.Width (250));
	//	currentMessage = GUILayout.TextField (currentMessage);
	//	if (GUILayout.Button("Send"))
	//	{
	//		if (!string.IsNullOrEmpty(currentMessage.Trim()))
	//			currentMessage = string.Empty;
	//		{
	//			networkView.RPC
	//		}
	//	}
	//	GUILayout.EndHorizontal();
	//	foreach (string c in chatHistory)
	//		GUILayout.Label(c);
	//}

	public Text chatText;
	private InputField chatInput;
 	public string message;
	//add private Canvas speechBubbles at some point.

	void Start()
	{
		//chatText = GameObject.Find ("ChatText").GetComponent<Text> ();
		chatInput = GameObject.Find ("ChatInput").GetComponent<InputField> ();
	}
	void Update()
	{
		
		if (chatInput.text != "" ) 
		{
			message = chatInput.text;
		}
	}
	public void chat(string message)
	{
		if (!isLocalPlayer) {
			return;
		}
		chatText.text = message;
		CmdChat (message);
	}

	[Command]
	public void CmdChat(string message)
	{
		RpcChat (message);
	}
	[ClientRpc]
	public void RpcChat(string message)
	{
		chatText.text = message;
		//chatText.text += "/n";
	}
}
