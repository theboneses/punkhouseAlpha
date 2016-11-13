using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputBub : MonoBehaviour 
{
	[SerializeField]
	private Text myBubble;
	public InputField chatInput;

	void Update () 
	{
		myBubble = GameObject.Find ("MyBub").GetComponent<Text>();
		chatInput = GameObject.Find ("ChatInput").GetComponent<InputField> ();

	}

	public void UpdateMyBubble()
	{
		string message = chatInput.text;
		myBubble.text = message;
	}
}
