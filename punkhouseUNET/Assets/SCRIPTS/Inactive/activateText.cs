using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activateText : MonoBehaviour {

	public TextAsset theText;
	public int startLine;
	public int endLine;
	public npcChatManager theTextBox;
	public bool DestroyWhenActviated;
	//public Color active;
	//public Color inactive;
	public Button chat;
	//public GUIText speechBubs;
	
	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<npcChatManager> ();
		//active = chat.colors.highlightedColor;
		//inactive = chat.colors.normalColor;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//chat = ColorBlock.defaultColorBlock.highlightedColor;
			//chat.colors = active;
			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();
			if(DestroyWhenActviated == true){
				Destroy(gameObject);
			}
		}
	}
	void OnTriggerExit(Collider other){
	if (other.tag == "Player") {
			//chat.colors = inactive;
		}
	}
}
