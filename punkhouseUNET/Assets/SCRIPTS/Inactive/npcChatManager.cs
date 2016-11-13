using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class npcChatManager : MonoBehaviour {

	public Text theText;
	public TextAsset textfile;
	public string[] textlines;
	public char splitter;
	public int currentLine;
	public int endAtLine;
	public GameObject player;
	public bool isActive;
	public Button button;
	public string buttonName;

	// Use this for initialization
	void Start () {
		buttonName = button.name;
		splitter = '\n';
		player = GameObject.FindGameObjectWithTag ("Player");

		//splits script into lines
		if (textfile != null) {
			textlines = (textfile.text.Split(splitter));
		}
		//sets the length for array numbers
		if (endAtLine == 0) {
			endAtLine = textlines.Length - 1;
		}
		//calls enable
		if (isActive) {
			EnableTextBox();
		} else {
			DisableTextBox();
		}
	}
	// Update is called once per frame
	void Update () {
		if (!isActive) {
			return;
			}
		}

	//wire this up to the bobbin
	public void AdvanceChat(){
		theText.text = textlines [currentLine];
		currentLine += 1;
		if (currentLine > endAtLine) {
			DisableTextBox ();
		}
	}

	//these two set the bool active or not
	public void EnableTextBox(){
		isActive = true;
	}
	public void DisableTextBox(){
		isActive = false;
	}

	//used by activateText to load the text into the chat bubble 
	public void ReloadScript(TextAsset theText){
		if(theText != null){
			textlines = new string[1];
			textlines = (theText.text.Split(splitter));
		}
	}
	
}